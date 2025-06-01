using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlDeGastos.Data;
using ControlDeGastos.Models;

namespace ControlDeGastos.Pages_Presupuesto
{
    public class EditModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public EditModel(ControlDeGastos.Data.ControlDeGastosContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PresupuestoModel PresupuestoModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestomodel =  await _context.Presupuestos.FirstOrDefaultAsync(m => m.rowid == id);
            if (presupuestomodel == null)
            {
                return NotFound();
            }
            PresupuestoModel = presupuestomodel;
           ViewData["tipo_gasto_id"] = new SelectList(_context.TiposGasto, "rowid", "codigo");
           ViewData["usuario_id"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {


            _context.Attach(PresupuestoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresupuestoModelExists(PresupuestoModel.rowid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PresupuestoModelExists(int id)
        {
            return _context.Presupuestos.Any(e => e.rowid == id);
        }
    }
}
