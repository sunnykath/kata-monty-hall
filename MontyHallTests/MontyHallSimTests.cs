using System;
using System.Linq;
using MontyHallKata;
using Xunit;

namespace MontyHallTests
{
    public class MontyHallSimTests
    {
        [Fact]
        public void GivenASimulation_WhenCreated_ThenThreeDoorsAreCreated()
        {
            // Arrange
            const int expectedDoors = 3;
            
            // Act
            var simulation = new MontyHallSimulation();
            var doors = simulation.RandomlyOrderedDoors;

            // Assert
            Assert.Equal(expectedDoors, doors.Count);
        }
        
        [Fact]
        public void GivenASimulation_WhenThreeDoorsAreCreated_ThenThereIsExactlyOneCarDoor()
        {
            // Arrange
            var simulation = new MontyHallSimulation();
            
            // Act
            var doors = simulation.RandomlyOrderedDoors;
            var carDoors = doors.Where(door => door.GetType() == typeof(CarDoor));

            // Assert
            Assert.Single(carDoors);
        }
        
        [Fact]
        public void GivenASimulation_WhenThreeDoorsAreCreated_ThenTheUserShouldBeAbleToSelectOne()
        {
            // Arrange
            var simulation = new MontyHallSimulation();
            const int doorToSelected = 1;
            
            // Act
            simulation.SelectDoor(doorToSelected);
            var selectedDoor = simulation.RandomlyOrderedDoors[doorToSelected];
            

            // Assert
            Assert.True(selectedDoor.IsSelected);
        }
        
        [Fact]
        public void GivenASimulation_WhenTheUserHasSelectedADoor_ThenTheUserShouldBeAbleToOpenAnUnselectedGoatDoor()
        {
            // Arrange
            var simulation = new MontyHallSimulation();
            const int doorSelection = 1;
            var expectedOpenedDoors = 1;
            
            // Act
            simulation.SelectDoor(doorSelection);
            simulation.OpenAnUnselectedGoatDoor();
            var actualOpenedDoors = simulation.RandomlyOrderedDoors.Where(door => door.IsOpen).ToList();
            
        
            // Assert
            Assert.Equal(expectedOpenedDoors, actualOpenedDoors.Count);
            Assert.Equal(typeof(GoatDoor), actualOpenedDoors.First().GetType());
        }
        
        [Fact]
        public void GivenTheUserHasNOTSelectedADoor_WhenTheUserTriesToOpenAnUnselectedGoatDoor_ThenThrowException()
        {
            // Arrange
            var simulation = new MontyHallSimulation();
            
            // Act & Assert
            var exception = Assert.Throws<Exception>(() => simulation.OpenAnUnselectedGoatDoor());
            Assert.Contains("Please select a door first", exception.Message);
        }
    }
}
