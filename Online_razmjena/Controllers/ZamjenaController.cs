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
    public class ZamjenaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZamjenaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zamjena
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zamjene.ToListAsync());
        }

        // GET: Zamjena/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamjenaModel = await _context.Zamjene
                .FirstOrDefaultAsync(m => m.ZamjenaId == id);
            if (zamjenaModel == null)
            {
                return NotFound();
            }

            return View(zamjenaModel);
        }

        // GET: Zamjena/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zamjena/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZamjenaId,Način")] ZamjenaModel zamjenaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamjenaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zamjenaModel);
        }

        // GET: Zamjena/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamjenaModel = await _context.Zamjene.FindAsync(id);
            if (zamjenaModel == null)
            {
                return NotFound();
            }
            return View(zamjenaModel);
        }

        // POST: Zamjena/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZamjenaId,Način")] ZamjenaModel zamjenaModel)
        {
            if (id != zamjenaModel.ZamjenaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamjenaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamjenaModelExists(zamjenaModel.ZamjenaId))
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
            return View(zamjenaModel);
        }

        // GET: Zamjena/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamjenaModel = await _context.Zamjene
                .FirstOrDefaultAsync(m => m.ZamjenaId == id);
            if (zamjenaModel == null)
            {
                return NotFound();
            }

            return View(zamjenaModel);
        }

        // POST: Zamjena/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamjenaModel = await _context.Zamjene.FindAsync(id);
            _context.Zamjene.Remove(zamjenaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamjenaModelExists(int id)
        {
            return _context.Zamjene.Any(e => e.ZamjenaId == id);
        }
    }
}
