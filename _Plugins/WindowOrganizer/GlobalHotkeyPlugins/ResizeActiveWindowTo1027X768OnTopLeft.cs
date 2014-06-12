using nhammerl.WindowOrganizer.ExecutionMains;
using nhammerl.WindowOrganizer.Internal;
using nhammerlGlobalHotkeyPluginLib;

namespace nhammerl.WindowOrganizer.GlobalHotkeyPlugins
{
    public class ResizeActiveWindowTo1027X768OnTopLeft : IGlobalHotkeyPlugin
    {
        public string PluginName
        {
            get { return "Resize Window to 1024 X 768 on Top Left of Current Screen"; }
        }

        public void Execute()
        {
            IActiveWindow activeWindow = new EnvironmentActiveWindow();
<<<<<<< HEAD:HotkeyManagerPlugins/WindowOrganizer/GlobalHotkeyPlugins/ResizeActiveWindowTo1027X768.cs
            IScreens screens = new AllActiveScreens();
            IWindowRectangle windowRectangle = new ActiveWindowRectangle(activeWindow);
            IWindowScreenInfos windowScreenInfos = new ActiveWindowScreenInfos(screens, windowRectangle);
            IWindowPositionMover positionMover = new ResizeActiveWindowTo1024X768(activeWindow, windowScreenInfos);
=======
            IScreen screen = new ActiveWindowDependendScreen(activeWindow);
            IMoveWindow moveWindow = new MoveActiveWindow(activeWindow);
            IChangeWindowPosition position = new ResizeActiveWindowTo1024X768OnTopLeftOfCurrentScreen(screen, moveWindow);
>>>>>>> 7f0500458c789a7b81bd97e4daa621ad3266f28f:_Plugins/WindowOrganizer/GlobalHotkeyPlugins/ResizeActiveWindowTo1027X768OnTopLeft.cs
            IWindowTitle windowTitle = new ActiveWindowTitle(activeWindow);
            IPluginState pluginState = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);
            IExecutionMain executionMain = new MoveActiveWindowPositionExecutionMain(position, pluginState);

            executionMain.Run();
        }
    }
}