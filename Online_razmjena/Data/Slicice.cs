using Online_razmjena.Models;
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
        public string Korisnik { get; set; }
        public string BrojSlicica { get; set; }
        public string Izdavac { get; set; }
        public int GodinaIzdanja { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int ZamjenaId { get; set; }
        public Zamjena Zamjena { get; set; }
        public string Opis { get; set; }
        public string Kontakt { get; set; }
        public string DodatneInformacije { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }


        public ICollection<SliciceGallery> sliciceGallery { get; set; }
    }
}
