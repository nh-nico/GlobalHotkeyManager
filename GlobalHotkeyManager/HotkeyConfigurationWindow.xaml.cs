using nhammerl.GlobalHotkeyManager.Data.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace nhammerl.GlobalHotkeyManager
{
    /// <summary>
    /// Interaction logic for HotkeyConfigurationWindow.xaml
    /// </summary>
    public partial class HotkeyConfigurationWindow : UserControl
    {
        public HotkeyConfigurationWindow()
        {
            InitializeComponent();
        }

        private void OnClickAddHotkeyButton(object sender, RoutedEventArgs e)
        {
            var x = new XmlConfiguredHotkeys(new HotkeyConfigurationPath());

            var y = x.List;
        }
    }

    //public class HotkeySetting
    //{
    //    public int _modifier;
    //    public Key _key;

    //}
}