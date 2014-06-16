using System;
using System.IO;
using System.Xml;

namespace nhammerl.GlobalHotkeyManager.Internal.Data.Configuration
{
    /// <summary>
    /// Path of the configured hotkey xml file.
    /// </summary>
    public class HotkeyXmlConfigurationPath : IXmlConfigurationPath
    {
        /// <summary>
        /// Path to xml file.
        /// </summary>
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