﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calalb_Ana_proiect.Models
{
    public class AlbumData
    {
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<AlbumGenre> AlbumGenres { get; set; }
    }
}
