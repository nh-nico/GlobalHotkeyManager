using System;
using System.Runtime.InteropServices;

namespace nhammerl.WindowOrganizer.Internal
{
    /// <summary>
    /// Moves window to new position.
    /// </summary>
    public class MoveActiveWindow : IMoveWindow
    {
        private readonly IWindowHandle _windowHandle;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="windowHandle"></param>
        public MoveActiveWindow(IWindowHandle windowHandle)
        {
            if (windowHandle == null) throw new ArgumentNullException("windowHandle");

            _windowHandle = windowHandle;
        }

        /// <summary>
        /// Position to move to.
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="with">With</param>
        /// <param name="height">Height</param>
        public void To(int x, int y, int with, int height)
        {
            MoveWindow(_windowHandle.Value, x, y, with, height, true);
        }

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool repaint);
    }
}