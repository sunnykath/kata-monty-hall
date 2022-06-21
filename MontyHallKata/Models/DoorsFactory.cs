using MontyHallKata.Models.Entity;

namespace MontyHallKata.Models
{
    public static class DoorsFactory
    {
        public static Door CreateWinningDoor()
        {
            return new Door {IsWinningDoor = true};
        }
        public static Door CreateLosingDoor()
        {
            return new Door {IsWinningDoor = false};
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