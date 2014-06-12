using nhammerl.WindowOrganizer.Internal;
using System;

namespace nhammerl.WindowOrganizer.ExecutionMains
{
    /// <summary>
    /// Move current active window to other position
    /// </summary>
    public class MoveActiveWindowPositionExecutionMain : IExecutionMain
    {
        private readonly IChangeWindowPosition _position;
        private readonly IPluginState _pluginState;

        public MoveActiveWindowPositionExecutionMain(IChangeWindowPosition position, IPluginState pluginState)
        {
            if (position == null) { throw new ArgumentNullException("position"); }
            if (pluginState == null) { throw new ArgumentNullException("pluginState"); }

            _position = position;
            _pluginState = pluginState;
        }

        /// <summary>
        /// Dependend on IChangeWindowPosition, move the active window.
        /// </summary>
        public void Run()
        {
            if (_pluginState.State)
            {
                _position.Now();
            }
        }
    }
}