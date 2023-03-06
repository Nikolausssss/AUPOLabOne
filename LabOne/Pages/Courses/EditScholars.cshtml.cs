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
    public class EditScholarsModel : PageModel
    {
        private readonly ApplicationContext _context;


        public EditScholarsModel(ApplicationContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Course Course { get; set; } = default!;
        public IList<Scholar> Scholar { get;set; } = default!;


        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await ApplicationContext
                .GetNonRemoved(_context.Courses
                    .Include(c => c.Parallel)
                    .Include(c=>c.Year))
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (course == null)
            {
                return NotFound();
            }

            Course = course;

            if (_context.Scholars != null)
            {
                Scholar = await ApplicationContext
                    .GetNonRemoved(_context.Scholars
                        .Include(s => s.Course))
                    .Where(s => s.CourseId.Equals(id)).ToListAsync();
            }

            return Page();
        }
    }
}
