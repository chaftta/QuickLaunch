using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace QuickLaunch {
	/// <summary>アイコンサイズ</summary>
	public enum IconSize {
		Small,
		Large,
	}

	/// <summary>シェルアイコン操作</summary>
	public class ShellIcon {
		// SHFILEINFO構造体
		[StructLayout(LayoutKind.Sequential)]
		private struct SHFILEINFO
		{
			public IntPtr hIcon; // アイコンのハンドル
			public IntPtr iIcon; // アイコンのインデックス
			public uint dwAttributes; // 属性
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName; // 表示名
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName; // タイプ名
		}

		/// <summary>大アイコン</summary>
		private const uint SHGFI_LARGEICON	= 0x000000100;
		/// <summary>小アイコン</summary>
		private const uint SHGFI_SMALLICON	= 0x000000101;

		/// <summary>SHGetFileInfo関数の宣言</summary>
		/// <param name="pszPath"></param>
		/// <param name="dwFileAttributes"></param>
		/// <param name="psfi"></param>
		/// <param name="cbFileInfo"></param>
		/// <param name="uFlags"></param>
		/// <returns></returns>
		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

		/// <summary>SHGetFileInfo関数の宣言</summary>
		/// <param name="Path">パス</param>
		/// <param name="Type">アイコンサイズ</param>
		/// <returns>アイコン</returns>
		public static Icon GetIcon(string Path, IconSize Type) {
			uint Flag = 0;
			switch(Type) {
				case IconSize.Small: Flag = SHGFI_SMALLICON; break;
				case IconSize.Large: Flag = SHGFI_LARGEICON; break;
			}
			var Info = new SHFILEINFO();
			IntPtr Handle = SHGetFileInfo(Path, 0, ref Info, (uint)Marshal.SizeOf(Info), Flag);
			// アイコンが取得できなかった場合
			if (Handle == IntPtr.Zero) return null; 

			// Iconオブジェクトを作成
			return Icon.FromHandle(Info.hIcon);
		}
	}
}
