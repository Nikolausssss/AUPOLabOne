using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LabOne.Data;
using LabOne.Data.MainEntities;

namespace LabOne.Pages.Years
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;


        public CreateModel(ApplicationContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Year Year { get; set; } = default!;


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Year.Id = Guid.NewGuid().ToString();
            if (!ModelState.IsValid || _context.Years == null || Year == null)
            {
                return Page();
            }
            
            _context.Years.Add(Year);
            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
