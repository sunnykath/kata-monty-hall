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
    }
}