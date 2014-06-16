using Microsoft.QualityTools.Testing.Fakes;
using nhammerl.WindowOrganizer.Internal;
using NSubstitute;
using System.Drawing;
using System.Windows.Forms.Fakes;
using Xunit.Extensions;

namespace WindowOrganizer.Tests.Internal
{
    public class SplitActiveWindowToHalfBottomOnCurrentScreenTests
    {
        [Theory]
        [InlineData(0, 0, 10, 10)]
        [InlineData(10, 10, 15, 8)]
        [InlineData(20, 20, 485, 695)]
        [InlineData(5697, 1358, 1254, 569)]
        public void Now_CallsMoveWindowWithScreenWorkingAreaXAndYPlusHalfWorkingHeightWorkingHeightAndHalfWorkingheight(
            int workingX,
            int workingY,
            int workingWidth,
            int workingHeight)
        {
            using (ShimsContext.Create())
            {
                // Arrange
                var screen = Substitute.For<IScreen>();
                var moveWindow = Substitute.For<IMoveWindow>();
                var halfWorkingHeight = workingHeight / 2;

                var screenShim = new ShimScreen
                {
                    WorkingAreaGet = () => new Rectangle(workingX, workingY, workingWidth, workingHeight)
                };
                screen.Value.Returns(screenShim);

                var sut = new SplitActiveWindowToHalfBottomOnCurrentScreen(screen, moveWindow);

                // Act
                sut.Now();

                // Assert
                moveWindow.Received(1).To(workingX, workingY + halfWorkingHeight, workingWidth, halfWorkingHeight);
            }
        }
    }
}