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
    public class ContratacionController : Controller
    {
        private readonly ContratosContainer _context;

        public ContratacionController(ContratosContainer context)
        {
            _context = context;
        }

        // GET: Contratacion
        public async Task<IActionResult> Index()
        {
            var contratosContainer = _context.Contrataciones.Include(c => c.Cargo).Include(c => c.Empleado).Include(c => c.TipoDeContrato).Include(c => c.Unidad);
            return View(await contratosContainer.ToListAsync());
        }

        // GET: Contratacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contrataciones == null)
            {
                return NotFound();
            }

            var contratacion = await _context.Contrataciones
                .Include(c => c.Cargo)
                .Include(c => c.Empleado)
                .Include(c => c.TipoDeContrato)
                .Include(c => c.Unidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratacion == null)
            {
                return NotFound();
            }

            return View(contratacion);
        }

        // GET: Contratacion/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Codigo");
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido1");
            ViewData["TipoDeContratoId"] = new SelectList(_context.TipoDeContratos, "Id", "CodigoTipo");
            ViewData["UnidadId"] = new SelectList(_context.Unidades, "Id", "CodigoUnidad");
            return View();
        }

        // POST: Contratacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpleadoId,CargoId,Salario,FechaInicio,FechaFin,Activo,TipoDeContratoId,UnidadId")] Contratacion contratacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Codigo", contratacion.CargoId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido1", contratacion.EmpleadoId);
            ViewData["TipoDeContratoId"] = new SelectList(_context.TipoDeContratos, "Id", "CodigoTipo", contratacion.TipoDeContratoId);
            ViewData["UnidadId"] = new SelectList(_context.Unidades, "Id", "CodigoUnidad", contratacion.UnidadId);
            return View(contratacion);
        }

        // GET: Contratacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contrataciones == null)
            {
                return NotFound();
            }

            var contratacion = await _context.Contrataciones.FindAsync(id);
            if (contratacion == null)
            {
                return NotFound();
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Codigo", contratacion.CargoId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido1", contratacion.EmpleadoId);
            ViewData["TipoDeContratoId"] = new SelectList(_context.TipoDeContratos, "Id", "CodigoTipo", contratacion.TipoDeContratoId);
            ViewData["UnidadId"] = new SelectList(_context.Unidades, "Id", "CodigoUnidad", contratacion.UnidadId);
            return View(contratacion);
        }

        // POST: Contratacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpleadoId,CargoId,Salario,FechaInicio,FechaFin,Activo,TipoDeContratoId,UnidadId")] Contratacion contratacion)
        {
            if (id != contratacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratacionExists(contratacion.Id))
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
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Codigo", contratacion.CargoId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido1", contratacion.EmpleadoId);
            ViewData["TipoDeContratoId"] = new SelectList(_context.TipoDeContratos, "Id", "CodigoTipo", contratacion.TipoDeContratoId);
            ViewData["UnidadId"] = new SelectList(_context.Unidades, "Id", "CodigoUnidad", contratacion.UnidadId);
            return View(contratacion);
        }

        // GET: Contratacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contrataciones == null)
            {
                return NotFound();
            }

            var contratacion = await _context.Contrataciones
                .Include(c => c.Cargo)
                .Include(c => c.Empleado)
                .Include(c => c.TipoDeContrato)
                .Include(c => c.Unidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratacion == null)
            {
                return NotFound();
            }

            return View(contratacion);
        }

        // POST: Contratacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contrataciones == null)
            {
                return Problem("Entity set 'ContratosContainer.Contrataciones'  is null.");
            }
            var contratacion = await _context.Contrataciones.FindAsync(id);
            if (contratacion != null)
            {
                _context.Contrataciones.Remove(contratacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratacionExists(int id)
        {
          return (_context.Contrataciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
