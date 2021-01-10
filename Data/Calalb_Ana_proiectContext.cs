using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Calalb_Ana_proiect.Models;

namespace Calalb_Ana_proiect.Data
{
    public class Calalb_Ana_proiectContext : DbContext
    {
        public Calalb_Ana_proiectContext (DbContextOptions<Calalb_Ana_proiectContext> options)
            : base(options)
        {
        }

        public DbSet<Calalb_Ana_proiect.Models.Album> Album { get; set; }

        public DbSet<Calalb_Ana_proiect.Models.Artist> Artist { get; set; }

        public DbSet<Calalb_Ana_proiect.Models.Genre> Genre { get; set; }
    }
}
