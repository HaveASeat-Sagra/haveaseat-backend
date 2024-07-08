using haveaseat.DbContexts;
using haveaseat.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace haveaseat.Repositories;

public class DeskRepository : IDeskRepository
{
    private readonly DataContext _context;
    public DeskRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<List<Desk>> GetAllDesks()
    {
        var desks = await _context.Desks.ToListAsync();
        return desks;
    }
}