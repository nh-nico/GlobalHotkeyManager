using nhammerlGlobalHotkeyPluginLib;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer
{
    public class TestMessageThrower : IGlobalHotkeyPlugin
    {
        public void Execute()
        {
            MessageBox.Show("TestMessage Thrower");
        }
    }
}