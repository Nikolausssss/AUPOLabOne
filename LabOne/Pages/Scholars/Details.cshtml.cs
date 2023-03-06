using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabOne.Data;
using LabOne.Data.MainEntities;

namespace LabOne.Pages.Scholars
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationContext _context;

        
        public DetailsModel(ApplicationContext context)
        {
            _context = context;
        }


        public Scholar Scholar { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Scholars == null)
            {
                return NotFound();
            }

            Scholar? scholar = await ApplicationContext.GetNonRemoved(_context.Scholars
                                                           .Include(s=>s.Course)
                                                           .Include(s=>s.Course.Parallel)
                                                           .Include(s => s.Course.Year))
                                                       .FirstOrDefaultAsync(m => m.Id == id);

            if (scholar == null)
            {
                return NotFound();
            }
            else 
            {
                Scholar = scholar;
            }
            return Page();
        }
    }
}
