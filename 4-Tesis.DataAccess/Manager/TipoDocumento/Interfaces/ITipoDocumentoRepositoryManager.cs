namespace _4_Tesis.DataAccess.Manager.TipoDocumento.Interfaces
{
    public interface ITipoDocumentoRepositoryManager
    {
        Task SaveTipoDocumento(DataBaseObjects.TipoDocumento tipoDocumento);
        Task<DataBaseObjects.TipoDocumento> GetTipoDocumentoByName(string name);
    }
}
