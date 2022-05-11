namespace MontyHallKata
{
    public class SimulationGenerator
    {
        private readonly IShuffle _shuffler;
        private MontyHallGame? _game;
        public SimulationGenerator(IShuffle shuffler)
        {
            _shuffler = shuffler;
        }

        public int Simulate(int numberOfSimulations, string choice)
        {
            var gamesWon = 0;
            for (var i = 0; i < numberOfSimulations; i++)
            {
                _game = new MontyHallGame(_shuffler);
                
                _game.SetSelectedDoor(1);
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