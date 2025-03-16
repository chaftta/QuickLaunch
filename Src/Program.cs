using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickLaunch {
	static class Program {
		/// <summary>排他制御用オブジェクト</summary>
		private static Mutex mutex = null;
		/// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
		[STAThread]
		static void Main() {
			const string appName = "QuickLaunch";
			bool createdNew;

			// アプリケーションにユニークな名前を付けてミューテックスを作成
			mutex = new Mutex(true, appName, out createdNew);
			// 多重起動時は、終了
			if (!createdNew) return;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
