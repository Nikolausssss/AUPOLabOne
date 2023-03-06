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

namespace LabOne.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly ApplicationContext _context;


        public EditModel(ApplicationContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Course Course { get; set; } = default!;


        private bool CourseExists(string? id)
        {
            return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course =  await ApplicationContext.GetNonRemoved(_context.Courses
                                                       .Include(c => c.Scholars))
                                                  .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            Course = course;

            ViewData["ParallelId"] = new SelectList(ApplicationContext.GetNonRemoved(_context.Parallels),
                                                    nameof(Data.Catalogs.Parallel.Id),
                                                    nameof(Data.Catalogs.Parallel.Number));
            ViewData["TeacherId"] = new SelectList(ApplicationContext.GetNonRemoved(_context.Teachers),
                                                   nameof(Teacher.Id),
                                                   nameof(Teacher.FullName));
            ViewData["YearId"] = new SelectList(ApplicationContext.GetNonRemoved(_context.Years),
                                                nameof(Year.Id),
                                                nameof(Year.Title));
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(Course.Id))
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
