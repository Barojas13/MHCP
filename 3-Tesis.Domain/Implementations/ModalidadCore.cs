using _3_Tesis.Domain.Interfaces;
using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.DesingContext;
using _5_Tesis.TransverseInfraestructure.Implementations;
using _5_Tesis.TransverseInfraestructure.Interfaces;

namespace _3_Tesis.Domain.Implementations
{
    public class ModalidadCore : IModalidadCore
    {
        private static IObjectConverterHelper _objectConverterHelper;

        public static IObjectConverterHelper ObjectConverterHelper
        {
            get
            {
                if (_objectConverterHelper == null)
                {
                    _objectConverterHelper = new ObjectConverterHelper();
                }
                return _objectConverterHelper;
            }
            set { _objectConverterHelper = value; }
        }

        public async Task SaveModalidad(Modalidad modalidad)
        {
            await FactoryDataAccess.ModalidadRepositoryManager.SaveModalidad(modalidad);
        }
    }
}
