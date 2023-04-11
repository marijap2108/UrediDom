using Microsoft.EntityFrameworkCore;

namespace UrediDom.Entities
{
    public class CustomerContext : DbContext
    {
        private readonly IConfiguration configuration;

        public CustomerContext(DbContextOptions<CustomerContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
