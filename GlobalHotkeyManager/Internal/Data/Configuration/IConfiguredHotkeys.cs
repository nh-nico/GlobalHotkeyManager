using System;
using System.Collections.Generic;

namespace nhammerl.GlobalHotkeyManager.Internal.Data.Configuration
{
    public interface IConfiguredHotkeys
    {
        IEnumerable<HotkeyConfiguration> List { get; }

        void AddHotkey(HotkeyConfiguration hotkey);

        void RemoveHotkey(Guid hotKeyId);
    }
}