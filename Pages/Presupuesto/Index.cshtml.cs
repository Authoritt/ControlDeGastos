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

        // Propiedades para los filtros (con BindProperty para recibir los par�metros GET)
        [BindProperty(SupportsGet = true)]
        public int? AnioFiltro { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? MesFiltro { get; set; }

        // Lista de a�os disponibles para el dropdown
        public List<int> AniosDisponibles { get; set; } = new List<int>();

        public IList<PresupuestoModel> PresupuestoModel { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Obtener a�os distintos disponibles en la BD
            AniosDisponibles = await _context.Presupuestos
                .Select(p => p.anio)
                .Distinct()
                .OrderByDescending(y => y) // Orden descendente (m�s reciente primero)
                .ToListAsync();

            // Consulta base con includes
            var query = _context.Presupuestos
                .Include(p => p.TipoGasto)
                .Include(p => p.Usuario)
                .AsQueryable();

            // Aplicar filtros si existen valores
            if (AnioFiltro.HasValue)
            {
                query = query.Where(p => p.anio == AnioFiltro.Value);

                if (MesFiltro.HasValue)
                {
                    query = query.Where(p => p.mes == MesFiltro.Value);
                }
            }

            // Ejecutar consulta final
            PresupuestoModel = await query
                .OrderBy(p => p.anio)
                .ThenBy(p => p.mes)
                .ToListAsync();
        }
    }
}