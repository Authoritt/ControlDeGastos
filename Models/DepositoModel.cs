using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastos.Models
{
    [Table("t006_deposito")]
    public class DepositoModel
    {
        [Column("f001_rowid_deposito")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rowid_deposito { get; set; }

        [Column("f002_fecha_deposito")]
        public DateTime fecha_deposito { get; set; }

        [Column("f003_fondo_monetario_id_deposito")]
        public int fondo_monetario_id_deposito { get; set; }

        [Column("f004_monto_deposito")]
        public decimal monto_deposito { get; set; }

        [Column("f005_fondo_monetario_id_deposito")]
        public int fk_t002_fondo_monetario_id_deposito { get; set; }
    }
}