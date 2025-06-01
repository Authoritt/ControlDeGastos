using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastos.Models
{
    [Table("t001_tipo_gasto")]
    public class FondoMonetarioModel
    {
        [Column("f001_rowid_fondo_monetario")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_fondo_monetario { get; set; }

        [Column("f002_fondo_monetario")]
        [StringLength(100)]
        public string tipo_fondo_monetario { get; set; }

        [Column("f003_descripcion_fondo_monetario")]
        [StringLength(200)]
        public string? descripcion_fondo_monetario { get; set; }
    }
}