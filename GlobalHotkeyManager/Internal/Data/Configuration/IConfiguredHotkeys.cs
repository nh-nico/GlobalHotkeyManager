using System;
using System.Collections.Generic;

namespace nhammerl.GlobalHotkeyManager.Internal.Data.Configuration
{
    /// <summary>
    /// Parsed HotkeyConfiguration.
    /// </summary>
    public interface IConfiguredHotkeys
    {
        /// <summary>
        /// List of configured hotkeys.
        /// </summary>
        IEnumerable<HotkeyConfiguration> List { get; }

        /// <summary>
        /// Add hotkey to list.
        /// </summary>
        /// <param name="hotkey"></param>
        void AddHotkey(HotkeyConfiguration hotkey);

        /// <summary>
        /// Remove hotkey from list.
        /// </summary>
        /// <param name="hotKeyId"></param>
        void RemoveHotkey(Guid hotKeyId);
    }
}