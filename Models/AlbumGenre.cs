using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calalb_Ana_proiect.Models
{
    public class AlbumGenre
    {
        public int ID { get; set; }
        public int AlbumID { get; set; }
        public Album Album { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
