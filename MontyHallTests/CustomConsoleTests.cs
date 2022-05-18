using Castle.Core.Internal;
using MontyHallKata.Views;
using Xunit;

namespace MontyHallTests
{
    public class CustomConsoleTests
    {
        [Fact]
        public void GivenACustomConsole_WhenGetInputStringIsCalled_ShouldReturnAString()
        {
            // Arrange
            var customConsole = new CustomConsole();
            
            // Act
            var inputString = customConsole.GetInputString();
            
            // Assert
            Assert.IsType<string>(inputString);
        }
        
        [Fact]
        public void GivenACustomConsole_WhenGetInputStringIsCalled_ShouldReturnANonNullOrEmptyString()
        {
            // Arrange
            var customConsole = new CustomConsole();
            
            // Act
            var inputString = customConsole.GetInputString();
            
            // Assert
            Assert.False(inputString.IsNullOrEmpty());
        }
    }
}