﻿using nhammerl.WindowOrganizer.ExecutionMains;
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
            IWindowPositionMover positionMover = new HalfTopActiveWindowPositionMover(activeWindow, windowScreenInfos);
            IWindowTitle windowTitle = new ActiveWindowTitle(activeWindow);
            IPluginState pluginState = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);
            IExecutionMain executionMain = new MoveActiveWindowPositionExecutionMain(positionMover, pluginState);

            executionMain.Run();
        }
    }
}