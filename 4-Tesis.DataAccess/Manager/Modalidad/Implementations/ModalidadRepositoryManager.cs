using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.Modalidad.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.Modalidad.Implementations
{
    public class ModalidadRepositoryManager : IModalidadRepositoryManager
    {
        private static IModalidadRepository _modalidadRepository;

        public static IModalidadRepository ModalidadRepository
        {
            get
            {
                if (_modalidadRepository == null)
                {
                    _modalidadRepository = new ModalidadRepository();
                }
                return _modalidadRepository;
            }
            set { _modalidadRepository = value; }
        }

        public async Task<DataBaseObjects.Modalidad> GetModalidadByName(string name)
        {
            return await ModalidadRepository.GetModalidadByName(name);
        }

        public async Task SaveModalidad(DataBaseObjects.Modalidad modalidad)
        {
            await ModalidadRepository.SaveModalidad(modalidad);
        }
    }
}
