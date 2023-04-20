using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IAvailabilityRepository
    {
        List<AvailabilityDto> GetAvailability();

        AvailabilityDto CreateAvailability(AvailabilityDto availability);

        AvailabilityDto? GetAvailabilityById(long repairmanID);

        void DeleteAvailability(long repairmanID);

        AvailabilityDto UpdateAvailability(AvailabilityDto availability, AvailabilityDto newAvailability);
    }
}
