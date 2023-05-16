using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;
using Microsoft.EntityFrameworkCore;

namespace _4_Tesis.DataAccess.Repositories
{
    public class ClasificacionRepository : IClasificacionRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public ClasificacionRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task<Clasificacion> GetClasificacionByName(string name)
        {
            Clasificacion clasificacion = new Clasificacion();

            try
            {
                clasificacion = await _eTLCRMContext.Clasificaciones.FirstAsync(a => a.nombre_clasificacion == name);
            }
            catch (Exception)
            {
                clasificacion = null;
            }

            return clasificacion;
        }

        public async Task SaveClasificacion(Clasificacion clasificacion)
        {
            await _eTLCRMContext.Clasificaciones.AddAsync(clasificacion);
            await _eTLCRMContext.SaveChangesAsync();
        }
    }
}
