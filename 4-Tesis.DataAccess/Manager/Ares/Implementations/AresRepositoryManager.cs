using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.Ares.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.Ares.Implementations
{
    public class AresRepositoryManager : IAresRepositoryManager
    {
        private static IAresRepository _aresRepository;

        public static IAresRepository AresRepository
        {
            get
            {
                if (_aresRepository == null)
                {
                    _aresRepository = new AresRepository();
                }
                return _aresRepository;
            }
            set { _aresRepository = value; }
        }

        public async Task SaveAres(DataBaseObjects.Ares ares)
        {
            await AresRepository.SaveAres(ares);
        }
    }
}
