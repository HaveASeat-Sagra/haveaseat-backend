namespace haveaseat.Repositories.Interfaces;

public interface IDeskRepository
{
     Task<List<Desk>> GetAllDesks();
}