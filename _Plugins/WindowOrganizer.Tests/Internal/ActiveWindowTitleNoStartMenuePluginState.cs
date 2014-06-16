using nhammerl.WindowOrganizer.Internal;
using NSubstitute;
using Xunit;
using Xunit.Extensions;

namespace WindowOrganizer.Tests.Internal
{
    public class ActiveWindowTitleNoStartMenuePluginState
    {
        [Theory]
        [InlineData("MyWindow")]
        [InlineData("WindowWhatever..?!")]
        public void State_WindowTitleEqualsNotStartmenü_ReturnsTrue(string title)
        {
            // Arrange
            var windowTitle = Substitute.For<IWindowTitle>();
            windowTitle.Value.Returns(title);

            var sut = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);

            // Act
            var result = sut.State;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void State_WindowTitleEqualsNull_ReturnsFalse()
        {
            // Arrange
            var windowTitle = Substitute.For<IWindowTitle>();
            windowTitle.Value.Returns(x => null);

            var sut = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);

            // Act
            var result = sut.State;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void State_WindowTitleEqualsStartmenü_ReturnsFalse()
        {
            // Arrange
            var windowTitle = Substitute.For<IWindowTitle>();
            windowTitle.Value.Returns("Startmenü");

            var sut = new ActiveWindowTitleNotStartMenuePluginState(windowTitle);

            // Act
            var result = sut.State;

            // Assert
            Assert.False(result);
        }
    }
}