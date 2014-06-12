using System;
using System.Runtime.InteropServices;

namespace nhammerl.WindowOrganizer.Internal
{
    public class MoveActiveWindow : IMoveWindow
    {
        private readonly IWindowHandle _windowHandle;

        public MoveActiveWindow(IWindowHandle windowHandle)
        {
            if (windowHandle == null) throw new ArgumentNullException("windowHandle");

            _windowHandle = windowHandle;
        }

        public void To(int x, int y, int with, int height)
        {
            MoveWindow(_windowHandle.Value, x, y, with, height, true);
        }

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool repaint);
    }
}