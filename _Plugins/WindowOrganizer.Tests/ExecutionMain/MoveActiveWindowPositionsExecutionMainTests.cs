using nhammerl.WindowOrganizer.ExecutionMains;
using nhammerl.WindowOrganizer.Internal;
using NSubstitute;
using Xunit;

namespace WindowOrganizer.Tests.ExecutionMain
{
    public class MoveActiveWindowPositionsExecutionMainTests
    {
        [Fact]
        public void Run_PluginStateTrue_CallsPositionMoverOnce()
        {
            // Arrange
            var windowPositionMover = Substitute.For<IChangeWindowPosition>();
            var pluginState = Substitute.For<IPluginState>();
            pluginState.State.Returns(true);

            var sut = new MoveActiveWindowPositionExecutionMain(windowPositionMover, pluginState);

            // Act
            sut.Run();

            // Assert
            windowPositionMover.Received(1).Now();
        }

        [Fact]
        public void Run_PluginStateFalse_NotCallsPositionMover()
        {
            // Arrange
            var windowPositionMover = Substitute.For<IChangeWindowPosition>();
            var pluginState = Substitute.For<IPluginState>();
            pluginState.State.Returns(false);

            var sut = new MoveActiveWindowPositionExecutionMain(windowPositionMover, pluginState);

            // Act
            sut.Run();

            // Assert
            windowPositionMover.Received(0).Now();
        }
    }
}