using System;
using System.IO;

namespace nhammerl.GlobalHotkeyManager.Internal.Plugins
{
    public class HotkeyManagerPluginsPath : IPluginPath
    {
        public string Value
        {
            get
            {
                var executingDirectory =
                    Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                        .Replace("file:\\", "");

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