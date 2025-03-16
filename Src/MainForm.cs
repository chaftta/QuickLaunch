using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuickLaunch {
	/// <summary>フォーム</summary>
	public partial class MainForm : Form {
		[DllImport("dwmapi.dll", PreserveSig = true)]
		private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
		private const int DWMWA_NCRENDERING_POLICY = 2;
		private const int DWMNCRP_DISABLED = 1;
		[DllImport("dwmapi.dll")]
		private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

		[StructLayout(LayoutKind.Sequential)]
		public struct MARGINS
		{
			public int leftWidth;
			public int rightWidth;
			public int topHeight;
			public int bottomHeight;
		}
		/// <summary>設定ファイル名</summary>
		const string SettingFile = "QuickLaunch.json";
		private Settings Settings;
		/// <summary>ショートカットフォルダのパス</summary>
		private string ShortcutPath = "";
		/// <summary>アイコンサイズ</summary>
		private int IconSize;
		/// <summary>iconのツールチップ表示用</summary>
		private ToolTip Tips;
		/// <summary>通知領域のアイコン</summary>
		private NotifyIcon NotifyIcon;
		/// <summary>固定AppBar</summary>
		private FixedAppBar Bar;

		/// <summary>コンストラクタ</summary>
		public MainForm() {
			InitializeComponent();

			// フォームのイベント設定
			Load += MainForm_Load;
			FormClosing += MainForm_FormClosing;

			// アセンブリのバージョンを取得
			var version = Assembly.GetExecutingAssembly().GetName().Version;

			InitTaskTray();
		}
		/// <summary>設定の読み込み</summary>
		private Settings LoadSettings() {
			try {
				// 設定の読み込み
				if (System.IO.File.Exists(SettingFile)) {
					var Data = System.IO.File.ReadAllText(SettingFile);
					var Settings = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(Data);
					if (Settings != null && !string.IsNullOrWhiteSpace(Settings.Path)) return Settings;
				}
			} catch {}
			return null;
		}
		/// <summary>設定の保存</summary>
		private Settings SaveSettings(string Path, int IconSize) {
			if (string.IsNullOrWhiteSpace(Path)) return null;
			if (Settings == null) {
				Settings = new Settings();
			}
			if (Size.Width <= 0 || Size.Height <= 0) return null;
			// 現在の状態を保存用データに変換
			Settings.Size = Size.Width;
			Settings.Path = Path;
			Settings.Icon = IconSize;
			// 設定ファイルに保存
			var Data = Newtonsoft.Json.JsonConvert.SerializeObject(Settings);
			File.WriteAllText(SettingFile, Data);
			return Settings;
		}
		/// <summary>初期化処理</summary>
		private void MainForm_Load(object sender, EventArgs e) {
			View.SuspendLayout();
			// 枠をなくす
			FormBorderStyle = FormBorderStyle.FixedDialog;
			// Windows Vista以上
			if (Environment.OSVersion.Version.Major >= 6) {
				int value = DWMNCRP_DISABLED;
				DwmSetWindowAttribute(this.Handle, DWMWA_NCRENDERING_POLICY, ref value, sizeof(int));
			}


			Tips = new ToolTip();
			Tips.InitialDelay = 1000;
			Tips.ReshowDelay = 1000;
			Tips.ShowAlways = false;

			// 設定の読み込み
			Settings = LoadSettings();
			if (Settings == null) {
				Visible = false;
				var Dialog = new OptionForm();
				var Result = Dialog.ShowDialog();
				if (Result == DialogResult.OK) {
					Settings = SaveSettings(Dialog.ShortcutPath, Dialog.IconSize);
				} else {
					Application.Exit();
					return;
				}
				Visible = true;
			}
			// ウインドウ設定
			var FormH = Screen.PrimaryScreen.WorkingArea.Height;
			Size = new Size(Settings.Size, FormH);
			Location = new Point(0, 0);
			// ショートカット情報
			IconSize = Settings.Icon;
			ShortcutPath = Settings.Path;

			var Links = GetLinks(Settings.Path);
			foreach (var Link in Links) {
				var B = GetButton(Link, IconSize);
				if (B == null) continue;
				View.Controls.Add(B);
				Tips.SetToolTip(B, Link);
			}

			TopMost = true;
			View.AllowDrop = true;

			View.ResumeLayout(false);

			// 固定領域の作成
			Bar = new FixedAppBar(Settings.Size, FormH, Settings.Padding);
			Bar.Register(this);
		}
		/// <summary>終了処理</summary>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (Bar != null) Bar.Unregister();
		}
		/// <summary>ボタンの取得</summary>
		Button GetButton(string Link, int Size) {
			var I = GetIcon(Link);
			if (I == null) return null;
			var B = new Button();
			B.Size = new Size(Size+2, Size+2);
			B.Padding = new Padding(0);
			B.Text = "";
			B.TextImageRelation = TextImageRelation.ImageAboveText;
			B.BackgroundImage = I.ToBitmap();
			B.BackgroundImageLayout = ImageLayout.Zoom;
			// ボタンのイベント処理
			B.Click += (s, e) => {
				try {
					var P = new Process();
					P.StartInfo.FileName = Link;
					P.StartInfo.UseShellExecute = true;
					P.Start();
				} catch {
					MessageBox.Show($"起動エラー:{Link}\nファイルの確認をしてください");
				}
			};

			return B;
		}
		/// <summary>アイコンの取得</summary>
		Icon GetIcon(string FilePath) {
			var Base = FilePath;
			try {
				if (!File.Exists(FilePath)) {
					Debug.WriteLine("指定されたリンクファイルが存在しません。");
					return null;
				}
				//ショートカット
				if (Path.GetExtension(FilePath).Equals(".lnk")) {
				}
				var IsDir = File.GetAttributes(FilePath).HasFlag(FileAttributes.Directory);
				if (!IsDir) return Icon.ExtractAssociatedIcon(FilePath);
				// シェル系のパス(ドライブやディレクトリ)
				return ShellIcon.GetIcon(FilePath, QuickLaunch.IconSize.Large);
			} catch (Exception ex) {
				Debug.WriteLine($"エラー({Base}:{FilePath}): {ex.Message}");
				return null;
			}
		}
		/// <summary>リンク一覧を取得</summary>
		string[] GetLinks(string TargetDir) {
			try {
				// .lnkファイルを検索
				return Directory.GetFiles(TargetDir, "*.lnk", SearchOption.TopDirectoryOnly);
			} catch (Exception ex) {
				Console.WriteLine($"エラーが発生しました: {ex.Message}");
				return Array.Empty<string>();
			}
		}
		/// <summary>タスクトレイ表示物の初期化</summary>
		private void InitTaskTray() {
			var version = Assembly.GetExecutingAssembly().GetName().Version;
			NotifyIcon = new NotifyIcon();
			NotifyIcon.Icon = Properties.Resources.App;
			NotifyIcon.Text = $"QuickLaunch v{version}";
			NotifyIcon.Visible = true;
			var contextMenuStrip = new ContextMenuStrip();
			var exitMenuItem = new ToolStripMenuItem("Exit", null, (sender, e) => Application.Exit());
			contextMenuStrip.Items.Add(exitMenuItem);
			NotifyIcon.ContextMenuStrip = contextMenuStrip;
		}
	}
}
