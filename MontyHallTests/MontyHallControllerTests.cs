using System;
using System.IO;
using MontyHallKata.Controllers;
using MontyHallKata.Models;
using MontyHallKata.Models.Randomizer;
using Moq;
using Xunit;

namespace MontyHallTests
{
    public class MontyHallControllerTests
    {
        private readonly Controller _controller;
        private readonly CustomRandomizer _randomizer;

        public MontyHallControllerTests()
        {
            _controller = new Controller();
            _randomizer = new CustomRandomizer();
        }
        
        [Fact]
        public void GivenAMontyHallController_WhenPlayIsCalled_ThenTheUserShouldBeGivenTheOptionToQuitByInputtingZero()
        {
            // Arrange
            var stringReader = new StringReader("0\n");
            var stringWriter = new StringWriter();
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
        
            const string expectedOutput = "You have quit the game.\n";
        
            // Act
            _controller.Play(_randomizer);
        
            // Assert
            Assert.Contains(expectedOutput, stringWriter.ToString());
        }
        
        [Fact]
        public void GivenAMontyHallController_WhenPlayIsCalled_ThenShouldDisplayTheThreeDoorsToSelectFrom()
        {
            // Arrange
            var stringReader = new StringReader("0\n");
            var stringWriter = new StringWriter();
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
        
            const string expectedOutput = "#Door 1#\t#Closed#\n" +
                                          "#Door 2#\t#Closed#\n" +
                                          "#Door 3#\t#Closed#\n";
            
            // Act
            _controller.Play(_randomizer);
        
            // Assert
            Assert.Contains(expectedOutput, stringWriter.ToString());
        }
        
        [Fact]
        public void GivenTheDoorsArePrinted_WhenTheUserIsPromptedToSelectADoor_ThenTheUserSelectionShouldBeDisplayedInTheOutput()
        {
            // Arrange
            var stringReader = new StringReader("1\n0\n");
            var stringWriter = new StringWriter();
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
        
            const string expectedOutcome = "#Door 1#\t#Selected#"; 
            
            // Act
            _controller.Play(_randomizer);
            
            // Assert
            Assert.Contains(expectedOutcome, stringWriter.ToString());
        }
        
        [Fact]
        public void GivenTheDoorsArePrinted_WhenTheUserHasSelectedADoor_ThenOneOfTheRemainingDoorsShouldOpenAndShouldBeDisplayedInTheOutput()
        {
            // Arrange
            var stringReader = new StringReader("1\n0\n");
            var stringWriter = new StringWriter();
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
            
            var mockRandomizer = new Mock<IRandomizer>();
            mockRandomizer.Setup(randomizer => randomizer.GetRandomizedArray(It.IsAny<Door[]>()))
                .Returns(() => new[]
                {
                    DoorsFactory.CreateLosingDoor(), DoorsFactory.CreateWinningDoor(), DoorsFactory.CreateLosingDoor()
                });
        
            const string expectedOutcome = "#Door 3#\t#Open#"; 
            
            // Act
            _controller.Play(mockRandomizer.Object);
            
            // Assert
            Assert.Contains(expectedOutcome, stringWriter.ToString());
        }
        
        [Fact]
        public void GivenTheUserHasSelectedADoor_WhenOneOfTheRemainingDoorsOpens_ThenTheUserShouldBeAbleToSwitchOrStayWithTheirInitialSelection()
        {
            // Arrange
            var stringReader = new StringReader("1\n2\n0\n");
            var stringWriter = new StringWriter();
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
            
            var mockRandomizer = new Mock<IRandomizer>();
            mockRandomizer.Setup(randomizer => randomizer.GetRandomizedArray(It.IsAny<Door[]>()))
                .Returns(() => new[]
                {
                    DoorsFactory.CreateLosingDoor(), DoorsFactory.CreateWinningDoor(), DoorsFactory.CreateLosingDoor()
                });
        
            const string expectedPromptOutput = "Would you like to switch or stay with you selection?:";
            const string expectedDoorsOutput = "#Door 1#\t#Closed#\n" +
                                               "#Door 2#\t#Selected#\n" +
                                               "#Door 3#\t#Open#\n"; 
            
            // Act
            _controller.Play(mockRandomizer.Object);
            
            // Assert
            Assert.Contains(expectedPromptOutput, stringWriter.ToString());
            Assert.Contains(expectedDoorsOutput, stringWriter.ToString());
        }
        
        // [Fact]
        // public void GivenOneOfTheRemainingDoorsHasOpened_WhenTheUserHasMadeTheirChoice_ThenTheResultOfTheGameShouldBeRevealed()
        // {
        //     // Arrange
        //     var stringReader = new StringReader("1\n2\n");
        //     var stringWriter = new StringWriter();
        //     Console.SetIn(stringReader);
        //     Console.SetOut(stringWriter);
        //     
        //     var mockRandomizer = new Mock<IRandomizer>();
        //     mockRandomizer.Setup(randomizer => randomizer.GetRandomizedArray(It.IsAny<Door[]>()))
        //         .Returns(() => new[]
        //         {
        //             DoorsFactory.CreateLosingDoor(), DoorsFactory.CreateWinningDoor(), DoorsFactory.CreateLosingDoor()
        //         });
        //
        //     const string expectedResult = "You have won the game!";
        //     
        //     // Act
        //     _montyHallView.Play(mockRandomizer.Object);
        //     
        //     // Assert
        //     Assert.Contains(expectedResult, stringWriter.ToString());
        // }
    }
}