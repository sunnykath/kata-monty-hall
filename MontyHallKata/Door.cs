namespace MontyHallKata
{
    public class Door
    {
        private bool _isOpen;
        private bool _isSelected;
        
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

        public void OpenDoor()
        {
            _isOpen = true;
        }
        public bool IsDoorOpen()
        {
            return _isOpen;
        }

        public void SelectDoor()
        {
            _isSelected = true;
        }
        public void DeSelectDoor()
        {
            _isSelected = false;
        }
        public bool IsDoorSelected()
        {
            return _isSelected;
        }
    }
}