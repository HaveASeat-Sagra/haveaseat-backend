using haveaseat.DTOs;

namespace haveaseat.Repositories.Interfaces;

public interface IDeskRepository
{
     Task<List<DeskDTO>> GetAllDesks();
}