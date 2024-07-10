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
        List<Desk> desks = await _context.Desks.Include(d => d.Chairs).ToListAsync();
        List<DeskDTO> deskDtos = desks.Select(d => new DeskDTO
        {
            Id = d.Id,
            PositionX = d.PositionX,
            PositionY = d.PositionY,
            Width = d.Width,
            Height = d.Height,
            Chairs = d.Chairs.Select(c => new ChairDTO(c))
        }).ToList();
        return deskDtos;
    }
}