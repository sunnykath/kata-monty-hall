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
    }
}   