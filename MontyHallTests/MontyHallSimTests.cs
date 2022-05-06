using System;
using System.Linq;
using MontyHallKata;
using Xunit;

namespace MontyHallTests
{
    public class MontyHallSimTests
    {
        private readonly MontyHallSimulation _simulation;
        public MontyHallSimTests()
        {
            _simulation = new MontyHallSimulation();
        }
        
        [Fact]
        public void GivenASimulation_WhenCreated_ThenThreeDoorsAreCreated()
        {
            // Arrange
            const int expectedDoors = 3;
            
            // Act
            var doors = _simulation.RandomlyOrderedDoors;

            // Assert
            Assert.Equal(expectedDoors, doors.Count);
        }
        
        [Fact]
        public void GivenASimulation_WhenThreeDoorsAreCreated_ThenThereIsExactlyOneCarDoor()
        {
            // Act
            var doors = _simulation.RandomlyOrderedDoors;
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
            _simulation.SetSelectedDoor(doorToSelected);
            var selectedDoor = _simulation.RandomlyOrderedDoors[doorToSelected];
            
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
            _simulation.SetSelectedDoor(doorSelection);
            _simulation.OpenAnUnselectedGoatDoor();
            var actualOpenedDoors = _simulation.RandomlyOrderedDoors.Where(door => door.IsOpen).ToList();
            
            // Assert
            Assert.Equal(expectedOpenedDoors, actualOpenedDoors.Count);
            Assert.Equal(typeof(GoatDoor), actualOpenedDoors.First().GetType());
        }
        
        [Fact]
        public void GivenTheUserHasNOTSelectedADoor_WhenTheUserTriesToOpenAnUnselectedGoatDoor_ThenThrowException()
        {
            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _simulation.OpenAnUnselectedGoatDoor());
            Assert.Contains("Please select a door first", exception.Message);
        }
        
        [Fact]
        public void GivenTheUserHasOpenedAnUnselectedGoatDoor_WhenTheUserDecidesToSwitch_ThenTheSelectedDoorWillBeChangedToTheUnselectedClosedDoor()
        {
            // Arrange
            const int doorSelectionIndex = 1;
            _simulation.SetSelectedDoor(doorSelectionIndex);
            _simulation.OpenAnUnselectedGoatDoor();
            
            // Act
            _simulation.SwitchDoorSelection();
            var doorBeforeSwitch = _simulation.RandomlyOrderedDoors[doorSelectionIndex];
            var doorAfterSwitch = _simulation.GetSelectedDoor();
            
            // Assert
            Assert.NotEqual(doorBeforeSwitch, doorAfterSwitch);
            Assert.False(doorAfterSwitch.IsOpen);
        }
        
        [Fact]
        public void GivenTheUserHasOpenedAnUnselectedGoatDoor_WhenTheUserDecidesToStay_TheyShouldBeAbleToRevealTheResult()
        {
            // Arrange
            const int doorSelectionIndex = 1;
            _simulation.SetSelectedDoor(doorSelectionIndex);
            _simulation.OpenAnUnselectedGoatDoor();
            
            // Act
            var hasWonGame = _simulation.HasWonGame();
            var finialDoorSelection = _simulation.GetSelectedDoor();
            var expectedGameResult = (typeof(CarDoor) == finialDoorSelection.GetType());
            
            // Assert
            Assert.Equal(expectedGameResult, hasWonGame);
        }
    }
}
