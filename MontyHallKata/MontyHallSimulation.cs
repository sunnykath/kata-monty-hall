using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHallKata
{
    public class MontyHallSimulation
    {
        private readonly IDoor[] _defaultDoors = {new CarDoor(), new GoatDoor(), new GoatDoor()};

        public int? SelectedDoor { get; private set; } = null;

        public readonly List<IDoor> RandomlyOrderedDoors;

        public MontyHallSimulation()
        {
            RandomlyOrderedDoors = GetRandomlyPopulateDoors();
        }

        private List<IDoor> GetRandomlyPopulateDoors()
        {
            var random = new Random();
            return _defaultDoors.OrderBy(_ => random.Next()).ToList();
        }

        public void SelectDoor(int selectedDoor)
        {
            SelectedDoor = selectedDoor;
        }

        public IDoor GetAGoatDoor()
        {
            return new GoatDoor();
        }
    }
}