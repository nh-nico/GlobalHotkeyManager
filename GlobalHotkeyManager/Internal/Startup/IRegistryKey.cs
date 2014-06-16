using Microsoft.Win32;

namespace nhammerl.GlobalHotkeyManager.Internal.Startup
{
    /// <summary>
    /// Any registry key.
    /// </summary>
    public interface IRegistryKey
    {
        RegistryKey Value { get; }
    }
}