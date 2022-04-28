namespace MontyHallKata
{
    public class MontyHallSimulation
    {
        public IDoor[] Doors = System.Array.Empty<IDoor>();


        public void Start()
        {
            RandomlyAssignDoors();
        }

        private void RandomlyAssignDoors()
        {
            Doors = new IDoor[] {new GoatDoor(), new GoatDoor(), new GoatDoor() };
        }
    }
}