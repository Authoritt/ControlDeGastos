using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastos.Models
{
    [Table("t006_deposito")]
    public class DepositoModel
    {
        [Key]
        [Column("f006_rowid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rowid { get; set; }

        [Column("f006_fecha")]
        public DateTime fecha { get; set; }

        [Column("f006_fondo_monetario_id")]
        public int fondo_monetario_id { get; set; }

        [Column("f006_monto")]
        //[Column(TypeName = "decimal(18,2)")]
        public decimal monto { get; set; }

        // Relaciones
        [ForeignKey("fondo_monetario_id")]
        public virtual FondoMonetarioModel FondoMonetario { get; set; }
    }
}