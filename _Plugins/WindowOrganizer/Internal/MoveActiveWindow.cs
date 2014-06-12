using System;
using System.Runtime.InteropServices;

namespace nhammerl.WindowOrganizer.Internal
{
    public class MoveActiveWindow : IMoveWindow
    {
        private readonly IActiveWindow _activeWindow;

        public MoveActiveWindow(IActiveWindow activeWindow)
        {
            if (activeWindow == null) throw new ArgumentNullException("activeWindow");

            _activeWindow = activeWindow;
        }

        public void To(int x, int y, int with, int height)
        {
            MoveWindow(_activeWindow.Value, x, y, with, height, true);
        }

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool repaint);
    }
}