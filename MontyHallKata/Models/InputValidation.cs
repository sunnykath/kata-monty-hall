namespace MontyHallKata.Models
{
    public static class InputValidation
    {
        public static bool IsValidDoorSelection(int doorSelection)
        {
            return doorSelection is >= 0 and <= 3;
        }
        public static bool IsValidChoice(int choice)
        {
            return choice is >= 0 and <= 2;
        }
    }
}