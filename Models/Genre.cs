using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calalb_Ana_proiect.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string GenreName { get; set; }
        public ICollection<AlbumGenre> AlbumGenres { get; set; }
    }
}
