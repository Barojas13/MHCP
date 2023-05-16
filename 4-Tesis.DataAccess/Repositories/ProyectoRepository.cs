using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;
using Microsoft.EntityFrameworkCore;

namespace _4_Tesis.DataAccess.Repositories
{
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public ProyectoRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task<Proyecto> GetProyectoByNameAndItemId(string name, int idItem)
        {
            Proyecto proyecto = new Proyecto();

            try
            {
                return await _eTLCRMContext.Proyectos.FirstOrDefaultAsync(e => e.nombre_proyecto == name && e.id_item == idItem);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task SaveProyecto(Proyecto proyecto)
        {
            try
            {
                await _eTLCRMContext.Proyectos.AddAsync(proyecto);
                await _eTLCRMContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
