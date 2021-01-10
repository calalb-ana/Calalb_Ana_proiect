using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Calalb_Ana_proiect.Data;

namespace Calalb_Ana_proiect.Models
{
    public class AlbumGenresPageModel:PageModel
    {
        public List<AssignedGenreData> AssignedGenreDataList;

        public void PopulateAssignedGenreData(Calalb_Ana_proiectContext context, Album album)
        {
            var allGenres = context.Genre;
            var albumGenres = new HashSet<int>(
                album.AlbumGenres.Select(c => c.AlbumID));
            AssignedGenreDataList = new List<AssignedGenreData>();
            foreach(var gen in allGenres)
            {
                AssignedGenreDataList.Add(new AssignedGenreData
                {
                    GenreID = gen.ID,
                    Name = gen.GenreName,
                    Assigned = albumGenres.Contains(gen.ID)
                });
            }
        }

        public void UpdateAlbumGenres(Calalb_Ana_proiectContext context, string[] selectedGenres, Album albumToUpdate)
        {
            if(selectedGenres == null)
            {
                albumToUpdate.AlbumGenres = new List<AlbumGenre>();
                return;
            }

            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var albumGenres = new HashSet<int>(albumToUpdate.AlbumGenres.Select(c => c.Genre.ID));
            foreach (var gen in context.Genre)
            {
                if (selectedGenresHS.Contains(gen.ID.ToString()))
                {
                    if (!albumGenres.Contains(gen.ID))
                    {
                        albumToUpdate.AlbumGenres.Add(
                            new AlbumGenre
                            {
                                AlbumID = albumToUpdate.ID,
                                GenreID = gen.ID
                            });
                    }
                }
                else
                {
                    if (albumGenres.Contains(gen.ID))
                    {
                        AlbumGenre courseToRemove =
                            albumToUpdate.AlbumGenres.SingleOrDefault(i => i.GenreID == gen.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
