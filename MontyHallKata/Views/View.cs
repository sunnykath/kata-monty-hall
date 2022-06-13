using System;
using MontyHallKata.Models;
using MontyHallKata.Models.Entity;
using MontyHallKata.Views.Console;

namespace MontyHallKata.Views
{
    public class View
    {
        private readonly IConsole _customConsole;

        public View(IConsole customConsole)
        {
            _customConsole = customConsole;
        }

        public int GetUserChoice()
        {
            _customConsole.PrintOutput(IOMessages.ChoicePromptMessage);
            
            var choice = _customConsole.GetIntInput();
            while (!InputValidation.IsValidChoice(choice))
            {
                _customConsole.PrintOutput(IOMessages.InvalidInputMessage);
                choice = _customConsole.GetIntInput();
            }
            return choice;
        }

        public int GetDoorSelectionFromUser()
        {   
            _customConsole.PrintOutput(IOMessages.DoorSelectionPrompt);

            var doorSelection = _customConsole.GetIntInput();
            while (!InputValidation.IsValidDoorSelection(doorSelection))
            {
                _customConsole.PrintOutput(IOMessages.InvalidInputMessage);
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
                    _customConsole.PrintOutput(IOMessages.QuitOutputMessage);
                    break;
                case GameStatus.Lost:
                    _customConsole.PrintOutput(IOMessages.LosingOutputMessage);
                    break;
                case GameStatus.Won: 
                    _customConsole.PrintOutput(IOMessages.WinningOutputMessage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}