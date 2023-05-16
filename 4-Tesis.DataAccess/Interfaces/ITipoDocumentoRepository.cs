using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface ITipoDocumentoRepository
    {
        Task SaveTipoDocumento(TipoDocumento tipoDocumento);
        Task<TipoDocumento> GetTipoDocumentoByName(string name);
    }
}
