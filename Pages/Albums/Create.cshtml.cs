using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Calalb_Ana_proiect.Data;
using Calalb_Ana_proiect.Models;

namespace Calalb_Ana_proiect.Pages.Albums
{
    public class CreateModel : AlbumGenresPageModel
    {
        private readonly Calalb_Ana_proiect.Data.Calalb_Ana_proiectContext _context;

        public CreateModel(Calalb_Ana_proiect.Data.Calalb_Ana_proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "ArtistName");

            var album = new Album();
            album.AlbumGenres = new List<AlbumGenre>();

            PopulateAssignedGenreData(_context, album);

            return Page();
        }

        [BindProperty]
        public Album Album { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedGenres)
        {
            var newAlbum = new Album();
            if (selectedGenres != null)
            {
                newAlbum.AlbumGenres = new List<AlbumGenre>();
                foreach (var gen in selectedGenres)
                {
                    var genToAdd = new AlbumGenre
                    {
                        GenreID = int.Parse(gen)
                    };
                    newAlbum.AlbumGenres.Add(genToAdd);
                }
            }
            if (await TryUpdateModelAsync<Album>(
                newAlbum, "Album",
                i => i.Title, i => i.Type, i => i.Length,
                i => i.Year, i => i.ArtistID))
            {
                _context.Album.Add(newAlbum);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedGenreData(_context, newAlbum);
            return Page();
        }
    }
}
