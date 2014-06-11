using nhammerl.GlobalHotkeyManager.Annotations;
using nhammerl.GlobalHotkeyManager.Internal.Data.Configuration;
using nhammerl.GlobalHotkeyManager.Internal.Plugins;
using nhammerl.HotkeyLib;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace nhammerl.GlobalHotkeyManager
{
    /// <summary>
    /// Interaction logic for HotkeyConfigurationWindow.xaml
    /// </summary>
    public partial class HotkeyConfigurationWindow : UserControl, INotifyPropertyChanged
    {
        #region private variables

        private ObservableCollection<HotkeyConfiguration> _configuredHotkeys;
        private readonly IConfiguredHotkeys _xmlConfiguredHotkeys;
        private readonly ILoadPlugins _hotKeyPlugins;
        private Keys _lastPressedKey;
        private const string PressAnyKeyText = "Press any Key";

        #endregion

        #region public variables
        
        public ObservableCollection<HotkeyConfiguration> ConfiguredHotkeys
        {
            get { return _configuredHotkeys; }
            set
            {
                _configuredHotkeys = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public HotkeyConfigurationWindow()
        {
            InitializeComponent();

            // Init Collections
            ConfiguredHotkeys = new ObservableCollection<HotkeyConfiguration>();

            // Init XmlConfigurations
            _xmlConfiguredHotkeys = new XmlConfiguredHotkeys(new HotkeyConfigurationPath());

            // Init PluginLoader
            _hotKeyPlugins = new GlobalHotkeyManagerLoadPlugins(new HotkeyManagerPluginsPath());

            // Bindings
            ConfiguredKeyDataGrid.ItemsSource = ConfiguredHotkeys;

            // Load already configured Hotkeys
            LoadXmlHotKeys();

            // Load Dropdown Menues
            LoadDropDowns();
        }

        #endregion

        #region Init Loads
        
        /// <summary>
        /// Load Dropdown Lists with DefaultValues
        /// </summary>
        private void LoadDropDowns()
        {
            ModifierDropDown.Items.Add(new ComboBoxItem() {Content = "ALT", Tag = KeyConstants.ALT});
            ModifierDropDown.Items.Add(new ComboBoxItem() {Content = "CTRL", Tag = KeyConstants.CTRL});
            //ModifierDropDown.Items.Add(new ComboBoxItem() {Content = "NOMOD", Tag = KeyConstants.NOMOD}); // Not yet supported
            ModifierDropDown.Items.Add(new ComboBoxItem() {Content = "SHIFT", Tag = KeyConstants.SHIFT});
            //ModifierDropDown.Items.Add(new ComboBoxItem() {Content = "WIN", Tag = KeyConstants.WIN}); // Not yet suppored.

            foreach (var globalHotkeyPlugin in _hotKeyPlugins.Plugins)
            {
                PluginsDropDown.Items.Add(globalHotkeyPlugin.PluginName);
            }
        }
        
        
        
        #endregion

        #region Configuration
        
        /// <summary>
        /// Init load the xml configured Hotkeys
        /// </summary>
        private void LoadXmlHotKeys()
        {
            _xmlConfiguredHotkeys.List.ToList().ForEach(config => ConfiguredHotkeys.Add(config));
        }

        /// <summary>
        /// Delete the current selected HotkeyConfig
        /// </summary>
        private void DeleteSelectedFromConfig()
        {
            var selectedItem = ConfiguredKeyDataGrid.SelectedItem;

            if (selectedItem != null)
            {
                _xmlConfiguredHotkeys.RemoveHotkey(((HotkeyConfiguration) selectedItem).Id);
                ConfiguredHotkeys.Remove((HotkeyConfiguration) selectedItem);
            }
        }

        #endregion
        
        #region Eventhanlder
        
        /// <summary>
        /// Handler for AddHotkey Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickAddHotkeyButton(object sender, RoutedEventArgs e)
        {
            var selectedModifier = (ComboBoxItem) ModifierDropDown.SelectedItem;
            var selectedPluginName = (string) PluginsDropDown.SelectedItem;

            if (selectedModifier == null || selectedPluginName == null || PressedKeyIdentifier.Text == "" ||
                PressedKeyIdentifier.Text == PressAnyKeyText)
            {
                MessageBox.Show("Select Modifier, Key and Plugin");
                return;
            }

            var hotkeyConfig = new HotkeyConfiguration(Guid.NewGuid(), (int) selectedModifier.Tag, _lastPressedKey,
                selectedPluginName);

            _xmlConfiguredHotkeys.AddHotkey(hotkeyConfig);
            ConfiguredHotkeys.Add(hotkeyConfig);

            ModifierDropDown.SelectedItem = null;
            PluginsDropDown.SelectedItem = null;
            PressedKeyIdentifier.Text = "";
        }

        /// <summary>
        /// Handler for AddHotkey Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickRemoveHotkeyButton(object sender, RoutedEventArgs e)
        {
            DeleteSelectedFromConfig();
        }

        /// <summary>
        /// Get the Pressed Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyCombinationDown(object sender, KeyEventArgs e)
        {
            _lastPressedKey = (Keys) KeyInterop.VirtualKeyFromKey(e.Key);
            PressedKeyIdentifier.Text = _lastPressedKey.ToString();
        }

        /// <summary>
        /// Set the Default Text on focus the identifierbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyComboTextSetTextOnFocus(object sender, RoutedEventArgs e)
        {
            PressedKeyIdentifier.Text = PressAnyKeyText;
        }

        #endregion
        
        #region Helper

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}