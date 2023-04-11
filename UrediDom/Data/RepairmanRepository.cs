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

        public List<Repairman> GetRepairman()
        {
            Console.WriteLine(context.Repairman.ToList());
            return context.Repairman.ToList();
        }

        public Repairman CreateRepairman(Repairman repairman)
        {
            var createdEntity = context.Add(repairman);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public Repairman? GetRepairmanById(long repairmanID)
        {
            return context.Repairman.FirstOrDefault(e => e.RepairmanID == repairmanID);
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
