using haveaseat.DTOs;
using haveaseat.Entities;
using haveaseat.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace haveaseat_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeskController : ControllerBase
{
    private readonly IDeskRepository _deskRepository;
    public DeskController(IDeskRepository deskRepository)
    {
        _deskRepository = deskRepository;
    }
    
    [HttpGet("getAllDesks")]
    [ProducesResponseType(typeof(List<DeskDTO>), 200)]
    public async Task<IActionResult> GetAllDesks()
    {
        var result = await _deskRepository.GetAllDesks();
        return Ok(result);
    }
}