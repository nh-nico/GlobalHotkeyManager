using nhammerl.WindowOrganizer.Internal;
using System;

namespace nhammerl.WindowOrganizer.ExecutionMains
{
    public class MoveActiveWindowPositionExecutionMain : IExecutionMain
    {
        private readonly IWindowPositionMover _positionMover;
        private readonly IPluginState _pluginState;

        public MoveActiveWindowPositionExecutionMain(IWindowPositionMover positionMover, IPluginState pluginState)
        {
            if (positionMover == null) { throw new ArgumentNullException("positionMover"); }
            if (pluginState == null) { throw new ArgumentNullException("pluginState"); }

            _positionMover = positionMover;
            _pluginState = pluginState;
        }

        public void Run()
        {
            if (_pluginState.State)
            {
                _positionMover.Now();
            }
        }
    }
}