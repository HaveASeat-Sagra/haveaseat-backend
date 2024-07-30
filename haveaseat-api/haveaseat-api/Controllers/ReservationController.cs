using haveaseat.DTOs;
using haveaseat.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace haveaseat_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController(IReservationRepository _reservationRepository) : ControllerBase
{
    [HttpGet("getByEmail/{email}")]
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
    
    [HttpGet("getByDay/{date}")]
    [ProducesResponseType(typeof(List<ReservationDTO>), 200)]
    public async Task<IActionResult> ReservationsByEmail(DateOnly date)
    {
        List<ReservationDTO> result = await _reservationRepository.GetReservationsByDay(date);
        if (!result.Any())
        {
            return NotFound(new { Message = "No reservations for this day", Date = date });
        }
        return Ok(result);
    }

    [HttpPost("newReservation")]
    public async Task<IActionResult> InsertReservation(AddReservationDTO reservation)
    {
        var result = await _reservationRepository.InsertReservations(reservation);
        return Created("Reservation added", result);
    }
} 