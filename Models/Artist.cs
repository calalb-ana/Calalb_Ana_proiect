using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calalb_Ana_proiect.Models
{
    public class Artist
    {
        public int ID { get; set; }
        [Display(Name ="Artist")]
        [Required, StringLength(50, MinimumLength = 1)]
        public string ArtistName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Debut { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
