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

        [Column("f002_nombre")]
        [Required]
        [StringLength(35)]
        public string nombre { get; set; } // Autogenerado (GASTO-001)

        [Column("f003_Descripcion")]
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        // Relaciones
        public virtual ICollection<PresupuestoModel> Presupuestos { get; set; }
        public virtual ICollection<GastoDetalleModel> GastosDetalle { get; set; }
    }
}