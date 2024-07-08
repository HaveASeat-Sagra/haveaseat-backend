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
    public async Task<ActionResult<List<Desk>>> GetAllDesks()
    {
        var desks = await _deskRepository.GetAllDesks();
        return Ok(desks);
    }
}