using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlDeGastos.Data;
using ControlDeGastos.Models;

namespace ControlDeGastos.Pages_Deposito
{
    public class DeleteModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public DeleteModel(ControlDeGastos.Data.ControlDeGastosContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DepositoModel DepositoModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depositomodel = await _context.Depositos.FirstOrDefaultAsync(m => m.rowid == id);

            if (depositomodel is not null)
            {
                DepositoModel = depositomodel;

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

            var depositomodel = await _context.Depositos.FindAsync(id);
            if (depositomodel != null)
            {
                DepositoModel = depositomodel;
                _context.Depositos.Remove(DepositoModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
