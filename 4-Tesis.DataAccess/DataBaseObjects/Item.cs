using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_item { get; set; }
        public string nombre_item { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
        public virtual ICollection<Proyecto> Proyectos { get; set; }
        public virtual ICollection<Programacion> Programaciones { get; set; }
        public virtual ICollection<Documento> Documentos { get; set; }
    }
}
