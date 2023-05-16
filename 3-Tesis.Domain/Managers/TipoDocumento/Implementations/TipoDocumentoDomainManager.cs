using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.TipoDocumento.Interfaces;

namespace _3_Tesis.Domain.Managers.TipoDocumento.Implementations
{
    public class TipoDocumentoDomainManager : ITipoDocumentoDomainManager
    {
        private static ITipoDocumentoCore _tipoDocumentoCore;

        public static ITipoDocumentoCore TipoDocumentoCore
        {
            get
            {
                if (_tipoDocumentoCore == null)
                {
                    _tipoDocumentoCore = new TipoDocumentoCore();
                }
                return _tipoDocumentoCore;
            }
            set { _tipoDocumentoCore = value; }
        }

        public async Task SaveTipoDocumento(_4_Tesis.DataAccess.DataBaseObjects.TipoDocumento tipoDocumento)
        {
            await _tipoDocumentoCore.SaveTipoDocumento(tipoDocumento);
        }
    }
}
