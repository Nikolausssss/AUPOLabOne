using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabOne.Data;
using LabOne.Data.MainEntities;

namespace LabOne.Pages.Teachers
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationContext _context;


        public DetailsModel(ApplicationContext context)
        {
            _context = context;
        }

        
        public Teacher Teacher { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            Teacher? teacher = await ApplicationContext.GetNonRemoved(_context.Teachers)
                                                       .FirstOrDefaultAsync(m => m.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }
            else 
            {
                Teacher = teacher;
            }
            return Page();
        }
    }
}
