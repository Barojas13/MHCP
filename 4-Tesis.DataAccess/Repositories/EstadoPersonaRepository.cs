using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;
using Microsoft.EntityFrameworkCore;

namespace _4_Tesis.DataAccess.Repositories
{
    public class EstadoPersonaRepository : IEstadoPersonaRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public EstadoPersonaRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task<EstadoPersona> GetEstadoPersonaByName(string name)
        {
            EstadoPersona estadoPersona = new EstadoPersona();

            try
            {
                estadoPersona = await _eTLCRMContext.EstadoPersonas.FirstAsync(a => a.nombre_estado_persona == name);
            }
            catch (Exception)
            {
                estadoPersona = null;
            }

            return estadoPersona;
        }

        public async Task SaveEstadoPersona(EstadoPersona estadoPersona)
        {
            await _eTLCRMContext.EstadoPersonas.AddAsync(estadoPersona);
            await _eTLCRMContext.SaveChangesAsync();
        }
    }
}
