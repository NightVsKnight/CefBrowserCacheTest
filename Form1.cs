using CefSharp.WinForms;
using CefSharp;
using System;
using System.IO;
using System.Windows.Forms;

namespace CefBrowserCacheTest
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser browser;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Cef.IsInitialized)
            {
                throw new InvalidOperationException("Cef.Initialize(...) must be called first");
            }

            var appSettings = App.CEF_SETTINGS;
            var cachePath = Path.Combine(appSettings.CachePath, "User_Profile");

            RequestContextSettings requestContextSettings = new RequestContextSettings();
            if (!String.IsNullOrEmpty(cachePath))
            {
                requestContextSettings.CachePath = cachePath;
                requestContextSettings.PersistSessionCookies = true;
                requestContextSettings.PersistUserPreferences = true;
            }

            browser = new ChromiumWebBrowser(String.Empty)
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
