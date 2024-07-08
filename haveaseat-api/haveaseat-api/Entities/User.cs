using System.ComponentModel.DataAnnotations;
using haveaseat.Models;

namespace haveaseat.Entities;

public class User
{
    public long Id { get; set; }
    
    [MaxLength(45)]
    public string Email { get; set; }
    
    [MaxLength(255)]
    public string Password { get; set; }

    public Role Role { get; set; } 
    public ICollection<Reservation> Reservations { get; }
}