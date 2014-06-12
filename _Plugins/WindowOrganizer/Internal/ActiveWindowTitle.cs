using System;
using System.Runtime.InteropServices;
using System.Text;

namespace nhammerl.WindowOrganizer.Internal
{
    public class ActiveWindowTitle : IWindowTitle
    {
        private readonly IWindowHandle _windowHandle;

        public ActiveWindowTitle(IWindowHandle windowHandle)
        {
            if (windowHandle == null) { throw new ArgumentNullException("windowHandle"); }

            _windowHandle = windowHandle;
        }

        public string Value
        {
            get
            {
                const int nChars = 256;
                var buff = new StringBuilder(nChars);

                if (GetWindowText(_windowHandle.Value, buff, nChars) > 0)
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