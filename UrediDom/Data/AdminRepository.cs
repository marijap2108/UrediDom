using UrediDom.Entities;

namespace UrediDom.Data
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AdminContext context;

        public AdminRepository(AdminContext context)
        {
            this.context = context;
        }

        public List<Admin> GetAdmin()
        {
            Console.WriteLine(context.Admin.ToList());
            return context.Admin.ToList();
        }

        public Admin CreateAdmin(Admin admin)
        {
            var createdEntity = context.Add(admin);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public Admin? GetAdminById(long adminID)
        {
            return context.Admin.FirstOrDefault(e => e.AdminID == adminID);
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
