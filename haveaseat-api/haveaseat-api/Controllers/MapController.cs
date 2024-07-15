using haveaseat.DTOs;
using haveaseat.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace haveaseat_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MapController(IMapRepository mapRepository) : ControllerBase
{
    [HttpGet("getAllRooms")]
    [ProducesResponseType(typeof(List<RoomDTOCells>), 200)]
    public async Task<IActionResult> GetAllRooms()
    {
        var result = await mapRepository.GetAllRooms();
        return Ok(result);
    }
}