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

namespace LabOne.Pages.Scholars
{
    public class EditModel : PageModel
    {
        private readonly ApplicationContext _context;


        public EditModel(ApplicationContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Scholar Scholar { get; set; } = default!;

        public SelectList CoursesList { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Scholars == null)
            {
                return NotFound();
            }

            Scholar? scholar =  await _context.Scholars.FirstOrDefaultAsync(m => m.Id == id);
            if (scholar == null)
            {
                return NotFound();
            }

            Scholar = scholar;

            List<Course> courses = ApplicationContext.GetNonRemoved(_context.Courses
                                                         .Include(c => c.Parallel)
                                                         .Include(c => c.Year))
                                                     .ToList();

            ViewData["CoursesId"] = new SelectList(courses,
                                                   nameof(Course.Id),
                                                   $"{nameof(Course.Title)}",
                                                   Scholar.CourseId);

            return Page();
        }
       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Scholar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScholarExists(Scholar.Id))
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

        private bool ScholarExists(string? id)
        {
          return (_context.Scholars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
