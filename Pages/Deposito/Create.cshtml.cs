using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ControlDeGastos.Data;
using ControlDeGastos.Models;

namespace ControlDeGastos.Pages_Deposito
{
    public class CreateModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public CreateModel(ControlDeGastos.Data.ControlDeGastosContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["fondo_monetario_id"] = new SelectList(_context.FondosMonetarios, "rowid", "nombre");
            return Page();
        }

        [BindProperty]
        public DepositoModel DepositoModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
  

            _context.Depositos.Add(DepositoModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
