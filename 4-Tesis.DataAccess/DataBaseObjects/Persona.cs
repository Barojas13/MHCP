using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_persona { get; set; }
        public string nombre_persona { get; set; }
        public int? id_rol { get; set; }
        public int id_item { get; set; }
        public int id_proyecto { get; set; }
        public int id_modalidad { get; set; }
        public int? id_clasificacion { get; set; }
        public int? id_cumplimiento { get; set; }
        public int? id_estado_persona { get; set; }
        public int? id_estado_contratacion { get; set; }
        public DateTime? fecha_solicitud { get; set; }
        public DateTime? fecha_envio { get; set; }
        public DateTime? fecha_supervisores { get; set; }
        public DateTime? fecha_aprobacion { get; set; }
        public DateTime? fecha_contratacion { get; set; }
        public DateTime? fecha_ingreso { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? responsable { get; set; }
        public string? bitacora { get; set; }

        [ForeignKey("id_estado_persona")]
        public virtual EstadoPersona EstadoPersona { get; set; }

        [ForeignKey("id_estado_contratacion")]
        public virtual EstadoContratacion EstadoContratacion { get; set; }

        [ForeignKey("id_cumplimiento")]
        public virtual Cumplimiento Cumplimiento { get; set; }

        [ForeignKey("id_modalidad")]
        public virtual Modalidad Modalidad { get; set; }

        [ForeignKey("id_rol")]
        public virtual Rol Rol { get; set; }

        [ForeignKey("id_item")]
        public virtual Item Item { get; set; }

        [ForeignKey("id_proyecto")]
        public virtual Proyecto Proyecto { get; set; }

        [ForeignKey("id_clasificacion")]
        public virtual Clasificacion Clasificacion { get; set; }
    }
}
