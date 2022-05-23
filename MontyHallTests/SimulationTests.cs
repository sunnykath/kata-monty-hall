using System;
using MontyHallKata;
using MontyHallKata.Controllers;
using MontyHallKata.Models;
using MontyHallKata.Models.Randomizer;
using Moq;
using Xunit;

namespace MontyHallTests
{
    public class SimulationTests
    {
        private readonly SimulationGenerator _simulation;
        private readonly Mock<IRandomizer> _mockRandomizer;
        
        public SimulationTests()
        {
            _mockRandomizer = new Mock<IRandomizer>();
            _mockRandomizer.Setup(randomizer => randomizer.GetRandomizedArray(It.IsAny<Door[]>()))
                .Returns(() => new[]
                {
                    DoorsFactory.CreateLosingDoor(), DoorsFactory.CreateWinningDoor(), DoorsFactory.CreateLosingDoor()
                });

            _simulation = new SimulationGenerator(_mockRandomizer.Object);
        }

        [Theory]
        [InlineData("stay", 100)]
        [InlineData("switch", 0)]
        public void GivenAMontyHallGame_WhenSimulatedOnce_ThenShouldCalculateAndReturnWinningPercentageCorrectly(string choice, int expectedWinningPercentage)
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
        [InlineData("stay", 30)]
        [InlineData("switch", 70)]
        public void GivenAMontyHallGame_WhenSimulatedTenTimes_ThenShouldCalculateAndReturnTheWinningPercentageCorrectly(string choice, int expectedWinningPercentage)
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
