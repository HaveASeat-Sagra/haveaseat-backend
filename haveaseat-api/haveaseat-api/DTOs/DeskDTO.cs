namespace haveaseat.DTOs;

public class DeskDTO
{
    public long Id { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public IEnumerable<ChairDTO> Chairs { get; set; }
}