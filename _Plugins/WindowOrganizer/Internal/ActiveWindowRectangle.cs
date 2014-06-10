using System;
using System.Runtime.InteropServices;

namespace nhammerl.WindowOrganizer.Internal
{
    public class ActiveWindowRectangle : IWindowRectangle
    {
        private readonly IActiveWindow _activeWindow;

        public ActiveWindowRectangle(IActiveWindow activeWindow)
        {
            if (activeWindow == null) { throw new ArgumentNullException("activeWindow"); }

            _activeWindow = activeWindow;
        }

        public WindowRectangle Value
        {
            get
            {
                WindowRectangle rect;
                var success = GetWindowRect(_activeWindow.Value, out rect);

                if (!success)
                {
                    throw new ExternalException("Could not create Rectangle for active window");
                }

                return rect;
            }
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out WindowRectangle lpWindowRectangle);
    }
}