using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.EstadoContratacion.Interfaces;

namespace _3_Tesis.Domain.Managers.EstadoContratacion.Implementations
{
    public class EstadoContratacionDomainManager : IEstadoContratacionDomainManager
    {
        private static IEstadoContratacionCore _estadoContratacionCore;

        public static IEstadoContratacionCore EstadoContratacionCore
        {
            get
            {
                if (_estadoContratacionCore == null)
                {
                    _estadoContratacionCore = new EstadoContratacionCore();
                }
                return _estadoContratacionCore;
            }
            set { _estadoContratacionCore = value; }
        }

        public async Task SaveEstadoContratacion(_4_Tesis.DataAccess.DataBaseObjects.EstadoContratacion estadoContratacion)
        {
            await _estadoContratacionCore.SaveEstadoContratacion(estadoContratacion);
        }
    }
}
