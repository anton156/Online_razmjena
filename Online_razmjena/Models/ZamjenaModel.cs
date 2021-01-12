using Online_razmjena.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Models
{
    public class ZamjenaModel
    {
        [Key]
        public int ZamjenaId { get; set; }
        [Required]
        public string Način { get; set; }

        public virtual ICollection<Slicice> Slicice { get; set; }
    }
}
