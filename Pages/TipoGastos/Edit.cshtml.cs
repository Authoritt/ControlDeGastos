using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlDeGastos.Data;
using ControlDeGastosControlDeGastos.Models;

namespace ControlDeGastos.Pages_TipoGastos
{
    public class EditModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public EditModel(ControlDeGastos.Data.ControlDeGastosContext context)
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

            var tipogastomodel =  await _context.TiposGasto.FirstOrDefaultAsync(m => m.rowid == id);
            if (tipogastomodel == null)
            {
                return NotFound();
            }
            TipoGastoModel = tipogastomodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Attach(TipoGastoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoGastoModelExists(TipoGastoModel.rowid))
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

        private bool TipoGastoModelExists(int id)
        {
            return _context.TiposGasto.Any(e => e.rowid == id);
        }
    }
}
