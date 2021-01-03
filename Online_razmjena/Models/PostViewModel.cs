using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Online_razmjena.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = "";
        public string Tip { get; set; } = "";
        public string Opis { get; set; } = "";
        public string Korisnik { get; set; } = "";

        public IFormFile Image { get; set; } = null;
    }
}
