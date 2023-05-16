using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.Clasificacion.Interfaces;

namespace _3_Tesis.Domain.Managers.Clasificacion.Implementations
{
    public class ClasificacionDomainManager : IClasificacionDomainManager
    {
        private static IClasificacionCore _clasificacionCore;

        public static IClasificacionCore ClasificacionCore
        {
            get
            {
                if (_clasificacionCore == null)
                {
                    _clasificacionCore = new ClasificacionCore();
                }
                return _clasificacionCore;
            }
            set { _clasificacionCore = value; }
        }

        public async Task SaveClasificacion(_4_Tesis.DataAccess.DataBaseObjects.Clasificacion clasificacion)
        {
            await _clasificacionCore.SaveClasificacion(clasificacion);
        }
    }
}
