using System;
using System.Windows.Input;

namespace nhammerl.GlobalHotkeyManager.Data.Configuration
{
    public class HotkeyConfiguration
    {
        private Guid Id { get; set; }

        public int Modifier { get; set; }

        public Key Key { get; set; }

        public HotkeyConfiguration(Guid id, int modifier, Key key)
        {
            Id = id;
            Modifier = modifier;
            Key = key;
        }
    }
}