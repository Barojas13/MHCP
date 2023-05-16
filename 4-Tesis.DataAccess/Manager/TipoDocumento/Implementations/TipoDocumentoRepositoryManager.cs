using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.TipoDocumento.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.TipoDocumento.Implementations
{
    public class TipoDocumentoRepositoryManager : ITipoDocumentoRepositoryManager
    {
        private static ITipoDocumentoRepository _tipoDocumentoRepository;

        public static ITipoDocumentoRepository TipoDocumentoRepository
        {
            get
            {
                if (_tipoDocumentoRepository == null)
                {
                    _tipoDocumentoRepository = new TipoDocumentoRepository();
                }
                return _tipoDocumentoRepository;
            }
            set { _tipoDocumentoRepository = value; }
        }

        public async Task<DataBaseObjects.TipoDocumento> GetTipoDocumentoByName(string name)
        {
            return await TipoDocumentoRepository.GetTipoDocumentoByName(name);
        }

        public async Task SaveTipoDocumento(DataBaseObjects.TipoDocumento tipoDocumento)
        {
            await TipoDocumentoRepository.SaveTipoDocumento(tipoDocumento);
        }
    }
}
