using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using F1Lib.Models;
using F1Project.Data;

namespace F1Project.Controllers
{
    public class CircuitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CircuitController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Circuit
        public async Task<IActionResult> Index(string? id = "")
        {
            var circuitsList = _context.Drivers.ToList();

            return View(circuitsList.Where(r => r.Name == id));
        }

        // GET: Circuit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Circuits == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuits
                .FirstOrDefaultAsync(m => m.ID == id);
            if (circuit == null)
            {
                return NotFound();
            }

            return View(circuit);
        }

        // GET: Circuit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Circuit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Latitute,Longitute,Wiki")] Circuit circuit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(circuit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(circuit);
        }

        // GET: Circuit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Circuits == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuits.FindAsync(id);
            if (circuit == null)
            {
                return NotFound();
            }
            return View(circuit);
        }

        // POST: Circuit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Latitute,Longitute,Wiki")] Circuit circuit)
        {
            if (id != circuit.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(circuit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CircuitExists(circuit.ID))
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
            return View(circuit);
        }

        // GET: Circuit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Circuits == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuits
                .FirstOrDefaultAsync(m => m.ID == id);
            if (circuit == null)
            {
                return NotFound();
            }

            return View(circuit);
        }

        // POST: Circuit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Circuits == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Circuits'  is null.");
            }
            var circuit = await _context.Circuits.FindAsync(id);
            if (circuit != null)
            {
                _context.Circuits.Remove(circuit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CircuitExists(int id)
        {
          return (_context.Circuits?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
