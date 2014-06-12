using System;
using System.Runtime.InteropServices;

namespace nhammerl.WindowOrganizer.Internal
{
    /// <summary>
    /// Represents the last active window
    /// </summary>
    public class LastActiveWindowHandle : IWindowHandle
    {
        /// <summary>
        /// Extracts the last active window handle with helf of user32.dll (GetForegroundWindow)
        /// </summary>
        public IntPtr Value
        {
            get
            {
                return GetForegroundWindow();
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
    }
}