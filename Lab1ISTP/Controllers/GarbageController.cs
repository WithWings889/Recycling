using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab1ISTP;

namespace Lab1ISTP.Controllers
{
    public class GarbageController : Controller
    {
        private readonly RecyclingContext _context;

        public GarbageController(RecyclingContext context)
        {
            _context = context;
        }

        // GET: Garbage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Garbage.ToListAsync());
        }

        // GET: Garbage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garbage = await _context.Garbage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garbage == null)
            {
                return NotFound();
            }

            //return View(garbage);
            return RedirectToAction("Index", "Materials", new { id = garbage.Id, name = garbage.Name });
        }

        // GET: Garbage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Garbage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Info")] Garbage garbage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garbage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garbage);
        }

        // GET: Garbage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garbage = await _context.Garbage.FindAsync(id);
            if (garbage == null)
            {
                return NotFound();
            }
            return View(garbage);
        }

        // POST: Garbage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Info")] Garbage garbage)
        {
            if (id != garbage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garbage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarbageExists(garbage.Id))
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
            return View(garbage);
        }

        // GET: Garbage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garbage = await _context.Garbage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garbage == null)
            {
                return NotFound();
            }

            return View(garbage);
        }

        // POST: Garbage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garbage = await _context.Garbage.FindAsync(id);
            _context.Garbage.Remove(garbage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarbageExists(int id)
        {
            return _context.Garbage.Any(e => e.Id == id);
        }
    }
}
