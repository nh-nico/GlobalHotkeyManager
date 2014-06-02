using System.Windows.Forms;
using nhammerlGlobalHotkeyPluginLib;

namespace nhammerl.WindowOrganizer
{
    public class TestMessageThrower2 : IGlobalHotkeyPlugin
    {
        public string PluginName
        {
            get { return "MessageThrower2"; }
        }

        public void Execute()
        {
            MessageBox.Show("TestMessage Thrower2");
        }
    }
}