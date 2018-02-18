using Microsoft.EntityFrameworkCore;
using OData.Locations.Models;

namespace OData.Locations
{
    public class LocationsContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Region> Regions { get; set; }

        public LocationsContext() : base()
        {
        }

        public LocationsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>()
                .HasMany(r => r.Cities)
                .WithOne(c => c.Region)
                .HasForeignKey(x => x.RegionId);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Regions)
                .WithOne(c => c.Country)
                .HasForeignKey(x => x.CountryId);
        }
    }
}