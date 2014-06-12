using System;
using System.IO;
using System.Xml;
using nhammerl.GlobalHotkeyManager.Annotations;
using nhammerl.GlobalHotkeyManager.Internal.Startup;

namespace nhammerl.GlobalHotkeyManager.Internal.Data.Configuration
{
    public class HotkeyConfigurationPath : IConfigurationPath
    {
        public string Value
        {
            get
            {
                var currentDirectory =
                    Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                        .Replace("file:\\", "");

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