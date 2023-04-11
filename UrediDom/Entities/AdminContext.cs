using Microsoft.EntityFrameworkCore;

namespace UrediDom.Entities
{
    public class AdminContext : DbContext
    {
        private readonly IConfiguration configuration;

        public AdminContext(DbContextOptions<AdminContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Admin> Admin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
