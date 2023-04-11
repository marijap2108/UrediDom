namespace UrediDom.Data
{
    public interface IUserRepository
    {
        List<User> GetUser();

        User CreateUser(User user);

        User? GetUserById(long userID);

        void DeleteUser(long userID);

        User UpdateUser(User user, User newUser);
    }
}
