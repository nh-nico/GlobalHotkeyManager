using System.Collections.Generic;

namespace nhammerl.GlobalHotkeyManager.Data.Configuration
{
    public interface IConfiguredHotkeys
    {
        IEnumerable<HotkeyConfiguration> List { get; }
    }
}