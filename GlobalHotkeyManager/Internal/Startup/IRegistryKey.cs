using Microsoft.Win32;

namespace nhammerl.GlobalHotkeyManager.Internal.Startup
{
    public interface IRegistryKey
    {
        RegistryKey Value { get; }
    }
}