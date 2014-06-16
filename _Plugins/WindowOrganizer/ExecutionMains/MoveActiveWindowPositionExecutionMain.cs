using nhammerl.WindowOrganizer.Internal;
using System;

namespace nhammerl.WindowOrganizer.ExecutionMains
{
    /// <summary>
    /// Move current active window to other changePosition.
    /// </summary>
    public class MoveActiveWindowPositionExecutionMain : IExecutionMain
    {
        private readonly IChangeWindowPosition _changePosition;
        private readonly IPluginState _pluginState;

        /// <summary>
        /// Construcotr of the class.
        /// </summary>
        /// <param name="changePosition"></param>
        /// <param name="pluginState"></param>
        public MoveActiveWindowPositionExecutionMain(IChangeWindowPosition changePosition, IPluginState pluginState)
        {
            if (changePosition == null) { throw new ArgumentNullException("changePosition"); }
            if (pluginState == null) { throw new ArgumentNullException("pluginState"); }

            _changePosition = changePosition;
            _pluginState = pluginState;
        }

        /// <summary>
        /// Dependend on IChangeWindowPosition, move the active window.
        /// </summary>
        public void Run()
        {
            if (_pluginState.State)
            {
                _changePosition.Now();
            }
        }
    }
}