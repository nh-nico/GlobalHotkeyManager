using nhammerl.WindowOrganizer.Internal;
using NSubstitute;
using Xunit;
using Xunit.Extensions;

namespace WindowOrganizer.Tests.Internal
{
    public class ActiveWindowTitleNotStartmenuePluginStateTests
    {
        [Fact]
        public void State_WindowTitleEqualsStartMenü_ReturnsFalse()
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

        [Theory,
         InlineData("StartDings"),
         InlineData("Wurzelbrumf"),
         InlineData("Foo"),
         InlineData("bar")]
        public void State_WindowTitleNotEqualsStartMenü_ReturnsTrue(string title)
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
    }
}