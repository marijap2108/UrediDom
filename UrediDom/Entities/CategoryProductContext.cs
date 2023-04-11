using Microsoft.EntityFrameworkCore;

namespace UrediDom.Entities
{
    public class CategoryProductContext : DbContext
    {
        private readonly IConfiguration configuration;

        public CategoryProductContext(DbContextOptions<CategoryProductContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<CategoryProduct> CategoryProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
