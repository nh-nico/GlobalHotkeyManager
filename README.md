## Global Hotkey Manager ##

**Global HotKey Manager** is developed to easily execute own code on an global registered hotkey.
My main reason for developing this was the ability to split my windows in horizontal half and attach it to the top or bottom of the screen where the window is currently over.
So that are the first features (plugins) of this Manager.


----------

### Build your own plugins ###

*Simply use this interface:*

    /// <summary>
    /// Interface searched used from HotkeyManager for Plugins
    /// </summary>
    public interface IGlobalHotkeyPlugin
    {
        // Name of the plugin, shown in hotkeymanager
        String PluginName { get; }

        // Main execution of plugin.
        void Execute();
    }

*Example:*

    /// <summary>
    /// Throw a testmessage.
    /// </summary>
    public class TestMessageThrower : IGlobalHotkeyPlugin
    {
        /// <summary>
        /// Name of plugin for the hotkeymanager.
        /// </summary>
        public string PluginName
        {
            get { return "MessageThrower"; }
        }

        /// <summary>
        /// Throw a testmessage.
        /// </summary>
        public void Execute()
        {
            MessageBox.Show("Hello World!");
        }
    }

All classes in an DLL wich implement this interface, will be reconiced from the global hotkey manager with the ability to attach it to an hotkey.

The DLL has to be in the "Plugin" directory of the output.

----------