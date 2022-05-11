namespace MontyHallKata.Models
{
    public class DoorsFactory
    {
        public static Door CreateWinningDoor()
        {
            var winningDoor = new Door
            {
                IsWinningDoor = true
            };
            return winningDoor;
        }
        public static Door CreateLosingDoor()
        {
            var winningDoor = new Door
            {
                IsWinningDoor = false
            };
            return winningDoor;
        }

        public static void OpenDoor(Door door)
        {
            door.IsOpen = true;
        }
        public static bool IsDoorOpen(Door door)
        {
            return door.IsOpen;
        }

        public static void SelectDoor(Door door)
        {
            door.IsSelected = true;
        }
        public static void DeSelectDoor(Door door)
        {
            door.IsSelected = false;
        }
        public static bool IsDoorSelected(Door door)
        {
            return door.IsSelected;
        }

        public static bool IsWinningDoor(Door door)
        {
            return door.IsWinningDoor;
        }
    }
}