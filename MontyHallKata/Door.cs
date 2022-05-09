namespace MontyHallKata
{
    public class Door
    {
        public bool IsOpen;
        public bool IsSelected;
        public readonly bool IsWinningDoor;

        private Door(bool isWinningDoor)
        {
            IsWinningDoor = isWinningDoor;
        }

        public static Door WinningDoor()
        {
            return new Door(true);
        }
        public static Door LosingDoor()
        {
            return new Door(false);
        }
    }
}