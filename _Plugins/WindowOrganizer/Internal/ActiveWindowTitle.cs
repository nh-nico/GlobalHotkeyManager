using System;
using System.Runtime.InteropServices;
using System.Text;

namespace nhammerl.WindowOrganizer.Internal
{
    public class ActiveWindowTitle : IWindowTitle
    {
        private readonly IActiveWindow _activeWindow;

        public ActiveWindowTitle(IActiveWindow activeWindow)
        {
            if (activeWindow == null) { throw new ArgumentNullException("activeWindow"); }

            _activeWindow = activeWindow;
        }

        public string Value
        {
            get
            {
                const int nChars = 256;
                var buff = new StringBuilder(nChars);

                if (GetWindowText(_activeWindow.Value, buff, nChars) > 0)
                {
                    return buff.ToString();
                }
                return null;
            }
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
    }
}