using System;
using System.IO;

namespace nhammerl.GlobalHotkeyManager.Data.Configuration
{
    public class HotkeyConfigurationPath : IConfigurationPath
    {
        public string Value
        {
            get
            {
                var currentDirectory = Environment.CurrentDirectory;
                var configFilePath = String.Format("{0}/HotkeyConfig.xml", currentDirectory);

                if (!File.Exists(configFilePath))
                {
                    File.Create(configFilePath);
                }

                return configFilePath;
            }
        }
    }
}