using MontyHallKata;
using Moq;
using Xunit;

namespace MontyHallTests
{
    public class SimulationTests
    {
        private readonly SimulationGenerator _simulation;
        
        public SimulationTests()
        {
            _simulation = new SimulationGenerator(new Shuffler());
        }

        [Fact]
        public void GivenAMontyHallGame_WhenSimulatedOnceUsingStay_ThenShouldReturnTheWinningPercentageAsANumber()
        {
            // Arrange
            const string choice = "stay";
            const int numberOfSimulations = 1;
            
            // Act
            var winningPercentage = _simulation.Simulate(numberOfSimulations, choice);

            // Assert
            Assert.True(winningPercentage is 0 or 100);
        }

        [Fact]
        public void GivenAMontyHallGame_WhenSimulatedOnceUsingSwitch_ThenShouldReturnTheWinningPercentageAsANumber()
        {
            // Arrange
            const string choice = "switch";
            const int numberOfSimulations = 1;
            
            // Act
            var winningPercentage = _simulation.Simulate(numberOfSimulations, choice);

            // Assert
            Assert.True(winningPercentage is 0 or 100);
        }

        [Fact]
        public void GivenAMontyHallGame_WhenSimulatedHundredTimesUsingSwitch_ThenShouldReturnTheWinningPercentageAsANumber()
        {
            // Arrange
            const string choice = "switch";
            const int numberOfSimulations = 1;
            
            // Act
            var winningPercentage = _simulation.Simulate(numberOfSimulations, choice);

            // Assert
            Assert.True(winningPercentage is >= 0 and <= 100);
        }

        [Fact]
        public void GivenAMontyHallGame_WhenSimulatedHundredTimesUsingStay_ThenShouldReturnTheWinningPercentageAsANumber()
        {
            // Arrange
            const string choice = "switch";
            const int numberOfSimulations = 1;
            
            // Act
            var winningPercentage = _simulation.Simulate(numberOfSimulations, choice);

            // Assert
            Assert.True(winningPercentage is >= 0 and <= 100);
        }
    }
}