using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using employee_and_unit_management_system.Data;
using employee_and_unit_management_system.Models;

namespace employee_and_unit_management_system.Controllers
{
    public class CollaboratorController : Controller
    {
        private readonly DataContext _context;

        public CollaboratorController(DataContext context)
        {
            _context = context;
        }

        // GET: Collaborator
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Collaborator.Include(c => c.Unit);
            return View(await dataContext.ToListAsync());
        }

        // GET: Collaborator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborator = await _context.Collaborator
                .Include(c => c.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collaborator == null)
            {
                return NotFound();
            }

            return View(collaborator);
        }

        // GET: Collaborator/Create
        public IActionResult Create()
        {
            ViewData["UnitId"] = new SelectList(_context.Unit.Where(x => x.Status).ToList(), "Id", "Name");
            return View();
        }

        // POST: Collaborator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UnitId")] Collaborator collaborator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collaborator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnitId"] = new SelectList(_context.Unit, "Id", "Id", collaborator.UnitId);
            return View(collaborator);
        }

        // GET: Collaborator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborator = await _context.Collaborator.FindAsync(id);
            if (collaborator == null)
            {
                return NotFound();
            }
            ViewData["UnitId"] = new SelectList(_context.Unit.Where(x => x.Status).ToList(), "Id", "Name", collaborator.UnitId);
            return View(collaborator);
        }

        // POST: Collaborator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UnitId")] Collaborator collaborator)
        {
            if (id != collaborator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collaborator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollaboratorExists(collaborator.Id))
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
            ViewData["UnitId"] = new SelectList(_context.Unit, "Id", "Id", collaborator.UnitId);
            return View(collaborator);
        }

        // GET: Collaborator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborator = await _context.Collaborator
                .Include(c => c.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collaborator == null)
            {
                return NotFound();
            }

            return View(collaborator);
        }

        // POST: Collaborator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collaborator = await _context.Collaborator.FindAsync(id);
            if (collaborator != null)
            {
                _context.Collaborator.Remove(collaborator);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollaboratorExists(int id)
        {
            return _context.Collaborator.Any(e => e.Id == id);
        }
    }
}
