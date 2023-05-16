using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.EstadoPersona.Interfaces;

namespace _3_Tesis.Domain.Managers.EstadoPersona.Implementations
{
    public class EstadoPersonaDomainManager : IEstadoPersonaDomainManager
    {
        private static IEstadoPersonaCore _estadoPersonaCore;

        public static IEstadoPersonaCore EstadoPersonaCore
        {
            get
            {
                if (_estadoPersonaCore == null)
                {
                    _estadoPersonaCore = new EstadoPersonaCore();
                }
                return _estadoPersonaCore;
            }
            set { _estadoPersonaCore = value; }
        }

        public async Task SaveEstadoPersona(_4_Tesis.DataAccess.DataBaseObjects.EstadoPersona estadoPersona)
        {
            await _estadoPersonaCore.SaveEstadoPersona(estadoPersona);
        }
    }
}
