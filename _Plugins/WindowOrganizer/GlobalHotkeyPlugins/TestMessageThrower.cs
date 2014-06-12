using nhammerlGlobalHotkeyPluginLib;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer.GlobalHotkeyPlugins
{
    /// <summary>
    /// Throw a testmessage.
    /// </summary>
    public class TestMessageThrower : IGlobalHotkeyPlugin
    {
        /// <summary>
        /// Name of plugin for the hotkeymanager.
        /// </summary>
        public string PluginName
        {
            get { return "MessageThrower"; }
        }

        /// <summary>
        /// Throw a testmessage.
        /// </summary>
        public void Execute()
        {
            MessageBox.Show("Hello World!");
        }
    }
}