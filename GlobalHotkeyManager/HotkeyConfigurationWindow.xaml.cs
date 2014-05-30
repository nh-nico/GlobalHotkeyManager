using nhammerl.GlobalHotkeyManager.Annotations;
using nhammerl.GlobalHotkeyManager.Data.Configuration;
using nhammerl.GlobalHotkeyManager.Plugins;
using nhammerl.HotkeyLib;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using UserControl = System.Windows.Controls.UserControl;

namespace nhammerl.GlobalHotkeyManager
{
    /// <summary>
    /// Interaction logic for HotkeyConfigurationWindow.xaml
    /// </summary>
    public partial class HotkeyConfigurationWindow : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<HotkeyConfiguration> _configuredHotkeys;
        private readonly IConfiguredHotkeys _xmlConfiguredHotkeys;
        private readonly ILoadPlugins _hotKeyPlugins;

        public ObservableCollection<HotkeyConfiguration> ConfiguredHotkeys
        {
            get { return _configuredHotkeys; }
            set
            {
                _configuredHotkeys = value;
                OnPropertyChanged();
            }
        }

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

        private void LoadDropDowns()
        {
            foreach (var key in Enum.GetValues(typeof(Key)))
            {
                KeyDropDown.Items.Add(key);
            }

            ModifierDropDown.Items.Add(KeyConstants.ALT);
            ModifierDropDown.Items.Add(KeyConstants.CTRL);
            ModifierDropDown.Items.Add(KeyConstants.NOMOD);
            ModifierDropDown.Items.Add(KeyConstants.SHIFT);
            ModifierDropDown.Items.Add(KeyConstants.WIN);

            foreach (var globalHotkeyPlugin in _hotKeyPlugins.Plugins)
            {
                PluginsDropDown.Items.Add(globalHotkeyPlugin.PluginName);
            }
        }

        /// <summary>
        /// Init load the xml configured Hotkeys
        /// </summary>
        private void LoadXmlHotKeys()
        {
            _xmlConfiguredHotkeys.List.ToList().ForEach(config => ConfiguredHotkeys.Add(config));
        }

        /// <summary>
        /// Handler for AddHotkey Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickAddHotkeyButton(object sender, RoutedEventArgs e)
        {
            var selectedKey = (Key)KeyDropDown.SelectedItem;
            var selectedModifier = ModifierDropDown.SelectedItem;
            var selectedPluginName = (string)PluginsDropDown.SelectedItem;

            var hotkeyConfig = new HotkeyConfiguration(Guid.NewGuid(), (int)selectedModifier + 1, selectedKey, selectedPluginName);

            _xmlConfiguredHotkeys.AddHotkey(hotkeyConfig);
            ConfiguredHotkeys.Add(hotkeyConfig);

            KeyDropDown.SelectedItem = null;
            ModifierDropDown.SelectedItem = null;
            PluginsDropDown.SelectedItem = null;
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
        /// Delete the current selected HotkeyConfig
        /// </summary>
        private void DeleteSelectedFromConfig()
        {
            var selectedItem = ConfiguredKeyDataGrid.SelectedItem;

            if (selectedItem != null)
            {
                _xmlConfiguredHotkeys.RemoveHotkey(((HotkeyConfiguration)selectedItem).Id);
                ConfiguredHotkeys.Remove((HotkeyConfiguration)selectedItem);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) { handler(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}