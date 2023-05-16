using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_rol { get; set; }
        public string nombre_rol { get; set; }
        public decimal? tarifa_presecial { get; set; }
        public decimal? tarifa_virtual { get; set; }
        public decimal? tarifa_hibrido { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
        public virtual ICollection<Programacion> Programaciones { get; set; }
    }
}
