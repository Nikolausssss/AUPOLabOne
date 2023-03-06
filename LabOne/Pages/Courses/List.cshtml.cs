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
    public class ListModel : PageModel
    {
        private readonly ApplicationContext _context;


        public ListModel(ApplicationContext context)
        {
            _context = context;
        }


        public IList<Course> Course { get;set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Course = await ApplicationContext
                    .GetNonRemoved(_context.Courses
                        .Include(c => c.Parallel)
                        .Include(c => c.Teacher)
                        .Include(c => c.Year))
                    .ToListAsync();
            }
        }
    }
}
