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
    public class ResultController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResultController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Result
        public async Task<IActionResult> Index(int? id = 0, int filter = 0)
        {
            ViewBag.Id = id;
            List<int> years = new List<int>();
            for (int i = DateTime.Now.Year; i >= 1950; i--)
            {
                years.Add(i);
            }
            int loadCount = 0;
            if (filter == 0)
            {
                loadCount = loadCount + 1;
                filter = years[0];
            }

            ViewBag.Year = new SelectList(years, filter);



            var resultsList = await _context.Results.Include(x => x.Driver).ThenInclude(g => g.Country).Include(z => z.Circuit).Include(n => n.Team).ThenInclude(h => h.Country).Include(j => j.Grandprix).OrderBy(d => d.Racenumber).ToListAsync();


            if (loadCount == 1)
            {
                


                if (filter > 0)
                {

                    resultsList = resultsList.Where(r => r.Year == id).ToList();

                }
                if (resultsList == null)
                {
                    return Problem("Entity set ApplicationDbContext.Results is null");
                }
                return View(resultsList);
            }
            else if (filter != null)
            {
                if (filter > 0)
                {
                    resultsList = resultsList.Where(r => r.Year == filter).ToList();
                }
                if (resultsList == null)
                {
                    return Problem("Entity set ApplicationDbContext.Results is null");
                }
                return View(resultsList);
            }
            return View(resultsList);
        }

        // GET: Result/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Results == null)
            {
                return NotFound();
            }

            var result = await _context.Results
                .FirstOrDefaultAsync(m => m.ID == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: Result/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Result/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Year,Racenumber,Date,Rounds,Time")] Result result)
        {
            if (ModelState.IsValid)
            {
                _context.Add(result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(result);
        }

        // GET: Result/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Results == null)
            {
                return NotFound();
            }

            var result = await _context.Results.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Result/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Year,Racenumber,Date,Rounds,Time")] Result result)
        {
            if (id != result.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(result);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultExists(result.ID))
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
            return View(result);
        }

        // GET: Result/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Results == null)
            {
                return NotFound();
            }

            var result = await _context.Results
                .FirstOrDefaultAsync(m => m.ID == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Results == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Results'  is null.");
            }
            var result = await _context.Results.FindAsync(id);
            if (result != null)
            {
                _context.Results.Remove(result);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultExists(int id)
        {
            return (_context.Results?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
