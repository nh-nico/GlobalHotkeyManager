using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer.Internal
{
    public class ResizeActiveWindowTo1024X768 : IWindowPositionMover
    {
        private readonly IActiveWindow _activeWindow;
        private readonly IWindowScreenInfos _windowScreenInfos;
        private readonly IScreenHeight _screenHeight;

        public ResizeActiveWindowTo1024X768(IActiveWindow activeWindow, IWindowScreenInfos windowScreenInfos, IScreenHeight screenHeight)
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
                _screenHeight.ForScreen(currentScreen),
                1024,
                768,
                true);
        }

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool repaint);
    }
}