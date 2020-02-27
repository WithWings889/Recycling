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
    public class GarbageTypesController : Controller
    {
        private readonly RecyclingContext _context;

        public GarbageTypesController(RecyclingContext context)
        {
            _context = context;
        }

        // GET: GarbageTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GarbageType.ToListAsync());
        }

        // GET: GarbageTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garbageType = await _context.GarbageType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garbageType == null)
            {
                return NotFound();
            }

            return View(garbageType);
        }

        // GET: GarbageTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GarbageTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] GarbageType garbageType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garbageType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garbageType);
        }

        // GET: GarbageTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garbageType = await _context.GarbageType.FindAsync(id);
            if (garbageType == null)
            {
                return NotFound();
            }
            return View(garbageType);
        }

        // POST: GarbageTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] GarbageType garbageType)
        {
            if (id != garbageType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garbageType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarbageTypeExists(garbageType.Id))
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
            return View(garbageType);
        }

        // GET: GarbageTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garbageType = await _context.GarbageType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garbageType == null)
            {
                return NotFound();
            }

            return View(garbageType);
        }

        // POST: GarbageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garbageType = await _context.GarbageType.FindAsync(id);
            _context.GarbageType.Remove(garbageType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarbageTypeExists(int id)
        {
            return _context.GarbageType.Any(e => e.Id == id);
        }
    }
}
