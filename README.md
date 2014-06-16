## Global Hotkey Manager ##

**Global HotKey Manager** was developed to easily execute own code on global registered hotkeys.


My main reason why i developed this was the need to split my windows in horizontal half and attach it to the top or bottom of the screen where the window is currently active.
So that´s are the first features (plugins) of this manager.


----------


*Application runs in Background.*

![](https://cloud.githubusercontent.com/assets/2332468/3293951/a6014f0a-f5a1-11e3-91a8-6da97783a72b.png)


*Configure hotkeys.*

![](https://cloud.githubusercontent.com/assets/2332468/3293950/a600e1dc-f5a1-11e3-9b2a-cce8aa62e7d2.png)


----------

### Build your own plugins ###

*Simply use this interface:*

    /// <summary>
    /// Interface used from hotkeymanager to detect Plugins
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
    /// Throw a test message.
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
        /// Execute TestMessageThrower.
        /// </summary>
        public void Execute()
        {
            MessageBox.Show("Hello World!");
        }
    }

All classes in an assembly wich implement this interface, will be reconiced from the global hotkey manager with the ability to attach it to an hotkey.

The DLL has to be in the "Plugin" directory of the output.
![](https://cloud.githubusercontent.com/assets/2332468/3294124/8a2cc5b8-f5a4-11e3-9292-22c38a0ffcca.PNG)




> This project is in development and will be further developed sporadically.

----------
