using nhammerlGlobalHotkeyPluginLib;
using System.Collections.Generic;
using System.Windows.Forms;

namespace nhammerl.GlobalHotkeyManager.Plugins
{
    public interface ILoadPlugins
    {
        IEnumerable<IGlobalHotkeyPlugin> Plugins { get; }
    }
}