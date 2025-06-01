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

namespace ControlDeGastos.Pages_Deposito
{
    public class EditModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public EditModel(ControlDeGastos.Data.ControlDeGastosContext context)
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

            var depositomodel =  await _context.Depositos.FirstOrDefaultAsync(m => m.rowid == id);
            if (depositomodel == null)
            {
                return NotFound();
            }
            DepositoModel = depositomodel;
           ViewData["fondo_monetario_id"] = new SelectList(_context.FondosMonetarios, "rowid", "nombre");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(DepositoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositoModelExists(DepositoModel.rowid))
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

        private bool DepositoModelExists(int id)
        {
            return _context.Depositos.Any(e => e.rowid == id);
        }
    }
}
