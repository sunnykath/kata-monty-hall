using Xunit;

namespace MontyHallTests
{
    public class MontyHallSimTests
    {
        [Fact]
        public void GivenASimulation_WhenStarted_ThreeDoorsAreCreated()
        {
            // Arrange
            var simulation = new MontyHallSimulation();
            var expectedDoors = 3;
            
            // Act
            simulation.Start();
            var doors = simulation.doors;

            // Assert
            Assert.Equal(expectedDoors, doors.Length);
        }
    }
}
