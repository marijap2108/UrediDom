using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class RepairmanRepository : IRepairmanRepository
    {
        private readonly RepairmanContext context;

        public RepairmanRepository(RepairmanContext context)
        {
            this.context = context;
        }

        public List<RepairmanDto> GetRepairman()
        {
            Console.WriteLine(context.repairman.ToList());
            return context.repairman.ToList();
        }

        public RepairmanDto CreateRepairman(RepairmanDto repairman)
        {
            var createdEntity = context.Add(repairman);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public RepairmanDto? GetRepairmanById(long repairmanID)
        {
            return context.repairman.FirstOrDefault(e => e.repairmanID == repairmanID);
        }

        public void DeleteRepairman(long repairmanID)
        {
            var repairman = GetRepairmanById(repairmanID);

            if (repairman != null)
            {
                context.Remove(repairman);
                context.SaveChanges();
            }
        }
    }
}
