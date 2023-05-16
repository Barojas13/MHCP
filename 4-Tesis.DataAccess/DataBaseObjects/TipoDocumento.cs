using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class TipoDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tipo_documento { get; set; }
        public string nombre_tipo_documento { get; set; }
        public virtual ICollection<Documento> Documentos { get; set; }
    }
}
