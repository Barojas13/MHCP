using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class Clasificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_clasificacion { get; set; }
        public string nombre_clasificacion { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
