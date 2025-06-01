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

namespace ControlDeGastos.Pages_FondoMonetario
{
    public class EditModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public EditModel(ControlDeGastos.Data.ControlDeGastosContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FondoMonetarioModel FondoMonetarioModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fondomonetariomodel =  await _context.FondosMonetarios.FirstOrDefaultAsync(m => m.rowid == id);
            if (fondomonetariomodel == null)
            {
                return NotFound();
            }
            FondoMonetarioModel = fondomonetariomodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(FondoMonetarioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FondoMonetarioModelExists(FondoMonetarioModel.rowid))
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

        private bool FondoMonetarioModelExists(int id)
        {
            return _context.FondosMonetarios.Any(e => e.rowid == id);
        }
    }
}
