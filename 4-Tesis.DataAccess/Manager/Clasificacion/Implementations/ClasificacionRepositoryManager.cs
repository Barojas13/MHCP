using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.Clasificacion.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.Clasificacion.Implementations
{
    public class ClasificacionRepositoryManager : IClasificacionRepositoryManager
    {
        private static IClasificacionRepository _clasificacionRepository;

        public static IClasificacionRepository ClasificacionRepository
        {
            get
            {
                if (_clasificacionRepository == null)
                {
                    _clasificacionRepository = new ClasificacionRepository();
                }
                return _clasificacionRepository;
            }
            set { _clasificacionRepository = value; }
        }

        public async Task<DataBaseObjects.Clasificacion> GetClasificacionByName(string name)
        {
            return await ClasificacionRepository.GetClasificacionByName(name);
        }

        public async Task SaveClasificacion(DataBaseObjects.Clasificacion clasificacion)
        {
            await ClasificacionRepository.SaveClasificacion(clasificacion);
        }
    }
}
