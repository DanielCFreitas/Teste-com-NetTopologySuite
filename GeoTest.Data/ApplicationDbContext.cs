using GeoTest.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace GeoTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Farm> farm { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=GeoTestDb;User Id=postgres;Password=;",
                config =>
                {
                    config.UseNetTopologySuite();
                });
        }
    }
}
