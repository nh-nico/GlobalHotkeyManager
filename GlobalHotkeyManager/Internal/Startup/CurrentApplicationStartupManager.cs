using nhammerl.GlobalHotkeyManager.Annotations;
using System;
using System.Windows.Forms;

namespace nhammerl.GlobalHotkeyManager.Internal.Startup
{
    /// <summary>
    /// Register and Unregister current app from autostart.
    /// </summary>
    public class CurrentApplicationStartupManager : IApplicationStartupManager
    {
        private readonly IRegistryKey _registryKey;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="registryKey"></param>
        public CurrentApplicationStartupManager([NotNull] IRegistryKey registryKey)
        {
            if (registryKey == null) throw new ArgumentNullException("registryKey");

            _registryKey = registryKey;
        }

        /// <summary>
        /// Register from autostart.
        /// </summary>
        public void Register()
        {
            _registryKey.Value.SetValue("GlobalHotkeyManager", Application.ExecutablePath);
        }

        /// <summary>
        /// Unregister from autostart.
        /// </summary>
        public void Unregister()
        {
            _registryKey.Value.DeleteValue("GlobalHotkeyManager", false);
        }
    }
}