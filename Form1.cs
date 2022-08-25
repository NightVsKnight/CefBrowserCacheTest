using CefSharp.WinForms;
using CefSharp;
using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace CefBrowserCacheTest
{
    public partial class Form1 : Form
    {
        private readonly ChromiumWebBrowser browser;

        public Form1()
        {
            InitializeComponent();

            if (!Cef.IsInitialized) throw new InvalidOperationException("Cef.Initialize(...) must be called first");

            var cefSettings = Program.CEF_SETTINGS;
            Debug.Assert(cefSettings != null, "cefSettings should not be null");
            var cachePath = Path.Combine(cefSettings.CachePath, "User_Profile");

            RequestContextSettings requestContextSettings = new RequestContextSettings()
            {
                CachePath = cachePath,
                PersistSessionCookies = true,
                PersistUserPreferences = true,
            };

            browser = new ChromiumWebBrowser("www.google.com")
            {
                BrowserSettings = new BrowserSettings()
                {
                    LocalStorage = CefState.Enabled,
                },
                RequestContext = new RequestContext(requestContextSettings)
            };

            Controls.Add(browser);
        }
    }
}
