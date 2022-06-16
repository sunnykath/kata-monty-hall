using MontyHallKata.Models.Entity;
using MontyHallKata.Models.Randomizer;
using MontyHallKata.Views;
using MontyHallKata.Views.InputOutput;

namespace MontyHallKata.Controllers
{
    public class Controller
    {
        private const int IndexAdjustment = 1;
        
        private Gameplay? _game;
        private readonly View _view;
        private GameStatus _gameStatus;
        
        private bool _doorSelected;
        private bool _choiceMade;

        public Controller(IInputOutput inputOutput)
        {
            _gameStatus = GameStatus.Playing;
            _view = new View(inputOutput);
        }

        public void Play(IRandomizer randomizer)
        {
            _game = new Gameplay(randomizer);

            while (_gameStatus == GameStatus.Playing)
            {
                _view.PrintDoors(_game.RandomlyOrderedDoors);

                var playerInput = _view.GetPlayerInput(_doorSelected, _choiceMade);

                HandleGameStatus(playerInput);
            }
            _view.PrintDoors(_game.RandomlyOrderedDoors);
            _view.HandleOutputMessage(_gameStatus);
        }

        private void HandleGameStatus(int playerInput)
        {
            if (playerInput == 0)
            {
                _gameStatus = GameStatus.Quit;
            }
            else if (!_doorSelected)
            {
                HandleDoorSelection(playerInput);
                _doorSelected = true;
            }
            else if (!_choiceMade)
            {
                HandleChoiceSelection(playerInput);
                _choiceMade = true;
            }
            else
            {
                _gameStatus = _game!.HasWonGame() ? GameStatus.Won : GameStatus.Lost;
            }
        }

        private void HandleChoiceSelection(int choice)
        {
            if (choice != 2) return;
            _game!.SwitchDoorSelection();
        }

        private void HandleDoorSelection(int doorSelection)
        {
            _game!.SetSelectedDoor(doorSelection - IndexAdjustment);
            _game.OpenAnUnselectedLosingDoor();
        }
    }
}