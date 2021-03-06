﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_razmjena.Models;
using Online_razmjena.Models.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_razmjena.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
        public DbSet<Album> Albumi { get; set; }
        public DbSet<Zamjena> Zamjene { get; set; }
        public DbSet<PorukaModel> Poruke { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole { Name = "Korisnik", NormalizedName = "Korisnik".ToUpper() });
        }
    }
}
