namespace UrediDom.Data
{
    public interface IReservationRepository
    {
        List<Reservation> GetReservation();

        Reservation CreateReservation(Reservation reservation);

        Reservation? GetReservationById(long reservationID);

        void DeleteReservation(long reservationID);

        Reservation UpdateReservation(Reservation reservation, Reservation newReservation);
    }
}
