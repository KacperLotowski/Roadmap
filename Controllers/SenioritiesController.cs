using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Roadmap.Data;
using Roadmap.Models;

namespace Roadmap.Controllers
{
    public class SenioritiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SenioritiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seniorities
        public async Task<IActionResult> Index()
        {
              return View(await _context.Seniority.ToListAsync());
        }

        // GET: Seniorities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Seniority == null)
            {
                return NotFound();
            }

            var seniority = await _context.Seniority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seniority == null)
            {
                return NotFound();
            }

            return View(seniority);
        }

        // GET: Seniorities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seniorities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Seniority seniority)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seniority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seniority);
        }

        // GET: Seniorities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Seniority == null)
            {
                return NotFound();
            }

            var seniority = await _context.Seniority.FindAsync(id);
            if (seniority == null)
            {
                return NotFound();
            }
            return View(seniority);
        }

        // POST: Seniorities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Seniority seniority)
        {
            if (id != seniority.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seniority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeniorityExists(seniority.Id))
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
            return View(seniority);
        }

        // GET: Seniorities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Seniority == null)
            {
                return NotFound();
            }

            var seniority = await _context.Seniority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seniority == null)
            {
                return NotFound();
            }

            return View(seniority);
        }

        // POST: Seniorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Seniority == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Seniority'  is null.");
            }
            var seniority = await _context.Seniority.FindAsync(id);
            if (seniority != null)
            {
                _context.Seniority.Remove(seniority);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeniorityExists(int id)
        {
          return _context.Seniority.Any(e => e.Id == id);
        }
    }
}
