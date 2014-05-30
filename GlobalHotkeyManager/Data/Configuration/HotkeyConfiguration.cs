using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace nhammerl.GlobalHotkeyManager.Data.Configuration
{
    public class HotkeyConfiguration
    {
        public Guid Id { get; set; }

        public int Modifier { get; set; }

        public Keys Key { get; set; }

        public string PluginName { get; set; }

        public HotkeyConfiguration(Guid id, int modifier, Keys key, string pluginName)
        {
            Id = id;
            Modifier = modifier;
            Key = key;
            PluginName = pluginName;
        }
    }
}