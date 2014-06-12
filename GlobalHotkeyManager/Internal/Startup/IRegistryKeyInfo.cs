namespace nhammerl.GlobalHotkeyManager.Internal.Startup
{
    public interface IRegistryKeyInfo
    {
        bool TryGetValue(out string value);
    }
}