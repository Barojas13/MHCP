using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class EstadoContratacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_estado_contratacion { get; set; }
        public string nombre_estado_contratacion { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
