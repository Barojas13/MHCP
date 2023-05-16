using _2_Tesis.Application.Managers.Clasificacion.Implementations;
using _2_Tesis.Application.Managers.Clasificacion.Interfaces;
using _2_Tesis.Application.Managers.LeerExcel1.Implementations;
using _2_Tesis.Application.Managers.LeerExcel1.Interfaces;

namespace _2_Tesis.Application.DesingContext
{
    public class FactoryContext
    {
        private static FactoryContext _factoryContextInstance = null;
        private static IClasificacionContextManager _clasificacionContextManager;
        private static ILeerExcel1ContextManager _leerExcel1ContextManager;

        public static FactoryContext FactoryContextInstance
        {
            get
            {
                if (_factoryContextInstance == null)
                {
                    _factoryContextInstance = new FactoryContext();
                }

                return _factoryContextInstance;
            }
        }

        public static IClasificacionContextManager ClasificacionContextManager
        {
            get
            {
                if (_clasificacionContextManager == null)
                {
                    _clasificacionContextManager = new ClasificacionContextManager();
                }
                return _clasificacionContextManager;
            }
            set { _clasificacionContextManager = value; }
        }

        public static ILeerExcel1ContextManager LeerExcel1ContextManager
        {
            get
            {
                if (_leerExcel1ContextManager == null)
                {
                    _leerExcel1ContextManager = new LeerExcel1ContextManager();
                }
                return _leerExcel1ContextManager;
            }
            set { _leerExcel1ContextManager = value; }
        }
    }
}
