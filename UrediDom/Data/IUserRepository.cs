using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IUserRepository
    {
        List<UserDto> GetUser();

        UserDto CreateUser(UserDto user);

        UserDto? GetUserById(long userID);

        void DeleteUser(long userID);

        UserDto UpdateUser(UserDto user, UserDto newUser);

        UserDto? LoginUser(LoginDto user);

        string GenerateToken(UserDto user, IConfiguration config);
    }
}
