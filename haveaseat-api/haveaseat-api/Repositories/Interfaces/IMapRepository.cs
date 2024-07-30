using haveaseat.DTOs;

namespace haveaseat.Repositories.Interfaces;

public interface IMapRepository
{
    Task<List<RoomDTO>> GetAllRooms();
}