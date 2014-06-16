using nhammerl.WindowOrganizer.ExecutionMains;
using nhammerl.WindowOrganizer.Internal;
using nhammerlGlobalHotkeyPluginLib;

namespace nhammerl.WindowOrganizer.GlobalHotkeyPlugins
{
    /// <summary>
    /// Resize the active window to 1024 x 768 pixel and attach it on top left.
    /// </summary>
    public class ResizeActiveWindowTo1024X768OnTopLeft : IGlobalHotkeyPlugin
    {
        /// <summary>
        /// Name of plugin for the hotkeymanager.
        /// </summary>
        public string PluginName
        {
            get { return "Resize window to 1024 X 768 on top left of current screen"; }
        }

        /// <summary>
        /// Build IExecutionMain and start logic.
        /// </summary>
        public void Execute()
        {
            IWindowHandle windowHandle = new LastActiveWindowHandle();
            IScreen screen = new ActiveWindowDependendScreen(windowHandle);
            IMoveWindow moveWindow = new MoveActiveWindow(windowHandle);
            IChangeWindowPosition position = new ResizeActiveWindowTo1024X768OnTopLeftOfCurrentScreen(screen, moveWindow);
            IWindowTitle windowTitle = new ActiveWindowTitle(windowHandle);
            IPluginState pluginState = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);
            IExecutionMain executionMain = new MoveActiveWindowPositionExecutionMain(position, pluginState);

            executionMain.Run();
        }
    }
}