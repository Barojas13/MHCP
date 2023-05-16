using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;
using Microsoft.EntityFrameworkCore;

namespace _4_Tesis.DataAccess.Repositories
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public TipoDocumentoRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task<TipoDocumento> GetTipoDocumentoByName(string name)
        {
            TipoDocumento tipoDocumento = new TipoDocumento();

            try
            {
                tipoDocumento = await _eTLCRMContext.TipoDocumentos.FirstAsync(a => a.nombre_tipo_documento == name);
            }
            catch (Exception)
            {
                tipoDocumento = null;
            }

            return tipoDocumento;
        }

        public async Task SaveTipoDocumento(TipoDocumento tipoDocumento)
        {
            await _eTLCRMContext.AddAsync(tipoDocumento);
            await _eTLCRMContext.SaveChangesAsync();
        }
    }
}
