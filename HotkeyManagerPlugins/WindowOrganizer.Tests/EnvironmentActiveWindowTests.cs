using nhammerl.WindowOrganizer.Internal;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Xunit;

namespace WindowOrganizer.Tests
{
    public class EnvironmentActiveWindowTests
    {
        [Fact]
        public void Value_IsNotNull()
        {
            // Arrange

            var sut = new EnvironmentActiveWindow();
            // Act
            var result = sut.Value;

            // Assert
            Assert.IsAssignableFrom<IActiveWindow>(sut);
            Assert.NotNull(result);
        }
    }
}