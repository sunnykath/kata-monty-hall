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
    }
}
