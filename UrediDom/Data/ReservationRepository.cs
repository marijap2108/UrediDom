using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationContext context;

        public ReservationRepository(ReservationContext context)
        {
            this.context = context;
        }

        public List<ReservationDto> GetReservation()
        {
            Console.WriteLine(context.reservation.ToList());
            return context.reservation.ToList();
        }

        public ReservationDto CreateReservation(ReservationDto reservation)
        {
            var createdEntity = context.Add(reservation);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public ReservationDto? GetReservationById(long reservationID)
        {
            return context.reservation.FirstOrDefault(e => e.reservationID == reservationID);
        }

        public void DeleteReservation(long reservationID)
        {
            var reservation = GetReservationById(reservationID);

            if (reservation != null)
            {
                context.Remove(reservation);
                context.SaveChanges();
            }
        }

        public ReservationDto UpdateReservation(ReservationDto reservation, ReservationDto newReservation)
        {
            reservation.startDate = newReservation.startDate;
            reservation.endDate = newReservation.endDate;
            reservation.repairmanID = newReservation.repairmanID;
            context.SaveChanges();
            return reservation;
        }
    }
}
