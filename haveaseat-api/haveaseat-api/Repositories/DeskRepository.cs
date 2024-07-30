using haveaseat.DbContexts;
using haveaseat.DTOs;
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
    public async Task<List<DeskDTO>> GetAllDesks()
    {
        List<Desk> desks = await _context.Desks.ToListAsync();
        List<DeskDTO> deskDtos = desks.Select(d => new DeskDTO(d)).ToList();
        return deskDtos;
    }
}