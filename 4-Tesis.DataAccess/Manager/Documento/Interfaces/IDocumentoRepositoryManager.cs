namespace _4_Tesis.DataAccess.Manager.Documento.Interfaces
{
    public interface IDocumentoRepositoryManager
    {
        Task SaveDocumento(DataBaseObjects.Documento documento);
    }
}
