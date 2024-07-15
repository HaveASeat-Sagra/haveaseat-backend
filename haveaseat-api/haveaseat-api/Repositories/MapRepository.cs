using haveaseat.DbContexts;
using haveaseat.DTOs;
using haveaseat.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace haveaseat.Repositories;

public class MapRepository : IMapRepository
{
    private readonly DataContext _context;

    public MapRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<RoomDTOCells>> GetAllRooms()
    {
        List<Room> rooms = await _context.Rooms
            .Include(c => c.Cells)
            .ToListAsync();

        List<RoomDTOCells> roomDtos = rooms.Select(room => new RoomDTOCells(room)).ToList();
        return roomDtos;
    }

    public async Task<List<RoomDTO>> GetAllMap()
    {
        List<Room> rooms = await _context.Rooms
            .Include(r => r.Cells)
            .Include(r => r.Desks)
            .ToListAsync();

        List<RoomDTO> roomDtos = rooms.Select(room => new RoomDTO(room)).ToList();
        return roomDtos;
    }
}