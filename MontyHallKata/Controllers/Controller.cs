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

        public void Play(CustomRandomizer randomizer)
        {
            _game = new MontyHallGame(randomizer);

            int playerInput;
            var doorSelected = false;

            while (_gameStatus == GameStatus.Playing)
            {
                _view.PrintDoors(_game.RandomlyOrderedDoors);
                
                if (!doorSelected)
                {
                    playerInput = _view.GetDoorSelectionFromUser();
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
                }
            }
            
            _view.OutputQuitMessage();
        }
    }
}