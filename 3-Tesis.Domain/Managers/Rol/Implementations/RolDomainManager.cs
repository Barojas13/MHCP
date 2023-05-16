using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.Rol.Interfaces;

namespace _3_Tesis.Domain.Managers.Rol.Implementations
{
    public class RolDomainManager : IRolDomainManager
    {
        private static IRolCore _rolCore;

        public static IRolCore RolCore
        {
            get
            {
                if (_rolCore == null)
                {
                    _rolCore = new RolCore();
                }
                return _rolCore;
            }
            set { _rolCore = value; }
        }

        public async Task SaveRol(_4_Tesis.DataAccess.DataBaseObjects.Rol rol)
        {
            await _rolCore.SaveRol(rol);
        }
    }
}
