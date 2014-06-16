using System;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer.Internal
{
    /// <summary>
    /// Screen where the currently active window is on.
    /// </summary>
    public class ActiveWindowDependendScreen : IScreen
    {
        private readonly IWindowHandle _windowHandle;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="windowHandle"></param>
        public ActiveWindowDependendScreen(IWindowHandle windowHandle)
        {
            if (windowHandle == null) throw new ArgumentNullException("windowHandle");

            _windowHandle = windowHandle;
        }

        /// <summary>
        /// Screen from active window handle.
        /// </summary>
        public Screen Value
        {
            get { return Screen.FromHandle(_windowHandle.Value); }
        }
    }
}