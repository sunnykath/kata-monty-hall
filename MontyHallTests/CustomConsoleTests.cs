using System;
using System.IO;
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
        
        [Fact]
        public void GivenACustomConsole_WhenGetInputStringIsCalled_ShouldReturnWhatWasInputtedInTheConsole()
        {
            // Arrange
            const string expectedInputString = "Hello World"; 
            var stringReader = new StringReader(expectedInputString);
            Console.SetIn(stringReader);
            
            var customConsole = new CustomConsole();
            
            // Act
            var actualInputString = customConsole.GetInputString();
            
            // Assert
            Assert.Equal(expectedInputString, actualInputString);
        }
    }
}