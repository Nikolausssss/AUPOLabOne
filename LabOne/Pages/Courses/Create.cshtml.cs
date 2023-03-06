using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LabOne.Data;
using LabOne.Data.MainEntities;
using LabOne.Data.Catalogs;

namespace LabOne.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;


        public CreateModel(ApplicationContext context)
        {
            _context = context;
        }

        
        [BindProperty]
        public Course Course { get; set; } = default!;


        public IActionResult OnGet()
        {
            var parallels = ApplicationContext.GetNonRemoved(_context.Parallels).ToList();
            parallels.Sort(new ParallelComparer());

            ViewData["ParallelId"] = new SelectList(parallels,
                                                    nameof(Data.Catalogs.Parallel.Id),
                                                    nameof(Data.Catalogs.Parallel.Number));
            ViewData["TeacherId"] = new SelectList(ApplicationContext
                                                       .GetNonRemoved(_context.Teachers),
                                                   nameof(Teacher.Id),
                                                   nameof(Teacher.FullName));
            ViewData["YearId"] = new SelectList(ApplicationContext
                                                    .GetNonRemoved(_context.Years),
                                                nameof(Year.Id),
                                                nameof(Year.Title));
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Course.Id = Guid.NewGuid().ToString();

            if (_context.Courses
                .Where(c => c.YearId.Equals(Course.YearId))
                .FirstOrDefault(c => c.Letter.Equals(Course.Letter)) != null)
            {
                ModelState.AddModelError($"{nameof(Course)}.{nameof(Course.Letter)}",
                                         "Класс с такой буквой в этом году уже существует");
            }

            if (!ModelState.IsValid || _context.Courses == null || Course == null)
            {
                return Page();
            }

            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
