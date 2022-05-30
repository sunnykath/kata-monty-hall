using System;
using System.IO;
using MontyHallKata.Models;
using MontyHallKata.Views;
using Xunit;

namespace MontyHallTests
{
    public class ViewTests
    {
        [Theory]
        [InlineData(true, Constants.WinningOutputMessage)]
        [InlineData(false, Constants.LosingOutputMessage)]
        public void GivenTheGameWonBooleanIsPassedIn_WhenTheValueChanges_ThenTheOutputMessageShouldChangeAccordingly(bool hasWonGame, string expectedOutputMessage)
        {
            // Arrange 
            var montyHallView = new MontyHallView();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            // Act 
            montyHallView.OutputFinalMessage(hasWonGame);
            
            // Assert
            Assert.Contains(expectedOutputMessage, stringWriter.ToString());
        }

        [Fact]
        public void GivenTheMontyHallView_WhenGetUserChoiceIsCalled_TheUserShouldBePromptedWithTheChoiceToStaySwitchOrQuitAndTheChoiceShouldBeReturned()
        {
            // Arrange
            const int expectedChoice = 1;
            var montyHallView = new MontyHallView();
            var stringReader = new StringReader($"{expectedChoice}\n");
            var stringWriter = new StringWriter();
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
            
            // Act 
            var userChoice = montyHallView.GetUserChoice();
            
            // Assert
            Assert.Contains(Constants.ChoicePromptMessage, stringWriter.ToString());
            Assert.Equal(expectedChoice, userChoice);
        }

        [Fact]
        public void GivenTheMontyHallView_WhenGetDoorSelectionIsCalled_TheUserShouldBePromptedToSelectADoorAndTheChoiceShouldBeReturned()
        {
            // Arrange
            const int expectedDoorSelection = 2;
            var montyHallView = new MontyHallView();
            var stringReader = new StringReader($"{expectedDoorSelection}\n");
            var stringWriter = new StringWriter();
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
            
            // Act 
            var doorSelection = montyHallView.GetDoorSelectionFromUser();
            
            // Assert
            Assert.Contains(Constants.DoorSelectionPrompt, stringWriter.ToString());
            Assert.Equal(expectedDoorSelection, doorSelection);
        }
    }
}