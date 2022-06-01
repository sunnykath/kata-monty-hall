using MontyHallKata.Models;
using MontyHallKata.Models.Randomizer;
using MontyHallKata.Views;

namespace MontyHallKata.Controllers
{
    public class Controller
    {
        private MontyHallGame? _game;
        private MontyHallView _view;
        private GameStatus _gameStatus;
        
        private enum GameStatus
        {
            Playing,
            Quit,
            Lost,
            Won
        }

        public Controller()
        {
            _gameStatus = GameStatus.Playing;
            _view = new MontyHallView(new CustomConsole());
        }

        public void Play(IRandomizer randomizer)
        {
            _game = new MontyHallGame(randomizer);

            var doorSelected = false;
            var choiceMade = false;

            while (_gameStatus == GameStatus.Playing)
            {
                _view.PrintDoors(_game.RandomlyOrderedDoors);

                int playerInput;
                if (!doorSelected)
                {
                    playerInput = _view.GetDoorSelectionFromUser();
                }
                else if (!choiceMade)
                {
                    playerInput = _view.GetUserChoice();
                }
                else
                {
                    playerInput = new CustomConsole().GetIntInput();
                }

                if (playerInput == 0)
                {
                    _gameStatus = GameStatus.Quit;
                }
                else if (!doorSelected)
                {
                    _game.SetSelectedDoor(playerInput - Constants.IndexAdjustment);
                    doorSelected = true;
                    _game.OpenAnUnselectedLosingDoor();
                }
                else if (!choiceMade)
                {
                    if (playerInput != 2) continue;
                    _game.SwitchDoorSelection();
                    choiceMade = true;
                }
            }
            
            _view.OutputQuitMessage();
        }
    }
}