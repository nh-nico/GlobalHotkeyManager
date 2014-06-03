using Microsoft.QualityTools.Testing.Fakes;
using nhammerl.WindowOrganizer.Internal;
using System.Drawing;
using System.Windows.Forms.Fakes;
using Xunit;

namespace WindowOrganizer.Tests.Internal
{
    public class PrimaryScreenDependentScreenHeightTests
    {
        [Fact]
        public void ForScreen_ReturnsPrimaryScreenWorkingAreaHeightMinusInputScreenHeight()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                var primaryScreen = new ShimScreen { WorkingAreaGet = () => new Rectangle(100, 100, 100, 100) };
                ShimScreen.PrimaryScreenGet = () => primaryScreen;
                var currentScreen = new ShimScreen { WorkingAreaGet = () => new Rectangle(20, 20, 20, 20) };

                var sut = new PrimaryScreenDependentScreenHeight();
                // Act
                var result = sut.ForScreen(currentScreen);

                // Assert
                Assert.Equal(80, result);
            }
        }
    }
}