using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace haveaseat.Entities;

public class Chair
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public long Id { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public long DeskId { get; set; }
    public Desk Desk { get; set; }
    public ICollection<Reservation> Reservations { get; }
}
