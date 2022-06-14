using MontyHallKata.Controllers;
using MontyHallKata.Models.Randomizer;
using MontyHallKata.Views.Console;

namespace MontyHallKata
{
    public static class Program
    {
        public static void Main()
        {
            var randomizer = new CustomRandomizer();
            var console = new InputOutputConsole();
            
            // Get user input and ask for simulations or play through
            console.PrintOutput(InputOutputMessages.InitialChoicePrompt);
            var consoleInput =  console.GetIntInput();

            switch (consoleInput)
            { 
                case 1:
                    // Simulation
                    var simulation = new SimulationGenerator(randomizer);
            
                    console.PrintOutput(InputOutputMessages.NumberOfSimulationsPrompt);
                    var numberOfSimulations = console.GetIntInput();
                    
                    simulation.Simulate(numberOfSimulations, "stay");
                    var stayWinningPercentage = simulation.GetWinningPercentage();
                    simulation.Simulate(numberOfSimulations, "switch");
                    var switchWinningPercentage = simulation.GetWinningPercentage();
            
                    console.PrintOutput("After a 1000 simulations of each strategy, here are the results:\n");
                    console.PrintOutput($"Stay Winning Percentage: {stayWinningPercentage}%\n");
                    console.PrintOutput($"Switch Winning Percentage: {switchWinningPercentage}%\n");

                    break;
                
                case 2:
                    // Play through
                    var game = new Controller(console);
            
                    game.Play(randomizer);
                    break;
                
                case 0:
                    
                    break;
            }
        }
    }
    
}