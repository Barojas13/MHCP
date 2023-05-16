using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class Documento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_documento { get; set; }
        public string nombre_documento { get; set; }
        public int id_proyecto { get; set; }
        public int id_item { get; set; }
        public int id_tipo_documento { get; set; }
        public int id_estado_acta { get; set; }
        public string? mes { get; set; }
        public DateTime? fecha_reunion { get; set; }
        public string? responsable { get; set; }
        public DateTime? fecha_envio_rev { get; set; }
        public DateTime? fecha_apro { get; set; }
        public DateTime? fecha_envio_fir { get; set; }
        public DateTime? fecha_cargue { get; set; }
        public string? observaciones { get; set; }
        public string? link_editable { get; set; }
        public string? link_consulta { get; set; }
        public string? link_sharepoint_aws { get; set; }

        [ForeignKey("id_proyecto")]
        public virtual Proyecto Proyecto { get; set; }

        [ForeignKey("id_item")]
        public virtual Item Item { get; set; }

        [ForeignKey("id_tipo_documento")]
        public virtual TipoDocumento TipoDocumento { get; set; }

        [ForeignKey("id_estado_acta")]
        public virtual EstadoActa EstadoActa { get; set; }
    }
}
