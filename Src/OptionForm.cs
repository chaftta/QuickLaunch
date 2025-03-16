using System;
using System.Windows.Forms;

namespace QuickLaunch {
	public partial class OptionForm : Form {
		/// <summary>ショートカットのパス</summary>
		public string ShortcutPath;
		/// <summary>アイコンサイズ</summary>
		public int IconSize = 16;
		/// <summary>固定境界のパディングサイズ</summary>
		public int PaddingSize = 0;
		/// <summary>コンストラクタ</summary>
		public OptionForm() {
			InitializeComponent();
		}
		/// <summary>読み込み</summary>
		private void OptionForm_Load(object sender, EventArgs e) {
			InputIconSize.Value		= IconSize;
			InputPaddingSize.Value	= PaddingSize;
			NowIconSize.Text		= IconSize.ToString();
			NowPaddingSize.Text		= PaddingSize.ToString();

			InputIconSize.ValueChanged += InputIconSize_ValueChanged;
			InputPaddingSize.ValueChanged += InputPaddingSize_ValueChanged;
			FormClosing += Form_Closing;
		}
		/// <summary>アイコンサイズの変更処理</summary>
		private void InputIconSize_ValueChanged(object sender, EventArgs e) {
			NowIconSize.Text = InputIconSize.Value.ToString();
		}
		/// <summary>パディングサイズの変更処理</summary>
		private void InputPaddingSize_ValueChanged(object sender, EventArgs e) {
			NowPaddingSize.Text = InputPaddingSize.Value.ToString();
		}
		/// <summary>ショートカットフォルダを指定</summary>
		private void ChoicePath_Click(object sender, EventArgs e) {
			var Folder = BrowseFolder();
			if (Folder == null) return;
			InputShortcutPath.Text = Folder;
		}
		/// <summary>OKボタン処理</summary>
		private void OK_Click(object sender, EventArgs e) {
			// 結果を保存
			ShortcutPath = InputShortcutPath.Text;
			IconSize = InputIconSize.Value;
		}
		/// <summary>中止ボタン処理</summary>
		private void Cancel_Click(object sender, EventArgs e) {}
		private void Form_Closing(object sender, FormClosingEventArgs e) {
			if (this.DialogResult == DialogResult.OK) {
				if (InputShortcutPath.Text == "") {
					// 閉じる処理を中断
					e.Cancel = true; 
					MessageBox.Show("ショートカットパスを指定してください");
					return;
				}
			}
		}
		/// <summary>ショートカットフォルダを指定する</summary>
		private string BrowseFolder() {
			using (var Folder = new FolderBrowserDialog()) {
				// ダイアログの説明文を設定
				Folder.Description = "ショートカットフォルダを指定してください。";
				// 初期ディレクトリを設定 (任意)
				Folder.SelectedPath = Environment.CurrentDirectory;

				// ダイアログを表示
				var Result = Folder.ShowDialog();

				// OKが選択され、パスが有効な場合、そのパスを返す
				if (Result == DialogResult.OK && !string.IsNullOrWhiteSpace(Folder.SelectedPath)) {
					return Folder.SelectedPath;
				}
				return null;
			}
		}

	}
}
