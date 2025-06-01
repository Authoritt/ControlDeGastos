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
    public class IndexModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public IndexModel(ControlDeGastos.Data.ControlDeGastosContext context)
        {
            _context = context;
        }

        public IList<DepositoModel> DepositoModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            DepositoModel = await _context.Depositos
                .Include(d => d.FondoMonetario).ToListAsync();
        }
    }
}
