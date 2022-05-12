using System;
using System.Linq;
using MontyHallKata;
using MontyHallKata.Controllers;
using MontyHallKata.Models;
using MontyHallKata.Models.Randomizer;
using Moq;
using Xunit;

namespace MontyHallTests
{
    public class MontyHallGameTests
    {
        private readonly MontyHallGame _game;
        public MontyHallGameTests()
        {
            var shuffler = new CustomRandomizer();
            _game = new MontyHallGame(shuffler);
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
            var winningDoors = doors.Where(door => door.IsWinningDoor);

            // Assert
            Assert.Single(winningDoors);
        }

        [Fact]
        public void GivenASimulation_WhenThreeDoorsAreCreated_ThenTheyAreShuffledUsingTheShuffler()
        {
            // Arrange
            var expectedShuffledDoors = new[] { DoorsFactory.CreateLosingDoor(), DoorsFactory.CreateWinningDoor(), DoorsFactory.CreateLosingDoor() };
            var mockShuffler = new Mock<IRandomizer>();
            mockShuffler.Setup(shuffle => shuffle.GetRandomizedArray(It.IsAny<Door[]>()))
                .Returns(expectedShuffledDoors);
            var game = new MontyHallGame(mockShuffler.Object);
            
            // Act
            var actualShuffledDoors = game.RandomlyOrderedDoors;

            // Assert
            // mockShuffler.Verify();
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
            Assert.True(DoorsFactory.IsDoorSelected(selectedDoor));
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
            var actualOpenedDoors = _game.RandomlyOrderedDoors.Where(DoorsFactory.IsDoorOpen).ToList();
            
            // Assert
            Assert.Equal(expectedOpenedDoors, actualOpenedDoors.Count);
            Assert.False(actualOpenedDoors.First().IsWinningDoor);
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
            Assert.False(DoorsFactory.IsDoorOpen(doorAfterSwitch));
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
            var expectedGameResult = finialDoorSelection.IsWinningDoor;
            
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
            var expectedGameResult = finialDoorSelection.IsWinningDoor;
            
            // Assert
            Assert.Equal(expectedGameResult, hasWonGame);
        }
    }
}
