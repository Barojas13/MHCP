using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.Cumplimiento.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.Cumplimiento.Implementations
{
    public class CumplimientoRepositoryManager : ICumplimientoRepositoryManager
    {
        private static ICumplimientoRepository _cumplimientoRepository;

        public static ICumplimientoRepository CumplimientoRepository
        {
            get
            {
                if (_cumplimientoRepository == null)
                {
                    _cumplimientoRepository = new CumplimientoRepository();
                }
                return _cumplimientoRepository;
            }
            set { _cumplimientoRepository = value; }
        }

        public async Task<DataBaseObjects.Cumplimiento> GetCumplimientoByName(string name)
        {
           return await CumplimientoRepository.GetCumplimientoByName(name);
        }

        public async Task SaveCumplimiento(DataBaseObjects.Cumplimiento cumplimiento)
        {
            await CumplimientoRepository.SaveCumplimiento(cumplimiento);
        }
    }
}
