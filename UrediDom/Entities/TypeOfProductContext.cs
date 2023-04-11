using Microsoft.EntityFrameworkCore;

namespace UrediDom.Entities
{
    public class TypeOfProductContext : DbContext
    {
        private readonly IConfiguration configuration;

        public TypeOfProductContext(DbContextOptions<TypeOfProductContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<TypeOfProduct> TypeOfProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
