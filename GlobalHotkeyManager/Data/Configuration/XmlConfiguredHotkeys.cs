﻿using nhammerl.HotkeyLib;
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

        /// <summary>
        /// Retrun the Configured Hotkeys
        /// </summary>
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
                    var key = (Keys)(Convert.ToInt32(hotKey.Attributes["Key"].Value));
                    var pluginName = hotKey.Attributes["PluginName"].Value;

                    configuredKeys.Add(new HotkeyConfiguration(new Guid(id), modifier, key, pluginName));
                }

                return configuredKeys;
            }
        }

        /// <summary>
        /// Add new Hotkey to Xml
        /// </summary>
        /// <param name="hotkey"></param>
        public void AddHotkey(HotkeyConfiguration hotkey)
        {
            var configXml = new XmlDocument();
            configXml.Load(_configurationPath.Value);

            var configParent = configXml.SelectSingleNode("/HotkeyConfigurations");

            if (configParent == null)
            {
                return;
            }

            var configXmlNode = configXml.CreateElement("HotkeyConfiguration");
            var idAttribute = configXml.CreateAttribute("Id");
            idAttribute.Value = hotkey.Id.ToString();
            var keyAttribute = configXml.CreateAttribute("Key");
            keyAttribute.Value = ((int)hotkey.Key).ToString();
            var modifierAttribute = configXml.CreateAttribute("Modifier");
            modifierAttribute.Value = hotkey.Modifier.ToString();
            var pluginNameAttribute = configXml.CreateAttribute("PluginName");
            pluginNameAttribute.Value = hotkey.PluginName;

            configXmlNode.Attributes.Append(idAttribute);
            configXmlNode.Attributes.Append(keyAttribute);
            configXmlNode.Attributes.Append(modifierAttribute);
            configXmlNode.Attributes.Append(pluginNameAttribute);

            configParent.AppendChild(configXmlNode);
            configXml.Save(_configurationPath.Value);
        }

        /// <summary>
        /// Remove Hotkey by Id
        /// </summary>
        /// <param name="hotKeyId"></param>
        public void RemoveHotkey(Guid hotKeyId)
        {
            var configXml = new XmlDocument();
            configXml.Load(_configurationPath.Value);

            var configParent = configXml.SelectSingleNode("/HotkeyConfigurations");

            if (configParent == null)
            {
                return;
            }

            var selectedConfig = configXml.SelectSingleNode("/HotkeyConfigurations/HotkeyConfiguration[@Id='" + hotKeyId + "']");

            if (selectedConfig != null)
            {
                configParent.RemoveChild(selectedConfig);
                configXml.Save(_configurationPath.Value);
            }
        }
    }
}