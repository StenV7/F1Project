using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using F1Project.Data;
using F1Project.Models;

namespace F1Project.Controllers
{
    public class GrandprixController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GrandprixController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Grandprix
        public async Task<IActionResult> Index()
        {
              return _context.Grandprix != null ? 
                          View(await _context.Grandprix.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Grandprix'  is null.");
        }

        // GET: Grandprix/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grandprix == null)
            {
                return NotFound();
            }

            var grandprix = await _context.Grandprix
                .FirstOrDefaultAsync(m => m.ID == id);
            if (grandprix == null)
            {
                return NotFound();
            }

            return View(grandprix);
        }

        // GET: Grandprix/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grandprix/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Wiki")] Grandprix grandprix)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grandprix);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grandprix);
        }

        // GET: Grandprix/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grandprix == null)
            {
                return NotFound();
            }

            var grandprix = await _context.Grandprix.FindAsync(id);
            if (grandprix == null)
            {
                return NotFound();
            }
            return View(grandprix);
        }

        // POST: Grandprix/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Wiki")] Grandprix grandprix)
        {
            if (id != grandprix.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grandprix);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrandprixExists(grandprix.ID))
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
            return View(grandprix);
        }

        // GET: Grandprix/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grandprix == null)
            {
                return NotFound();
            }

            var grandprix = await _context.Grandprix
                .FirstOrDefaultAsync(m => m.ID == id);
            if (grandprix == null)
            {
                return NotFound();
            }

            return View(grandprix);
        }

        // POST: Grandprix/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grandprix == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Grandprix'  is null.");
            }
            var grandprix = await _context.Grandprix.FindAsync(id);
            if (grandprix != null)
            {
                _context.Grandprix.Remove(grandprix);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrandprixExists(int id)
        {
          return (_context.Grandprix?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
