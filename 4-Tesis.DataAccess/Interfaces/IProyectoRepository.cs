using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface IProyectoRepository
    {
        Task SaveProyecto(Proyecto proyecto);
        Task<Proyecto> GetProyectoByNameAndItemId(string name, int idItem);
    }
}
