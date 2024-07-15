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
    public async Task<List<RoomDTODesks>> GetAllDesks()
    {
        List<Room> rooms = await _context.Rooms
            .Include(r => r.Desks)
            .ToListAsync();
        List<RoomDTODesks> deskDtos = rooms.Select(d => new RoomDTODesks(d)).ToList();
        return deskDtos;
    }
}