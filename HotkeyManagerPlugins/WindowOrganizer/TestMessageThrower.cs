using nhammerlGlobalHotkeyPluginLib;
using System;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer
{
    public class TestMessageThrower : IGlobalHotkeyPlugin
    {
        public string PluginName
        {
            get { return "MessageThrower"; }
        }

        public void Execute()
        {
            MessageBox.Show("TestMessage Thrower");
        }
    }
}