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

            var choice = GetUserChoice();

            switch (choice)
            {
                case 0:
                    _customConsole.PrintOutput("You have quit the game.\n");
                    return;
                case 2:
                    game.SwitchDoorSelection();
                    break;
            }
            
            PrintDoors(game.RandomlyOrderedDoors);

            var hasWonGame = game.HasWonGame();
            OutputFinalResult(hasWonGame);
            
            PrintDoors(game.RandomlyOrderedDoors);

        }

        private void OutputFinalResult(bool hasWonGame)
        {
            var finalOutputString = hasWonGame ? "You have won the game!\n" : "You have lost the game!\n";
            _customConsole.PrintOutput(finalOutputString);
        }

        private int GetUserChoice()
        {
            _customConsole.PrintOutput("Would you like to switch or stay with you selection?:\n" +
                                       "1\t-\tStay\n"+
                                       "2\t-\tSwitch\n"+
                                       "0\t-\tQuit\n");
            return _customConsole.GetIntInput();
        }

        private int GetDoorSelectionFromUser()
        {
            _customConsole.PrintOutput("Select a door to begin (or enter 0 to quit): ");
            return _customConsole.GetIntInput();
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