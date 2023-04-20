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

        public List<AvailabilityDto> GetAvailability()
        {
            Console.WriteLine(context.availability.ToList());
            return context.availability.ToList();
        }

        public AvailabilityDto CreateAvailability(AvailabilityDto availability)
        {
            var createdEntity = context.Add(availability);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public AvailabilityDto? GetAvailabilityById(long repairmanID)
        {
        return context.availability.FirstOrDefault(e => e.repairmanID == repairmanID);
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

        public AvailabilityDto UpdateAvailability(AvailabilityDto availability, AvailabilityDto newAvailability)
        {
            availability.unavailable = newAvailability.unavailable;
            context.SaveChanges();
            return availability;
        }
    }
}
