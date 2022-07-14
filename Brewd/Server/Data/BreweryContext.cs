using Microsoft.EntityFrameworkCore;
using Brewd.Shared.Models;

namespace Brewd.Server.Data
{
    public class BreweryContext : DbContext
    {
        public DbSet<Brewery> Breweries { get; set; }

        public BreweryContext(DbContextOptions<BreweryContext> options): base(options) { }
        public BreweryContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
