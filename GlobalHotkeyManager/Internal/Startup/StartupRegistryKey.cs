using Microsoft.Win32;

namespace nhammerl.GlobalHotkeyManager.Internal.Startup
{
    public class StartupRegistryKey : IRegistryKey
    {
        public RegistryKey Value
        {
            get
            {
                return Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            }
        }
    }
}