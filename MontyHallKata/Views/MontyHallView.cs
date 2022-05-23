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

            var playerInput = _customConsole.GetStringInput();
            if (playerInput.Equals("q"))
            {
                _customConsole.PrintOutput("You have Quit the game.\n");
                return;
            }
        }

        private void PrintDoors(Door[] doors)
        {
            var outputString = "";

            for (var i = 0; i < doors.Length; i++)
            {
                outputString += $"#Door {i+1}#\t#{(doors[i].IsOpen ? "Open" : "Closed")}#\n";
            }
            _customConsole.PrintOutput(outputString);
        }
    }
}