using _4_Tesis.DataAccess.DataBaseObjects;

namespace _3_Tesis.Domain.Interfaces
{
    public interface IDocumentoCore
    {
        Task SaveDocumento(Documento documento);
    }
}
