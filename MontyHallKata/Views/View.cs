using System;
using MontyHallKata.Models;
using MontyHallKata.Models.Entity;
using MontyHallKata.Views.InputOutput;

namespace MontyHallKata.Views
{
    public class View
    {
        private readonly IInputOutput _inputOutputConsole;

        public View(IInputOutput inputOutputConsole)
        {
            _inputOutputConsole = inputOutputConsole;
        }

        public int GetUserChoice()
        {
            _inputOutputConsole.PrintOutput(InputOutputMessages.ChoicePromptMessage);
            
            var choice = _inputOutputConsole.GetIntInput();
            while (!InputValidation.IsValidChoice(choice))
            {
                _inputOutputConsole.PrintOutput(InputOutputMessages.InvalidInputMessage);
                choice = _inputOutputConsole.GetIntInput();
            }
            return choice;
        }

        public int GetDoorSelectionFromUser()
        {   
            _inputOutputConsole.PrintOutput(InputOutputMessages.DoorSelectionPrompt);

            var doorSelection = _inputOutputConsole.GetIntInput();
            while (!InputValidation.IsValidDoorSelection(doorSelection))
            {
                _inputOutputConsole.PrintOutput(InputOutputMessages.InvalidInputMessage);
                doorSelection = _inputOutputConsole.GetIntInput();
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
            _inputOutputConsole.PrintOutput(outputString);
        }
        
        public int GetPlayerInput(bool doorSelected , bool choiceMade)
        {
            var playerInput = -1;
            if (!doorSelected)
            {
                playerInput = GetDoorSelectionFromUser();
            }
            else if (!choiceMade)
            {
                playerInput = GetUserChoice();
            }
            return playerInput;
        }

        public void HandleOutputMessage(GameStatus gameStatus)
        {
            switch (gameStatus)
            {
                case GameStatus.Quit:
                    _inputOutputConsole.PrintOutput(InputOutputMessages.QuitOutputMessage);
                    break;
                case GameStatus.Lost:
                    _inputOutputConsole.PrintOutput(InputOutputMessages.LosingOutputMessage);
                    break;
                case GameStatus.Won: 
                    _inputOutputConsole.PrintOutput(InputOutputMessages.WinningOutputMessage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}