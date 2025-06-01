using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlDeGastos.Data;
using ControlDeGastos.Models;

namespace ControlDeGastos.Pages_FondoMonetario
{
    public class DeleteModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public DeleteModel(ControlDeGastos.Data.ControlDeGastosContext context)
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

            var fondomonetariomodel = await _context.FondosMonetarios.FirstOrDefaultAsync(m => m.rowid == id);

            if (fondomonetariomodel is not null)
            {
                FondoMonetarioModel = fondomonetariomodel;

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

            var fondomonetariomodel = await _context.FondosMonetarios.FindAsync(id);
            if (fondomonetariomodel != null)
            {
                FondoMonetarioModel = fondomonetariomodel;
                _context.FondosMonetarios.Remove(FondoMonetarioModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
