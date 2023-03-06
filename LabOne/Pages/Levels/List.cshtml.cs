using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabOne.Data;
using LabOne.Data.Catalogs;

namespace LabOne.Pages.Levels
{
    public class ListModel : PageModel
    {
        private readonly ApplicationContext _context;


        public ListModel(ApplicationContext context)
        {
            _context = context;
        }


        public IList<Level> Level { get;set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Levels != null)
            {
                Level = await ApplicationContext.GetNonRemoved(_context.Levels)
                                                .ToListAsync();
            }
        }
    }
}
