using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;
using Microsoft.EntityFrameworkCore;

namespace _4_Tesis.DataAccess.Repositories
{
    public class CumplimientoRepository : ICumplimientoRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public CumplimientoRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task<Cumplimiento> GetCumplimientoByName(string name)
        {
            Cumplimiento cumplimiento = new Cumplimiento();

            try
            {
                return await _eTLCRMContext.Cumplimientos.FirstAsync(a => a.nombre_cumplimiento == name);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task SaveCumplimiento(Cumplimiento cumplimiento)
        {
            await _eTLCRMContext.Cumplimientos.AddAsync(cumplimiento);
            await _eTLCRMContext.SaveChangesAsync();
        }
    }
}
