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
        public static readonly CefSettings CEF_SETTINGS;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static Program()
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

        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }
    }
}
