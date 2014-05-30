using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;

namespace nhammerl.GlobalHotkeyManager.Data.Configuration
{
    public class XmlConfiguredHotkeys : IConfiguredHotkeys
    {
        private readonly IConfigurationPath _configurationPath;

        public XmlConfiguredHotkeys(IConfigurationPath configurationPath)
        {
            if (configurationPath == null) { throw new ArgumentNullException("configurationPath"); }

            _configurationPath = configurationPath;
        }

        public IEnumerable<HotkeyConfiguration> List
        {
            get
            {
                var configXml = new XmlDocument();
                configXml.Load(_configurationPath.Value);

                var configuredHotKeys = configXml.GetElementsByTagName("HotkeyConfiguration");

                var configuredKeys = new List<HotkeyConfiguration>();

                foreach (XmlNode hotKey in configuredHotKeys)
                {
                    var id = hotKey.Attributes["Id"].Value;
                    var modifier = Convert.ToInt32(hotKey.Attributes["Modifier"].Value);
                    var key = (Key)Enum.GetValues(typeof(Keys)).GetValue(Convert.ToInt32(hotKey.Attributes["Key"].Value));

                    configuredKeys.Add(new HotkeyConfiguration(new Guid(id), modifier, key));
                }

                return configuredKeys;
            }
        }
    }
}