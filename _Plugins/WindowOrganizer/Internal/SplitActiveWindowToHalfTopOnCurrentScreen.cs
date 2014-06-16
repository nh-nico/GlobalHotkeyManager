using System;

namespace nhammerl.WindowOrganizer.Internal
{
    /// <summary>
    /// Split active window half and attach it on top of current screen
    /// </summary>
    public class SplitActiveWindowToHalfTopOnCurrentScreen : IChangeWindowPosition
    {
        private readonly IScreen _screen;
        private readonly IMoveWindow _moveWindow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="moveWindow"></param>
        public SplitActiveWindowToHalfTopOnCurrentScreen(IScreen screen, IMoveWindow moveWindow)
        {
            if (screen == null) throw new ArgumentNullException("screen");
            if (moveWindow == null) throw new ArgumentNullException("moveWindow");

            _screen = screen;
            _moveWindow = moveWindow;
        }

        /// <summary>
        /// Split active window half and attach it on top of current screen
        /// </summary>
        public void Now()
        {
            var currentWorkingArea = _screen.Value.WorkingArea;
            var halfWorkingHeight = currentWorkingArea.Height / 2;

            _moveWindow.To(currentWorkingArea.X, currentWorkingArea.Y, currentWorkingArea.Width, halfWorkingHeight);
        }
    }
}