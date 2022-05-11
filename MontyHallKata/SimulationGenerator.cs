
using System;

namespace MontyHallKata
{
    public class SimulationGenerator
    {
        private readonly MontyHallGame _game;
        public SimulationGenerator(IShuffle shuffler)
        {
            _game = new MontyHallGame(shuffler);
        }

        public int Simulate(int numberOfSimulations, string choice)
        {
            var gamesWon = 0;
            for (var i = 0; i < numberOfSimulations; i++)
            {
                _game.SetSelectedDoor(1);
                _game.OpenAnUnselectedLosingDoor();

                bool hasWonGame;
                if (choice.ToLower().Equals("stay"))
                {
                    hasWonGame = _game.HasWonGame();
                }
                else
                {
                    _game.SwitchDoorSelection();
                    hasWonGame = _game.HasWonGame();
                }

                if (hasWonGame)
                {
                    gamesWon++;
                }
            }

            var winningPercentage = gamesWon * 100 / numberOfSimulations;

            return winningPercentage;
        }
    }
}