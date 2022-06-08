using System;
using MontyHallKata;
using MontyHallKata.Controllers;
using MontyHallKata.Models.Randomizer;
using MontyHallKata.Views;


var simulation = new SimulationGenerator(new CustomRandomizer());
simulation.Simulate(1000, "stay");
var stayWinningPercentage = simulation.GetWinningPercentage();
simulation.Simulate(1000, "switch");
var switchWinningPercentage = simulation.GetWinningPercentage();


Console.WriteLine(("After a 1000 simulations of each strategy, here are the results:"));
Console.WriteLine($"Stay Winning Percentage: {stayWinningPercentage}%");
Console.WriteLine($"Switch Winning Percentage: {switchWinningPercentage}%");


//
// var game = new MontyHallGame(new CustomRandomizer());
//
// var montyHallView = new MontyHallView();
//
// montyHallView.PrintDoors(game.RandomlyOrderedDoors);
//
// var doorSelection = montyHallView.GetDoorSelectionFromUser();
//             
// if (doorSelection == 0)
// {
//     montyHallView.OutputQuitMessage();
//     return;
// }
//
// game.SetSelectedDoor(doorSelection - 1);
//
// montyHallView.PrintDoors(game.RandomlyOrderedDoors);
//             
// game.OpenAnUnselectedLosingDoor();
//             
// montyHallView.PrintDoors(game.RandomlyOrderedDoors);
//
// var choice = montyHallView.GetUserChoice();
//
// switch (choice)
// {
//     case 0:
//         montyHallView.OutputQuitMessage();
//         return;
//     case 2:
//         game.SwitchDoorSelection();
//         break;
// }
//             
// montyHallView.PrintDoors(game.RandomlyOrderedDoors);
//
// var hasWonGame = game.HasWonGame();
// montyHallView.OutputFinalMessage(hasWonGame);
//             
// montyHallView.PrintDoors(game.RandomlyOrderedDoors);