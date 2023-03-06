using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LabOne.Data;
using LabOne.Data.MainEntities;

namespace LabOne.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;


        public CreateModel(ApplicationContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Teacher Teacher { get; set; } = default!;
        
        
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Teacher.Id = Guid.NewGuid().ToString();
            if (!ModelState.IsValid || _context.Teachers == null || Teacher == null)
            {
                return Page();
            }

            _context.Teachers.Add(Teacher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
