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
    public class IndexModel : PageModel
    {
        private readonly ControlDeGastos.Data.ControlDeGastosContext _context;

        public IndexModel(ControlDeGastos.Data.ControlDeGastosContext context)
        {
            _context = context;
        }

        public IList<FondoMonetarioModel> FondoMonetarioModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            FondoMonetarioModel = await _context.FondosMonetarios.ToListAsync();
        }
    }
}
