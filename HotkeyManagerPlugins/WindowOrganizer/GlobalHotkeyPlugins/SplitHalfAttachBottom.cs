using nhammerl.WindowOrganizer.ExecutionMains;
using nhammerl.WindowOrganizer.Internal;
using nhammerlGlobalHotkeyPluginLib;

namespace nhammerl.WindowOrganizer.GlobalHotkeyPlugins
{
    public class SplitHalfAttachBottom : IGlobalHotkeyPlugin
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
            IScreens screens = new AllActiveScreens();
            IWindowRectangle windowRectangle = new ActiveWindowRectangle(activeWindow);
            IWindowScreenInfos windowScreenInfos = new ActiveWindowScreenInfos(screens, windowRectangle);
            IScreenHeight screenHeight = new PrimaryScreenDependentScreenHeight();
            IWindowPositionMover positionMover = new HalfBottomActiveWindowPositionMover(activeWindow, windowScreenInfos, screenHeight);
            IWindowTitle windowTitle = new ActiveWindowTitle(activeWindow);
            IPluginState pluginState = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);
            IExecutionMain executionMain = new MoveActiveWindowPositionExecutionMain(positionMover, pluginState);

            executionMain.Run();
        }
    }
}