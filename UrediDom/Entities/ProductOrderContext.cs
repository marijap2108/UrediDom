using Microsoft.EntityFrameworkCore;

namespace UrediDom.Entities
{
    public class ProductOrderContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ProductOrderContext(DbContextOptions<ProductOrderContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<ProductOrder> ProductOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
