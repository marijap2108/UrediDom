using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IRepairmanRepository
    {
        List<Repairman> GetRepairman();

        Repairman CreateRepairman(Repairman repairman);

        Repairman? GetRepairmanById(long repairmanID);

        void DeleteRepairman(long repairmanID);
    }
}
