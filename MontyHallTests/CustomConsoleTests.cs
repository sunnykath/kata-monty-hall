using MontyHallKata.Views;
using Xunit;

namespace MontyHallTests
{
    public class CustomConsoleTests
    {
        [Fact]
        public void GivenAConsole_WhenGetInputStringIsCalled_ShouldReturnAString()
        {
            // Arrange
            var customConsole = new CustomConsole();
            
            // Act
            var inputString = customConsole.GetInputString();
            
            // Assert
            Assert.IsType<string>(inputString);
        }
    }
}