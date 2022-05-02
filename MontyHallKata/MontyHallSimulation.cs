using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHallKata
{
    public class MontyHallSimulation
    {
        private readonly IDoor[] _defaultDoors = {new CarDoor(), new GoatDoor(), new GoatDoor()};

        public List<IDoor> RandomlyOrderedDoors;
        
        public MontyHallSimulation()
        {
            RandomlyOrderedDoors = GetRandomlyPopulateDoors();
        }

        private List<IDoor> GetRandomlyPopulateDoors()
        {
            var random = new Random();
            return _defaultDoors.OrderBy(_ => random.Next()).ToList();
        }
    }
}