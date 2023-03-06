using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabOne.Data;
using LabOne.Data.MainEntities;

namespace LabOne.Pages.Years
{
    public class EditModel : PageModel
    {
        private readonly ApplicationContext _context;


        public EditModel(ApplicationContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Year Year { get; set; } = default!;


        private bool YearExists(string? id)
        {
            return (_context.Years?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Years == null)
            {
                return NotFound();
            }

            Year? year =  await ApplicationContext.GetNonRemoved(_context.Years)
                                                  .FirstOrDefaultAsync(m => m.Id == id);

            if (year == null)
            {
                return NotFound();
            }
            Year = year;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Year).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearExists(Year.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./List");
        }
    }
}
