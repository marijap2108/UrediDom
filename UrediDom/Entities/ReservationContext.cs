using Microsoft.EntityFrameworkCore;

namespace UrediDom.Entities
{
    public class ReservationContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ReservationContext(DbContextOptions<ReservationContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Reservation> Reservation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
