namespace MontyHallKata.Models
{
    public class Door
    {
        public bool IsOpen { get; set; }
        public bool IsSelected { get; set; }
        
        public bool IsWinningDoor { get; init; }
    }
}