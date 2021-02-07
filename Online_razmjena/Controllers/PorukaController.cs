using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_razmjena.Data;
using Online_razmjena.Models;

namespace Online_razmjena.Controllers
{
    [Authorize]
    public class PorukaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public PorukaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: Poruka
        public async Task<IActionResult> Index()
        {
            var primatelj = User.Identity.Name;
            return View(await _context.Poruke.Where(x => x.Primatelj.Equals(primatelj)).ToListAsync());
        }
        public async Task<IActionResult> Poslano()
        {
            var korisnik = User.Identity.Name;
            return View(await _context.Poruke.Where(x=>x.Korisnik.Equals(korisnik)).ToListAsync());
        }

        // GET: Poruka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var porukaModel = await _context.Poruke
                .FirstOrDefaultAsync(m => m.Id == id);
            if (porukaModel.Procitano == false)
            {
                var Procitaj = _context.Poruke.Where(x => x.Id == id).ToList();
                foreach (var procitano in Procitaj)
                {
                    procitano.Procitano = true;
                }
                var OduzmiNeProc = userManager.Users.Where(x => porukaModel.Primatelj == x.Email).ToList();
                foreach (var neproc in OduzmiNeProc)
                {
                    neproc.NeProcitano = neproc.NeProcitano - 1;
                }
                await _context.SaveChangesAsync();
            }
            if (porukaModel == null)
            {
                return NotFound();
            }

            return View(porukaModel);
        }
        public async Task<IActionResult> DetailsOutbox(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var porukaModel = await _context.Poruke
                .FirstOrDefaultAsync(m => m.Id == id);
            if (porukaModel == null)
            {
                return NotFound();
            }

            return View(porukaModel);
        }

        // GET: Poruka/Create
        public IActionResult Create(string? korisnik)
        {
            if (!String.IsNullOrEmpty(korisnik))
            {
                ViewBag.korisnik = korisnik;
                return View();
            }
            else
            {
                ViewData["Primatelj"] = new SelectList(_context.Users, "UserName", "Email");
                return View();
            }
        }

        // POST: Poruka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Korisnik,Primatelj,Naslov,Tekst")] PorukaModel porukaModel)
        {
            var DodajNeProc = userManager.Users.Where(x => porukaModel.Primatelj == x.Email).ToList();
            foreach (var neproc in DodajNeProc)
            {
                neproc.NeProcitano = neproc.NeProcitano + 1;
            }
            if (ModelState.IsValid)
            {
                _context.Add(porukaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(porukaModel);
        }

        // GET: Poruka/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var porukaModel = await _context.Poruke.FindAsync(id);
        //    if (porukaModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(porukaModel);
        //}

        // POST: Poruka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Korisnik,Primatelj,Naslov,Tekst")] PorukaModel porukaModel)
        //{
        //    if (id != porukaModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(porukaModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PorukaModelExists(porukaModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(porukaModel);
        //}

        // GET: Poruka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var porukaModel = await _context.Poruke
                .FirstOrDefaultAsync(m => m.Id == id);
            if (porukaModel == null)
            {
                return NotFound();
            }

            return View(porukaModel);
        }

        // POST: Poruka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var porukaModel = await _context.Poruke.FindAsync(id);
            _context.Poruke.Remove(porukaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PorukaModelExists(int id)
        {
            return _context.Poruke.Any(e => e.Id == id);
        }
    }
}
