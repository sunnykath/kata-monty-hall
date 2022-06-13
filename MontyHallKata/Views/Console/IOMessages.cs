namespace MontyHallKata.Views.Console
{
    public static class IOMessages
    {
        public const string ChoicePromptMessage = "Would you like to switch or stay with you selection?:\n" +
                                                  "1\t-\tStay\n" +
                                                  "2\t-\tSwitch\n" +
                                                  "0\t-\tQuit\n";

        public const string DoorSelectionPrompt = "Select a door to begin (or enter 0 to quit): ";

        public const string QuitOutputMessage = "You have quit the game.\n";
        
        public const string WinningOutputMessage = "You have won the game!\n";
        public const string LosingOutputMessage = "You have lost the game!\n";

        public const string InvalidInputMessage = "Invalid Input, Please try again: ";

    }
}