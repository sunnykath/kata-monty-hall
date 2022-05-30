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
            _customConsole.PrintOutput("Would you like to switch or stay with you selection?:\n" +
                                       "1\t-\tStay\n"+
                                       "2\t-\tSwitch\n"+
                                       "0\t-\tQuit\n");
            return _customConsole.GetIntInput();
        }

        public int GetDoorSelectionFromUser()
        {   
            _customConsole.PrintOutput("Select a door to begin (or enter 0 to quit): ");
            return _customConsole.GetIntInput();
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
            _customConsole.PrintOutput("You have quit the game.\n");
        }
    }
}