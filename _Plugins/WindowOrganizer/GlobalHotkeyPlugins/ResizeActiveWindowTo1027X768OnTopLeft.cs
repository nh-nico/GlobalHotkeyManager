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
            IScreen screen = new ActiveWindowDependendScreen(activeWindow);
            IMoveWindow moveWindow = new MoveActiveWindow(activeWindow);
            IChangeWindowPosition position = new ResizeActiveWindowTo1024X768OnTopLeftOfCurrentScreen(screen, moveWindow);
            IWindowTitle windowTitle = new ActiveWindowTitle(activeWindow);
            IPluginState pluginState = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);
            IExecutionMain executionMain = new MoveActiveWindowPositionExecutionMain(position, pluginState);

            executionMain.Run();
        }
    }
}