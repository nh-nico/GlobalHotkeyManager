using nhammerl.WindowOrganizer.ExecutionMains;
using nhammerl.WindowOrganizer.Internal;
using nhammerlGlobalHotkeyPluginLib;

namespace nhammerl.WindowOrganizer.GlobalHotkeyPlugins
{
    public class SplitHalfAttachTop : IGlobalHotkeyPlugin
    {
        public string PluginName
        {
            get { return "Split Active Window half and Attach on Top"; }
        }

        public void Execute()
        {
            IActiveWindow activeWindow = new EnvironmentActiveWindow();
            IScreens screens = new AllActiveScreens();
            IWindowRectangle windowRectangle = new ActiveWindowRectangle(activeWindow);
            IWindowScreenInfos windowScreenInfos = new ActiveWindowScreenInfos(screens, windowRectangle);
            IScreenHeight screenHeight = new PrimaryScreenDependentScreenHeight();
            IWindowPositionMover positionMover = new HalfTopActiveWindowPositionMover(activeWindow, windowScreenInfos, screenHeight);
            IExecutionMain executionMain = new MoveActiveWindowPositionExecutionMain(positionMover);

            executionMain.Run();
        }
    }
}