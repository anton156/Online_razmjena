using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Data
{
    public class Album
    {
        public int AlbumId { get; set; }
        
        public string Naziv { get; set; }

        public virtual ICollection<Slicice> Slicice { get; set; }
    }
}
