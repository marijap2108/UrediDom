using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AdminContext context;

        public AdminRepository(AdminContext context)
        {
            this.context = context;
        }

        public List<AdminDto> GetAdmin()
        {
            Console.WriteLine(context.admin.ToList());
            return context.admin.ToList();
        }

        public AdminDto CreateAdmin(AdminDto admin)
        {
            var createdEntity = context.Add(admin);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public AdminDto? GetAdminById(long adminID)
        {
            return context.admin.FirstOrDefault(e => e.adminID == adminID);
        }

        public void DeleteAdmin(long adminID)
        {
            var admin = GetAdminById(adminID);

            if (admin != null)
            {
                context.Remove(admin);
                context.SaveChanges();
            }
        }
    }
}
