using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ControlDeGastos.Data;
using ControlDeGastos.Models;

namespace ControlDeGastos.Pages_Presupuesto
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
        ViewData["tipo_gasto_id"] = new SelectList(_context.TiposGasto, "rowid", "codigo");
        ViewData["usuario_id"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public PresupuestoModel PresupuestoModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
   
            _context.Presupuestos.Add(PresupuestoModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
