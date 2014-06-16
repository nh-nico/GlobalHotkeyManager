using nhammerl.WindowOrganizer.ExecutionMains;
using nhammerl.WindowOrganizer.Internal;
using nhammerlGlobalHotkeyPluginLib;

namespace nhammerl.WindowOrganizer.GlobalHotkeyPlugins
{
    /// <summary>
    /// Split the active window half and attach it on top.
    /// </summary>
    public class SplitActiveWindowHalfAttachTop : IGlobalHotkeyPlugin
    {
        /// <summary>
        /// Name of plugin for the hotkeymanager.
        /// </summary>
        public string PluginName
        {
            get { return "Split active window half and attach on top"; }
        }

        /// <summary>
        /// Build IExecutionMain and start the logic.
        /// </summary>
        public void Execute()
        {
            IWindowHandle windowHandle = new LastActiveWindowHandle();
            IScreen screen = new ActiveWindowDependendScreen(windowHandle);
            IMoveWindow moveWindow = new MoveActiveWindow(windowHandle);
            IChangeWindowPosition position = new SplitActiveWindowToHalfTopOnCurrentScreen(screen, moveWindow);
            IWindowTitle windowTitle = new ActiveWindowTitle(windowHandle);
            IPluginState pluginState = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);
            IExecutionMain executionMain = new MoveActiveWindowPositionExecutionMain(position, pluginState);

            executionMain.Run();
        }
    }
}