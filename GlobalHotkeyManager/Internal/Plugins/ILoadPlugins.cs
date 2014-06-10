using System.Collections.Generic;
using nhammerlGlobalHotkeyPluginLib;

namespace nhammerl.GlobalHotkeyManager.Internal.Plugins
{
    public interface ILoadPlugins
    {
        IEnumerable<IGlobalHotkeyPlugin> Plugins { get; }
    }
}