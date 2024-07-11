namespace haveaseat.DTOs;

public class ReservationDTO
{
    public ReservationDTO(Reservation reservation)
    {
        this.Id = reservation.Id;
        this.Date = reservation.Date;
        this.DeskId = reservation.DeskId;
        this.Desk = new DeskDTO(reservation.Desk);
    }
    public long Id { get; set; }
    public DateOnly Date { get; set; }
    public long DeskId { get; set; }
    public DeskDTO Desk { get; set; }
}