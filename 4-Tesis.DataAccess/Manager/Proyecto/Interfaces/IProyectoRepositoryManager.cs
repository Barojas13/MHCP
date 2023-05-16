namespace _4_Tesis.DataAccess.Manager.Proyecto.Interfaces
{
    public interface IProyectoRepositoryManager
    {
        Task SaveProyecto(DataBaseObjects.Proyecto proyecto);
        Task<DataBaseObjects.Proyecto> GetProyectoByNameAndItemId(string name, int idItem);
    }
}
