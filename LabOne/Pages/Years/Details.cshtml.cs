using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabOne.Data;
using LabOne.Data.MainEntities;

namespace LabOne.Pages.Years
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationContext _context;

        
        public DetailsModel(ApplicationContext context)
        {
            _context = context;
        }

        
        public Year Year { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Years == null)
            {
                return NotFound();
            }

            Year? year = await ApplicationContext.GetNonRemoved(_context.Years)
                                                 .FirstOrDefaultAsync(m => m.Id == id);

            if (year == null)
            {
                return NotFound();
            }
            else 
            {
                Year = year;
            }
            return Page();
        }
    }
}
