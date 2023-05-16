using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class Modalidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_modalidad { get; set; }
        public string nombre_modalidad { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
        public virtual ICollection<Programacion> Programaciones { get; set; }
    }
}
