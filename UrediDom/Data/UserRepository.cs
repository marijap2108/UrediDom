using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;

        public UserRepository(UserContext context)
        {
            this.context = context;
        }

        public List<UserDto> GetUser()
        {
            Console.WriteLine(context.user.ToList());
            return context.user.ToList();
        }

        public UserDto CreateUser(UserDto user)
        {
            var createdEntity = context.Add(user);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public UserDto? GetUserById(long userID)
        {
            return context.user.FirstOrDefault(e => e.userID == userID);
        }

        public UserDto? GetUserByEmail(string email)
        {
            return context.user.FirstOrDefault(e => e.email == email);
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

        public UserDto UpdateUser(UserDto user, UserDto newUser)
        {
            user.name = newUser.name;
            user.surname = newUser.surname;
            user.username = newUser.username;
            user.email = newUser.email;
            user.password = newUser.password;
            user.phone = newUser.phone;
            user.birthday = newUser.birthday;
            user.role = newUser.role;
            context.SaveChanges();
            return user;
        }

        public UserDto? LoginUser(LoginDto login)
        {
            return context.user.FirstOrDefault(e => e.email == login.email && e.password == login.password);
        }

        public string GenerateToken(UserDto user, IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.email),
                new Claim(ClaimTypes.Role,user.role)
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
