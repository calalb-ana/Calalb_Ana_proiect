using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Calalb_Ana_proiect.Data;
using Calalb_Ana_proiect.Models;

namespace Calalb_Ana_proiect.Pages.Albums
{
    public class EditModel : AlbumGenresPageModel
    {
        private readonly Calalb_Ana_proiect.Data.Calalb_Ana_proiectContext _context;

        public EditModel(Calalb_Ana_proiect.Data.Calalb_Ana_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _context.Album
                .Include(b => b.Artist)
                .Include(b => b.AlbumGenres).ThenInclude(b => b.Genre)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Album == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedGenreData pentru a obtine informatiile necesare
            //checkbox-urilor folosind clasa AssignedGenreData
            PopulateAssignedGenreData(_context, Album);

            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "ArtistName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id,string[] selectedGenres)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumToUpdate = await _context.Album
                .Include(i => i.Artist)
                .Include(i => i.AlbumGenres)
                .ThenInclude(i => i.Genre)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (albumToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Album>(
                albumToUpdate, "Album",
                i => i.Title, i => i.Type, i => i.Length,
                i => i.Year, i => i.Artist))
            {
                UpdateAlbumGenres(_context, selectedGenres, albumToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateAlbumGenres pentru a aplica informatiile din checkboxuri la entitatea Albums
            //care este editata
            UpdateAlbumGenres(_context, selectedGenres, albumToUpdate);
            PopulateAssignedGenreData(_context, albumToUpdate);
            return Page();
        }

        private bool AlbumExists(int id)
        {
            return _context.Album.Any(e => e.ID == id);
        }
    }
}
