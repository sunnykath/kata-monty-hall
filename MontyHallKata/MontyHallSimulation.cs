namespace MontyHallKata
{
    public class MontyHallSimulation
    {
        public IDoor[] Doors = System.Array.Empty<IDoor>();


        public void SetUp()
        {
            PopulateDoors();
        }

        private void PopulateDoors()
        {
            Doors = new IDoor[] {new CarDoor(), new GoatDoor(), new GoatDoor() };
        }
    }
}