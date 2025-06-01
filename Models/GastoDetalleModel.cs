using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastos.Models
{
    [Table("t005_gasto_detalle")]
    public class GastoDetalleModel
    {
        [Column("f001_rowid_gasto_detalle")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rowid_gasto_detalle { get; set; }

        [Column("f002_encabezado_id_gasto_detalle")]
        public int encabezado_id_gasto_detalle { get; set; }

        [Column("f003_tipo_gasto_id_gasto_detalle")]
        public int tipo_gasto_id_gasto_detalle { get; set; }

        [Column("f004_monto_gasto_detalle")]
        public decimal monto_gasto_detalle { get; set; }

        [Column("f005_encabezado_id_gasto_detalle")]
        public int fk_t004_encabezado_id_gasto_detalle { get; set; }

        [Column("f006_tipo_gasto_id_gasto_detalle")]
        public int fk_t001_tipo_gasto_id_gasto_detalle { get; set; }
    }
}