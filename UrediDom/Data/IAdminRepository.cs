namespace UrediDom.Data
{
    public interface IAdminRepository
    {
        List<Admin> GetAdmin();

        Admin CreateAdmin(Admin admin);

        Admin? GetAdminById(long adminID);

        void DeleteAdmin(long adminID);
    }
}
