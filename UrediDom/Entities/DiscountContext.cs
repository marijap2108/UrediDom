using Microsoft.EntityFrameworkCore;

namespace UrediDom.Entities
{
    public class DiscountContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DiscountContext(DbContextOptions<DiscountContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Discount> Discount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
