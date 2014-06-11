namespace nhammerl.GlobalHotkeyManager.Internal.Startup
{
    public interface IApplicationStartupManager
    {
        void Register();

        void Unregister();
    }
}
