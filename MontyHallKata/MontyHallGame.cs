using System;
using System.Linq;

namespace MontyHallKata
{
    public class MontyHallGame
    {
        private readonly Door[] _defaultDoors = {Door.WinningDoor(), Door.LosingDoor(), Door.LosingDoor()};

        public readonly Door[] RandomlyOrderedDoors;

        public MontyHallGame(IShuffle shuffler)
        {
            RandomlyOrderedDoors = shuffler.GetShuffledArray(_defaultDoors);
        }
        
        public void SetSelectedDoor(int selectedDoor)
        {
            RandomlyOrderedDoors[selectedDoor].SelectDoor();
        }

        public Door GetSelectedDoor()
        {
            return Array.Find(RandomlyOrderedDoors, door => door.IsDoorSelected())!;
        }

        public void OpenAnUnselectedLosingDoor()
        {
            if (!HasADoorBeenSelected())
            {
                throw new Exception("Please select a door first");
            }
            var losingDoor = Array.Find(RandomlyOrderedDoors, door => !door.IsWinningDoor && !door.IsDoorSelected())!;
            losingDoor.OpenDoor();
        }
        
        private bool HasADoorBeenSelected()
        {
            return RandomlyOrderedDoors.Any(door => door.IsDoorSelected());
        }

        public void SwitchDoorSelection()
        {
            var newSelectedDoor = Array.Find(RandomlyOrderedDoors, door => !door.IsDoorOpen() && !door.IsDoorSelected())!;
            var oldSelectedDoor = GetSelectedDoor();

            newSelectedDoor.SelectDoor();
            oldSelectedDoor.DeSelectDoor();
        }
        
        public bool HasWonGame()
        {
            return GetSelectedDoor().IsWinningDoor;
        }
    }
}