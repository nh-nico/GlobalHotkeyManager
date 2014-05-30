using System;
using System.IO;

namespace nhammerl.GlobalHotkeyManager.Plugins
{
    public class HotkeyManagerPluginsPath : IPluginPath
    {
        public string Value
        {
            get
            {
                var executingDirectory = Environment.CurrentDirectory;

                var pluginsDirectory = String.Format("{0}/Plugins", executingDirectory);

                if (!Directory.Exists(pluginsDirectory))
                {
                    Directory.CreateDirectory(pluginsDirectory);
                }

                return pluginsDirectory;
            }
        }
    }
}