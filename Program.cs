using CefSharp.WinForms;
using CefSharp;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CefBrowserCacheTest
{
    public class Program
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int CefInitialize(string[] args)
        {
            CefRuntime.SubscribeAnyCpuAssemblyResolver();
            Cef.EnableHighDPISupport();
            var exitCode = CefSharp.BrowserSubprocess.SelfHost.Main(args);
            if (exitCode >= 0) return exitCode;
            var cefSettings = new CefSettings()
            {
                CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"MyApp\CefSharp\Cache"),
                PersistSessionCookies = true,
                PersistUserPreferences = true,
                BrowserSubprocessPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName,
            };
            Cef.Initialize(cefSettings, performDependencyCheck: false, browserProcessHandler: null);
            return 0;
        }

        [STAThread]
        public static int Main(string[] args)
        {
            CefInitialize(args);
            Application.Run(new Form1());
            return 0;
        }
    }
}
