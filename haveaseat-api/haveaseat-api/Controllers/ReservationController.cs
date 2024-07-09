using haveaseat.DTOs;
using haveaseat.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace haveaseat_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationController(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    [HttpGet("/{email}")]
    [ProducesResponseType(typeof(List<ReservationDTO>), 200)]
    public async Task<IActionResult> ReservationsByEmail(string email)
    {
        List<ReservationDTO> result = await _reservationRepository.GetReservationsByUserEmail(email);
        if (!result.Any())
        {
            return NotFound(new { Message = "No reservations for given user", User = email });
        }

        return Ok(result);
    }
} 