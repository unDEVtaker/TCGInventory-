using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCGInventory.Data;
using TCGInventory.Models;

namespace TCGInventory.Controllers
{
    public class CardExpansionsController : Controller
    {
        private readonly Context _context;

        public CardExpansionsController(Context context)
        {
            _context = context;
        }

        // GET: CardExpansions
        public async Task<IActionResult> Index()
        {
              return _context.CardExpansion != null ? 
                          View(await _context.CardExpansion.ToListAsync()) :
                          Problem("Entity set 'Context.CardExpansion'  is null.");
        }

        // GET: CardExpansions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CardExpansion == null)
            {
                return NotFound();
            }

            var cardExpansion = await _context.CardExpansion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardExpansion == null)
            {
                return NotFound();
            }

            return View(cardExpansion);
        }

        // GET: CardExpansions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardExpansions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Company,Price,ImageUrl")] CardExpansion cardExpansion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardExpansion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardExpansion);
        }

        // GET: CardExpansions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CardExpansion == null)
            {
                return NotFound();
            }

            var cardExpansion = await _context.CardExpansion.FindAsync(id);
            if (cardExpansion == null)
            {
                return NotFound();
            }
            return View(cardExpansion);
        }

        // POST: CardExpansions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Company,Price,ImageUrl")] CardExpansion cardExpansion)
        {
            if (id != cardExpansion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardExpansion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExpansionExists(cardExpansion.Id))
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
            return View(cardExpansion);
        }

        // GET: CardExpansions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CardExpansion == null)
            {
                return NotFound();
            }

            var cardExpansion = await _context.CardExpansion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardExpansion == null)
            {
                return NotFound();
            }

            return View(cardExpansion);
        }

        // POST: CardExpansions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CardExpansion == null)
            {
                return Problem("Entity set 'Context.CardExpansion'  is null.");
            }
            var cardExpansion = await _context.CardExpansion.FindAsync(id);
            if (cardExpansion != null)
            {
                _context.CardExpansion.Remove(cardExpansion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExpansionExists(int id)
        {
          return (_context.CardExpansion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
