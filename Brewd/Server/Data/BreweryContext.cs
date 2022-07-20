using Microsoft.EntityFrameworkCore;
using Brewd.Shared.Models;

namespace Brewd.Server.Data
{
    public class BreweryContext : DbContext
    {
        public BreweryContext()
        {
        }

        public BreweryContext(DbContextOptions<BreweryContext> options)
            : base(options) { }

        public DbSet<BreweryModel> Breweries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BreweryModel>().ToTable("Breweries");
        }
    }
}
