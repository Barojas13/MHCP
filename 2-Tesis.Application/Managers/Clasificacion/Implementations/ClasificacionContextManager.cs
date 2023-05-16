using _2_Tesis.Application.Implementations;
using _2_Tesis.Application.Interfaces;
using _2_Tesis.Application.Managers.Clasificacion.Interfaces;

namespace _2_Tesis.Application.Managers.Clasificacion.Implementations
{
    public class ClasificacionContextManager : IClasificacionContextManager
    {
        private static IClasificacionContext _clasificacionContext;

        public ClasificacionContextManager()
        {
        }

        public static IClasificacionContext ClasificacionContext
        {
            get
            {
                if (_clasificacionContext == null)
                {
                    _clasificacionContext = new ClasificacionContext();
                }
                return _clasificacionContext;
            }
            set { _clasificacionContext = value; }
        }

        public async Task SaveClasificacion(_4_Tesis.DataAccess.DataBaseObjects.Clasificacion clasificacion)
        {
            await _clasificacionContext.SaveClasificacion(clasificacion);
        }
    }
}
