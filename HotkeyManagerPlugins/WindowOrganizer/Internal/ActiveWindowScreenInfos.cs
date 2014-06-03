using System;
using System.Linq;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer.Internal
{
    public class ActiveWindowScreenInfos : IWindowScreenInfos
    {
        private readonly IScreens _screens;
        private readonly IWindowRectangle _windowRectangle;

        public ActiveWindowScreenInfos(IScreens screens, IWindowRectangle windowRectangle)
        {
            if (screens == null) { throw new ArgumentNullException("screens"); }
            if (windowRectangle == null) { throw new ArgumentNullException("windowRectangle"); }

            _screens = screens;
            _windowRectangle = windowRectangle;
        }

        public void GetInfos(out int currentWindowTopLeftCorner, out Screen currentScreen)
        {
            currentWindowTopLeftCorner = 0;
            var currentScreenIndex = 0;
            foreach (var screen in _screens.List)
            {
                if (_windowRectangle.Value.Left > screen.WorkingArea.Width + currentWindowTopLeftCorner)
                {
                    currentWindowTopLeftCorner += screen.WorkingArea.Width;
                    currentScreenIndex++;
                }
            }
            currentScreen = _screens.List.ToArray()[currentScreenIndex];
        }
    }
}