using MontyHallKata.Controllers;
using MontyHallKata.Models.Doors;
using MontyHallKata.Models.Entity;
using MontyHallKata.Models.Randomizer;
using Moq;
using Xunit;

namespace MontyHallTests.ControllersTest
{
    public class SimulationTests
    {
        private readonly SimulationGenerator _simulation;
        private readonly Mock<IRandomizer> _mockRandomizer;
        
        public SimulationTests()
        {
            var doorFactory = new DoorsFactory();
            _mockRandomizer = new Mock<IRandomizer>();
            _mockRandomizer.Setup(randomizer => randomizer.GetRandomizedArray(It.IsAny<Door[]>()))
                .Returns(() => new[]
                {
                    doorFactory.CreateLosingDoor(), doorFactory.CreateWinningDoor(), doorFactory.CreateLosingDoor()
                });

            _simulation = new SimulationGenerator(_mockRandomizer.Object);
        }

        [Theory]
        [InlineData(Choices.Stay, 100)]
        [InlineData(Choices.Switch, 0)]
        public void GivenAMontyHallGame_WhenSimulatedOnce_ThenShouldCalculateAndReturnWinningPercentageCorrectly(Choices choice, int expectedWinningPercentage)
        {
            // Arrange
            const int doorSelection = 1;
            _mockRandomizer.Setup(randomizer => randomizer.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(doorSelection);
            
            const int numberOfSimulations = 1;

            // Act
            _simulation.Simulate(numberOfSimulations, choice);
            var actualWinningPercentage = _simulation.GetWinningPercentage();

            // Assert
            Assert.Equal(expectedWinningPercentage, actualWinningPercentage);
        }

        [Theory]
        [InlineData(Choices.Stay, 30)]
        [InlineData(Choices.Switch, 70)]
        public void GivenAMontyHallGame_WhenSimulatedTenTimes_ThenShouldCalculateAndReturnTheWinningPercentageCorrectly(Choices choice, int expectedWinningPercentage)
        {
            // Arrange
            const int initialWinningDoorSelection = 1;
            const int initialLosingDoorSelection = 0;
            _mockRandomizer.SetupSequence(randomizer => randomizer.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(initialWinningDoorSelection)
                .Returns(initialWinningDoorSelection)
                .Returns(initialWinningDoorSelection)
                .Returns(initialLosingDoorSelection);
            
            const int numberOfSimulations = 10;
            
            // Act
            _simulation.Simulate(numberOfSimulations, choice);
            var actualWinningPercentage = _simulation.GetWinningPercentage();

            // Assert
            Assert.Equal(expectedWinningPercentage, actualWinningPercentage);
        }
    }
}
