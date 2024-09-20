using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MarketplaceApp.Models;

/// <summary>
/// Class <c>Listing</c> represents a listing within the marketplace. Listings are tied to one Category instance.
/// </summary>

public class Listing
{
    [Key]
    public int Id { get; set; }

    [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters long.")]
    public string Title { get; set; }

    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string UserEmailAddress { get; set; }

    [StringLength(5000, MinimumLength = 15, ErrorMessage = "Please enter a description between 15 and 5000 characters long.")]
    public string Description { get; set; }

    [Range(1, 100000, ErrorMessage = "Please enter a value between 1 and 100,000")]
    public int Price { get; set; }
    public string? ImagePath { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    public DateTime DateListed { get; set; }

    public Listing() { }
    public Listing(string title, string userEmailAddress, int price, DateTime dateListed, string description, string imagePath, Category category)
    {
        this.Title = title;
        this.UserEmailAddress = userEmailAddress;
        this.Price = price;
        this.DateListed = dateListed;
        this.Description = description;
        this.ImagePath = imagePath;
        this.Category = category;
        this.CategoryId = category.Id;
    }
}
