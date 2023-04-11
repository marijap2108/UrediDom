namespace UrediDom.Data
{
    public interface IAvailabilityRepository
    {
        List<Availability> GetAvailability();

        Availability CreateAvailability(Availability availability);

        Availability? GetAvailabilityById(long repairmanID);

        void DeleteAvailability(long repairmanID);

        Availability UpdateAvailability(Availability availability, Availability newAvailability);
    }
}
