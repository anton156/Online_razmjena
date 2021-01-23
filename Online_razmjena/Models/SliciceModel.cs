using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Models
{
    public class SliciceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Odaberite kupnju ili prodaju")]
        public string Filter { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "Unesite naziv")]
        public string Naziv { get; set; }
        [Display(Name = "Broj Sličice")]
        public string BrojSlicica { get; set; }
        [Display(Name = "Izdavač")]
        public string Izdavac { get; set; }
        [Display(Name = "Godina izdanja")]
        public int GodinaIzdanja { get; set; }
        public int AlbumId { get; set; }
        public string Album { get; set; }
        public int ZamjenaId { get; set; }
        public string Zamjena { get; set; }
        [StringLength(10000)]
        public string Opis { get; set; }

        public string Kontakt { get; set; }
        public string Korisnik { get; set; }

        [Display(Name = "Unesite dodatne podatke koje želite")]
        public string DodatneInformacije { get; set; }
        [NotMapped]
        [Display(Name = "Slika sličice/a")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }
        [NotMapped]
        [Display(Name = "Dodatne slike")]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }
    }
}
