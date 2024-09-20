using MarketplaceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceApp2.Pages.Listings
{
    public class CreateModel : PageModel
    {
        private readonly MarketplaceApp2.Data.MarketplaceApp2Context _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(MarketplaceApp2.Data.MarketplaceApp2Context context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            Categories = _context.Set<Category>().ToList(); // Load categories once here
        }

        [BindProperty]
        [Required(ErrorMessage = "Please upload an image.")]
        public IFormFile ListingImage { get; set; }

        [BindProperty]
        public Listing Listing { get; set; } = new Listing();

        [BindProperty]
        public List<Category> Categories { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (Listing.CategoryId == 0)
            {
                ModelState.AddModelError("Listing.CategoryId", "Please select a category.");
            }
            Listing.Category = Categories.FirstOrDefault(c => c.Id == Listing.CategoryId);

            if (!ModelState.IsValid)
            {
                Categories = _context.Set<Category>().ToList();
                return Page();
            }

            // Handle the image saving
            if (ListingImage != null)
            {
                await SaveListingImageAsync();
            }

            Listing.DateListed = DateTime.Now;

            _context.Listing.Add(Listing);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Listings/Index");
        }

        private async Task SaveListingImageAsync()
        {
            var filePath = Path.Combine(_environment.WebRootPath, "Images", "Listings", ListingImage.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await ListingImage.CopyToAsync(fileStream);
            }

            Listing.ImagePath = Path.Combine("Images", "Listings", ListingImage.FileName);
        }

    }
}
