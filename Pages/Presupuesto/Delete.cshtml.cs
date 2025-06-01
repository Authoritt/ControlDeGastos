using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlDeGastos.Data;
using ControlDeGastos.Models;

namespace ControlDeGastos.Pages_Presupuesto
{
    public class DeleteModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public DeleteModel(ControlDeGastos.Data.ControlDeGastosContext context)
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

            var presupuestomodel = await _context.Presupuestos.FirstOrDefaultAsync(m => m.rowid == id);

            if (presupuestomodel is not null)
            {
                PresupuestoModel = presupuestomodel;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestomodel = await _context.Presupuestos.FindAsync(id);
            if (presupuestomodel != null)
            {
                PresupuestoModel = presupuestomodel;
                _context.Presupuestos.Remove(PresupuestoModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
