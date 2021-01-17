using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Models
{
    public class PorukaModel
    {
        [Key]
        public int Id{ get; set; }
       
        public string Korisnik { get; set; }
        
        public string Primatelj { get; set; }
        [Required(ErrorMessage = "Unesite ispravne podatke")]
        public string Naslov { get; set; }
        [Required(ErrorMessage = "Unesite ispravne podatke")]
        public string Tekst { get; set; }
    }
}
