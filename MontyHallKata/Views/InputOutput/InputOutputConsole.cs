namespace MontyHallKata.Views.InputOutput
{
    public class InputOutputConsole : IInputOutput
    {
        public int GetIntInput()
        {
            bool successfullyParsed;
            int inputInt;
            do
            {
                var inputString = GetStringInput();
                successfullyParsed = int.TryParse(inputString, out inputInt);
            } while (!successfullyParsed);

            return inputInt;
        }

        public void PrintSimulationResults(int stayWinningPercentage, int switchWinningPercentage)
        {
            PrintOutput("After a 1000 simulations of each strategy, here are the results:\n");
            PrintOutput($"Stay Winning Percentage: {stayWinningPercentage}%\n");
            PrintOutput($"Switch Winning Percentage: {switchWinningPercentage}%\n");
        }
        
        public void PrintOutput(string outputString)
        {
            System.Console.Write(outputString);
        }
        
        private string GetStringInput()
        {
            var inputString = "";
            do
            {
                inputString = System.Console.ReadLine();
            } while (string.IsNullOrEmpty(inputString));

            return inputString;
        }

    }
}   