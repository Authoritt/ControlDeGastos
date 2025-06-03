using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlDeGastos.Data; // Ajusta según tu namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlDeGastos.Pages.Reportes
{
    public class MovimientosModel : PageModel
    {
        private readonly ControlDeGastosContext _context;

        public MovimientosModel(ControlDeGastosContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DateTime FechaInicio { get; set; } = DateTime.Today.AddMonths(-1);

        [BindProperty]
        public DateTime FechaFin { get; set; } = DateTime.Today;

        public List<MovimientoDto> Movimientos { get; set; } = new();
        public List<GraficoDto> GraficoData { get; set; } = new();

        public async Task OnGetAsync()
        {
            // Al cargar por primera vez, podrías dejar vacío o inicializar con el mes anterior
            await CargarDatosAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await CargarDatosAsync();
            return Page();
        }

        private async Task CargarDatosAsync()
        {
            // 1) Movimientos (Depósitos + Gastos)
            var depositos = await _context.Depositos
                .Where(d => d.fecha >= FechaInicio && d.fecha <= FechaFin)
                .Select(d => new MovimientoDto
                {
                    Fecha = d.fecha,
                    Tipo = "Depósito",
                    //Descripcion = d.Descripcion,
                    Monto = d.monto
                }).ToListAsync();

            var gastosEnc = await _context.GastosEncabezado
                .Where(g => g.fecha >= FechaInicio && g.fecha <= FechaFin)
                .Include(g => g.Detalles).ThenInclude(d => d.TipoGasto)
                .ToListAsync();

            var gastos = gastosEnc.SelectMany(g => g.Detalles.Select(det => new MovimientoDto
            {
                Fecha = g.fecha,
                Tipo = $"Gasto ({det.TipoGasto.nombre})",
                //Descripcion = g.Descripcion,
                Monto = det.monto
            })).ToList();

            Movimientos = depositos
                .Concat(gastos)
                .OrderBy(m => m.Fecha)
                .ToList();

            // 2) Datos para gráfico: por TipoGasto, sumar Presupuestado vs Ejecutado
            GraficoData = await _context.TiposGasto
                .Select(tg => new GraficoDto
                {
                    TipoGasto = tg.nombre,
                    Presupuestado = _context.Presupuestos
                        .Where(p => p.tipo_gasto_id == tg.rowid
                                    //&& p. >= FechaInicio && p. <= FechaFin
                                    )
                        .Sum(p => (decimal?)p.monto) ?? 0,
                    Ejecutado = _context.GastosDetalle
                        .Where(det => det.tipo_gasto_id == tg.rowid
                                      //&& det.TipoGasto. >= FechaInicio
                                      //&& det.GastoEncabezado.Fecha <= FechaFin
                                      )
                        .Sum(det => (decimal?)det.monto) ?? 0
                })
                .ToListAsync();
        }

        public class MovimientoDto
        {
            public DateTime Fecha { get; set; }
            public string Tipo { get; set; }
            public string Descripcion { get; set; }
            public decimal Monto { get; set; }
        }

        public class GraficoDto
        {
            public string TipoGasto { get; set; }
            public decimal Presupuestado { get; set; }
            public decimal Ejecutado { get; set; }
        }
    }
}
