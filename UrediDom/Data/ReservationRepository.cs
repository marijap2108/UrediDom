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

        public List<Reservation> GetReservation()
        {
            Console.WriteLine(context.Reservation.ToList());
            return context.Reservation.ToList();
        }

        public Reservation CreateReservation(Reservation reservation)
        {
            var createdEntity = context.Add(reservation);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public Reservation? GetReservationById(long reservationID)
        {
            return context.Reservation.FirstOrDefault(e => e.ReservationID == reservationID);
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

        public Reservation UpdateReservation(Reservation reservation, Reservation newReservation)
        {
            reservation.StartDate = newReservation.StartDate;
            reservation.EndDate = newReservation.EndDate;
            reservation.RepairmanID = newReservation.RepairmanID;
            context.SaveChanges();
            return reservation;
        }
    }
}
