using System;
using System.Linq;
using MontyHallKata.Models.Doors;
using MontyHallKata.Models.Randomizer;

namespace MontyHallKata.Controllers
{
    public class Gameplay
    {

        public readonly Door[] RandomlyOrderedDoors;

        public Gameplay(IRandomizer shuffler)
        {
            var doorFactory = new DoorsFactory();
            var defaultDoors = new []{doorFactory.CreateWinningDoor(), doorFactory.CreateLosingDoor(), doorFactory.CreateLosingDoor()};
            RandomlyOrderedDoors = shuffler.GetRandomizedArray(defaultDoors);
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
            var losingDoor = Array.Find(RandomlyOrderedDoors, door => !door.IsWinningDoor() && !door.IsDoorSelected())!;
            losingDoor.OpenDoor();
        }

        public void SwitchDoorSelection()
        {
            var doorToBeSelected = Array.Find(RandomlyOrderedDoors, door => !door.IsDoorOpen() && !door.IsDoorSelected())!;
            var oldSelectedDoor = GetSelectedDoor();

            doorToBeSelected.SelectDoor();
            oldSelectedDoor.DeSelectDoor();
        }
        
        public bool HasWonGame()
        {
            return GetSelectedDoor().IsWinningDoor();
        }
        
        private bool HasADoorBeenSelected()
        {
            return RandomlyOrderedDoors.Any(door => door.IsDoorSelected());
        }
    }
}