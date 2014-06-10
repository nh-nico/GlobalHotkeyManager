using System;
using System.IO;
using System.Xml;

namespace nhammerl.GlobalHotkeyManager.Internal.Data.Configuration
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
                    var configFile = new XmlDocument();

                        configFile.AppendChild(configFile.CreateElement("HotkeyConfigurations"));
                        configFile.Save(configFilePath);
                }
                return configFilePath;
            }
        }
    }
}