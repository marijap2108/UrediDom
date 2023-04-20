using Microsoft.EntityFrameworkCore;
using UrediDom.Models;

namespace UrediDom.Entities
{
    public class DiscountContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DiscountContext(DbContextOptions<DiscountContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<DiscountDto> discount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
