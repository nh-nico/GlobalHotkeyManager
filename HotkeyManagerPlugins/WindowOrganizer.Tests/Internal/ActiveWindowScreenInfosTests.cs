using Microsoft.QualityTools.Testing.Fakes;
using nhammerl.WindowOrganizer.Internal;
using NSubstitute;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Fakes;
using Xunit;

namespace WindowOrganizer.Tests.Internal
{
    public class ActiveWindowScreenInfosTests
    {
        [Fact]
        public void GetInfos_ActiveWindowOnFirstScreenReturnsZeroTopEdgeAndFirstCurrentScreen()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                var screens = Substitute.For<IScreens>();
                var windowRectangle = Substitute.For<IWindowRectangle>();

                windowRectangle.Value.Returns(new WindowRectangle
                {
                    xUpperLeft = 30,
                    yUpperLeft = 200,
                    xLowerRight = 60,
                    yLowerRight = 600
                });

                var screen1 = new ShimScreen { WorkingAreaGet = () => new Rectangle(100, 200, 300, 400) };
                var screen2 = new ShimScreen { WorkingAreaGet = () => new Rectangle(111, 222, 333, 444) };

                screens.List.Returns(new Screen[] { screen1, screen2 });

                var sut = new ActiveWindowScreenInfos(screens, windowRectangle);
                // Act
                int topLeft;
                Screen currentScreen;

                sut.GetInfos(out topLeft, out currentScreen);

                // Assert
                Assert.Equal(0, topLeft);
                Assert.Equal(screen1, currentScreen);
            }
        }

        [Fact]
        public void GetInfos_ActiveWindowOnSecondScreenReturnsFirstScreenResolutionWithAndSecondCurrentScreen()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                var screens = Substitute.For<IScreens>();
                var windowRectangle = Substitute.For<IWindowRectangle>();

                windowRectangle.Value.Returns(new WindowRectangle
                {
                    xUpperLeft = 350,
                    yUpperLeft = 200,
                    xLowerRight = 60,
                    yLowerRight = 600
                });

                var screen1 = new ShimScreen { WorkingAreaGet = () => new Rectangle(100, 200, 300, 400) };
                var screen2 = new ShimScreen { WorkingAreaGet = () => new Rectangle(111, 222, 333, 444) };

                screens.List.Returns(new Screen[] { screen1, screen2 });

                var sut = new ActiveWindowScreenInfos(screens, windowRectangle);
                // Act
                int topLeft;
                Screen currentScreen;

                sut.GetInfos(out topLeft, out currentScreen);

                // Assert
                Assert.Equal(300, topLeft);
                Assert.Equal(screen2, currentScreen);
            }
        }

        [Fact]
        public void GetInfos_ActiveWindowOnSecondScreenWithFirstPixelOfSecondScreenReturnsSecondScreenFirstPixelResolutionWithAndSecondCurrentScreen()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                var screens = Substitute.For<IScreens>();
                var windowRectangle = Substitute.For<IWindowRectangle>();

                windowRectangle.Value.Returns(new WindowRectangle
                {
                    xUpperLeft = 300,
                    yUpperLeft = 200,
                    xLowerRight = 60,
                    yLowerRight = 600
                });

                var screen1 = new ShimScreen { WorkingAreaGet = () => new Rectangle(100, 200, 300, 400) };
                var screen2 = new ShimScreen { WorkingAreaGet = () => new Rectangle(111, 222, 333, 444) };
                var screen3 = new ShimScreen { WorkingAreaGet = () => new Rectangle(123, 124, 456, 786) };

                screens.List.Returns(new Screen[] { screen1, screen2, screen3 });

                var sut = new ActiveWindowScreenInfos(screens, windowRectangle);
                // Act
                int topLeft;
                Screen currentScreen;

                sut.GetInfos(out topLeft, out currentScreen);

                // Assert
                Assert.Equal(300, topLeft);
                Assert.Equal(screen2, currentScreen);
            }
        }
    }
}