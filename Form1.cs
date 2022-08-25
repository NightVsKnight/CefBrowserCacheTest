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
            browser = new ChromiumWebBrowser("restream.io")
            {
                BrowserSettings = new BrowserSettings()
                {
                    LocalStorage = CefState.Enabled,
                },
                RequestContext = RequestContext.Configure()
                            .WithSharedSettings(Cef.GetGlobalRequestContext())
                            .Create(),
            };
            browser.Dock = DockStyle.Fill;
            Controls.Add(browser);
        }
    }
}
