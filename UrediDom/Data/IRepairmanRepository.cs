using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IRepairmanRepository
    {
        List<RepairmanDto> GetRepairman();

        RepairmanDto CreateRepairman(RepairmanDto repairman);

        RepairmanDto? GetRepairmanById(long repairmanID);

        void DeleteRepairman(long repairmanID);
    }
}
