using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.Modalidad.Interfaces;

namespace _3_Tesis.Domain.Managers.Modalidad.Implementations
{
    public class ModalidadDomainManager : IModalidadDomainManager
    {
        private static IModalidadCore _modalidadCore;

        public static IModalidadCore ModalidadCore
        {
            get
            {
                if (_modalidadCore == null)
                {
                    _modalidadCore = new ModalidadCore();
                }
                return _modalidadCore;
            }
            set { _modalidadCore = value; }
        }

        public async Task SaveModalidad(_4_Tesis.DataAccess.DataBaseObjects.Modalidad modalidad)
        {
            await _modalidadCore.SaveModalidad(modalidad);
        }
    }
}
