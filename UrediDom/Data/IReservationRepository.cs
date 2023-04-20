using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IReservationRepository
    {
        List<ReservationDto> GetReservation();

        ReservationDto CreateReservation(ReservationDto reservation);

        ReservationDto? GetReservationById(long reservationID);

        void DeleteReservation(long reservationID);

        ReservationDto UpdateReservation(ReservationDto reservation, ReservationDto newReservation);
    }
}
