using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlDeGastos.Data;
using ControlDeGastos.Models;

namespace ControlDeGastos.Pages_GastoEncabezado
{
    public class IndexModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public IndexModel(ControlDeGastos.Data.ControlDeGastosContext context)
        {
            _context = context;
        }

        public IList<GastoEncabezadoModel> GastoEncabezadoModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            GastoEncabezadoModel = await _context.GastosEncabezado
                .Include(g => g.FondoMonetario).ToListAsync();
        }
    }
}
