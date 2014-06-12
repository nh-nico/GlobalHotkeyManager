using System;

namespace nhammerl.WindowOrganizer.Internal
{
    /// <summary>
    /// Resize last active window to 1024 x 768 pixel and attach on top left of current screen.
    /// </summary>
    public class ResizeActiveWindowTo1024X768OnTopLeftOfCurrentScreen : IChangeWindowPosition
    {
        private readonly IScreen _screen;
        private readonly IMoveWindow _moveWindow;

        /// <summary>
        /// Constructor of class.
        /// </summary>
        /// <param name="screen">Active window dependend screen</param>
        /// <param name="moveWindow">Move active window to specified position</param>
        public ResizeActiveWindowTo1024X768OnTopLeftOfCurrentScreen(IScreen screen, IMoveWindow moveWindow)
        {
            if (screen == null) throw new ArgumentNullException("screen");
            if (moveWindow == null) throw new ArgumentNullException("moveWindow");

            _screen = screen;
            _moveWindow = moveWindow;
        }

        /// <summary>
        /// Execute logic.
        /// </summary>
        public void Now()
        {
            var currentScreen = _screen.Value;

            _moveWindow.To(currentScreen.WorkingArea.X, currentScreen.WorkingArea.Y, 1024, 768);
        }
    }
}