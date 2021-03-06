using System;
using System.Linq;
using MontyHallKata.Controllers;
using MontyHallKata.Models.Doors;
using MontyHallKata.Models.Randomizer;
using Moq;
using Xunit;

namespace MontyHallTests.ControllersTest
{
    public class GameplayTests
    {
        private readonly Gameplay _game;
        public GameplayTests()
        {
            var randomizer = new DefaultRandomizer();
            _game = new Gameplay(randomizer);
        }
        
        [Fact]
        public void GivenASimulation_WhenCreated_ThenThreeDoorsAreCreated()
        {
            // Arrange
            const int expectedDoors = 3;
            
            // Act
            var doors = _game.RandomlyOrderedDoors;

            // Assert
            Assert.Equal(expectedDoors, doors.Length);
        }
        
        [Fact]
        public void GivenASimulation_WhenThreeDoorsAreCreated_ThenThereIsExactlyOneWinningDoor()
        {
            // Act
            var doors = _game.RandomlyOrderedDoors;
            var winningDoors = doors.Where(door => door.IsWinningDoor());

            // Assert
            Assert.Single(winningDoors);
        }

        [Fact]
        public void GivenASimulation_WhenThreeDoorsAreCreated_ThenTheyAreShuffledUsingTheShuffler()
        {
            // Arrange
            var doorFactory = new DoorsFactory();
            var expectedShuffledDoors = new []{doorFactory.CreateWinningDoor(), doorFactory.CreateLosingDoor(), doorFactory.CreateLosingDoor()};
            var mockShuffler = new Mock<IRandomizer>();
            mockShuffler.Setup(shuffle => shuffle.GetRandomizedArray(It.IsAny<Door[]>()))
                .Returns(expectedShuffledDoors)
                .Verifiable();
            var game = new Gameplay(mockShuffler.Object);
            
            // Act
            var actualShuffledDoors = game.RandomlyOrderedDoors;

            // Assert
            mockShuffler.Verify();
            Assert.Equal(expectedShuffledDoors, actualShuffledDoors);
        }        
        
        [Fact]
        public void GivenASimulation_WhenThreeDoorsAreCreated_ThenTheUserShouldBeAbleToSelectOne()
        {
            // Arrange
            const int doorToBeSelected = 1;
            
            // Act
            _game.SetSelectedDoor(doorToBeSelected);
            var selectedDoor = _game.RandomlyOrderedDoors[doorToBeSelected];
            
            // Assert
            Assert.True(selectedDoor.IsDoorSelected());
        }
        
        [Fact]
        public void GivenASimulation_WhenTheUserHasSelectedADoor_ThenTheUserShouldBeAbleToOpenAnUnselectedLosingDoor()
        {
            // Arrange
            const int doorSelection = 1;
            var expectedOpenedDoors = 1;
            
            // Act
            _game.SetSelectedDoor(doorSelection);
            _game.OpenAnUnselectedLosingDoor();
            var actualOpenedDoors = _game.RandomlyOrderedDoors.Where(door => door.IsDoorOpen()).ToList();
            
            // Assert
            Assert.Equal(expectedOpenedDoors, actualOpenedDoors.Count);
            Assert.False(actualOpenedDoors.First().IsWinningDoor());
        }
        
        [Fact]
        public void GivenTheUserHasNOTSelectedADoor_WhenTheUserTriesToOpenAnUnselectedGoatDoor_ThenThrowException()
        {
            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _game.OpenAnUnselectedLosingDoor());
            Assert.Contains("Please select a door first", exception.Message);
        }
        
        [Fact]
        public void GivenTheUserHasOpenedAnUnselectedGoatDoor_WhenTheUserDecidesToSwitch_ThenTheSelectedDoorWillBeChangedToTheUnselectedClosedDoor()
        {
            // Arrange
            const int doorSelectionIndex = 1;
            _game.SetSelectedDoor(doorSelectionIndex);
            _game.OpenAnUnselectedLosingDoor();
            
            // Act
            _game.SwitchDoorSelection();
            var doorBeforeSwitch = _game.RandomlyOrderedDoors[doorSelectionIndex];
            var doorAfterSwitch = _game.GetSelectedDoor();
            
            // Assert
            Assert.NotEqual(doorBeforeSwitch, doorAfterSwitch);
            Assert.False(doorAfterSwitch.IsDoorOpen());
        }
        
        [Fact]
        public void GivenTheUserHasOpenedAnUnselectedGoatDoor_WhenTheUserDecidesToStay_TheyShouldBeAbleToCheckIfUserHasWonTheGame()
        {
            // Arrange
            const int doorSelectionIndex = 1;
            _game.SetSelectedDoor(doorSelectionIndex);
            _game.OpenAnUnselectedLosingDoor();
            
            // Act
            var hasWonGame = _game.HasWonGame();
            var finialDoorSelection = _game.GetSelectedDoor();
            var expectedGameResult = finialDoorSelection.IsWinningDoor();
            
            // Assert
            Assert.Equal(expectedGameResult, hasWonGame);
        }
        
        [Fact]
        public void GivenTheUserHasOpenedAnUnselectedGoatDoor_WhenTheUserHasDecidedToSwitch_TheyShouldBeAbleToRevealTheResult()
        {
            // Arrange
            const int doorSelectionIndex = 1;
            _game.SetSelectedDoor(doorSelectionIndex);
            _game.OpenAnUnselectedLosingDoor();
            _game.SwitchDoorSelection();
            
            // Act
            var hasWonGame = _game.HasWonGame();
            var finialDoorSelection = _game.GetSelectedDoor();
            var expectedGameResult = finialDoorSelection.IsWinningDoor();
            
            // Assert
            Assert.Equal(expectedGameResult, hasWonGame);
        }
    }
}
