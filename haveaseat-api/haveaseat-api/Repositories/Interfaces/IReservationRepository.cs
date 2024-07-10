using haveaseat.DTOs;

namespace haveaseat.Repositories.Interfaces;

public interface IReservationRepository
{
    Task<List<ReservationDTO>> GetReservationsByUserEmail(string email);
}