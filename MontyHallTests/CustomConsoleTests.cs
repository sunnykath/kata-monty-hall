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
        public void GivenACustomConsole_WhenGetInputStringIsCalled_ThenShouldReturnAString()
        {
            // Arrange
            var customConsole = new CustomConsole();
            
            // Act
            var inputString = customConsole.GetInputString();
            
            // Assert
            Assert.IsType<string>(inputString);
        }
        
        [Fact]
        public void GivenACustomConsole_WhenGetInputStringIsCalled_ThenShouldReturnANonNullOrEmptyString()
        {
            // Arrange
            var customConsole = new CustomConsole();
            
            // Act
            var inputString = customConsole.GetInputString();
            
            // Assert
            Assert.False(inputString.IsNullOrEmpty());
        }
        
        [Fact]
        public void GivenACustomConsole_WhenGetInputStringIsCalled_ThenShouldReturnWhatWasInputtedInTheConsole()
        {
            // Arrange
            const string expectedInputString = "Hello World\n"; 
            var stringReader = new StringReader(expectedInputString);
            Console.SetIn(stringReader);
            
            var customConsole = new CustomConsole();
            
            // Act
            var actualInputString = customConsole.GetInputString();
            
            // Assert
            Assert.Equal(expectedInputString, actualInputString);
        }
        
        [Fact]
        public void GivenGetInputStringIsCalled_WhenTheInputIsNullOrEmpty_ThenShouldKeepAskingForANonEmptyInput()
        {
            // Arrange
            const string expectedInputString = "Hello World"; 
            var stringReader = new StringReader($"\n\n{expectedInputString}");
            Console.SetIn(stringReader);
            
            var customConsole = new CustomConsole();
            
            // Act
            var actualInputString = customConsole.GetInputString();
            
            // Assert
            Assert.Equal(expectedInputString, actualInputString);
        }
    }
}