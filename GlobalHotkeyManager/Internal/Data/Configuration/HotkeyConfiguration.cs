using nhammerl.GlobalHotkeyManager.Annotations;
using nhammerl.HotkeyLib;
using System;
using System.Windows.Forms;

namespace nhammerl.GlobalHotkeyManager.Internal.Data.Configuration
{
    /// <summary>
    /// Configured registered hotkey
    /// </summary>
    public class HotkeyConfiguration
    {
        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modifier"></param>
        /// <param name="key"></param>
        /// <param name="pluginName"></param>
        public HotkeyConfiguration(Guid id, int modifier, Keys key, string pluginName)
        {
            Id = id;
            Modifier = modifier;
            Key = key;
            PluginName = pluginName;
        }

        /// <summary>
        /// Id of hotkey
        /// </summary>
        public Guid Id { get; set; }

        private int _modifier;

        /// <summary>
        /// Modifier of hotkey combo.
        /// </summary>
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

        /// <summary>
        /// Name of modifier.
        /// </summary>
        public string ModifierName { get; [UsedImplicitly] private set; }

        /// <summary>
        /// Combo key.
        /// </summary>
        public Keys Key { get; set; }

        /// <summary>
        /// Pluginname dependend on.
        /// </summary>
        public string PluginName { get; set; }
    }
}