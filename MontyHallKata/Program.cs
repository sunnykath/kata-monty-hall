using System;
using MontyHallKata;
using MontyHallKata.Controllers;
using MontyHallKata.Models.Randomizer;


var simulation = new SimulationGenerator(new CustomRandomizer());
simulation.Simulate(1000, "stay");
var stayWinningPercentage = simulation.GetWinningPercentage();
simulation.Simulate(1000, "switch");
var switchWinningPercentage = simulation.GetWinningPercentage();


Console.WriteLine(("After a 1000 simulations of each strategy, here are the results:"));
Console.WriteLine($"Stay Winning Percentage: {stayWinningPercentage}%");
Console.WriteLine($"Switch Winning Percentage: {switchWinningPercentage}%");