namespace _4_Tesis.DataAccess.Manager.Modalidad.Interfaces
{
    public interface IModalidadRepositoryManager
    {
        Task SaveModalidad(DataBaseObjects.Modalidad modalidad);
        Task<DataBaseObjects.Modalidad> GetModalidadByName(string name);
    }
}
