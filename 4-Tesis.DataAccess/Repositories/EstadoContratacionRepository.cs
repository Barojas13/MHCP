using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;
using Microsoft.EntityFrameworkCore;

namespace _4_Tesis.DataAccess.Repositories
{
    public class EstadoContratacionRepository : IEstadoContratacionRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public EstadoContratacionRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task<EstadoContratacion> GetEstadoContratacionByName(string name)
        {
            EstadoContratacion estadoContratacion = new EstadoContratacion();

            try
            {
                estadoContratacion = await _eTLCRMContext.EstadoContratacion.FirstAsync(a => a.nombre_estado_contratacion == name);
            }
            catch (Exception)
            {
                estadoContratacion = null;
            }

            return estadoContratacion;
        }

        public async Task SaveEstadoContratacion(EstadoContratacion estadoContratacion)
        {
            await _eTLCRMContext.EstadoContratacion.AddAsync(estadoContratacion);
            await _eTLCRMContext.SaveChangesAsync();
        }
    }
}
