namespace haveaseat.Entities;

public class Desk
{
    public long Id { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public ICollection<Chair> Chairs { get; }
    
    public long RoomId { get; set; }
    public Room Room { get; set; }
}