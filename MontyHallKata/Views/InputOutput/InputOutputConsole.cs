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

        public void PrintOutput(string outputString)
        {
            System.Console.Write(outputString);
        }
        
        private string GetStringInput()
        {
            string? inputString;
            do
            {
                inputString = System.Console.ReadLine();
            } while (string.IsNullOrEmpty(inputString));

            return inputString;
        }

    }
}   