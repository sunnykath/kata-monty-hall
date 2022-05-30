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

        public void OutputFinalMessage(bool hasWonGame)
        {
            var finalOutputString = hasWonGame ? Constants.WinningOutputMessage : Constants.LosingOutputMessage;
            _customConsole.PrintOutput(finalOutputString);
        }

        public int GetUserChoice()
        {
            _customConsole.PrintOutput(Constants.ChoicePromptMessage);
            return _customConsole.GetIntInput();
        }

        public int GetDoorSelectionFromUser()
        {   
            _customConsole.PrintOutput(Constants.DoorSelectionPrompt);

            var doorSelection = _customConsole.GetIntInput();
            while (doorSelection is < 0 or > 3)
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