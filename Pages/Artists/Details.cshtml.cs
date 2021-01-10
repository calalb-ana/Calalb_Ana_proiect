using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Calalb_Ana_proiect.Data;
using Calalb_Ana_proiect.Models;

namespace Calalb_Ana_proiect.Pages.Artists
{
    public class DetailsModel : PageModel
    {
        private readonly Calalb_Ana_proiect.Data.Calalb_Ana_proiectContext _context;

        public DetailsModel(Calalb_Ana_proiect.Data.Calalb_Ana_proiectContext context)
        {
            _context = context;
        }

        public Artist Artist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = await _context.Artist.FirstOrDefaultAsync(m => m.ID == id);

            if (Artist == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
