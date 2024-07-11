using Microsoft.EntityFrameworkCore;

namespace haveaseat.Entities;

[Keyless]
public class Area
{
    public int height { get; set; } = 11;
    public int width { get; set; } = 15;
}