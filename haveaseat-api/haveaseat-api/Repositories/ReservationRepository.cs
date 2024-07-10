using haveaseat.DbContexts;
using haveaseat.DTOs;
using haveaseat.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace haveaseat.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly DataContext _context;
    public ReservationRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<ReservationDTO>> GetReservationsByUserEmail(string email)
    {
        List<Reservation> reservationsOfUser = await _context.Reservations
            .Include(r => r.Chair) 
            .Where(reservation => reservation.User.Email == email)
            .ToListAsync();
        
        List<ReservationDTO> reservationDtos = reservationsOfUser.Select(r => new ReservationDTO(r)).ToList();
        
        return reservationDtos;
    }
}