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

namespace ControlDeGastos.Pages_GastoEncabezado
{
    public class EditModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public EditModel(ControlDeGastos.Data.ControlDeGastosContext context)
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

            var gastoencabezadomodel =  await _context.GastosEncabezado.FirstOrDefaultAsync(m => m.rowid == id);
            if (gastoencabezadomodel == null)
            {
                return NotFound();
            }
            GastoEncabezadoModel = gastoencabezadomodel;
           ViewData["fondo_monetario_id"] = new SelectList(_context.FondosMonetarios, "rowid", "nombre");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(GastoEncabezadoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GastoEncabezadoModelExists(GastoEncabezadoModel.rowid))
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

        private bool GastoEncabezadoModelExists(int id)
        {
            return _context.GastosEncabezado.Any(e => e.rowid == id);
        }
    }
}
