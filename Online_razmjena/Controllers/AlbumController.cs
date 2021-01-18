using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_razmjena.Data;
using Online_razmjena.Models;

namespace Online_razmjena.Controllers
{
    public class AlbumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlbumController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Album
        public async Task<IActionResult> Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var album = _context.Albumi.AsNoTracking().Where(x => x.Naziv.Contains(search)).OrderBy(s => s.AlbumId);
                //var model = await PagingList.CreateAsync(roles, 5, page);
                return View(album);
            }
            else
            {
                var album = _context.Albumi.AsNoTracking().OrderBy(s => s.AlbumId);
                //var model = await PagingList.CreateAsync(roles, 5, page);
                return View(album);
            }
        }

        // GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumModel = await _context.Albumi
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (albumModel == null)
            {
                return NotFound();
            }

            return View(albumModel);
        }

        // GET: Album/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumId,Naziv")] Album albumModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(albumModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(albumModel);
        }

        // GET: Album/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumModel = await _context.Albumi.FindAsync(id);
            if (albumModel == null)
            {
                return NotFound();
            }
            return View(albumModel);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,Naziv")] Album albumModel)
        {
            if (id != albumModel.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(albumModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumModelExists(albumModel.AlbumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(albumModel);
        }

        // GET: Album/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumModel = await _context.Albumi
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (albumModel == null)
            {
                return NotFound();
            }

            return View(albumModel);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var albumModel = await _context.Albumi.FindAsync(id);
            _context.Albumi.Remove(albumModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumModelExists(int id)
        {
            return _context.Albumi.Any(e => e.AlbumId == id);
        }
    }
}
