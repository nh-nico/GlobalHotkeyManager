using System;
using System.Runtime.InteropServices;
using System.Text;

namespace nhammerl.WindowOrganizer.Internal
{
    /// <summary>
    /// Window title for current active window.
    /// </summary>
    public class ActiveWindowTitle : IWindowTitle
    {
        private readonly IWindowHandle _windowHandle;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="windowHandle"></param>
        public ActiveWindowTitle(IWindowHandle windowHandle)
        {
            if (windowHandle == null) { throw new ArgumentNullException("windowHandle"); }

            _windowHandle = windowHandle;
        }

        /// <summary>
        /// Title of active window.
        /// </summary>
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