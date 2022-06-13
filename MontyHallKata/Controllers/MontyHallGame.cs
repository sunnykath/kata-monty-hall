using System;
using System.Linq;
using MontyHallKata.Models;
using MontyHallKata.Models.Entity;
using MontyHallKata.Models.Randomizer;

namespace MontyHallKata.Controllers
{
    public class MontyHallGame
    {
        private readonly Door[] _defaultDoors = {DoorsFactory.CreateWinningDoor(), DoorsFactory.CreateLosingDoor(), DoorsFactory.CreateLosingDoor()};

        public readonly Door[] RandomlyOrderedDoors;

        public MontyHallGame(IRandomizer shuffler)
        {
            RandomlyOrderedDoors = shuffler.GetRandomizedArray(_defaultDoors);
        }
        
        public void SetSelectedDoor(int selectedDoor)
        {
            DoorsFactory.SelectDoor(RandomlyOrderedDoors[selectedDoor]);
        }

        public Door GetSelectedDoor()
        {
            return Array.Find(RandomlyOrderedDoors, DoorsFactory.IsDoorSelected)!;
        }

        public void OpenAnUnselectedLosingDoor()
        {
            if (!HasADoorBeenSelected())
            {
                throw new Exception("Please select a door first");
            }
            var losingDoor = Array.Find(RandomlyOrderedDoors, door => !DoorsFactory.IsWinningDoor(door) && !DoorsFactory.IsDoorSelected(door))!;
            DoorsFactory.OpenDoor(losingDoor);
        }
        
        private bool HasADoorBeenSelected()
        {
            return RandomlyOrderedDoors.Any(DoorsFactory.IsDoorSelected);
        }

        public void SwitchDoorSelection()
        {
            var doorToBeSelected = Array.Find(RandomlyOrderedDoors, door => !DoorsFactory.IsDoorOpen(door) && !DoorsFactory.IsDoorSelected(door))!;
            var oldSelectedDoor = GetSelectedDoor();

            DoorsFactory.SelectDoor(doorToBeSelected);
            DoorsFactory.DeSelectDoor(oldSelectedDoor);
        }
        
        public bool HasWonGame()
        {
            return GetSelectedDoor().IsWinningDoor;
        }
    }
}