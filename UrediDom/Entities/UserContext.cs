using Microsoft.EntityFrameworkCore;

namespace UrediDom.Entities
{
    public class UserContext : DbContext
    {
        private readonly IConfiguration configuration;

        public UserContext(DbContextOptions<UserContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
