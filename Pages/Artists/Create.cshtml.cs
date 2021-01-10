using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Calalb_Ana_proiect.Data;
using Calalb_Ana_proiect.Models;

namespace Calalb_Ana_proiect.Pages.Artists
{
    public class CreateModel : PageModel
    {
        private readonly Calalb_Ana_proiect.Data.Calalb_Ana_proiectContext _context;

        public CreateModel(Calalb_Ana_proiect.Data.Calalb_Ana_proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Artist Artist { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Artist.Add(Artist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
