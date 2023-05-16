using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.Cumplimiento.Interfaces;

namespace _3_Tesis.Domain.Managers.Cumplimiento.Implementations
{
    public class CumplimientoDomainManager : ICumplimientoDomainManager
    {
        private static ICumplimientoCore _cumplimientoCore;

        public static ICumplimientoCore CumplimientoCore
        {
            get
            {
                if (_cumplimientoCore == null)
                {
                    _cumplimientoCore = new CumplimientoCore();
                }
                return _cumplimientoCore;
            }
            set { _cumplimientoCore = value; }
        }

        public async Task SaveCumplimiento(_4_Tesis.DataAccess.DataBaseObjects.Cumplimiento cumplimiento)
        {
            await _cumplimientoCore.SaveCumplimiento(cumplimiento);
        }
    }
}
