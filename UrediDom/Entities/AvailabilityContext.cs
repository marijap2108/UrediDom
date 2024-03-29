﻿using Microsoft.EntityFrameworkCore;
using UrediDom.Models;

namespace UrediDom.Entities
{
    public class AvailabilityContext : DbContext
    {
        private readonly IConfiguration configuration;

        public AvailabilityContext(DbContextOptions<AvailabilityContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<AvailabilityDto> availability { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UrediDom"));
        }
    }
}
