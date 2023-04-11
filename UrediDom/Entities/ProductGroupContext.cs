using Microsoft.EntityFrameworkCore;

namespace UrediDom.Entities
{
    public class ProductGroupContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ProductGroupContext(DbContextOptions<ProductGroupContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<ProductGroup> ProductGroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
