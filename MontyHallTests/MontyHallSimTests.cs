using System.Linq;
using MontyHallKata;
using Xunit;

namespace MontyHallTests
{
    public class MontyHallSimTests
    {
        [Fact]
        public void GivenASimulation_WhenStarted_ThenThreeDoorsAreCreated()
        {
            // Arrange
            var simulation = new MontyHallSimulation();
            var expectedDoors = 3;
            
            // Act
            simulation.SetUp();
            var doors = simulation.Doors;

            // Assert
            Assert.Equal(expectedDoors, doors.Length);
        }
        
        [Fact]
        public void GivenAStartedSimulation_WhenThreeDoorsAreCreated_ThenThereIsExactlyOneCarDoor()
        {
            // Arrange
            var simulation = new MontyHallSimulation();
            var expectedCarDoors = 1;
            
            // Act
            simulation.SetUp();
            var doors = simulation.Doors;
            var carDoors = doors.Where(door => door.GetType() == typeof(CarDoor));

            // Assert
            Assert.Equal(expectedCarDoors, carDoors.Count());
        }
    }
}
