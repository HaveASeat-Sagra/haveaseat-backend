using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace haveaseat.Entities;

public class Reservation
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public long Id { get; set; }
    public DateOnly Date { get; set; }
    
    public long UserId { get; set; }
    public User User { get; set; }
    
    public long ChairId { get; set; }
    public Chair Chair { get; set; }
}