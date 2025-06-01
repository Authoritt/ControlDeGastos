using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastos.Models
{
    [Table("t004_gasto_encabezado")]
    public class GastoEncabezadoModel
    {
        [Column("f001_rowid_gasto_encabezado")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rowid { get; set; }

        [Column("f002_fecha_gasto_encabezado")]
        public DateTime fecha_gasto_encabezado { get; set; }

        [Column("f003_fondo_monetario_id_gasto_encabezado")]
        public int fondo_monetario_id_gasto_encabezado { get; set; }

        [Column("f004_observaciones_gasto_encabezado")]
        [StringLength(500)]
        public string observaciones_gasto_encabezado { get; set; }

        [Column("f005_nombre_comercio_gasto_encabezado")]
        [StringLength(100)]
        public string nombre_comercio_gasto_encabezado { get; set; }

        [Column("f006_tipo_documento_gasto_encabezado")]
        [StringLength(50)]
        public string tipo_documento_gasto_encabezado { get; set; }

        [Column("f007_fondo_monetario_id_gasto_encabezado")]
        public int fk_t002_fondo_monetario_gasto_encabezado { get; set; }
    }
}