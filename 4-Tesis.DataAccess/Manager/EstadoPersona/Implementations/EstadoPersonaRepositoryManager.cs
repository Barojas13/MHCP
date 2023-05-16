using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.EstadoPersona.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.EstadoPersona.Implementations
{
    public class EstadoPersonaRepositoryManager : IEstadoPersonaRepositoryManager
    {
        private static IEstadoPersonaRepository _estadoPersonaRepository;

        public static IEstadoPersonaRepository EstadoPersonaRepository
        {
            get
            {
                if (_estadoPersonaRepository == null)
                {
                    _estadoPersonaRepository = new EstadoPersonaRepository();
                }
                return _estadoPersonaRepository;
            }
            set { _estadoPersonaRepository = value; }
        }

        public async Task<DataBaseObjects.EstadoPersona> GetEstadoPersonaByName(string name)
        {
            return await EstadoPersonaRepository.GetEstadoPersonaByName(name);
        }

        public async Task SaveEstadoPersona(DataBaseObjects.EstadoPersona estadoPersona)
        {
            await EstadoPersonaRepository.SaveEstadoPersona(estadoPersona);
        }
    }
}
