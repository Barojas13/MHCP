using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.Documento.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.Documento.Implementations
{
    public class DocumentoRepositoryManager : IDocumentoRepositoryManager
    {
        private static IDocumentoRepository _documentoRepository;

        public static IDocumentoRepository DocumentoRepository
        {
            get
            {
                if (_documentoRepository == null)
                {
                    _documentoRepository = new DocumentoRepository();
                }
                return _documentoRepository;
            }
            set { _documentoRepository = value; }
        }

        public async Task SaveDocumento(DataBaseObjects.Documento documento)
        {
            await DocumentoRepository.SaveDocumento(documento);
        }
    }
}
