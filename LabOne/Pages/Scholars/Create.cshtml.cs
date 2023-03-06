using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LabOne.Data;
using LabOne.Data.MainEntities;
using Microsoft.EntityFrameworkCore;

namespace LabOne.Pages.Scholars
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;


        public CreateModel(ApplicationContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Scholar Scholar { get; set; } = default!;

       
        public IActionResult OnGet(string id = "")
        {
            if (_context.Courses != null)
            {
                IQueryable<Course> courses = 
                    ApplicationContext.GetNonRemoved(_context.Courses
                                                             .Include(c => c.Parallel)
                                                             .Include(c => c.Year));

                ViewData["CoursesId"] = new SelectList(courses,
                                                       nameof(Course.Id),
                                                       nameof(Course.Title),
                                                       courses.FirstOrDefault(c => c.Id.Equals(id))?.Id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Scholar.Id = Guid.NewGuid().ToString();
            if (!ModelState.IsValid || _context.Scholars == null || Scholar == null)
            {
                return Page();
            }

            _context.Scholars.Add(Scholar);
            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
