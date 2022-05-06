using System;
using System.Linq;
using MontyHallKata;
using Xunit;

namespace MontyHallTests
{
    public class MontyHallSimTests
    {
        private readonly MontyHallGame _game;
        public MontyHallSimTests()
        {
            _game = new MontyHallGame();
        }
        
        [Fact]
        public void GivenASimulation_WhenCreated_ThenThreeDoorsAreCreated()
        {
            // Arrange
            const int expectedDoors = 3;
            
            // Act
            var doors = _game.RandomlyOrderedDoors;

            // Assert
            Assert.Equal(expectedDoors, doors.Count);
        }
        
        [Fact]
        public void GivenASimulation_WhenThreeDoorsAreCreated_ThenThereIsExactlyOneCarDoor()
        {
            // Act
            var doors = _game.RandomlyOrderedDoors;
            var carDoors = doors.Where(door => door.GetType() == typeof(CarDoor));

            // Assert
            Assert.Single(carDoors);
        }
        
        [Fact]
        public void GivenASimulation_WhenThreeDoorsAreCreated_ThenTheUserShouldBeAbleToSelectOne()
        {
            // Arrange
            const int doorToSelected = 1;
            
            // Act
            _game.SetSelectedDoor(doorToSelected);
            var selectedDoor = _game.RandomlyOrderedDoors[doorToSelected];
            
            // Assert
            Assert.True(selectedDoor.IsSelected);
        }
        
        [Fact]
        public void GivenASimulation_WhenTheUserHasSelectedADoor_ThenTheUserShouldBeAbleToOpenAnUnselectedGoatDoor()
        {
            // Arrange
            const int doorSelection = 1;
            var expectedOpenedDoors = 1;
            
            // Act
            _game.SetSelectedDoor(doorSelection);
            _game.OpenAnUnselectedGoatDoor();
            var actualOpenedDoors = _game.RandomlyOrderedDoors.Where(door => door.IsOpen).ToList();
            
            // Assert
            Assert.Equal(expectedOpenedDoors, actualOpenedDoors.Count);
            Assert.Equal(typeof(GoatDoor), actualOpenedDoors.First().GetType());
        }
        
        [Fact]
        public void GivenTheUserHasNOTSelectedADoor_WhenTheUserTriesToOpenAnUnselectedGoatDoor_ThenThrowException()
        {
            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _game.OpenAnUnselectedGoatDoor());
            Assert.Contains("Please select a door first", exception.Message);
        }
        
        [Fact]
        public void GivenTheUserHasOpenedAnUnselectedGoatDoor_WhenTheUserDecidesToSwitch_ThenTheSelectedDoorWillBeChangedToTheUnselectedClosedDoor()
        {
            // Arrange
            const int doorSelectionIndex = 1;
            _game.SetSelectedDoor(doorSelectionIndex);
            _game.OpenAnUnselectedGoatDoor();
            
            // Act
            _game.SwitchDoorSelection();
            var doorBeforeSwitch = _game.RandomlyOrderedDoors[doorSelectionIndex];
            var doorAfterSwitch = _game.GetSelectedDoor();
            
            // Assert
            Assert.NotEqual(doorBeforeSwitch, doorAfterSwitch);
            Assert.False(doorAfterSwitch.IsOpen);
        }
        
        [Fact]
        public void GivenTheUserHasOpenedAnUnselectedGoatDoor_WhenTheUserDecidesToStay_TheyShouldBeAbleToRevealTheResult()
        {
            // Arrange
            const int doorSelectionIndex = 1;
            _game.SetSelectedDoor(doorSelectionIndex);
            _game.OpenAnUnselectedGoatDoor();
            
            // Act
            var hasWonGame = _game.HasWonGame();
            var finialDoorSelection = _game.GetSelectedDoor();
            var expectedGameResult = (typeof(CarDoor) == finialDoorSelection.GetType());
            
            // Assert
            Assert.Equal(expectedGameResult, hasWonGame);
        }
    }
}
