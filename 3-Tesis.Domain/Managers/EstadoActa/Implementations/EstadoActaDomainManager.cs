using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.EstadoActa.Interfaces;

namespace _3_Tesis.Domain.Managers.EstadoActa.Implementations
{
    public class EstadoActaDomainManager :IEstadoActaDomainManager
    {
        private static IEstadoActaCore _estadoActaCore;

        public static IEstadoActaCore EstadoActaCore
        {
            get
            {
                if (_estadoActaCore == null)
                {
                    _estadoActaCore = new EstadoActaCore();
                }
                return _estadoActaCore;
            }
            set { _estadoActaCore = value; }
        }

        public async Task SaveEstadoActa(_4_Tesis.DataAccess.DataBaseObjects.EstadoActa estadoActa)
        {
            await _estadoActaCore.SaveEstadoActa(estadoActa);
        }
    }
}
