using nhammerl.WindowOrganizer.ExecutionMains;
using nhammerl.WindowOrganizer.Internal;
using nhammerlGlobalHotkeyPluginLib;

namespace nhammerl.WindowOrganizer.GlobalHotkeyPlugins
{
    public class ResizeActiveWindowTo1027X768 : IGlobalHotkeyPlugin
    {
        public string PluginName
        {
            get { return "Resize Window to 1024 X 768"; }
        }

        public void Execute()
        {
            IActiveWindow activeWindow = new EnvironmentActiveWindow();
            IScreens screens = new AllActiveScreens();
            IWindowRectangle windowRectangle = new ActiveWindowRectangle(activeWindow);
            IWindowScreenInfos windowScreenInfos = new ActiveWindowScreenInfos(screens, windowRectangle);
            IWindowPositionMover positionMover = new ResizeActiveWindowTo1024X768(activeWindow, windowScreenInfos);
            IWindowTitle windowTitle = new ActiveWindowTitle(activeWindow);
            IPluginState pluginState = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);
            IExecutionMain executionMain = new MoveActiveWindowPositionExecutionMain(positionMover, pluginState);

            executionMain.Run();
        }
    }
}