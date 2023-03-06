using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabOne.Data;
using LabOne.Data.Catalogs;

namespace LabOne.Pages.Parallels
{
    public class ListModel : PageModel
    {
        private readonly ApplicationContext _context;


        public ListModel(ApplicationContext context)
        {
            _context = context;
        }

        public IList<Data.Catalogs.Parallel> Parallel { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Parallels == null)
            {
                return;
            }

            List<Data.Catalogs.Parallel> 
                parallel = await ApplicationContext.GetNonRemoved(_context.Parallels
                                                       .Include(p => p.Level))
                                                   .ToListAsync();
            parallel.Sort(new ParallelComparer());
            
            Parallel = parallel;
        }
    }
}
