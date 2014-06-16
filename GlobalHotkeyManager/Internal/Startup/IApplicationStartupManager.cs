namespace nhammerl.GlobalHotkeyManager.Internal.Startup
{
    /// <summary>
    /// Starup manager.
    /// </summary>
    public interface IApplicationStartupManager
    {
        /// <summary>
        /// Register app on start.
        /// </summary>
        void Register();

        /// <summary>
        /// Unregister app from start.
        /// </summary>
        void Unregister();
    }
}