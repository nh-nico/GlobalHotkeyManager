using nhammerl.WindowOrganizer.Internal;

namespace nhammerl.WindowOrganizer.ExecutionMains
{
    public class MoveActiveWindowPositionExecutionMain : IExecutionMain
    {
        private readonly IWindowPositionMover _positionMover;

        public MoveActiveWindowPositionExecutionMain(IWindowPositionMover positionMover)
        {
            _positionMover = positionMover;
        }

        public void Run()
        {
            _positionMover.Now();
        }
    }
}