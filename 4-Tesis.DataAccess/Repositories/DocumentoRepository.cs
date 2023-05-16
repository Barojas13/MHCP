using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;

namespace _4_Tesis.DataAccess.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public DocumentoRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task SaveDocumento(Documento documento)
        {
            await _eTLCRMContext.AddAsync(documento);
            await _eTLCRMContext.SaveChangesAsync();
        }
    }
}
