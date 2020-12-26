using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Data
{
    public class SliciceGallery
    {
        public int Id { get; set; }
        public int SliciceId { get; set; }
        public string Naziv { get; set; }
        public string URL { get; set; }

        public Slicice Slicica { get; set; }
    }
}
