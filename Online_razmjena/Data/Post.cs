using Online_razmjena.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Data
{
    public class Post
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = "";
        public string Tip { get; set; } = "";
        public string Opis { get; set; } = "";
        public string Korisnik { get; set; } = "";

        public string Image { get; set; } = "";

        public DateTime Created { get; set; } = DateTime.Now;

        public List<MainComment> MainComments { get; set; }
    }
}
