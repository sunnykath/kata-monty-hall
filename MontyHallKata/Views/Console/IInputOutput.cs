namespace MontyHallKata.Views.Console
{
    public interface IInputOutput 
    {
        public string GetStringInput();

        public int GetIntInput();

        public void PrintOutput(string outputString);   
    }
}