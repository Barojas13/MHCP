using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.Documento.Interfaces;

namespace _3_Tesis.Domain.Managers.Documento.Implementations
{
    public class DocumentoDomainManager : IDocumentoDomainManager
    {
        private static IDocumentoCore _documentoCore;

        public static IDocumentoCore DocumentoCore
        {
            get
            {
                if (_documentoCore == null)
                {
                    _documentoCore = new DocumentoCore();
                }
                return _documentoCore;
            }
            set { _documentoCore = value; }
        }

        public async Task SaveDocumento(_4_Tesis.DataAccess.DataBaseObjects.Documento documento)
        {
            await _documentoCore.SaveDocumento(documento);
        }
    }
}
