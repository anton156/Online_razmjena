using Online_razmjena.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Models
{
    public class AlbumModel
    {
        [Key]
        public int AlbumId { get; set; }
        [Required]
        public string Naziv { get; set; }

        public virtual ICollection<Slicice> Slicice { get; set; }
    }
}
