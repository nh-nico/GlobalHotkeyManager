using nhammerl.WindowOrganizer.ExecutionMains;
using nhammerl.WindowOrganizer.Internal;
using nhammerlGlobalHotkeyPluginLib;

namespace nhammerl.WindowOrganizer.GlobalHotkeyPlugins
{
    public class SplitActiveWindowHalfAttachToBottom : IGlobalHotkeyPlugin
    {
        public string PluginName
        {
            get
            {
                return "Split Active Window half and Attach on Bottom";
            }
        }

        public void Execute()
        {
            IActiveWindow activeWindow = new EnvironmentActiveWindow();
            IScreen screen = new ActiveWindowDependendScreen(activeWindow);
            IMoveWindow moveWindow = new MoveActiveWindow(activeWindow);
            IChangeWindowPosition position = new SplitActiveWindowToHalfBottomOnCurrentScreen(screen, moveWindow);
            IWindowTitle windowTitle = new ActiveWindowTitle(activeWindow);
            IPluginState pluginState = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);
            IExecutionMain executionMain = new MoveActiveWindowPositionExecutionMain(position, pluginState);

            executionMain.Run();
        }
    }
}