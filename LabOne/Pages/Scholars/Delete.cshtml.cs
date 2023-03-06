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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationContext _context;


        public DeleteModel(ApplicationContext context)
        {
            _context = context;
        }

        
        [BindProperty]
        public Scholar Scholar { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Scholars == null)
            {
                return NotFound();
            }

            var scholar = await ApplicationContext.GetNonRemoved(_context.Scholars)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Scholars == null)
            {
                return NotFound();
            }
            var scholar = await _context.Scholars.FindAsync(id);

            if (scholar != null)
            {
                Scholar = scholar;
                Scholar.IsRemoved = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./List");
        }
    }
}
