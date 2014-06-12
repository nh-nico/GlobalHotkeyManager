using System;

namespace nhammerlGlobalHotkeyPluginLib
{
    /// <summary>
    /// Interface searched by HotkeyManager
    /// </summary>
    public interface IGlobalHotkeyPlugin
    {
        // Name and Id of Plugin
        String PluginName { get; }

        // Execution
        void Execute();
    }
}