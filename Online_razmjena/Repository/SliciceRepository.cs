using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_razmjena.Data;
using Online_razmjena.Models;
using Microsoft.EntityFrameworkCore;

namespace Online_razmjena.Repository
{
    public class SliciceRepository : ISliciceRepository
    {
        private readonly ApplicationDbContext _context = null;


        public SliciceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(SliciceModel model)
        {
            var newSlicice = new Slicice()
            {
                Kontakt = model.Kontakt,
                Filter = model.Filter,
                Izdavac = model.Izdavac,
                GodinaIzdanja = model.GodinaIzdanja,
                AlbumId = model.AlbumId,
                ZamjenaId = model.ZamjenaId,
                CreatedOn = DateTime.UtcNow,
                Korisnik = model.Korisnik,
                Opis = model.Opis,
                Naziv = model.Naziv,
                BrojSlicica = model.BrojSlicica,
                DodatneInformacije = model.DodatneInformacije,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
            };

            newSlicice.sliciceGallery = new List<SliciceGallery>();

            foreach (var file in model.Gallery)
            {
                newSlicice.sliciceGallery.Add(new SliciceGallery()
                {
                    Naziv = file.Naziv,
                    URL = file.URL
                });
            }

            await _context.Slicice.AddAsync(newSlicice);
            await _context.SaveChangesAsync();

            return newSlicice.Id;

        }

        public async Task<List<SliciceModel>> Index(string search, string select, string broj, string filter)
        {
            if (!String.IsNullOrEmpty(search))
            {
                if (!String.IsNullOrEmpty(select))
                {
                    if (!String.IsNullOrEmpty(broj))
                    {
                        return await _context.Slicice.Where(x => x.Filter.Equals(filter)).Where(x => x.Naziv.Contains(search)).Where(x => x.Album.Naziv.Contains(select)).Where(x => x.BrojSlicica.Contains(broj))
                          .Select(slicice => new SliciceModel()
                          {
                              Kontakt = slicice.Kontakt,
                              Filter = slicice.Filter,
                              Album = slicice.Album.Naziv,
                              Korisnik = slicice.Korisnik,
                              Naziv = slicice.Naziv,
                              Opis = slicice.Opis,
                              Id = slicice.Id,
                              BrojSlicica = slicice.BrojSlicica,
                              DodatneInformacije = slicice.DodatneInformacije,
                              CoverImageUrl = slicice.CoverImageUrl
                          }).ToListAsync();
                    }
                    else
                    {
                        return await _context.Slicice.Where(x => x.Filter.Equals(filter)).Where(x => x.Naziv.Contains(search)).Where(x => x.Album.Naziv.Contains(select))
                          .Select(slicice => new SliciceModel()
                          {
                              Kontakt = slicice.Kontakt,
                              Filter = slicice.Filter,
                              Album = slicice.Album.Naziv,
                              Korisnik = slicice.Korisnik,
                              Naziv = slicice.Naziv,
                              Opis = slicice.Opis,
                              Id = slicice.Id,
                              BrojSlicica = slicice.BrojSlicica,
                              DodatneInformacije = slicice.DodatneInformacije,
                              CoverImageUrl = slicice.CoverImageUrl
                          }).ToListAsync();
                    }
                }
                else if (!String.IsNullOrEmpty(broj))
                {
                    return await _context.Slicice.Where(x => x.Filter.Equals(filter)).Where(x => x.Naziv.Contains(search)).Where(x => x.BrojSlicica.Contains(broj))
                      .Select(slicice => new SliciceModel()
                      {
                          Kontakt = slicice.Kontakt,
                          Filter = slicice.Filter,
                          Album = slicice.Album.Naziv,
                          Korisnik = slicice.Korisnik,
                          Naziv = slicice.Naziv,
                          Opis = slicice.Opis,
                          Id = slicice.Id,
                          BrojSlicica = slicice.BrojSlicica,
                          DodatneInformacije = slicice.DodatneInformacije,
                          CoverImageUrl = slicice.CoverImageUrl
                      }).ToListAsync();
                }
                else
                {
                    return await _context.Slicice.Where(x => x.Filter.Equals(filter)).Where(x => x.Naziv.Contains(search))
                      .Select(slicice => new SliciceModel()
                      {
                          Kontakt = slicice.Kontakt,
                          Filter = slicice.Filter,
                          Album = slicice.Album.Naziv,
                          Korisnik = slicice.Korisnik,
                          Naziv = slicice.Naziv,
                          Opis = slicice.Opis,
                          Id = slicice.Id,
                          BrojSlicica = slicice.BrojSlicica,
                          DodatneInformacije = slicice.DodatneInformacije,
                          CoverImageUrl = slicice.CoverImageUrl
                      }).ToListAsync();
                }
            }
            else if (!String.IsNullOrEmpty(select))
            {
                if (!String.IsNullOrEmpty(broj))
                {
                    return await _context.Slicice.Where(x => x.Filter.Equals(filter)).Where(x => x.Album.Naziv.Contains(select)).Where(x => x.BrojSlicica.Contains(broj))
                      .Select(slicice => new SliciceModel()
                      {
                          Kontakt = slicice.Kontakt,
                          Filter = slicice.Filter,
                          Album = slicice.Album.Naziv,
                          Korisnik = slicice.Korisnik,
                          Naziv = slicice.Naziv,
                          Opis = slicice.Opis,
                          Id = slicice.Id,
                          BrojSlicica = slicice.BrojSlicica,
                          DodatneInformacije = slicice.DodatneInformacije,
                          CoverImageUrl = slicice.CoverImageUrl
                      }).ToListAsync();
                }
                else
                {
                    return await _context.Slicice.Where(x => x.Filter.Equals(filter)).Where(x => x.Album.Naziv.Contains(select))
                      .Select(slicice => new SliciceModel()
                      {
                          Kontakt = slicice.Kontakt,
                          Filter = slicice.Filter,
                          Album = slicice.Album.Naziv,
                          Korisnik = slicice.Korisnik,
                          Naziv = slicice.Naziv,
                          Opis = slicice.Opis,
                          Id = slicice.Id,
                          BrojSlicica = slicice.BrojSlicica,
                          DodatneInformacije = slicice.DodatneInformacije,
                          CoverImageUrl = slicice.CoverImageUrl
                      }).ToListAsync();
                }
            }
            else if (!String.IsNullOrEmpty(broj))
            {
                return await _context.Slicice.Where(x => x.Filter.Equals(filter)).Where(x => x.BrojSlicica.Contains(broj))
                  .Select(slicice => new SliciceModel()
                  {
                      Kontakt = slicice.Kontakt,
                      Filter = slicice.Filter,
                      Album = slicice.Album.Naziv,
                      Korisnik = slicice.Korisnik,
                      Naziv = slicice.Naziv,
                      Opis = slicice.Opis,
                      Id = slicice.Id,
                      BrojSlicica = slicice.BrojSlicica,
                      DodatneInformacije = slicice.DodatneInformacije,
                      CoverImageUrl = slicice.CoverImageUrl
                  }).ToListAsync();
            }
            else
            {
                if (!String.IsNullOrEmpty(filter))
                {
                    return await _context.Slicice.Where(x => x.Filter.Equals(filter))
                  .Select(slicice => new SliciceModel()
                  {
                      Kontakt = slicice.Kontakt,
                      Filter = slicice.Filter,
                      Album = slicice.Album.Naziv,
                      Korisnik = slicice.Korisnik,
                      Naziv = slicice.Naziv,
                      Opis = slicice.Opis,
                      Id = slicice.Id,
                      BrojSlicica = slicice.BrojSlicica,
                      DodatneInformacije = slicice.DodatneInformacije,
                      CoverImageUrl = slicice.CoverImageUrl
                  }).ToListAsync();
                }
                else
                {
                    return await _context.Slicice.Where(x => x.Filter.Equals("Kupujem"))
                  .Select(slicice => new SliciceModel()
                  {
                      Kontakt = slicice.Kontakt,
                      Filter = slicice.Filter,
                      Album = slicice.Album.Naziv,
                      Korisnik = slicice.Korisnik,
                      Naziv = slicice.Naziv,
                      Opis = slicice.Opis,
                      Id = slicice.Id,
                      BrojSlicica = slicice.BrojSlicica,
                      DodatneInformacije = slicice.DodatneInformacije,
                      CoverImageUrl = slicice.CoverImageUrl
                  }).ToListAsync();
                }

            }
        }
        public async Task<SliciceModel> GetSliciceById(int id)
        {
            return await _context.Slicice.Where(x => x.Id == id)
                 .Select(slicice => new SliciceModel()
                 {
                     Kontakt = slicice.Kontakt,
                     Filter = slicice.Filter,
                     Izdavac = slicice.Izdavac,
                     GodinaIzdanja = slicice.GodinaIzdanja,
                     AlbumId = slicice.AlbumId,
                     Album = slicice.Album.Naziv,
                     ZamjenaId = slicice.ZamjenaId,
                     Zamjena = slicice.Zamjena.Nacin,
                     Korisnik = slicice.Korisnik,
                     Naziv = slicice.Naziv,
                     Opis = slicice.Opis,
                     Id = slicice.Id,
                     BrojSlicica = slicice.BrojSlicica,
                     DodatneInformacije = slicice.DodatneInformacije,
                     CoverImageUrl = slicice.CoverImageUrl,
                     Gallery = slicice.sliciceGallery.Select(g => new GalleryModel()
                     {
                         Id = g.Id,
                         Naziv = g.Naziv,
                         URL = g.URL
                     }).ToList()
                 }).FirstOrDefaultAsync();
        }

        public List<SliciceModel> SearchSlicice(string Naziv)
        {
            return null;
        }

        //public string GetAppName()
        //{
        //    return _configuration["AppName"];
        //}
    }
}
