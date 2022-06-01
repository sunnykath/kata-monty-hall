using MontyHallKata.Controllers;
using MontyHallKata.Models;
using MontyHallKata.Models.Randomizer;

namespace MontyHallKata.Views
{
    public class MontyHallView
    {
        private readonly CustomConsole _customConsole;

        public MontyHallView(CustomConsole customConsole)
        {
            _customConsole = customConsole;
        }

        public void OutputFinalMessage(bool hasWonGame)
        {
            var finalOutputString = hasWonGame ? Constants.WinningOutputMessage : Constants.LosingOutputMessage;
            _customConsole.PrintOutput(finalOutputString);
        }

        public int GetUserChoice()
        {
            _customConsole.PrintOutput(Constants.ChoicePromptMessage);
            
            var choice = _customConsole.GetIntInput();
            while (!InputValidation.IsValidChoice(choice))
            {
                _customConsole.PrintOutput(Constants.InvalidInputMessage);
                choice = _customConsole.GetIntInput();
            }
            return choice;
        }

        public int GetDoorSelectionFromUser()
        {   
            _customConsole.PrintOutput(Constants.DoorSelectionPrompt);

            var doorSelection = _customConsole.GetIntInput();
            while (!InputValidation.IsValidDoorSelection(doorSelection))
            {
                _customConsole.PrintOutput(Constants.InvalidInputMessage);
                doorSelection = _customConsole.GetIntInput();
            }
            return doorSelection;
        }

        public void PrintDoors(Door[] doors)
        {
            var outputString = "";

            for (var i = 0; i < doors.Length; i++)
            {
                outputString += $"#Door {i + 1}#\t#{(doors[i].IsSelected ? "Selected" : doors[i].IsOpen ? "Open" : "Closed")}#\n";
            }
            _customConsole.PrintOutput(outputString);
        }

        public void OutputQuitMessage()
        {
            _customConsole.PrintOutput(Constants.QuitOutputMessage);
        }
    }
}