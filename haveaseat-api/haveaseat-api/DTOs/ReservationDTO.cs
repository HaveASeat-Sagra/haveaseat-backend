namespace haveaseat.DTOs;

public class ReservationDTO
{
    public ReservationDTO(Reservation reservation)
    {
        this.Id = reservation.Id;
        this.Date = reservation.Date;
        this.ChairId = reservation.ChairId;
        this.Chair = new ChairDTO(reservation.Chair);
    }
    public long Id { get; set; }
    public DateOnly Date { get; set; }
    public long ChairId { get; set; }
    public ChairDTO Chair { get; set; }
}