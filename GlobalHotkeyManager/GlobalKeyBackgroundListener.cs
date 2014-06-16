using nhammerl.GlobalHotkeyManager.Internal.Data.Configuration;
using nhammerl.GlobalHotkeyManager.Internal.Plugins;
using nhammerl.GlobalHotkeyManager.Internal.Startup;
using nhammerl.HotkeyLib;
using nhammerlGlobalHotkeyPluginLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace nhammerl.GlobalHotkeyManager
{
    public partial class GlobalKeyBackgroundListener : Form
    {
        #region Private Members

        private readonly List<GlobalHotkey> _hotKeys;
        private readonly HotkeyConfigurationWindow _hotkeyConfigurationWindow;
        private readonly IConfiguredHotkeys _configuredHotkeys;
        private readonly IEnumerable<IGlobalHotkeyPlugin> _plugins;
        private readonly IApplicationStartupManager _applicationStartupManager;

        #endregion Private Members

        #region Constructor

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        public GlobalKeyBackgroundListener()
        {
            InitializeComponent();

            // Initialize the HotkeyList
            _hotKeys = new List<GlobalHotkey>();
            _hotkeyConfigurationWindow = new HotkeyConfigurationWindow();

            // Init configuredHotkey
            _configuredHotkeys = new XmlConfiguredHotkeys(new HotkeyXmlConfigurationPath());

            // Init Plugins
            var loadPlugins = new GlobalHotkeyManagerLoadPlugins(new HotkeyManagerPluginsPath());
            _plugins = loadPlugins.Plugins;

            // Init Startup Manager & KeyInfos
            var startupKey = new StartupRegistryKey();
            _applicationStartupManager = new CurrentApplicationStartupManager(startupKey);
            var registryKeyInfo = new GlobalHotkeyManagerAutostartRegistryKeyInfo(startupKey);

            // Check Autostart if already Registered
            string registryValue;
            if (registryKeyInfo.TryGetValue(out registryValue))
            {
                _autostartMenueItem.Checked = true;
            }

            // EventHandler
            Shown += BackgroundListenerFromShow;
            FormClosing += BackgroundListenerFromClosing;
            _trayNotification.DoubleClick += DoubleClickTrayIcon;
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

            var w = new Window { Content = _hotkeyConfigurationWindow, Width = 450, Height = 350 };
            w.ShowDialog();

            BuildGlobalKeys();
            RegisterGlobalKeys();
        }

        private void AutoStartMenueItemClicked(object sender, EventArgs e)
        {
            if (this._autostartMenueItem.Checked)
            {
                _applicationStartupManager.Register();
            }
            else
            {
                _applicationStartupManager.Unregister();
            }
        }

        #endregion TrayMenue Events

        #region HotKeyWorker

        /// <summary>
        /// Create all Global keys and add into global List
        /// </summary>
        public void BuildGlobalKeys()
        {
            // Clear all configured hotkeys and re-register after configuration.
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
                    try
                    {
                        hotKey.RunAction();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("NH: " + ex.Message);
                    }
                }
            }
            base.WndProc(ref m);
        }

        #endregion HotKeyWorker

        #region Debug and Log

        /// <summary>
        /// Logs into the Textfield
        /// </summary>
        /// <param name="text"></param>
        private void Log(string text)
        {
            _logger.Text += text + Environment.NewLine;
        }

        #endregion Debug and Log
    }
}