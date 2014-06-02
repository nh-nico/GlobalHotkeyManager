using System;
using System.Windows.Forms;
using nhammerl.GlobalHotkeyManager.Annotations;
using nhammerl.HotkeyLib;

namespace nhammerl.GlobalHotkeyManager.Data.Configuration
{
    public class HotkeyConfiguration
    {
        public Guid Id { get; set; }

        private int _modifier;
        public int Modifier
        {
            get { return _modifier; }
            set
            {
                _modifier = value;

                switch (value)
                {
                    case KeyConstants.ALT:
                        ModifierName = "Alt";
                        break;
                    case KeyConstants.CTRL:
                        ModifierName = "CTRL";
                        break;
                    case KeyConstants.NOMOD:
                        ModifierName = "NOMOD";
                        break;
                    case KeyConstants.SHIFT:
                        ModifierName = "SHIFT";
                        break;
                    case KeyConstants.WIN:
                        ModifierName = "WIN";
                        break;
                    default:
                        ModifierName = "";
                        break;
                }
            }
        }

        public string ModifierName { get; [UsedImplicitly] private set; }

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