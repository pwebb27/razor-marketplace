using MarketplaceApp.Models;
using MarketplaceApp2.Data;
using Microsoft.EntityFrameworkCore;

public static class DataSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using (var context = new MarketplaceApp2Context(
            serviceProvider.GetRequiredService<DbContextOptions<MarketplaceApp2Context>>()))
        {
            // Check if the database is already seeded
            if (context.Listing.Any())
            {
                return;
            }

            //Instantiate available categories for Listings
            var categories = new List<Category>
            {
                new Category("Antiques and Collectables", "fas fa-music"),
                new Category("Musical Instruments", "fas fa-music"),
                new Category("Sports & Outdoors", "fas fa-volleyball"),
                new Category("Arts & Crafts", "fas fa-computer"),
                new Category("Electronics", "fas fa-computer"),
                new Category("Toys & Games", "fas fa-chess"),
                new Category("Pets & Pet Supplies", "fas fa-dog"),
                new Category("Health & Beauty", "fas fa-heart"),
                new Category("Furniture", "fas fa-couch"),
                new Category("Tools", "fas fa-hammer"),
                new Category("Books", "fas fa-book"),
                new Category("Clothing", "fas fa-shirt"),
                new Category("Automobiles", "fas fa-car")
            };

            context.Category.AddRange(categories);
            context.Listing.AddRange(
                new Listing("Used Car", "user1@example.com", 10000, DateTime.Now.AddDays(-10), "A well-maintained used car.", "/Images/Listings/car.webp", categories.First(c => c.Name == "Automobiles")),
                new Listing("4K TV", "user2@example.com", 300, DateTime.Now.AddDays(-5), "Brand new 4K TV.", "/Images/Listings/tv.webp", categories.First(c => c.Name == "Electronics")),
                new Listing("Sofa Set", "user3@example.com", 250, DateTime.Now.AddDays(-2), "Comfortable sofa set in good condition.", "/Images/Listings/sofa.webp", categories.First(c => c.Name == "Furniture"))
            );

            context.SaveChanges();
        }
    }
}
