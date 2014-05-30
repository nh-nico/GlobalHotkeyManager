using nhammerl.GlobalHotkeyManager.Plugins;
using nhammerl.HotkeyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;

namespace nhammerl.GlobalHotkeyManager
{
    public partial class GlobalKeyBackgroundListener : Form
    {
        #region Private Members

        private readonly List<GlobalHotkey> _hotKeys;
        private HotkeyConfigurationWindow _hotkeyConfigurationWindow;

        #endregion Private Members

        #region Constructor

        public GlobalKeyBackgroundListener()
        {
            InitializeComponent();

            // Initialize the HotkeyList
            _hotKeys = new List<GlobalHotkey>();
            _hotkeyConfigurationWindow = new HotkeyConfigurationWindow();

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
            _hotKeys.ForEach(k => k.Unregiser());
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
            var w = new Window { Content = _hotkeyConfigurationWindow };
            w.ShowDialog();
        }

        #endregion TrayMenue Events

        #region HotKeyWorker

        /// <summary>
        /// Create all Global keys and add into global List
        /// </summary>
        public void BuildGlobalKeys()
        {
            _hotKeys.AddRange(
                new List<GlobalHotkey>
                {
                    new GlobalHotkey(KeyConstants.ALT, Keys.Up, this, HandleAltArrowUp),
                    new GlobalHotkey(KeyConstants.ALT, Keys.Down, this, HandleAltArrowDown),
                    new GlobalHotkey(KeyConstants.ALT, Keys.Left, this, HandleAltArrowLeft),
                    new GlobalHotkey(KeyConstants.ALT, Keys.Right,this, HandleAltArrowRight)
                });
        }

        /// <summary>
        /// Register all keys in private list
        /// </summary>
        public void RegisterGlobalKeys()
        {
            _hotKeys.ForEach(k => k.Register());
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