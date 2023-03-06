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

namespace LabOne.Pages.Teachers
{
    public class EditModel : PageModel
    {
        private readonly ApplicationContext _context;


        public EditModel(ApplicationContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Teacher Teacher { get; set; } = default!;


        private bool TeacherExists(string? id)
        {
            return (_context.Teachers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            Teacher? teacher =  await ApplicationContext.GetNonRemoved(_context.Teachers)
                                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            Teacher = teacher;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(Teacher.Id))
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
