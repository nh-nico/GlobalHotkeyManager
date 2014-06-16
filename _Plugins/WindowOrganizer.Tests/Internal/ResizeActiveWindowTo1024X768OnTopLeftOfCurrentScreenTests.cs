using Microsoft.QualityTools.Testing.Fakes;
using nhammerl.WindowOrganizer.Internal;
using NSubstitute;
using System.Drawing;
using System.Windows.Forms.Fakes;
using Xunit.Extensions;

namespace WindowOrganizer.Tests.Internal
{
    public class ResizeActiveWindowTo1024X768OnTopLeftOfCurrentScreenTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        [InlineData(20, 20)]
        [InlineData(5697, 1358)]
        public void Now_CallsMoveWindowWithScreenWorkingAreaXAndYWith1024AndHeight768(int workingX, int workingY)
        {
            using (ShimsContext.Create())
            {
                // Arrange
                var screen = Substitute.For<IScreen>();
                var moveWindow = Substitute.For<IMoveWindow>();

                var screenShim = new ShimScreen
                {
                    WorkingAreaGet = () => new Rectangle(workingX, workingY, 100, 100)
                };

                screen.Value.Returns(screenShim);

                var sut = new ResizeActiveWindowTo1024X768OnTopLeftOfCurrentScreen(screen, moveWindow);

                // Act
                sut.Now();

                // Assert
                moveWindow.Received(1).To(workingX, workingY, 1024, 768);
            }
        }
    }
}