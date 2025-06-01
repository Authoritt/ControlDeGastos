using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlDeGastos.Data;
using ControlDeGastos.Models;

namespace ControlDeGastos.Pages_Presupuesto
{
    public class IndexModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public IndexModel(ControlDeGastos.Data.ControlDeGastosContext context)
        {
            _context = context;
        }

        public IList<PresupuestoModel> PresupuestoModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PresupuestoModel = await _context.Presupuestos
                .Include(p => p.TipoGasto)
                .Include(p => p.Usuario).ToListAsync();
        }
    }
}
