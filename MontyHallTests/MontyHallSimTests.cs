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
            const int expectedSelectedDoor = 1;
            
            // Act
            simulation.SelectDoor(expectedSelectedDoor);
            var actualSelectedDoor = simulation.SelectedDoor;
            

            // Assert
            Assert.Equal(expectedSelectedDoor, actualSelectedDoor);
        }
        
        [Fact]
        public void GivenASimulation_WhenTheUserHasSelectedADoor_ThenTheUserShouldBeAbleToGetOneOfTheGoatDoors()
        {
            // Arrange
            var simulation = new MontyHallSimulation();
            const int doorSelection = 1;
            
            // Act
            simulation.SelectDoor(doorSelection);
            var goatDoor = simulation.GetAGoatDoor();
            

            // Assert
            Assert.Equal(GoatDoor, goatDoor.GetType());
        }
    }
}
