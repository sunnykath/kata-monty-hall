namespace MontyHallKata.Views.Console
{
    public interface IConsole
    {
        public string GetStringInput();

        public int GetIntInput();

        public void PrintOutput(string outputString);   
    }
}