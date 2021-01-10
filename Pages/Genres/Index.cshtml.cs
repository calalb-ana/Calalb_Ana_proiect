using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Calalb_Ana_proiect.Data;
using Calalb_Ana_proiect.Models;

namespace Calalb_Ana_proiect.Pages.Genres
{
    public class IndexModel : PageModel
    {
        private readonly Calalb_Ana_proiect.Data.Calalb_Ana_proiectContext _context;

        public IndexModel(Calalb_Ana_proiect.Data.Calalb_Ana_proiectContext context)
        {
            _context = context;
        }

        public IList<Genre> Genre { get;set; }

        public async Task OnGetAsync()
        {
            Genre = await _context.Genre.ToListAsync();
        }
    }
}
