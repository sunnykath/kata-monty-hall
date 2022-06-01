using System.Reflection.Metadata;
using Microsoft.VisualBasic;
using MontyHallKata.Models.Randomizer;
using MontyHallKata.Views;

namespace MontyHallKata.Controllers
{
    public class Controller
    {
        private MontyHallGame? _game;
        private MontyHallView _view;

        public Controller()
        {
            _view = new MontyHallView(new CustomConsole());;
        }

        public void Play(CustomRandomizer randomizer)
        {
            _game = new MontyHallGame(randomizer);

            var playerInput = new CustomConsole().GetIntInput();

            _view.PrintDoors(_game.RandomlyOrderedDoors);
            
            if (playerInput == 0)
            {
                _view.OutputQuitMessage();
            }
        }
    }
}