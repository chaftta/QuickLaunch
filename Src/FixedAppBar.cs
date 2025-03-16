using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuickLaunch {
	/// <summary>固定AppBarの作成クラス</summary>
	public class FixedAppBar {
		#region win32 api用
		private const int ABM_NEW		= 0;
		private const int ABM_REMOVE	= 1;
		private const int ABM_QUERYPOS	= 2;
		private const int ABM_SETPOS	= 3;
		private const int ABE_LEFT		= 0;

		[StructLayout(LayoutKind.Sequential)]
		private struct RECT {
			public int left;
			public int top;
			public int right;
			public int bottom;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct APPBARDATA {
			public int cbSize;
			public IntPtr hWnd;
			public int uCallbackMessage;
			public int uEdge;
			public RECT rc;
			public IntPtr lParam;
		}

		[DllImport("shell32.dll")]
		private static extern IntPtr SHAppBarMessage(int dwMessage, ref APPBARDATA pData);

		private APPBARDATA appBarData;
		#endregion
		/// <summary>固定領域の横幅</summary>
		private int width;
		/// <summary>固定領域の縦幅</summary>
		private int height;
		/// <summary>固定領域の右側のパディングサイズ</summary>
		private int padding;

		/// <summary>コンストラクタ</summary>
		/// <remarks>WinFormsの場合のheightはScreen.PrimaryScreen.Bounds.Heightを使ってください</remarks>
		/// <param name="width"></param>
		/// <param name="height"></param>
		public FixedAppBar(int width, int height, int padding) {
			this.width = width;
			this.height = height;
			this.padding = padding;
		}

		/// <summary>登録</summary>
		/// <param name="form">ウインドウ</param>
		public void Register(Form form) {
			appBarData = new APPBARDATA();
			appBarData.cbSize = Marshal.SizeOf(appBarData);
			appBarData.hWnd = form.Handle;
			appBarData.uEdge = ABE_LEFT;

			// 占有情報を設定
			SHAppBarMessage(ABM_NEW, ref appBarData);

			// 占有領域の矩形
			appBarData.rc.left = 0;
			appBarData.rc.top = 0;
			appBarData.rc.right = width + padding;
			appBarData.rc.bottom = height;

			// 位置情報を設定
			SHAppBarMessage(ABM_QUERYPOS, ref appBarData);
			SHAppBarMessage(ABM_SETPOS, ref appBarData);

			form.SetBounds(-1,0, width, height);
		}
		/// <summary>解除</summary>
		public void Unregister() {
			SHAppBarMessage(ABM_REMOVE, ref appBarData);
		}
	}
}
