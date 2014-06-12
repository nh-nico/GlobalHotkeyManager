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
<<<<<<< HEAD:HotkeyManagerPlugins/WindowOrganizer/GlobalHotkeyPlugins/SplitHalfAttachBottom.cs
            IScreens screens = new AllActiveScreens();
            IWindowRectangle windowRectangle = new ActiveWindowRectangle(activeWindow);
            IWindowScreenInfos windowScreenInfos = new ActiveWindowScreenInfos(screens, windowRectangle);
            IWindowPositionMover positionMover = new HalfBottomActiveWindowPositionMover(activeWindow, windowScreenInfos);
=======
            IScreen screen = new ActiveWindowDependendScreen(activeWindow);
            IMoveWindow moveWindow = new MoveActiveWindow(activeWindow);
            IChangeWindowPosition position = new SplitActiveWindowToHalfBottomOnCurrentScreen(screen, moveWindow);
>>>>>>> 7f0500458c789a7b81bd97e4daa621ad3266f28f:_Plugins/WindowOrganizer/GlobalHotkeyPlugins/SplitActiveWindowHalfAttachBottom.cs
            IWindowTitle windowTitle = new ActiveWindowTitle(activeWindow);
            IPluginState pluginState = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);
            IExecutionMain executionMain = new MoveActiveWindowPositionExecutionMain(position, pluginState);

            executionMain.Run();
        }
    }
}