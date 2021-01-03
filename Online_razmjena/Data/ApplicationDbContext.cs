using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
    }
}
