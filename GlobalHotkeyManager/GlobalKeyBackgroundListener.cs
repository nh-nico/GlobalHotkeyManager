using nhammerl.GlobalHotkeyManager.Data.Configuration;
using nhammerl.GlobalHotkeyManager.Plugins;
using nhammerl.HotkeyLib;
using nhammerlGlobalHotkeyPluginLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace nhammerl.GlobalHotkeyManager
{
    public partial class GlobalKeyBackgroundListener : Form
    {
        #region Private Members

        private readonly List<GlobalHotkey> _hotKeys;
        private readonly HotkeyConfigurationWindow _hotkeyConfigurationWindow;
        private readonly IConfiguredHotkeys _configuredHotkeys;
        private readonly IEnumerable<IGlobalHotkeyPlugin> _plugins;

        #endregion Private Members

        #region Constructor

        public GlobalKeyBackgroundListener()
        {
            InitializeComponent();

            // Initialize the HotkeyList
            _hotKeys = new List<GlobalHotkey>();
            _hotkeyConfigurationWindow = new HotkeyConfigurationWindow();

            // Init configuredHotkey
            _configuredHotkeys = new XmlConfiguredHotkeys(new HotkeyConfigurationPath());

            // Init Plugins
            var loadPlugins = new GlobalHotkeyManagerLoadPlugins(new HotkeyManagerPluginsPath());
            _plugins = loadPlugins.Plugins;

            // EventHandler
            Shown += BackgroundListenerFromShow;
            FormClosing += BackgroundListenerFromClosing;
            trayNotification.DoubleClick += DoubleClickTrayIcon;
        }

        #endregion Constructor

        #region Form Events

        /// <summary>
        /// Eventhandler for Doubleclick the TrayIcon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleClickTrayIcon(object sender, EventArgs e)
        {
            Log("Show Log");

            // Show the From
            //Show();
        }

        /// <summary>
        /// Eventhandler to show the BackgroundFrom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundListenerFromShow(object sender, EventArgs e)
        {
            // Hide BackgroundFrom
            Hide();
            ShowInTaskbar = false;

            // Register the GlobalHotkeys
            BuildGlobalKeys();
            RegisterGlobalKeys();
        }

        /// <summary>
        /// Eventhandler to Unregister the Hotkeys on closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundListenerFromClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterGlobalKeys();
        }

        #endregion Form Events

        #region TrayMenue Events

        /// <summary>
        /// Close the BackgroundListener
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayMenueExit(object sender, EventArgs e)
        {
            Log("Exit Programm");

            // Close Programm
            Close();
        }

        /// <summary>
        /// Open Configuration Window for Hotkeys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayMenueConfigureHotkeys(object sender, EventArgs e)
        {
            UnregisterGlobalKeys();

            var w = new Window { Content = _hotkeyConfigurationWindow, Width = 350, Height = 400 };
            w.ShowDialog();

            BuildGlobalKeys();
            RegisterGlobalKeys();
        }

        #endregion TrayMenue Events

        #region HotKeyWorker

        /// <summary>
        /// Create all Global keys and add into global List
        /// </summary>
        public void BuildGlobalKeys()
        {
            _hotKeys.Clear();

            foreach (var hotKey in _configuredHotkeys.List)
            {
                var globalHotKey = new GlobalHotkey(
                    hotKey.Modifier,
                    hotKey.Key,
                    this,
                    () => _plugins.First(p => p.PluginName == hotKey.PluginName).Execute());

                _hotKeys.Add(globalHotKey);
            }
        }

        /// <summary>
        /// Register all keys in private list
        /// </summary>
        public void RegisterGlobalKeys()
        {
            _hotKeys.ForEach(k => k.Register());
        }

        public void UnregisterGlobalKeys()
        {
            _hotKeys.ForEach(k => k.Unregiser());
        }

        /// <summary>
        /// Listen to keyinput and handle hotkeyEvents
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == KeyConstants.WM_HOTKEY_MSG_ID)
            {
                var pressedKey = KeyUtilities.GetKey(m.LParam);

                var hotKey = _hotKeys.FirstOrDefault(k => k.Key.Equals(pressedKey));

                if (hotKey != null)
                {
                    hotKey.RunAction();
                }
            }
            base.WndProc(ref m);
        }

        #endregion HotKeyWorker

        #region HotKeyActions

        private void HandleAltArrowUp()
        {
            Log("ALT+ArrowUp");
            var x = GetForegroundWindow();

            var screen = Screen.FromHandle(x);

            MoveWindow(x, 0, 0, 1920, 540, true);
        }

        private void HandleAltArrowDown()
        {
            Log("ALT+ArrowDown");

            Log("ALT+ArrowUp");
            var x = GetForegroundWindow();

            var screen = Screen.FromHandle(x);

            MoveWindow(x, 0, 540, 1920, 540, true);
        }

        private void HandleAltArrowLeft()
        {
            Log("ALT+ArrowLeft");

            var x = GetForegroundWindow();

            var screen = Screen.FromHandle(x);

            MoveWindow(x, 0, 0, 500, 500, true);
        }

        private void HandleAltArrowRight()
        {
            Log("ALT+ArrowRight");

            var x = GetForegroundWindow();

            var screen = Screen.FromHandle(x);

            MoveWindow(x, 0, 0, 1920, 1080, true);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        #endregion HotKeyActions

        #region Debug and Log

        /// <summary>
        /// Logs into the Textfield
        /// </summary>
        /// <param name="text"></param>
        private void Log(string text)
        {
            Logger.Text += text + Environment.NewLine;
        }

        #endregion Debug and Log
    }
}