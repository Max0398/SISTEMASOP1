using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContratosOP1.Data;
using ContratosOP1.Models;

namespace ContratosOP1.Controllers
{
    public class UnidadController : Controller
    {
        private readonly ContratosContainer _context;

        public UnidadController(ContratosContainer context)
        {
            _context = context;
        }

        // GET: Unidad
        public async Task<IActionResult> Index()
        {
              return _context.Unidades != null ? 
                          View(await _context.Unidades.ToListAsync()) :
                          Problem("Entity set 'ContratosContainer.Unidades'  is null.");
        }

        // GET: Unidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // GET: Unidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoUnidad,DescripcionUnidad")] Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidad);
        }

        // GET: Unidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidades.FindAsync(id);
            if (unidad == null)
            {
                return NotFound();
            }
            return View(unidad);
        }

        // POST: Unidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoUnidad,DescripcionUnidad")] Unidad unidad)
        {
            if (id != unidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadExists(unidad.Id))
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
            return View(unidad);
        }

        // GET: Unidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // POST: Unidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Unidades == null)
            {
                return Problem("Entity set 'ContratosContainer.Unidades'  is null.");
            }
            var unidad = await _context.Unidades.FindAsync(id);
            if (unidad != null)
            {
                _context.Unidades.Remove(unidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadExists(int id)
        {
          return (_context.Unidades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
