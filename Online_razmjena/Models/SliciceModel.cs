using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Models
{
    public class SliciceModel
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "Unesite naziv")]
        public string Naziv { get; set; }
        [Display(Name = "Broj Sličice")]
        public string BrojSlicica { get; set; }
        [StringLength(10000)]
        public string Opis { get; set; }

        public string Kontakt { get; set; }
        public string Korisnik { get; set; }

        [Display(Name = "Unesite dodatne podatke koje želite")]
        public string DodatneInformacije { get; set; }

        [Display(Name = "Slika sličice/a")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }

        [Display(Name = "Dodatne slike")]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }
    }
}
