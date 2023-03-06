using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabOne.Data;
using LabOne.Data.MainEntities;

namespace LabOne.Pages.Scholars
{
    public class ListModel : PageModel
    {
        private readonly ApplicationContext _context;

        
        public ListModel(ApplicationContext context)
        {
            _context = context;
        }

        
        public IList<Scholar> Scholar { get;set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Scholars != null)
            {
                Scholar = await ApplicationContext.GetNonRemoved(_context.Scholars
                                                      .Include(s=>s.Course.Parallel)
                                                      .Include(c => c.Course.Year))
                                                  .ToListAsync();
            }
        }
    }
}
