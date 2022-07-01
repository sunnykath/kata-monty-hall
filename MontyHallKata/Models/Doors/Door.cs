namespace MontyHallKata.Models.Doors
{
    public abstract class Door
    {
        private bool _isOpen;
        private bool _isSelected;
        
        public abstract bool IsWinningDoor();
        
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