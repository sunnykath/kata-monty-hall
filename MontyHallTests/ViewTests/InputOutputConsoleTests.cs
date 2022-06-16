using System;
using System.IO;
using MontyHallKata.Views.InputOutput;
using Xunit;

namespace MontyHallTests.ViewTests
{
    public class CustomConsoleTests
    {
        [Fact]
        public void GivenGetIntInputIsCalled_WhenTheInputIsNullOrEmpty_ThenShouldKeepAskingForANonEmptyInput()
        {
            // Arrange
            const int expectedInput = 1234; 
            var stringReader = new StringReader($"\n\n{expectedInput}");
            Console.SetIn(stringReader);
            
            var customConsole = new InputOutputConsole();
            
            // Act
            var actualInputString = customConsole.GetIntInput();
            
            // Assert
            Assert.Equal(expectedInput, actualInputString);
        }
        
        [Fact]
        public void GivenACustomConsole_WhenGetIntInputIsCalled_ThenShouldReturnTheIntThatWasInputtedInTheConsole()
        {
            // Arrange
            const int expectedInputInt = 1234;
            var stringReader = new StringReader($"{expectedInputInt}");
            Console.SetIn(stringReader);
            
            var customConsole = new InputOutputConsole();
            
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
            
            var customConsole = new InputOutputConsole();
            
            // Act
            var actualInputString = customConsole.GetIntInput();
            
            // Assert
            Assert.Equal(expectedInputInt, actualInputString);
        }
        
        [Fact]
        public void GivenACustomConsole_WhenPrintOutputIsCalled_ThenShouldPrintTheOutputToTheConsole()
        {
            // Arrange
            const string expectedOutput = "Hello World From A Custom Console\n";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var customConsole = new InputOutputConsole();
            
            // Act
            customConsole.PrintOutput(expectedOutput);
            
            // Assert
            Assert.Equal(expectedOutput, stringWriter.ToString());
        }
    }
}