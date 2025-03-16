
namespace QuickLaunch {
	partial class OptionForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionForm));
			this.InputIconSize = new System.Windows.Forms.TrackBar();
			this.IconSizeTitle = new System.Windows.Forms.Label();
			this.ShortcutPathTitle = new System.Windows.Forms.Label();
			this.InputShortcutPath = new System.Windows.Forms.TextBox();
			this.ChoicePath = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.OK = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.NowIconSize = new System.Windows.Forms.Label();
			this.NowPaddingSize = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.InputPaddingSize = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.InputIconSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InputPaddingSize)).BeginInit();
			this.SuspendLayout();
			// 
			// InputIconSize
			// 
			this.InputIconSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.InputIconSize.LargeChange = 4;
			this.InputIconSize.Location = new System.Drawing.Point(12, 34);
			this.InputIconSize.Maximum = 48;
			this.InputIconSize.Minimum = 16;
			this.InputIconSize.Name = "InputIconSize";
			this.InputIconSize.Size = new System.Drawing.Size(455, 45);
			this.InputIconSize.SmallChange = 4;
			this.InputIconSize.TabIndex = 0;
			this.InputIconSize.TickFrequency = 4;
			this.InputIconSize.Value = 16;
			// 
			// IconSizeTitle
			// 
			this.IconSizeTitle.AutoSize = true;
			this.IconSizeTitle.Location = new System.Drawing.Point(13, 16);
			this.IconSizeTitle.Name = "IconSizeTitle";
			this.IconSizeTitle.Size = new System.Drawing.Size(69, 12);
			this.IconSizeTitle.TabIndex = 1;
			this.IconSizeTitle.Text = "アイコンサイズ";
			// 
			// ShortcutPathTitle
			// 
			this.ShortcutPathTitle.AutoSize = true;
			this.ShortcutPathTitle.Location = new System.Drawing.Point(13, 113);
			this.ShortcutPathTitle.Name = "ShortcutPathTitle";
			this.ShortcutPathTitle.Size = new System.Drawing.Size(82, 12);
			this.ShortcutPathTitle.TabIndex = 2;
			this.ShortcutPathTitle.Text = "ショートカットパス";
			// 
			// InputShortcutPath
			// 
			this.InputShortcutPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.InputShortcutPath.Location = new System.Drawing.Point(15, 134);
			this.InputShortcutPath.Name = "InputShortcutPath";
			this.InputShortcutPath.Size = new System.Drawing.Size(419, 19);
			this.InputShortcutPath.TabIndex = 3;
			// 
			// ChoicePath
			// 
			this.ChoicePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ChoicePath.ImageIndex = 0;
			this.ChoicePath.ImageList = this.imageList1;
			this.ChoicePath.Location = new System.Drawing.Point(441, 129);
			this.ChoicePath.Name = "ChoicePath";
			this.ChoicePath.Size = new System.Drawing.Size(30, 28);
			this.ChoicePath.TabIndex = 4;
			this.ChoicePath.UseVisualStyleBackColor = true;
			this.ChoicePath.Click += new System.EventHandler(this.ChoicePath_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "FolderOpen.ico");
			// 
			// OK
			// 
			this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(353, 192);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(56, 33);
			this.OK.TabIndex = 5;
			this.OK.Text = "保存";
			this.OK.UseVisualStyleBackColor = true;
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// Cancel
			// 
			this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(415, 192);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(56, 33);
			this.Cancel.TabIndex = 6;
			this.Cancel.Text = "中止";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// NowIconSize
			// 
			this.NowIconSize.AutoSize = true;
			this.NowIconSize.Location = new System.Drawing.Point(88, 17);
			this.NowIconSize.Name = "NowIconSize";
			this.NowIconSize.Size = new System.Drawing.Size(11, 12);
			this.NowIconSize.TabIndex = 7;
			this.NowIconSize.Text = "0";
			// 
			// NowPaddingSize
			// 
			this.NowPaddingSize.AutoSize = true;
			this.NowPaddingSize.Location = new System.Drawing.Point(88, 63);
			this.NowPaddingSize.Name = "NowPaddingSize";
			this.NowPaddingSize.Size = new System.Drawing.Size(11, 12);
			this.NowPaddingSize.TabIndex = 10;
			this.NowPaddingSize.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 12);
			this.label2.TabIndex = 9;
			this.label2.Text = "境界スペース";
			// 
			// InputPaddingSize
			// 
			this.InputPaddingSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.InputPaddingSize.LargeChange = 4;
			this.InputPaddingSize.Location = new System.Drawing.Point(12, 80);
			this.InputPaddingSize.Maximum = 40;
			this.InputPaddingSize.Minimum = -40;
			this.InputPaddingSize.Name = "InputPaddingSize";
			this.InputPaddingSize.Size = new System.Drawing.Size(455, 45);
			this.InputPaddingSize.SmallChange = 4;
			this.InputPaddingSize.TabIndex = 2;
			this.InputPaddingSize.TickFrequency = 4;
			// 
			// OptionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(479, 238);
			this.Controls.Add(this.ShortcutPathTitle);
			this.Controls.Add(this.NowPaddingSize);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.InputPaddingSize);
			this.Controls.Add(this.NowIconSize);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.OK);
			this.Controls.Add(this.ChoicePath);
			this.Controls.Add(this.InputShortcutPath);
			this.Controls.Add(this.IconSizeTitle);
			this.Controls.Add(this.InputIconSize);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionForm";
			this.ShowIcon = false;
			this.Text = "設定";
			this.Load += new System.EventHandler(this.OptionForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.InputIconSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InputPaddingSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar InputIconSize;
		private System.Windows.Forms.Label IconSizeTitle;
		private System.Windows.Forms.Label ShortcutPathTitle;
		private System.Windows.Forms.TextBox InputShortcutPath;
		private System.Windows.Forms.Button ChoicePath;
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label NowIconSize;
		private System.Windows.Forms.Label NowPaddingSize;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TrackBar InputPaddingSize;
	}
}