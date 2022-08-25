using Microsoft.VisualBasic.ApplicationServices;
using CefSharp.WinForms;
using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CefBrowserCacheTest
{
    public class App : WindowsFormsApplicationBase
    {
        public static CefSettings CEF_SETTINGS
        {
            get;
            private set;
        }

        [STAThread]
        private static void Main(string[] args)
        {
            CefInitialize();
            new App()
            {
                EnableVisualStyles = true,
                MainForm = new Form1()
            }
            .Run(args);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void CefInitialize()
        {
            CefRuntime.SubscribeAnyCpuAssemblyResolver();
            var cachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"MyApp\CefSharp\Cache");
            CEF_SETTINGS = new CefSettings()
            {
                CachePath = cachePath,
                PersistSessionCookies = true,
                PersistUserPreferences = true,
            };
            Cef.Initialize(CEF_SETTINGS, performDependencyCheck: true, browserProcessHandler: null);
        }
    }
}
