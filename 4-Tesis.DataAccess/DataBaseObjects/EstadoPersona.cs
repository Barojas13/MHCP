using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class EstadoPersona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_estado_persona { get; set; }
        public string nombre_estado_persona { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
