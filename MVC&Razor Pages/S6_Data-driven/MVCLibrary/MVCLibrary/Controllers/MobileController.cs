using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCLibrary.Models;

namespace MVCLibrary.Controllers
{
    public class MobileController : Controller
    {
        private readonly MobileContext _context;

        public MobileController(MobileContext context)
        {
            _context = context;
        }

        // GET: Mobile
        public async Task<IActionResult> Index()
        {
              return _context.Mobiles != null ? 
                          View(await _context.Mobiles.ToListAsync()) :
                          Problem("Entity set 'MobileContext.Mobiles'  is null.");
        }

        // GET: Mobile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mobiles == null)
            {
                return NotFound();
            }

            var mobiles = await _context.Mobiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobiles == null)
            {
                return NotFound();
            }

            return View(mobiles);
        }

        // GET: Mobile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mobile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Ram,Rom")] Mobiles mobiles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobiles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobiles);
        }

        // GET: Mobile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mobiles == null)
            {
                return NotFound();
            }

            var mobiles = await _context.Mobiles.FindAsync(id);
            if (mobiles == null)
            {
                return NotFound();
            }
            return View(mobiles);
        }

        // POST: Mobile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Ram,Rom")] Mobiles mobiles)
        {
            if (id != mobiles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobiles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobilesExists(mobiles.Id))
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
            return View(mobiles);
        }

        // GET: Mobile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mobiles == null)
            {
                return NotFound();
            }

            var mobiles = await _context.Mobiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobiles == null)
            {
                return NotFound();
            }

            return View(mobiles);
        }

        // POST: Mobile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mobiles == null)
            {
                return Problem("Entity set 'MobileContext.Mobiles'  is null.");
            }
            var mobiles = await _context.Mobiles.FindAsync(id);
            if (mobiles != null)
            {
                _context.Mobiles.Remove(mobiles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobilesExists(int id)
        {
          return (_context.Mobiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
