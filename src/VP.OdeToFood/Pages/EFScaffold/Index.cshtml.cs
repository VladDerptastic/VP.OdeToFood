using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VP.OdeToFood.Data;
using VP.OdeToFood.Definition;

namespace VP.OdeToFood.Pages.EFScaffold
{
    public class IndexModel : PageModel
    {
        private readonly VP.OdeToFood.Data.OdeToFoodDbContext _context;

        public IndexModel(VP.OdeToFood.Data.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
