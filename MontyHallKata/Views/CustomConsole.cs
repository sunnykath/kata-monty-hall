using System;

namespace MontyHallKata.Views
{
    public class CustomConsole
    {
        public string GetStringInput()
        {
            string? inputString; 
                
            do
            {
                inputString = Console.ReadLine();
            } while (string.IsNullOrEmpty(inputString));

            return inputString;
        }

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
            Console.Write(outputString);
        }
    }
}   