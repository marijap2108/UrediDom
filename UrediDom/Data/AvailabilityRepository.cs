using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly AvailabilityContext context;

        public AvailabilityRepository(AvailabilityContext context)
        {
            this.context = context;
        }

        public List<Availability> GetAvailability()
        {
            Console.WriteLine(context.Availability.ToList());
            return context.Availability.ToList();
        }

        public Availability CreateAvailability(Availability availability)
        {
            var createdEntity = context.Add(availability);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public Availability? GetAvailabilityById(long repairmanID)
        {
        return context.Availability.FirstOrDefault(e => e.RepairmanID == repairmanID);
        }

        public void DeleteAvailability(long repairmanID)
        {
            var availability = GetAvailabilityById(repairmanID);

            if (availability != null)
            {
                context.Remove(availability);
                context.SaveChanges();
            }
        }

        public Availability UpdateAvailability(Availability availability, Availability newAvailability)
        {
            availability.Unavailable = newAvailability.Unavailable;
            context.SaveChanges();
            return availability;
        }
    }
}
