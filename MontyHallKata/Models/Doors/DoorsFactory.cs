namespace MontyHallKata.Models.Doors
{
    public class DoorsFactory
    {
        public Door CreateWinningDoor()
        {
            return new WinningDoor();
        }
        public Door CreateLosingDoor()
        {
            return new LoosingDoor();
        }
    }
}