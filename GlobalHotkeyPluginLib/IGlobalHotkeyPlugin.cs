using System;

namespace nhammerlGlobalHotkeyPluginLib
{
    public interface IGlobalHotkeyPlugin
    {
        String PluginName { get; }

        void Execute();
    }
}