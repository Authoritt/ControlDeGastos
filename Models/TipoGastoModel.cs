using ControlDeGastos.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastosControlDeGastos.Models
{
    [Table("t001_tipo_gasto")]
    public class TipoGastoModel
    {
        [Key]
        [Column("f001_rowid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rowid { get; set; }

        [Column("f002_codigo")]
        [Required]
        [StringLength(10)]
        public string codigo { get; set; } // Autogenerado (GASTO-001)

        [Column("f003_nombre")]
        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        // Relaciones
        public virtual ICollection<PresupuestoModel> Presupuestos { get; set; }
        public virtual ICollection<GastoDetalleModel> GastosDetalle { get; set; }
    }
}