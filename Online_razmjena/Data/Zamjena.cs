using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Data
{
    public class Zamjena
    {
        public int ZamjenaId { get; set; }
        
        public string Nacin { get; set; }

        public virtual ICollection<Slicice> Slicice { get; set; }
    }
}
