using nhammerl.WindowOrganizer.ExecutionMains;
using nhammerl.WindowOrganizer.Internal;
using nhammerlGlobalHotkeyPluginLib;

namespace nhammerl.WindowOrganizer.GlobalHotkeyPlugins
{
    public class SplitActiveWindowHalfAttachTop : IGlobalHotkeyPlugin
    {
        public string PluginName
        {
            get { return "Split Active Window half and Attach on Top"; }
        }

        public void Execute()
        {
            IActiveWindow activeWindow = new EnvironmentActiveWindow();
            IScreen screen = new ActiveWindowDependendScreen(activeWindow);
            IMoveWindow moveWindow = new MoveActiveWindow(activeWindow);
            IChangeWindowPosition position = new SplitActiveWindowToHalfTopOnCurrentScreen(screen, moveWindow);
            IWindowTitle windowTitle = new ActiveWindowTitle(activeWindow);
            IPluginState pluginState = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);
            IExecutionMain executionMain = new MoveActiveWindowPositionExecutionMain(position, pluginState);

            executionMain.Run();
        }
    }
}