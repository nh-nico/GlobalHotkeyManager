using nhammerl.HotkeyLib;
using System;
using System.Windows.Input;

namespace nhammerl.GlobalHotkeyManager.Data.Configuration
{
    public class HotkeyConfiguration
    {
        public Guid Id { get; set; }

        public int Modifier { get; set; }

        public Key Key { get; set; }

        public string PluginName { get; set; }

        public HotkeyConfiguration(Guid id, int modifier, Key key, string pluginName)
        {
            Id = id;
            Modifier = modifier;
            Key = key;
            PluginName = pluginName;
        }
    }
}