using System.ComponentModel.DataAnnotations;
namespace MarketplaceApp.Models;

/// <summary>
/// Class <c>Category</c> represents a category class used for categorizing listings. Each listing will be linked to one category.
/// </summary>

public class Category
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string IconClass { get; set; }

    public Category(string name, string iconClass)
    {
        Name = name;
        IconClass = iconClass;
    }
}