using ControlDeGastosControlDeGastos.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastos.Models
{
    [Table("t003_presupuesto")]
    public class PresupuestoModel
    {
        [Key]
        [Column("f003_rowid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rowid { get; set; }

        [Column("f003_usuario_id")]
        [Required]
        public string usuario_id { get; set; } // Relación con IdentityUser

        [Column("f003_tipo_gasto_id")]
        [Required]
        public int tipo_gasto_id { get; set; }

        [Column("f003_mes")]
        [Range(1, 12)]
        public int mes { get; set; }

        [Column("f003_anio")]
        public int anio { get; set; }

        [Column("f003_monto")]
        //[Column(TypeName = "decimal(18,2)")]
        public decimal monto { get; set; }

        // Relaciones
        [ForeignKey("tipo_gasto_id")]
        public virtual TipoGastoModel TipoGasto { get; set; }

        [ForeignKey("usuario_id")]
        public virtual IdentityUser Usuario { get; set; }
    }
}