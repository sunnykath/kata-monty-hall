using MontyHallKata.Controllers;
using MontyHallKata.Models;
using MontyHallKata.Models.Randomizer;

namespace MontyHallKata.Views
{
    public class MontyHallView
    {
        private readonly CustomConsole _customConsole;

        public MontyHallView()
        {
            _customConsole = new CustomConsole();
        }
        public void Play(IRandomizer randomizer)
        {
            var game = new MontyHallGame(randomizer);

            PrintDoors(game.RandomlyOrderedDoors);

            var doorSelection = GetDoorSelectionFromUser();
            
            if (doorSelection == 0)
            {
                _customConsole.PrintOutput("You have quit the game.\n");
                return;
            }
            
            game.SetSelectedDoor(doorSelection - 1);
            
            PrintDoors(game.RandomlyOrderedDoors);
            
            game.OpenAnUnselectedLosingDoor();
            
            PrintDoors(game.RandomlyOrderedDoors);

        }

        private int GetDoorSelectionFromUser()
        {
            _customConsole.PrintOutput("Select a door to begin (or enter 0 to quit): ");
            var intInput = _customConsole.GetIntInput();
            return intInput ;
        }

        private void PrintDoors(Door[] doors)
        {
            var outputString = "";

            for (var i = 0; i < doors.Length; i++)
            {
                outputString += $"#Door {i + 1}#\t#{(doors[i].IsSelected ? "Selected" : doors[i].IsOpen ? "Open" : "Closed")}#\n";
            }
            _customConsole.PrintOutput(outputString);
        }
    }
}