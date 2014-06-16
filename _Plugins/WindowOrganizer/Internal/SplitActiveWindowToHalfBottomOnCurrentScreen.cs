using System;

namespace nhammerl.WindowOrganizer.Internal
{
    /// <summary>
    /// Split the current active window half and attach it on bottom of current screen
    /// </summary>
    public class SplitActiveWindowToHalfBottomOnCurrentScreen : IChangeWindowPosition
    {
        private readonly IScreen _screen;
        private readonly IMoveWindow _moveWindow;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="screen">screen for action</param>
        /// <param name="moveWindow">moves window to other position</param>
        public SplitActiveWindowToHalfBottomOnCurrentScreen(IScreen screen, IMoveWindow moveWindow)
        {
            if (screen == null) throw new ArgumentNullException("screen");
            if (moveWindow == null) throw new ArgumentNullException("moveWindow");

            _screen = screen;
            _moveWindow = moveWindow;
        }

        /// <summary>
        /// Split the current active window half and attach it on bottom of current screen
        /// </summary>
        public void Now()
        {
            var currentWorkingArea = _screen.Value.WorkingArea;
            var halfHeightWorkingArea = currentWorkingArea.Height / 2;

            _moveWindow.To(currentWorkingArea.X, currentWorkingArea.Y + halfHeightWorkingArea, currentWorkingArea.Width, halfHeightWorkingArea);
        }
    }
}