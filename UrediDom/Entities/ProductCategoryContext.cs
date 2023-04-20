using Microsoft.EntityFrameworkCore;
using UrediDom.Models;

namespace UrediDom.Entities
{
    public class ProductCategoryContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ProductCategoryContext(DbContextOptions<ProductCategoryContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<ProductCategoryDto> productCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
