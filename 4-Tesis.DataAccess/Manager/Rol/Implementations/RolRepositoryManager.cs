using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.Rol.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.Rol.Implementations
{
    public class RolRepositoryManager : IRolRepositoryManager
    {
        private static IRolRepository _rolRepository;

        public static IRolRepository RolRepository
        {
            get
            {
                if (_rolRepository == null)
                {
                    _rolRepository = new RolRepository();
                }
                return _rolRepository;
            }
            set { _rolRepository = value; }
        }

        public async Task<DataBaseObjects.Rol> GetRolByName(string name)
        {
            return await RolRepository.GetRolByName(name);
        }

        public async Task SaveRol(DataBaseObjects.Rol rol)
        {
            await RolRepository.SaveRol(rol);
        }

        public async Task UpdateRol(DataBaseObjects.Rol rol)
        {
            await RolRepository.UpdateRol(rol);
        }
    }
}
