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
                .Returns(() => new [] { DoorsFactory.CreateLosingDoor(), DoorsFactory.CreateWinningDoor(), DoorsFactory.CreateLosingDoor() });
            
            
            _simulation = new SimulationGenerator(_mockRandomizer.Object);
        }

        [Fact]
        public void GivenAMontyHallGame_WhenSimulatedOnceUsingStayOnTheWinningDoor_ThenShouldReturnWinningPercentageAsHundred()
        {
            // Arrange
            const int doorSelection = 1;
            _mockRandomizer.Setup(randomizer => randomizer.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(doorSelection);
            
            const string choice = "stay";
            const int numberOfSimulations = 1;

            // Act
            var winningPercentage = _simulation.Simulate(numberOfSimulations, choice);

            // Assert
            Assert.Equal(100, winningPercentage);
        }

        [Fact]
        public void GivenAMontyHallGame_WhenSimulatedOnceUsingSwitchFromTheWinningDoor_ThenShouldReturnTheWinningPercentageAsZero()
        {
            // Arrange
            const int doorSelection = 1;
            _mockRandomizer.Setup(randomizer => randomizer.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(doorSelection);
            
            const string choice = "switch";
            const int numberOfSimulations = 1;
            
            // Act
            var winningPercentage = _simulation.Simulate(numberOfSimulations, choice);

            // Assert
            Assert.Equal(0, winningPercentage);
        }

        [Fact]
        public void GivenAMontyHallGame_WhenSimulatedTenTimesUsingSwitch_ThenShouldReturnTheWinningPercentageCorrectly()
        {
            // Arrange
            const int initialWinningDoorSelection = 1;
            const int initialLosingDoorSelection = 0;
            _mockRandomizer.SetupSequence(randomizer => randomizer.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(initialWinningDoorSelection)
                .Returns(initialWinningDoorSelection)
                .Returns(initialWinningDoorSelection)
                .Returns(initialLosingDoorSelection);
            
            const string choice = "switch";
            const int numberOfSimulations = 10;
            
            // Act
            var winningPercentage = _simulation.Simulate(numberOfSimulations, choice);

            // Assert
            Assert.Equal(70, winningPercentage);
        }

        [Fact]
        public void GivenAMontyHallGame_WhenSimulatedTenTimesUsingStay_ThenShouldReturnTheWinningPercentageAsANumber()
        {
            // Arrange
            const int initialWinningDoorSelection = 1;
            const int initialLosingDoorSelection = 0;
            _mockRandomizer.SetupSequence(randomizer => randomizer.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(initialWinningDoorSelection)
                .Returns(initialWinningDoorSelection)
                .Returns(initialWinningDoorSelection)
                .Returns(initialLosingDoorSelection);
            
            const string choice = "stay";
            const int numberOfSimulations = 10;
            
            // Act
            var winningPercentage = _simulation.Simulate(numberOfSimulations, choice);

            // Assert
            Assert.Equal(30, winningPercentage);
        }
    }
}