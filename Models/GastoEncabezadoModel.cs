using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastos.Models
{
    [Table("t004_gasto_encabezado")]
    public class GastoEncabezadoModel
    {
        [Key]
        [Column("f004_rowid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rowid { get; set; }

        [Column("f004_fecha")]
        public DateTime fecha { get; set; }

        [Column("f004_fondo_monetario_id")]
        public int fondo_monetario_id { get; set; }

        [Column("f004_observaciones")]
        [StringLength(500)]
        public string observaciones { get; set; }

        [Column("f004_nombre_comercio")]
        [StringLength(100)]
        public string nombre_comercio { get; set; }

        [Column("f004_tipo_documento")]
        [StringLength(20)]
        public string tipo_documento { get; set; } // Factura/Comprobante/Otro

        // Relaciones
        [ForeignKey("fondo_monetario_id")]
        public virtual FondoMonetarioModel FondoMonetario { get; set; }

        public virtual ICollection<GastoDetalleModel> Detalles { get; set; }
    }
}