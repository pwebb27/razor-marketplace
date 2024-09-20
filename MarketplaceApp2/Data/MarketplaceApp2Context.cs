using Microsoft.EntityFrameworkCore;

namespace MarketplaceApp2.Data
{
    public class MarketplaceApp2Context : DbContext
    {
        public MarketplaceApp2Context(DbContextOptions<MarketplaceApp2Context> options)
            : base(options)
        {
        }

        public DbSet<MarketplaceApp.Models.Listing> Listing { get; set; }
        public DbSet<MarketplaceApp.Models.Category> Category { get; set; }
    }
}
