using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ControlDeGastos.Data;
using ControlDeGastos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using System.Data;

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
        ViewData["tipo_gasto_id"] = new SelectList(_context.TiposGasto, "rowid", "Descripcion");
            return Page();
        }

        [BindProperty]
        public GastoDetalleModel GastoDetalleModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            // Dentro de tu método async (por ejemplo, OnPostAsync):
            string sql = @"
    SELECT CASE 
             WHEN f003_monto < (t.montoAcum + @p_monto) 
             THEN 1 
             ELSE 0 
           END
    FROM t003_presupuesto
    INNER JOIN (
        SELECT 
            SUM(f005_monto)      AS montoAcum,
            f005_tipo_gasto_id   AS tipoGasto,
            f004_fecha
        FROM t005_gasto_detalle
        INNER JOIN t004_gasto_encabezado 
            ON f004_rowid = f005_encabezado_id
        WHERE 
            f005_encabezado_id   = @p_rowid 
            AND f005_tipo_gasto_id = @p_tipo_gasto_id
        GROUP BY 
            f005_tipo_gasto_id, 
            f004_fecha
    ) AS t 
      ON t.tipoGasto = f003_tipo_gasto_id 
     AND f003_mes  = MONTH(t.f004_fecha) 
     AND f003_anio = YEAR(t.f004_fecha)
    WHERE 
      f003_tipo_gasto_id = @p_tipo_gasto_id 
      AND f003_mes        = MONTH(@p_fecha) 
      AND f003_anio       = YEAR(@p_fecha);
";

            int resultado = 0;

            // Obtenemos la cadena de conexión desde el DbContext
            var connectionString = _context.Database.GetConnectionString();

            await using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                await using (var command = new SqlCommand(sql, connection))
                {
                    // Definimos cada parámetro:
                    command.Parameters.Add(new SqlParameter("@p_monto", SqlDbType.Decimal)
                    { Value = GastoDetalleModel.monto });
                    command.Parameters.Add(new SqlParameter("@p_tipo_gasto_id", SqlDbType.Int)
                    { Value = GastoDetalleModel.tipo_gasto_id });
                    command.Parameters.Add(new SqlParameter("@p_rowid", SqlDbType.Int)
                    { Value = GastoDetalleModel.encabezado_id });
                    command.Parameters.Add(new SqlParameter("@p_fecha", SqlDbType.DateTime)
                    { Value = GastoDetalleModel.Fecha });

                    // ExecuteScalarAsync devuelve el primer valor de la primera fila:
                    var scalar = await command.ExecuteScalarAsync();
                    if (scalar != null && scalar != DBNull.Value)
                    {
                        resultado = Convert.ToInt32(scalar);
                    }
                }
            }

            if (resultado == 1)
            {

                var tipos = await _context.TiposGasto.AsNoTracking().ToListAsync();
                var encabezados = await _context.GastosEncabezado.AsNoTracking().ToListAsync();
                ViewData["tipo_gasto_id"] = new SelectList(tipos, "rowid", "nombre");
                ViewData["encabezado_id"] = new SelectList(encabezados, "rowid", "rowid");

                ModelState.AddModelError(string.Empty, "El monto excede el presupuesto disponible para este tipo de gasto.");

                return Page();
            }

            _context.GastosDetalle.Add(GastoDetalleModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
