using nhammerlGlobalHotkeyPluginLib;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer
{
    public class Foo : IGlobalHotkeyPlugin
    {
        public string PluginName
        {
            get { return "foo"; }
           
        }
        public void Execute()
        {
            MessageBox.Show("bar");
        }
    }
}