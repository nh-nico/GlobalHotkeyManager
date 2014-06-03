using Microsoft.QualityTools.Testing.Fakes;
using nhammerl.WindowOrganizer.Internal;
using System.Windows.Forms;
using System.Windows.Forms.Fakes;
using Xunit;

namespace WindowOrganizer.Tests.Internal
{
    public class AllActiveScreensTests
    {
        [Fact]
        public void List_ReturnsAllScreensFromWindowsFormsScreen()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                var screen1 = new ShimScreen();
                var screen2 = new ShimScreen();
                var screen3 = new ShimScreen();

                var screens = new Screen[] { screen1, screen2, screen3 };

                ShimScreen.AllScreensGet = () => screens;

                var sut = new AllActiveScreens();
                // Act
                var result = sut.List;

                // Assert
                Assert.Equal(screens, result);
            }
        }
    }
}