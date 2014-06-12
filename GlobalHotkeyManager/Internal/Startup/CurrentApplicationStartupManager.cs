using System;
using System.Windows.Forms;
using nhammerl.GlobalHotkeyManager.Annotations;

namespace nhammerl.GlobalHotkeyManager.Internal.Startup
{
    public class CurrentApplicationStartupManager : IApplicationStartupManager
    {
        private readonly IRegistryKey _registryKey;

        public CurrentApplicationStartupManager([NotNull] IRegistryKey registryKey)
        {
            if (registryKey == null) throw new ArgumentNullException("registryKey");

            _registryKey = registryKey;
        }

        public void Register()
        {
            _registryKey.Value.SetValue("GlobalHotkeyManager", Application.ExecutablePath);
        }

        public void Unregister()
        {
            _registryKey.Value.DeleteValue("GlobalHotkeyManager", false);
        }
    }
}