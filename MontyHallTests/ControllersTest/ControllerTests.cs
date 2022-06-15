using MontyHallKata.Controllers;
using MontyHallKata.Models;
using MontyHallKata.Models.Entity;
using MontyHallKata.Models.Randomizer;
using MontyHallKata.Views.Console;
using Moq;
using Xunit;

namespace MontyHallTests
{
    public class ControllerTests
    {
        private readonly Controller _controller;
        private readonly DefaultRandomizer _randomizer;
        private readonly Mock<IInputOutput> _mockedConsole;
        private readonly Mock<IRandomizer> _mockedRandomizer;

        public ControllerTests()
        {
            _mockedRandomizer = new Mock<IRandomizer>();
            _mockedConsole = new Mock<IInputOutput>();
            _controller = new Controller(_mockedConsole.Object);
            _randomizer = new DefaultRandomizer();
        }
        
        [Fact]
        public void GivenAMontyHallController_WhenPlayIsCalled_ThenTheUserShouldBeGivenTheOptionToQuitByInputtingZero()
        {
            // Arrange
            const string expectedOutput = InputOutputMessages.QuitOutputMessage;
            
            _mockedConsole.Setup(console => console.GetIntInput())
                .Returns(0);
            
            _mockedConsole.Setup(console => console.PrintOutput(expectedOutput))
                .Verifiable();

            // Act
            _controller.Play(_randomizer);
        
            // Assert
            _mockedConsole.Verify();
        }
        
        [Fact]
        public void GivenAMontyHallController_WhenPlayIsCalled_ThenShouldDisplayTheThreeDoorsToSelectFrom()
        {
            // Arrange
            const string expectedOutput = "#Door 1#\t#Closed#\n" +
                                          "#Door 2#\t#Closed#\n" +
                                          "#Door 3#\t#Closed#\n";
            _mockedConsole.Setup(console => console.GetIntInput())
                .Returns(0);
            
            _mockedConsole.Setup(console => console.PrintOutput(expectedOutput))
                .Verifiable();
            
            // Act
            _controller.Play(_randomizer);
        
            // Assert
            _mockedConsole.Verify();
        }
        
        [Fact]
        public void GivenTheDoorsArePrinted_WhenTheUserIsPromptedToSelectADoor_ThenTheUserSelectionShouldBeDisplayedInTheOutput()
        {
            // Arrange
            _mockedRandomizer.Setup(randomizer => randomizer.GetRandomizedArray(It.IsAny<Door[]>()))
                .Returns(() => new[]
                {
                    DoorsFactory.CreateLosingDoor(), DoorsFactory.CreateWinningDoor(), DoorsFactory.CreateLosingDoor()
                });
            
            const string expectedOutput = "#Door 1#\t#Selected#\n"+
                                          "#Door 2#\t#Closed#\n" +
                                          "#Door 3#\t#Open#\n"; 
            
            _mockedConsole.SetupSequence(console => console.GetIntInput())
                .Returns(1)
                .Returns(0);
            
            _mockedConsole.Setup(console => console.PrintOutput(expectedOutput))
                .Verifiable();
            
            // Act
            _controller.Play(_mockedRandomizer.Object);
            
            // Assert
            _mockedConsole.Verify();
        }
        
        [Fact]
        public void GivenTheDoorsArePrinted_WhenTheUserHasSelectedADoor_ThenOneOfTheRemainingDoorsShouldOpenAndShouldBeDisplayedInTheOutput()
        {
            // Arrange
            _mockedRandomizer.Setup(randomizer => randomizer.GetRandomizedArray(It.IsAny<Door[]>()))
                .Returns(() => new[]
                {
                    DoorsFactory.CreateLosingDoor(), DoorsFactory.CreateLosingDoor(), DoorsFactory.CreateWinningDoor()
                });
            
            const string expectedOutput = "#Door 1#\t#Selected#\n"+
                                          "#Door 2#\t#Open#\n" +
                                          "#Door 3#\t#Closed#\n"; 
            
            _mockedConsole.SetupSequence(console => console.GetIntInput())
                .Returns(1)
                .Returns(0);
            
            _mockedConsole.Setup(console => console.PrintOutput(expectedOutput))
                .Verifiable();
            
            
            // Act
            _controller.Play(_mockedRandomizer.Object);
            
            // Assert
            _mockedConsole.Verify();
        }
        
        [Fact]
        public void GivenTheUserHasSelectedADoor_WhenOneOfTheRemainingDoorsOpens_ThenTheUserShouldBeAbleToSwitchOrStayWithTheirInitialSelection()
        {
            // Arrange 
            const string expectedPromptOutput = InputOutputMessages.ChoicePromptMessage;
            const string expectedDoorsOutput = "#Door 1#\t#Closed#\n" +
                                               "#Door 2#\t#Selected#\n" +
                                               "#Door 3#\t#Open#\n"; 
            
            _mockedConsole.SetupSequence(console => console.GetIntInput())
                .Returns(1)
                .Returns(2);
            
            _mockedConsole.Setup(console => console.PrintOutput(expectedPromptOutput))
                .Verifiable();
            _mockedConsole.Setup(console => console.PrintOutput(expectedDoorsOutput))
                .Verifiable();
            
            _mockedRandomizer.Setup(randomizer => randomizer.GetRandomizedArray(It.IsAny<Door[]>()))
                .Returns(() => new[]
                {
                    DoorsFactory.CreateLosingDoor(), DoorsFactory.CreateWinningDoor(), DoorsFactory.CreateLosingDoor()
                });
        
            // Act
            _controller.Play(_mockedRandomizer.Object);
            
            // Assert
            _mockedConsole.Verify();
        }
        
        [Fact]
        public void GivenOneOfTheRemainingDoorsHasOpened_WhenTheUserHasMadeTheirChoice_ThenTheResultOfTheGameShouldBeRevealed()
        {
            // Arrange
            const string expectedResult = InputOutputMessages.WinningOutputMessage;
            
            _mockedRandomizer.Setup(randomizer => randomizer.GetRandomizedArray(It.IsAny<Door[]>()))
                .Returns(() => new[]
                {
                    DoorsFactory.CreateLosingDoor(), DoorsFactory.CreateWinningDoor(), DoorsFactory.CreateLosingDoor()
                });
            
            _mockedConsole.SetupSequence(console => console.GetIntInput())
                .Returns(1)
                .Returns(2);
            _mockedConsole.Setup(console => console.PrintOutput(expectedResult))
                .Verifiable();
        
            // Act
            _controller.Play(_mockedRandomizer.Object);
            
            // Assert
            _mockedConsole.Verify();
        }
    }
}