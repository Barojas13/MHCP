using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.Proyecto.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.Proyecto.Implementations
{
    public class ProyectoRepositoryManager : IProyectoRepositoryManager
    {
        private static IProyectoRepository _proyectoRepository;

        public static IProyectoRepository ProyectoRepository
        {
            get
            {
                if (_proyectoRepository == null)
                {
                    _proyectoRepository = new ProyectoRepository();
                }
                return _proyectoRepository;
            }
            set { _proyectoRepository = value; }
        }

        public async Task<DataBaseObjects.Proyecto> GetProyectoByNameAndItemId(string name, int idItem)
        {
            return await ProyectoRepository.GetProyectoByNameAndItemId(name, idItem);
        }

        public async Task SaveProyecto(DataBaseObjects.Proyecto proyecto)
        {
            await ProyectoRepository.SaveProyecto(proyecto);
        }
    }
}
