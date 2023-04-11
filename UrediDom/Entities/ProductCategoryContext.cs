using Microsoft.EntityFrameworkCore;

namespace UrediDom.Entities
{
    public class ProductCategoryContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ProductCategoryContext(ProductCategoryContext<AdminContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
