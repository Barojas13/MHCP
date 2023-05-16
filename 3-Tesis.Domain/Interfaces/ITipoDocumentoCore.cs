using _4_Tesis.DataAccess.DataBaseObjects;

namespace _3_Tesis.Domain.Interfaces
{
    public interface ITipoDocumentoCore
    {
        Task SaveTipoDocumento(TipoDocumento tipoDocumento);
    }
}
