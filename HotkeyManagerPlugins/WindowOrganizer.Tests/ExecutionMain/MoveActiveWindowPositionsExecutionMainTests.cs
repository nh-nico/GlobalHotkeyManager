using nhammerl.WindowOrganizer.ExecutionMains;
using nhammerl.WindowOrganizer.Internal;
using NSubstitute;
using Xunit;

namespace WindowOrganizer.Tests.ExecutionMain
{
    public class MoveActiveWindowPositionsExecutionMainTests
    {
        [Fact]
        public void Run_CallsPositionMoverOnce()
        {
            // Arrange
            var windowPositionMover = Substitute.For<IWindowPositionMover>();

            var sut = new MoveActiveWindowPositionExecutionMain(windowPositionMover);

            // Act
            sut.Run();

            // Assert
            windowPositionMover.Received(1).Now();
        }
    }
}