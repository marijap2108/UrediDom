using UrediDom.Entities;

namespace UrediDom.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;

        public UserRepository(UserContext context)
        {
            this.context = context;
        }

        public List<User> GetUser()
        {
            Console.WriteLine(context.User.ToList());
            return context.User.ToList();
        }

        public User CreateUser(User user)
        {
            var createdEntity = context.Add(user);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public User? GetUserById(long userID)
        {
            return context.User.FirstOrDefault(e => e.UserID == userID);
        }

        public void DeleteUser(long userID)
        {
            var user = GetUserById(userID);

            if (user != null)
            {
                context.Remove(user);
                context.SaveChanges();
            }
        }

        public User UpdateUser(User user, User newUser)
        {
            user.Name = newUser.Name;
            user.Surname = newUser.Surname;
            user.Username = newUser.Username;
            user.Email = newUser.Email;
            user.Password = newUser.Password;
            user.Phone = newUser.Phone;
            user.Birthday = newUser.Birthday;
            context.SaveChanges();
            return user;
        }
    }
}
