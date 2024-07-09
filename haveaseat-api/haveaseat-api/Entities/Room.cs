using System.ComponentModel.DataAnnotations;

namespace haveaseat.Entities;

public class Room
{
    public long Id { get; set; }
    [MaxLength(4)]
    public string Name { get; set; }
    public ICollection<Desk> Desks { get; }
}