namespace MontyHallKata.Models.Entity
{
    public record Door
    {
        public bool IsOpen { get; set; }
        public bool IsSelected { get; set; }
        public bool IsWinningDoor { get; init; }
    }
}