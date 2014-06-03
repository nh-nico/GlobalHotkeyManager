using nhammerlGlobalHotkeyPluginLib;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer.GlobalHotkeyPlugins
{
    public class TestMessageThrower : IGlobalHotkeyPlugin
    {
        public string PluginName
        {
            get { return "MessageThrower"; }
        }

        public void Execute()
        {
            MessageBox.Show("Hello World!");
        }
    }
}