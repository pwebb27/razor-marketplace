using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarketplaceApp.Models;
using MarketplaceApp2.Data;

namespace MarketplaceApp2.Pages.Listings
{
    public class EditModel : PageModel
    {
        private readonly MarketplaceApp2.Data.MarketplaceApp2Context _context;

        public EditModel(MarketplaceApp2.Data.MarketplaceApp2Context context)
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

            var listing =  await _context.Listing.FirstOrDefaultAsync(m => m.Id == id);
            if (listing == null)
            {
                return NotFound();
            }
            Listing = listing;
           ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Listing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListingExists(Listing.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ListingExists(int id)
        {
            return _context.Listing.Any(e => e.Id == id);
        }
    }
}
