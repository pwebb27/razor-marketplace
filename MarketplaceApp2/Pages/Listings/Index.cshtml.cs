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
    public class IndexModel : PageModel
    {
        private readonly MarketplaceApp2.Data.MarketplaceApp2Context _context;

        public IndexModel(MarketplaceApp2.Data.MarketplaceApp2Context context)
        {
            _context = context;
        }

        public IList<Listing> Listing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Listing = await _context.Listing
                .Include(l => l.Category).ToListAsync();
        }
    }
}
