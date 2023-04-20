using Microsoft.EntityFrameworkCore;
using UrediDom.Models;

namespace UrediDom.Entities
{
    public class ProductContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ProductContext(DbContextOptions<ProductContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<ProductDto> product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
