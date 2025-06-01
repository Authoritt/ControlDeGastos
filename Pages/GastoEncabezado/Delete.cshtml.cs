using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlDeGastos.Data;
using ControlDeGastos.Models;

namespace ControlDeGastos.Pages_GastoEncabezado
{
    public class DeleteModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public DeleteModel(ControlDeGastos.Data.ControlDeGastosContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GastoEncabezadoModel GastoEncabezadoModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastoencabezadomodel = await _context.GastosEncabezado.FirstOrDefaultAsync(m => m.rowid == id);

            if (gastoencabezadomodel is not null)
            {
                GastoEncabezadoModel = gastoencabezadomodel;

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

            var gastoencabezadomodel = await _context.GastosEncabezado.FindAsync(id);
            if (gastoencabezadomodel != null)
            {
                GastoEncabezadoModel = gastoencabezadomodel;
                _context.GastosEncabezado.Remove(GastoEncabezadoModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
