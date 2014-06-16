namespace nhammerl.WindowOrganizer.Internal
{
    /// <summary>
    /// Specified state of an plugin.
    /// </summary>
    public interface IPluginState
    {
        /// <summary>
        /// State of plugin. True == valid; False == Invalid;
        /// </summary>
        bool State { get; }
    }
}