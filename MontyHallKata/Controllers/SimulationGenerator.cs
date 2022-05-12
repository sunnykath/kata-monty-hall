using MontyHallKata.Models.Randomizer;

namespace MontyHallKata.Controllers
{
    public class SimulationGenerator
    {
        private readonly IRandomizer _randomizer;
        private MontyHallGame? _game;
        private const int MaxNumberOfDoors = 2;
        public SimulationGenerator(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public int Simulate(int numberOfSimulations, string choice)
        {
            var gamesWon = 0;
            for (var i = 0; i < numberOfSimulations; i++)
            {
                var doorSelection = _randomizer.GetRandomNumber(max: MaxNumberOfDoors);
                
                _game = new MontyHallGame(_randomizer);
                _game.SetSelectedDoor(doorSelection);
                _game.OpenAnUnselectedLosingDoor();

                HandleChoice(choice);

                if (_game.HasWonGame())
                {
                    gamesWon++;
                }
            }
            var winningPercentage = gamesWon * 100 / numberOfSimulations;

            return winningPercentage;
        }

        private void HandleChoice(string choice)
        {
            if (choice.ToLower().Equals("switch"))
            {
                _game!.SwitchDoorSelection();
            }
        }
    }
}