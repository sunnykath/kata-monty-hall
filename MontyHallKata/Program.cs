using System;
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
            var console = new CustomConsole();
            
            // Get user input and ask for simulations or play through
            console.PrintOutput("What would you like to do?\n" +
                                "1 - Run Simulations on monty hall\n" +
                                "2 - Play through monty hall once\n" +
                                "0 - Quit the program\n");
            var consoleInput =  console.GetIntInput();

            switch (consoleInput)
            { 
                case 1:
                    // Simulation
                    var simulation = new SimulationGenerator(randomizer);
            
                    console.PrintOutput("How many simulations would you like to run?\t");
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