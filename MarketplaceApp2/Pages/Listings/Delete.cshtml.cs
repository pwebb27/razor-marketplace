using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MarketplaceApp.Models;
using MarketplaceApp2.Data;

namespace MarketplaceApp2.Pages.Listings
{
    public class DeleteModel : PageModel
    {
        private readonly MarketplaceApp2.Data.MarketplaceApp2Context _context;

        public DeleteModel(MarketplaceApp2.Data.MarketplaceApp2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Listing Listing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _context.Listing.FirstOrDefaultAsync(m => m.Id == id);

            if (listing == null)
            {
                return NotFound();
            }
            else
            {
                Listing = listing;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _context.Listing.FindAsync(id);
            if (listing != null)
            {
                Listing = listing;
                _context.Listing.Remove(Listing);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
