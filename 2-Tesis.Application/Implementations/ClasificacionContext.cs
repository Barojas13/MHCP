using _2_Tesis.Application.Interfaces;
using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.DesingContext;

namespace _2_Tesis.Application.Implementations
{
    public class ClasificacionContext : IClasificacionContext
    {
        public async Task SaveClasificacion(Clasificacion clasificacion)
        {
            await FactoryDataAccess.ClasificacionRepositoryManager.SaveClasificacion(clasificacion);
        }
    }
}
