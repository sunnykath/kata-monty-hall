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
        public void GivenACustomConsole_WhenGetStringInputIsCalled_ThenShouldReturnWhatWasInputtedInTheConsole()
        {
            // Arrange
            const string expectedInputString = "Hello World"; 
            var stringReader = new StringReader(expectedInputString);
            Console.SetIn(stringReader);
            
            var customConsole = new CustomConsole();
            
            // Act
            var actualInputString = customConsole.GetStringInput();
            
            // Assert
            Assert.Equal(expectedInputString, actualInputString);
        }
        
        [Fact]
        public void GivenGetStringInputIsCalled_WhenTheInputIsNullOrEmpty_ThenShouldKeepAskingForANonEmptyInput()
        {
            // Arrange
            const string expectedInputString = "Hello World"; 
            var stringReader = new StringReader($"\n\n{expectedInputString}");
            Console.SetIn(stringReader);
            
            var customConsole = new CustomConsole();
            
            // Act
            var actualInputString = customConsole.GetStringInput();
            
            // Assert
            Assert.Equal(expectedInputString, actualInputString);
        }
        
        [Fact]
        public void GivenACustomConsole_WhenGetIntInputIsCalled_ThenShouldReturnTheIntThatWasInputtedInTheConsole()
        {
            // Arrange
            const int expectedInputInt = 1234;
            var stringReader = new StringReader($"{expectedInputInt}");
            Console.SetIn(stringReader);
            
            var customConsole = new CustomConsole();
            
            // Act
            var actualInputString = customConsole.GetIntInput();
            
            // Assert
            Assert.Equal(expectedInputInt, actualInputString);
        }
        
        [Fact]
        public void GivenGetIntInputIsCalled_WhenTheInputIsNotAnInt_ThenShouldKeepAskingForAIntInput()
        {
            // Arrange
            const int expectedInputInt = 1234;
            var stringReader = new StringReader($"hello\nR34D\n{expectedInputInt}");
            Console.SetIn(stringReader);
            
            var customConsole = new CustomConsole();
            
            // Act
            var actualInputString = customConsole.GetIntInput();
            
            // Assert
            Assert.Equal(expectedInputInt, actualInputString);
        }
    }
}