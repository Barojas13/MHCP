using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.EstadoActa.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.EstadoActa.Implementations
{
    public class EstadoActaRepositoryManager : IEstadoActaRepositoryManager
    {
        private static IEstadoActaRepository _estadoActaRepository;

        public static IEstadoActaRepository EstadoActaRepository
        {
            get
            {
                if (_estadoActaRepository == null)
                {
                    _estadoActaRepository = new EstadoActaRepository();
                }
                return _estadoActaRepository;
            }
            set { _estadoActaRepository = value; }
        }

        public async Task<DataBaseObjects.EstadoActa> GetEstadoActaByName(string name)
        {
            return await EstadoActaRepository.GetEstadoActaByName(name);
        }

        public async Task SaveEstadoActa(DataBaseObjects.EstadoActa estadoActa)
        {
            await EstadoActaRepository.SaveEstadoActa(estadoActa);
        }
    }
}
