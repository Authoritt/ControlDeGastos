using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlDeGastos.Data;
using ControlDeGastosControlDeGastos.Models;

namespace ControlDeGastos.Controllers
{
    public class TipoGastoController : Controller
    {
        private readonly ControlDeGastosContext _context;

        public TipoGastoController(ControlDeGastosContext context)
        {
            _context = context;
        }

        // GET: TipoGasto
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposGasto.ToListAsync());
        }

        // GET: TipoGasto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoGastoModel = await _context.TiposGasto
                .FirstOrDefaultAsync(m => m.rowid == id);
            if (tipoGastoModel == null)
            {
                return NotFound();
            }

            return View(tipoGastoModel);
        }

        // GET: TipoGasto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoGasto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("rowid,nombre,Descripcion")] TipoGastoModel tipoGastoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoGastoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoGastoModel);
        }

        // GET: TipoGasto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoGastoModel = await _context.TiposGasto.FindAsync(id);
            if (tipoGastoModel == null)
            {
                return NotFound();
            }
            return View(tipoGastoModel);
        }

        // POST: TipoGasto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("rowid,nombre,Descripcion")] TipoGastoModel tipoGastoModel)
        {
            if (id != tipoGastoModel.rowid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoGastoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoGastoModelExists(tipoGastoModel.rowid))
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
            return View(tipoGastoModel);
        }

        // GET: TipoGasto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoGastoModel = await _context.TiposGasto
                .FirstOrDefaultAsync(m => m.rowid == id);
            if (tipoGastoModel == null)
            {
                return NotFound();
            }

            return View(tipoGastoModel);
        }

        // POST: TipoGasto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoGastoModel = await _context.TiposGasto.FindAsync(id);
            if (tipoGastoModel != null)
            {
                _context.TiposGasto.Remove(tipoGastoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoGastoModelExists(int id)
        {
            return _context.TiposGasto.Any(e => e.rowid == id);
        }
    }
}
