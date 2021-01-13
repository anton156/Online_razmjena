using Microsoft.EntityFrameworkCore;
using Online_razmjena.Data;
using Online_razmjena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Repository
{
    public class AlbumRepository
    {
        private readonly ApplicationDbContext _context = null;


        public AlbumRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AlbumModel>> GetAlbum()
        {
            return await _context.Albumi.Select(x => new AlbumModel()
            {
                AlbumId=x.AlbumId,
                Naziv=x.Naziv
            }).ToListAsync();
        }
    }
}
