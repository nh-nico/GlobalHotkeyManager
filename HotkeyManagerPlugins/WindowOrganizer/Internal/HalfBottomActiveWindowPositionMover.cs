using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer.Internal
{
    public class HalfBottomActiveWindowPositionMover : IWindowPositionMover
    {
        private readonly IActiveWindow _activeWindow;
        private readonly IWindowScreenInfos _windowScreenInfos;
        private readonly IScreenHeight _screenHeight;

        public HalfBottomActiveWindowPositionMover(IActiveWindow activeWindow, IWindowScreenInfos windowScreenInfos, IScreenHeight screenHeight)
        {
            if (activeWindow == null) { throw new ArgumentNullException("activeWindow"); }
            if (windowScreenInfos == null) { throw new ArgumentNullException("windowScreenInfos"); }
            if (screenHeight == null) { throw new ArgumentNullException("screenHeight"); }

            _activeWindow = activeWindow;
            _windowScreenInfos = windowScreenInfos;
            _screenHeight = screenHeight;
        }

        public void Now()
        {
            int currentScreenTopLeft;
            Screen currentScreen;
            _windowScreenInfos.GetInfos(out currentScreenTopLeft, out currentScreen);

            MoveWindow(
                _activeWindow.Value,
                currentScreenTopLeft,
                _screenHeight.ForScreen(currentScreen) + (currentScreen.WorkingArea.Height / 2),
                currentScreen.WorkingArea.Width,
                currentScreen.WorkingArea.Height / 2,
                true);
        }

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool repaint);
    }
}