using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Update.Internal;
using TCGInventory.Data;
using TCGInventory.Models;
using TCGInventory.ViewModels;

namespace TCGInventory.Controllers
{
    public class CardController : Controller
    {
        private readonly Context _context;

        public CardController(Context context)
        {
            _context = context;
        }

        // GET: Card

    public async Task<IActionResult> Index(string filter) //filtro por nombre, visto en clase
        {
            var query = from card in _context.Card select card; // hago la query
            query = query.Include(x=> x.Expansion);  // el include nos trae los elementos de las relaciones

            if (!string.IsNullOrEmpty(filter)) //si el filtro no esta  vacio
            {
                query = query.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
            }

            var cardList = await query.ToListAsync();
            var cardListVM = new CardDetailVM(); 

            // Mapeamos la entidad con el view model para enviar a la vista
            foreach (var item in cardList)
            {
                cardListVM.Cards.Add(new CardVM {
                    Id = item.Id,
                    Name = item.Name,
                    Rarity = (CardVM.Rareza)item.Rarity,//enum
                    ImageUrl = item.ImageUrl,
                    YearReleased = item.YearReleased,
                    Set = item.Set,
                    Score = (CardVM.Puntaje)item.Score,

                    Price = item.Price,
                    ExpansionName = item.Expansion?.Name
                });
            }

            return View(cardListVM);
        }

        // GET: Card/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Card/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Card/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Rarity,Attack,Defense,ImageUrl,YearReleased,Set,Score,Price,CardExpansionId")] Card card)
        {
            ModelState.Remove("Expansion");
            if (ModelState.IsValid)
            {
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Card/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            
            return View(card);
        }

        // POST: Card/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rarity,Attack,Defense,ImageUrl,YearReleased,Set,Score,Price,CardExpansionId")] Card card)
        {
            if (id != card.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Expansion");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.Id))
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
            return View(card);
        }

        // GET: Card/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Card/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Card == null)
            {
                return Problem("Entity set 'Context.Card'  is null.");
            }
            var card = await _context.Card.FindAsync(id);
            if (card != null)
            {
                _context.Card.Remove(card);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
          return (_context.Card?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
