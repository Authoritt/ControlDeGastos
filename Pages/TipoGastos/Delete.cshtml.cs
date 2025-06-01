using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlDeGastos.Data;
using ControlDeGastosControlDeGastos.Models;

namespace ControlDeGastos.Pages_TipoGastos
{
    public class DeleteModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public DeleteModel(ControlDeGastos.Data.ControlDeGastosContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TipoGastoModel TipoGastoModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipogastomodel = await _context.TiposGasto.FirstOrDefaultAsync(m => m.rowid == id);

            if (tipogastomodel is not null)
            {
                TipoGastoModel = tipogastomodel;

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

            var tipogastomodel = await _context.TiposGasto.FindAsync(id);
            if (tipogastomodel != null)
            {
                TipoGastoModel = tipogastomodel;
                _context.TiposGasto.Remove(TipoGastoModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
