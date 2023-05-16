using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.EstadoContratacion.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.EstadoContratacion.Implementations
{
    public class EstadoContratacionRepositoryManager : IEstadoContratacionRepositoryManager
    {
        private static IEstadoContratacionRepository _estadoContratacionRepository;

        public static IEstadoContratacionRepository EstadoContratacionRepository
        {
            get
            {
                if (_estadoContratacionRepository == null)
                {
                    _estadoContratacionRepository = new EstadoContratacionRepository();
                }
                return _estadoContratacionRepository;
            }
            set { _estadoContratacionRepository = value; }
        }

        public async Task<DataBaseObjects.EstadoContratacion> GetEstadoContratacionByName(string name)
        {
            return await EstadoContratacionRepository.GetEstadoContratacionByName(name);
        }

        public async Task SaveEstadoContratacion(DataBaseObjects.EstadoContratacion estadoContratacion)
        {
            await EstadoContratacionRepository.SaveEstadoContratacion(estadoContratacion);
        }
    }
}
