using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.Proyecto.Interfaces;

namespace _3_Tesis.Domain.Managers.Proyecto.Implementations
{
    public class ProyectoDomainManager : IProyectoDomainManager
    {
        private static IProyectoCore _proyectoCore;

        public static IProyectoCore ProyectoCore
        {
            get
            {
                if (_proyectoCore == null)
                {
                    _proyectoCore = new ProyectoCore();
                }
                return _proyectoCore;
            }
            set { _proyectoCore = value; }
        }

        public async Task SaveProyecto(_4_Tesis.DataAccess.DataBaseObjects.Proyecto proyecto)
        {
            await _proyectoCore.SaveProyecto(proyecto);
        }
    }
}
