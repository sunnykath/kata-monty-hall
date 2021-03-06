using MontyHallKata.Controllers;
using MontyHallKata.Models.Entity;
using MontyHallKata.Models.Randomizer;
using MontyHallKata.Views.InputOutput;

namespace MontyHallKata
{
    public static class Program
    {
        private const int Simulation = 1;
        private const int PlayThrough = 2;
        private const int Quit = 0;
        public static void Main()
        {
            var randomizer = new DefaultRandomizer();
            var console = new InputOutputConsole();
            
            console.PrintOutput(InputOutputMessages.InitialChoicePrompt);
            var consoleInput =  console.GetIntInput();

            switch (consoleInput)
            { 
                case Simulation:
                    SimulateMontyHall(randomizer, console);
                    break;
                
                case PlayThrough:
                    var game = new Controller(console);
                    game.Play(randomizer);
                    break;
                
                case Quit:
                    break;
            }
        }

        private static void SimulateMontyHall(IRandomizer randomizer, IInputOutput console)
        {
            var simulation = new SimulationGenerator(randomizer);
            
            console.PrintOutput(InputOutputMessages.NumberOfSimulationsPrompt);
            var numberOfSimulations = console.GetIntInput();
                    
            simulation.Simulate(numberOfSimulations, Choices.Stay);
            var stayWinningPercentage = simulation.GetWinningPercentage();
            simulation.Simulate(numberOfSimulations, Choices.Switch);
            var switchWinningPercentage = simulation.GetWinningPercentage();
            
            console.PrintSimulationResults(stayWinningPercentage, switchWinningPercentage);
        }
    }
    
}