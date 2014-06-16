namespace nhammerl.GlobalHotkeyManager.Internal.Startup
{
    /// <summary>
    /// Registry key infos.
    /// </summary>
    public interface IRegistryKeyInfo
    {
        /// <summary>
        /// Try get the value if key is available.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool TryGetValue(out string value);
    }
}