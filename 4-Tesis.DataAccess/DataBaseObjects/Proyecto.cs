using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class Proyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_proyecto { get; set; }
        public string? codigo_proyecto { get; set; }
        public int id_item { get; set; }
        public string nombre_proyecto { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
        public virtual ICollection<Programacion> Programaciones { get; set; }
        public virtual ICollection<Documento> Documentos { get; set; }

        [ForeignKey("id_item")]
        public virtual Item Item { get; set; }
    }
}
