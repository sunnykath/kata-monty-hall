using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHallKata
{
    public class MontyHallSimulation
    {
        private readonly Door[] _defaultDoors = {new CarDoor(), new GoatDoor(), new GoatDoor()};

        public readonly List<Door> RandomlyOrderedDoors;

        public MontyHallSimulation()
        {
            RandomlyOrderedDoors = GetRandomlyPopulatedDoors();
        }
        private List<Door> GetRandomlyPopulatedDoors()
        {
            // @TODO: INTERFACE TO MOCK THIS
            var random = new Random();
            return _defaultDoors.OrderBy(_ => random.Next()).ToList();
        }

        public void SetSelectedDoor(int selectedDoor)
        {
            RandomlyOrderedDoors[selectedDoor].IsSelected = true;
        }

        public Door GetSelectedDoor()
        {
            return RandomlyOrderedDoors.Find(door => door.IsSelected)!;
        }

        public void OpenAnUnselectedGoatDoor()
        {
            if (!HasADoorBeenSelected())
            {
                throw new Exception("Please select a door first");
            }
            var goatDoor = RandomlyOrderedDoors.Find(door => door.GetType() == typeof(GoatDoor) && !door.IsSelected)!;
            goatDoor.IsOpen = true;
        }

        private bool HasADoorBeenSelected()
        {
            return RandomlyOrderedDoors.Any(door => door.IsSelected);
        }

        public void SwitchDoorSelection()
        {
            var newSelectedDoor = RandomlyOrderedDoors.Find(door => !door.IsOpen && !door.IsSelected)!;
            var oldSelectedDoor = GetSelectedDoor();

            newSelectedDoor.IsSelected = true;
            oldSelectedDoor.IsSelected = false;
        }


        public bool HasWonGame()
        {
            return GetSelectedDoor().GetType() == typeof(CarDoor);
        }
    }
}