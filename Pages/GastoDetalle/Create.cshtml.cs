using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ControlDeGastos.Data;
using ControlDeGastos.Models;

namespace ControlDeGastos.Pages_GastoDetalle
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
        ViewData["encabezado_id"] = new SelectList(_context.GastosEncabezado, "rowid", "rowid");
        ViewData["tipo_gasto_id"] = new SelectList(_context.TiposGasto, "rowid", "codigo");
            return Page();
        }

        [BindProperty]
        public GastoDetalleModel GastoDetalleModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.GastosDetalle.Add(GastoDetalleModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
