using System;

namespace nhammerl.WindowOrganizer.Internal
{
    public class ResizeActiveWindowTo1024X768OnTopLeftOfCurrentScreen : IChangeWindowPosition
    {
        private readonly IScreen _screen;
        private readonly IMoveWindow _moveWindow;

        public ResizeActiveWindowTo1024X768OnTopLeftOfCurrentScreen(IScreen screen, IMoveWindow moveWindow)
        {
            if (screen == null) throw new ArgumentNullException("screen");
            if (moveWindow == null) throw new ArgumentNullException("moveWindow");

            _screen = screen;
            _moveWindow = moveWindow;
        }

        public void Now()
        {
            var currentScreen = _screen.Value;

            _moveWindow.To(currentScreen.WorkingArea.X, currentScreen.WorkingArea.Y, 1024, 768);
        }
    }
}