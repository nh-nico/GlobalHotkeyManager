using System;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer.Internal
{
    public class ActiveWindowDependendScreen : IScreen
    {
        private readonly IActiveWindow _activeWindow;

        public ActiveWindowDependendScreen(IActiveWindow activeWindow)
        {
            if (activeWindow == null) throw new ArgumentNullException("activeWindow");

            _activeWindow = activeWindow;
        }

        public Screen Value
        {
            get { return Screen.FromHandle(_activeWindow.Value); }
        }
    }
}