namespace MontyHallKata.Views.InputOutput
{
    public interface IInputOutput 
    {
        public int GetIntInput();

        public void PrintSimulationResults(int stayWinningPercentage, int switchWinningPercentage);
        
        public void PrintOutput(string outputString);   
        
    }
}