using nhammerl.WindowOrganizer.Internal;
using NSubstitute;
using System.Runtime.InteropServices;
using Xunit;

namespace WindowOrganizer.Tests
{
    public class GetActiveWindowRectangleTests
    {
        [Fact]
        public void Vale_ExternalMethodsReturnsTrue_ReturnsRect()
        {
            // Arrange
            var activeWindow = new EnvironmentActiveWindow();

            var sut = new ActiveWindowRectangle(activeWindow);
            // Act

            var result = sut.Value;

            // Assert
            Assert.IsType<WindowRectangle>(result);
            Assert.IsAssignableFrom<IWindowRectangle>(sut);
        }

        [Fact]
        public void Vale_ExternalMethodsReturnsFalse_ThrowsExternalExceptionError()
        {
            // Arrange
            var activeWindow = Substitute.For<IActiveWindow>();

            var sut = new ActiveWindowRectangle(activeWindow);

            // Act
            // Assert
            Assert.Throws<ExternalException>(() => sut.Value);
        }
    }
}