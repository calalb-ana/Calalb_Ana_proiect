using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calalb_Ana_proiect.Models
{
    public class Album
    {
        public int ID { get; set; }
        [Display(Name="Album Title")]
        [Required, StringLength(100,MinimumLength = 1)]
        public string Title { get; set; }
        public string Type { get; set; }
        [RegularExpression(@"^[0-9]+\s[a-z]+\s[0-9]+\s[a-z]+$",ErrorMessage = "Lungimea trebuie sa fie de forma '0 h 0 min'"), StringLength(10, MinimumLength = 3)]
        public string Length { get; set; }
        public string Year { get; set; }

        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
        public ICollection<AlbumGenre> AlbumGenres { get; set; }
    }
}
