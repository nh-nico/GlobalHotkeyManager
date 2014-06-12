using System;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer.Internal
{
    public class ActiveWindowDependendScreen : IScreen
    {
        private readonly IWindowHandle _windowHandle;

        public ActiveWindowDependendScreen(IWindowHandle windowHandle)
        {
            if (windowHandle == null) throw new ArgumentNullException("windowHandle");

            _windowHandle = windowHandle;
        }

        public Screen Value
        {
            get { return Screen.FromHandle(_windowHandle.Value); }
        }
    }
}