using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastos.Models
{
    [Table("t002_fondo_monetario")]
    public class FondoMonetarioModel
    {
        [Key]
        [Column("f002_rowid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rowid { get; set; }

        [Column("f002_nombre")]
        [Required]
        [StringLength(100)]
        public string nombre { get; set; } // Ej: "Cuenta Bancaria X"

        [Column("f002_tipo")]
        [Required]
        [StringLength(30)]
        public string tipo { get; set; } // "Bancario" o "Efectivo"

        // Relaciones
        public virtual ICollection<GastoEncabezadoModel> Gastos { get; set; }
        public virtual ICollection<DepositoModel> Depositos { get; set; }
    }
}