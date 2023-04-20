using Microsoft.EntityFrameworkCore;
using UrediDom.Models;

namespace UrediDom.Entities
{
    public class ProductOrderContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ProductOrderContext(DbContextOptions<ProductOrderContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<ProductOrderDto> productOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
