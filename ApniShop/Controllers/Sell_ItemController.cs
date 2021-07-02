using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApniShop.Models;

namespace ApniShop.Controllers
{
    public class Sell_ItemController : Controller
    {
        private readonly Sell_Item_Context _context;

        public Sell_ItemController(Sell_Item_Context context)
        {
            _context = context;
        }

        // GET: Sell_Item
        public async Task<IActionResult> Index()
        {
            return View(await _context.SellItemsDB.ToListAsync());
        }

        // GET: Sell_Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sell_Item = await _context.SellItemsDB
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (sell_Item == null)
            {
                return NotFound();
            }

            return View(sell_Item);
        }

        // GET: Sell_Item/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sell_Item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,ItemUnitPrice,ItemQuantity,ItemDescription")] Sell_Item sell_Item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sell_Item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sell_Item);
        }

        // GET: Sell_Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sell_Item = await _context.SellItemsDB.FindAsync(id);
            if (sell_Item == null)
            {
                return NotFound();
            }
            return View(sell_Item);
        }

        // POST: Sell_Item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,ItemUnitPrice,ItemQuantity,ItemDescription")] Sell_Item sell_Item)
        {
            if (id != sell_Item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sell_Item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sell_ItemExists(sell_Item.ItemId))
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
            return View(sell_Item);
        }

        // GET: Sell_Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sell_Item = await _context.SellItemsDB
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (sell_Item == null)
            {
                return NotFound();
            }

            return View(sell_Item);
        }

        // POST: Sell_Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sell_Item = await _context.SellItemsDB.FindAsync(id);
            _context.SellItemsDB.Remove(sell_Item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sell_ItemExists(int id)
        {
            return _context.SellItemsDB.Any(e => e.ItemId == id);
        }
    }
}
