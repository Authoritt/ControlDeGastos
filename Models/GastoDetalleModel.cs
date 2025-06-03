using ControlDeGastosControlDeGastos.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastos.Models
{
    [Table("t005_gasto_detalle")]
    public class GastoDetalleModel
    {
        [Key]
        [Column("f005_rowid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rowid { get; set; }

        [Column("f005_fecha")]
        public DateTime Fecha { get; set; }

        [Column("f005_encabezado_id")]
        public int encabezado_id { get; set; }

        [Column("f005_tipo_gasto_id")]
        public int tipo_gasto_id { get; set; }

        [Column("f005_monto")]
        //[Column(TypeName = "decimal(18,2)")]
        public decimal monto { get; set; }

        // Relaciones
        [ForeignKey("encabezado_id")]
        public virtual GastoEncabezadoModel Encabezado { get; set; }

        [ForeignKey("tipo_gasto_id")]
        public virtual TipoGastoModel TipoGasto { get; set; }
    }
}