using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class EstadoActa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_estado_acta { get; set; }
        public string nombre_estado_acta { get; set; }
        public virtual ICollection<Documento> Documentos { get; set; }  
    }
}
