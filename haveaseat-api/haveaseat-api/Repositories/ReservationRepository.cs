using haveaseat.DbContexts;
using haveaseat.DTOs;
using haveaseat.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace haveaseat.Repositories;

public class ReservationRepository(DataContext context) : IReservationRepository
{
    public async Task<List<ReservationDTO>> GetReservationsByUserEmail(string email)
    {
        List<Reservation> reservationsOfUser = await context.Reservations
            .Include(r => r.Desk) 
            .Where(reservation => reservation.User.Email == email)
            .ToListAsync();
        
        List<ReservationDTO> reservationDtos = reservationsOfUser.Select(r => new ReservationDTO(r)).ToList();
        
        return reservationDtos;
    }

    public async Task<List<ReservationDTO>> GetReservationsByDay(DateOnly date)
    {
        List<Reservation> reservationsOnGivenDay = await context.Reservations
            .Include(r => r.Desk)
            .Include(r => r.User)
            .Where(r => r.Date == date)
            .ToListAsync();

        List<ReservationDTO> reservationDtos = reservationsOnGivenDay
            .Select(r => new ReservationDTO(r)).ToList();

        return reservationDtos;
    }

    public async Task<AddReservationDTO> InsertReservations(AddReservationDTO reservation)
    {
        Reservation entry = new Reservation
        {
            Date = reservation.Date,
            DeskId = reservation.DeskId,
            UserId = reservation.UserId
        };
        await context.Reservations.AddAsync(entry);
        await context.SaveChangesAsync();
        return reservation;
    }
}