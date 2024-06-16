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
    public class TipoDeContratosController : Controller
    {
        private readonly ContratosContainer _context;

        public TipoDeContratosController(ContratosContainer context)
        {
            _context = context;
        }

        // GET: TipoDeContratos
        public async Task<IActionResult> Index()
        {
              return _context.TipoDeContratos != null ? 
                          View(await _context.TipoDeContratos.ToListAsync()) :
                          Problem("Entity set 'ContratosContainer.TipoDeContratos'  is null.");
        }

        // GET: TipoDeContratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoDeContratos == null)
            {
                return NotFound();
            }

            var tipoDeContrato = await _context.TipoDeContratos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeContrato == null)
            {
                return NotFound();
            }

            return View(tipoDeContrato);
        }

        // GET: TipoDeContratos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeContratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoTipo,DescripcionTipo")] TipoDeContrato tipoDeContrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeContrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeContrato);
        }

        // GET: TipoDeContratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoDeContratos == null)
            {
                return NotFound();
            }

            var tipoDeContrato = await _context.TipoDeContratos.FindAsync(id);
            if (tipoDeContrato == null)
            {
                return NotFound();
            }
            return View(tipoDeContrato);
        }

        // POST: TipoDeContratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoTipo,DescripcionTipo")] TipoDeContrato tipoDeContrato)
        {
            if (id != tipoDeContrato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeContrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeContratoExists(tipoDeContrato.Id))
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
            return View(tipoDeContrato);
        }

        // GET: TipoDeContratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoDeContratos == null)
            {
                return NotFound();
            }

            var tipoDeContrato = await _context.TipoDeContratos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeContrato == null)
            {
                return NotFound();
            }

            return View(tipoDeContrato);
        }

        // POST: TipoDeContratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoDeContratos == null)
            {
                return Problem("Entity set 'ContratosContainer.TipoDeContratos'  is null.");
            }
            var tipoDeContrato = await _context.TipoDeContratos.FindAsync(id);
            if (tipoDeContrato != null)
            {
                _context.TipoDeContratos.Remove(tipoDeContrato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeContratoExists(int id)
        {
          return (_context.TipoDeContratos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
