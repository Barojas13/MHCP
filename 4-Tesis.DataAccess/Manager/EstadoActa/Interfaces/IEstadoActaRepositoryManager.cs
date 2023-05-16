namespace _4_Tesis.DataAccess.Manager.EstadoActa.Interfaces
{
    public interface IEstadoActaRepositoryManager
    {
        Task SaveEstadoActa(DataBaseObjects.EstadoActa estadoActa);
        Task<DataBaseObjects.EstadoActa> GetEstadoActaByName(string name);
    }
}
