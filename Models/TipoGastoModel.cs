using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastosControlDeGastos.Models
{
    [Table("t001_tipo_gasto")]
    public class TipoGastoModel
    {
        [Column("f001_rowid_tipo_gasto")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tipo_gasto { get; set; }

        [Column("f002_tipo_gasto")]
        [StringLength(20)]
        public string codigo_tipo_gasto { get; set; }

        [Column("f003_descripcion_tipo_gasto")]
        [StringLength(200)]
        public string? descripcion_tipo_gasto { get; set; }
    }
}