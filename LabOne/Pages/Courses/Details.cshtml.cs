using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabOne.Data;
using LabOne.Data.MainEntities;

namespace LabOne.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationContext _context;


        public DetailsModel(ApplicationContext context)
        {
            _context = context;
        }


        public Course Course { get; set; } = default!;

        public IList<Scholar> Scholar { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            Scholar = await ApplicationContext.GetNonRemoved(_context.Scholars
                                                    .Include(s => s.Course.Parallel))
                                              .Where(s => s.CourseId.Equals(id))
                                              .ToListAsync();

            var course = await ApplicationContext.GetNonRemoved(_context.Courses
                                                    .Include(course => course.Year)
                                                    .Include(course => course.Teacher)
                                                    .Include(course => course.Parallel))
                                                 .FirstOrDefaultAsync(m => m.Id == id);

            if (course == null)
            {
                return NotFound();
            }
            else
            {
                Course = course;
            }
            return Page();
        }
    }
}
