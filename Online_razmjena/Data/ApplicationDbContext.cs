using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_razmjena.Models;
using Online_razmjena.Models.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_razmjena.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Slicice> Slicice { get; set; }

        public DbSet<SliciceGallery> SliciceGallery { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<MainComment> MainComments { get; set; }
        public DbSet<SubComment> SubComments { get; set; }
        public DbSet<AlbumModel> Albumi { get; set; }
        public DbSet<ZamjenaModel> Zamjene { get; set; }

    }
}
