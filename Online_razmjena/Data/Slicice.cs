using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Data
{
    public class Slicice
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string BrojSlicica { get; set; }
        public string Opis { get; set; }
        public string Kontakt { get; set; }
        public string DodatneInformacije { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }


        public ICollection<SliciceGallery> sliciceGallery { get; set; }
    }
}
