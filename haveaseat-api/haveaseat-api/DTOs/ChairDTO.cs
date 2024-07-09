namespace haveaseat.DTOs;

public class ChairDTO
{
    public ChairDTO(Chair chair)
    {
        this.Id = chair.Id;
        this.PositionX = chair.PositionX;
        this.PositionY = chair.PositionY;
    }
    public long Id { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    // public long DeskId { get; set; }
    // public Desk Desk { get; set; }
}