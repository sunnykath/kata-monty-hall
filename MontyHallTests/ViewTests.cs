using MontyHallKata.Models.Entity;
using MontyHallKata.Views;
using MontyHallKata.Views.Console;
using Moq;
using Xunit;

namespace MontyHallTests
{
    public class ViewTests
    {
        private readonly Mock<IConsole> _mockedConsole;
        private readonly View _view;
        public ViewTests()
        {
            _mockedConsole = new Mock<IConsole>();
            _view = new View(_mockedConsole.Object);
        }
        
        [Theory]
        [InlineData(GameStatus.Won, IOMessages.WinningOutputMessage)]
        [InlineData(GameStatus.Lost, IOMessages.LosingOutputMessage)]
        public void GivenTheGameWonBooleanIsPassedIn_WhenTheValueChanges_ThenTheOutputMessageShouldChangeAccordingly(GameStatus gameStatus, string expectedOutputMessage)
        {
            // Arrange 
            _mockedConsole.Setup(console => console.PrintOutput(expectedOutputMessage));
            // Act 
            _view.HandleOutputMessage(gameStatus);
            
            // Assert
            _mockedConsole.Verify();
        }

        [Fact]
        public void GivenTheMontyHallView_WhenGetUserChoiceIsCalled_TheUserShouldBePromptedWithTheChoiceToStaySwitchOrQuitAndTheChoiceShouldBeReturned()
        {
            // Arrange
            const int expectedChoice = 1;
            _mockedConsole.Setup(console => console.GetIntInput())
                .Returns(expectedChoice);
            _mockedConsole.Setup(console => console.PrintOutput(IOMessages.ChoicePromptMessage))
                .Verifiable();
            
            // Act 
            var userChoice = _view.GetUserChoice();
            
            // Assert
            _mockedConsole.Verify();
            Assert.Equal(expectedChoice, userChoice);
        }

        [Fact]
        public void GivenTheMontyHallView_WhenGetDoorSelectionIsCalled_TheUserShouldBePromptedToSelectADoorAndTheChoiceShouldBeReturned()
        {
            // Arrange
            const int expectedDoorSelection = 2;
            _mockedConsole.Setup(console => console.GetIntInput())
                .Returns(expectedDoorSelection);
            _mockedConsole.Setup(console => console.PrintOutput(IOMessages.DoorSelectionPrompt))
                .Verifiable();
            
            // Act 
            var doorSelection = _view.GetDoorSelectionFromUser();
            
            // Assert
            _mockedConsole.Verify();
            Assert.Equal(expectedDoorSelection, doorSelection);
        }

        [Fact]
        public void GivenTheMontyHallView_WhenOutputQuitMessageIsCalled_ThenTheCorrectQuitMessageShouldBeOutputted()
        {
            // Arrange
            _mockedConsole.Setup(console => console.PrintOutput(IOMessages.QuitOutputMessage))
                .Verifiable();
            
            // Act 
            _view.HandleOutputMessage(GameStatus.Quit);
            
            // Assert
            _mockedConsole.Verify();
        }

        [Fact]
        public void GivenTheMontyHallView_WhenTheDoorsArePrinted_ThenTheDoorsShouldBePrintedCorrectlyWithTheirStatus()
        {
            // Arrange
            var selectedDoor = new Door
            {
                IsSelected = true,
                IsOpen = false
            };
            var openDoor = new Door
            {
                IsSelected = false,
                IsOpen = true
            };
            var closedDoor = new Door
            {
                IsOpen = false,
                IsSelected = false
            };

            var doors = new[] {closedDoor, selectedDoor, openDoor};
            
            const string expectedDoorsOutput = "#Door 1#\t#Closed#\n" +
                                                "#Door 2#\t#Selected#\n" +
                                                "#Door 3#\t#Open#\n";
            
            _mockedConsole.Setup(console => console.PrintOutput(expectedDoorsOutput))
                .Verifiable();
            
            // Act 
            _view.PrintDoors(doors);
            
            // Assert
            _mockedConsole.Verify();
        }
        
        [Fact]
        public void GivenGetDoorSelectionIsCalled_WhenTheUerInputsAnInvalidSelection_ThenShouldPrintInvalidInputMessageAndAskForInputAgain()
        {
            // Arrange
            const int invalidDoorSelection = 5;
            const int quitCommand = 0;
            
            _mockedConsole.SetupSequence(c => c.GetIntInput())
                .Returns(invalidDoorSelection)
                .Returns(quitCommand);
            _mockedConsole.Setup(console => console.PrintOutput(IOMessages.InvalidInputMessage))
                .Verifiable();
            
            // Act
            _view.GetDoorSelectionFromUser();
            
            // Assert
            _mockedConsole.Verify();
        }
    }
}