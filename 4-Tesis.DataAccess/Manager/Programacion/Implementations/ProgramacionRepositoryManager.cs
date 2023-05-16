using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.Programacion.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.Programacion.Implementations
{
    public class ProgramacionRepositoryManager : IProgramacionRepositoryManager
    {
        private static IProgramacionRepository _programacionRepository;

        public static IProgramacionRepository ProgramacionRepository
        {
            get
            {
                if (_programacionRepository == null)
                {
                    _programacionRepository = new ProgramacionRepository();
                }
                return _programacionRepository;
            }
            set { _programacionRepository = value; }
        }

        public async Task SaveProgramacion(DataBaseObjects.Programacion programacion)
        {
            await ProgramacionRepository.SaveProgramacion(programacion);
        }
    }
}
