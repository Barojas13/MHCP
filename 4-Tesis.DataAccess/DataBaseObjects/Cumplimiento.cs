using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class Cumplimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_cumplimiento { get; set; }
        public string nombre_cumplimiento { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
