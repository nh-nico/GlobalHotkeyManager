using System;
using nhammerl.GlobalHotkeyManager.Annotations;

namespace nhammerl.GlobalHotkeyManager.Internal.Startup
{
    public class GlobalHotkeyManagerAutostartRegistryKeyInfo : IRegistryKeyInfo
    {
        private readonly IRegistryKey _registryKey;

        public GlobalHotkeyManagerAutostartRegistryKeyInfo([NotNull] IRegistryKey registryKey)
        {
            if (registryKey == null) throw new ArgumentNullException("registryKey");

            _registryKey = registryKey;
        }

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