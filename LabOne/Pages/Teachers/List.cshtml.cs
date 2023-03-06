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
    public class ListModel : PageModel
    {
        private readonly ApplicationContext _context;


        public ListModel(ApplicationContext context)
        {
            _context = context;
        }


        public IList<Teacher> Teacher { get;set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Teachers != null)
            {
                Teacher = await ApplicationContext.GetNonRemoved(_context.Teachers)
                                                  .ToListAsync();
            }
        }
    }
}
