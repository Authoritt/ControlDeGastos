using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastos.Models
{
    [Table("t003_presupuesto")]
    public class PresupuestoModel
    {
        [Column("f001_rowid_presupuesto")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rowid_presupuesto { get; set; }

        [Column("f002_usuario_id_presupuesto")]
        public int usuario_id_presupuesto { get; set; }

        [Column("f003_tipo_gasto_id_presupuesto")]
        public int tipo_gasto_id_presupuesto { get; set; }

        [Column("f004_fecha")]
        public date fecha_presupuesto { get; set; }

        [Column("f005_monto_presupuesto")]
        public decimal monto_presupuesto { get; set; }

        [Column("f006_tipo_gasto_id_presupuesto")]
        public int fk_t001_tipo_gasto_presupuesto { get; set; }
    }
}