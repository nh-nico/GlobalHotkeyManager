using Microsoft.Win32;

namespace nhammerl.GlobalHotkeyManager.Internal.Startup
{
    /// <summary>
    /// Startup registry key path.
    /// </summary>
    public class StartupRegistryKey : IRegistryKey
    {
        /// <summary>
        /// Path of startup registry key.
        /// </summary>
        public RegistryKey Value
        {
            get
            {
                return Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            }
        }
    }
}