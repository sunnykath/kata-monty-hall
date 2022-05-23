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
            
            game.SetSelectedDoor(doorSelection);
            
            PrintDoors(game.RandomlyOrderedDoors);

            var playerInput = _customConsole.GetStringInput();
            
            if (playerInput.Equals("q"))
            {
                _customConsole.PrintOutput("You have Quit the game.\n");
                return;
            }
        }

        private int GetDoorSelectionFromUser()
        {
            _customConsole.PrintOutput("Select a door to begin: ");
            var intInput = _customConsole.GetIntInput();
            return intInput - 1;
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