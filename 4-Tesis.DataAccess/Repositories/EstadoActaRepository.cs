using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;
using Microsoft.EntityFrameworkCore;

namespace _4_Tesis.DataAccess.Repositories
{
    public class EstadoActaRepository : IEstadoActaRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public EstadoActaRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task<EstadoActa> GetEstadoActaByName(string name)
        {
            EstadoActa estadoActa = new EstadoActa();

            try
            {
                estadoActa = await _eTLCRMContext.EstadoActas.FirstAsync(a => a.nombre_estado_acta == name);
            }
            catch (Exception)
            {
                estadoActa = null;
            }

            return estadoActa;
        }

        public async Task SaveEstadoActa(EstadoActa estadoActa)
        {
            await _eTLCRMContext.EstadoActas.AddAsync(estadoActa);
            await _eTLCRMContext.SaveChangesAsync();
        }
    }
}
