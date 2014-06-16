using nhammerl.GlobalHotkeyManager.Annotations;
using System;

namespace nhammerl.GlobalHotkeyManager.Internal.Startup
{
    /// <summary>
    /// Registry keyinfos from GlobalHotkeyManager.
    /// </summary>
    public class GlobalHotkeyManagerAutostartRegistryKeyInfo : IRegistryKeyInfo
    {
        private readonly IRegistryKey _registryKey;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="registryKey"></param>
        public GlobalHotkeyManagerAutostartRegistryKeyInfo([NotNull] IRegistryKey registryKey)
        {
            if (registryKey == null) throw new ArgumentNullException("registryKey");

            _registryKey = registryKey;
        }

        /// <summary>
        /// Check key is available and try to get the value;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(out string value)
        {
            value = "";

            if (_registryKey.Value.GetValue("GlobalHotkeyManager") == null)
            {
                return false;
            }

            value = _registryKey.Value.GetValue("GlobalHotkeyManager").ToString();

            return true;
        }
    }
}