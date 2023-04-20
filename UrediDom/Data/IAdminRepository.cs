using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IAdminRepository
    {
        List<AdminDto> GetAdmin();

        AdminDto CreateAdmin(AdminDto admin);

        AdminDto? GetAdminById(long adminID);

        void DeleteAdmin(long adminID);
    }
}
