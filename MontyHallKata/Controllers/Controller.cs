using MontyHallKata.Models;
using MontyHallKata.Models.Entity;
using MontyHallKata.Models.Randomizer;
using MontyHallKata.Views;
using MontyHallKata.Views.Console;

namespace MontyHallKata.Controllers
{
    public class Controller
    {
        private MontyHallGame? _game;
        private MontyHallView _view;
        private GameStatus _gameStatus;
        
        private bool _doorSelected = false;
        private bool _choiceMade = false;

        public Controller(IConsole console)
        {
            _gameStatus = GameStatus.Playing;
            _view = new MontyHallView(console);
        }

        public void Play(IRandomizer randomizer)
        {
            _game = new MontyHallGame(randomizer);

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
                _gameStatus = _game.HasWonGame() ? GameStatus.Won : GameStatus.Lost;
            }
        }

        private void HandleChoiceSelection(int choice)
        {
            if (choice != 2) return;
            _game.SwitchDoorSelection();
        }

        private void HandleDoorSelection(int doorSelection)
        {
            _game.SetSelectedDoor(doorSelection - Constants.IndexAdjustment);
            _game.OpenAnUnselectedLosingDoor();
        }
    }
}