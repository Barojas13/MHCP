using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Models
{
    public class Documento
    {
        string NombreDocumento { get; set; }
        string NombreProyecto { get; set; }
        string NombreItem { get; set; }
        string NombreTipoDocumento { get; set; }
        string Mes { get; set; }
        string FechaEnvioFir { get; set; }
        string FechaCargue { get; set; }
        string Observaciones { get; set; }
        string link_editable { get; set; }
        string link_consulta { get; set; }
    }
}
