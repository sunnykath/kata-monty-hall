using System;
using MontyHallKata;



var simulation = new SimulationGenerator(new Shuffler());
var stayWinningPercentage = simulation.Simulate(1000, "stay");
var switchWinningPercentage = simulation.Simulate(1000, "switch");

Console.WriteLine($"Stay Winning Percentage: {stayWinningPercentage}");
Console.WriteLine($"Switch Winning Percentage: {switchWinningPercentage}");