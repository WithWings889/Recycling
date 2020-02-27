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
    public class GarbageFactoriesController : Controller
    {
        private readonly RecyclingContext _context;

        public GarbageFactoriesController(RecyclingContext context)
        {
            _context = context;
        }

        // GET: GarbageFactories
        public async Task<IActionResult> Index()
        {
            return View(await _context.GarbageFactory.ToListAsync());
        }

        // GET: GarbageFactories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garbageFactory = await _context.GarbageFactory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garbageFactory == null)
            {
                return NotFound();
            }

            return View(garbageFactory);
        }

        // GET: GarbageFactories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GarbageFactories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Website")] GarbageFactory garbageFactory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garbageFactory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garbageFactory);
        }

        // GET: GarbageFactories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garbageFactory = await _context.GarbageFactory.FindAsync(id);
            if (garbageFactory == null)
            {
                return NotFound();
            }
            return View(garbageFactory);
        }

        // POST: GarbageFactories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Website")] GarbageFactory garbageFactory)
        {
            if (id != garbageFactory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garbageFactory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarbageFactoryExists(garbageFactory.Id))
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
            return View(garbageFactory);
        }

        // GET: GarbageFactories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garbageFactory = await _context.GarbageFactory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garbageFactory == null)
            {
                return NotFound();
            }

            return View(garbageFactory);
        }

        // POST: GarbageFactories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garbageFactory = await _context.GarbageFactory.FindAsync(id);
            _context.GarbageFactory.Remove(garbageFactory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarbageFactoryExists(int id)
        {
            return _context.GarbageFactory.Any(e => e.Id == id);
        }
    }
}
