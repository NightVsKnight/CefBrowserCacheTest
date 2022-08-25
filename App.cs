using Microsoft.VisualBasic.ApplicationServices;
using CefSharp.WinForms;
using CefSharp;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace CefBrowserCacheTest
{
    public class App : WindowsFormsApplicationBase
    {
        public static readonly CefSettings CEF_SETTINGS;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static App()
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
        private static void Main(string[] args)
        {
            new App()
            {
                MainForm = new Form1()
            }
            .Run(args);
        }
    }
}
