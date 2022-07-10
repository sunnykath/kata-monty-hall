using MontyHallKata.Models.Entity;
using MontyHallKata.Models.Randomizer;

namespace MontyHallKata.Controllers
{
    public class SimulationGenerator
    {
        private readonly IRandomizer _randomizer;
        private Gameplay? _game;
        private const int MaxNumberOfDoors = 2;

        private int _winningPercentage;
        public SimulationGenerator(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public void Simulate(int numberOfSimulations, Choices choice)
        {
            var gamesWon = 0;
            for (var i = 0; i < numberOfSimulations; i++)
            {
                var doorSelection = _randomizer.GetRandomNumber(max: MaxNumberOfDoors);
                
                _game = new Gameplay(_randomizer);
                _game.SetSelectedDoor(doorSelection);
                _game.OpenAnUnselectedLosingDoor();

                HandleChoice(choice);

                if (_game.HasWonGame())
                {
                    gamesWon++;
                }
            }
            _winningPercentage = gamesWon * 100 / numberOfSimulations;
        }

        public int GetWinningPercentage()
        {
            return _winningPercentage;
        }

        private void HandleChoice(Choices choice)
        {
            if (choice.Equals(Choices.Switch))
            {
                _game!.SwitchDoorSelection();
            }
        }
    }
}