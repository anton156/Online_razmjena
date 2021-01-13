using Microsoft.EntityFrameworkCore;
using Online_razmjena.Data;
using Online_razmjena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Repository
{
    public class ZamjenaRepository
    {
        private readonly ApplicationDbContext _context = null;


        public ZamjenaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ZamjenaModel>> GetZamjena()
        {
            return await _context.Zamjene.Select(x => new ZamjenaModel()
            {
                ZamjenaId = x.ZamjenaId,
                Nacin = x.Nacin
            }).ToListAsync();
        }
    }
}
