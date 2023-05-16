namespace _4_Tesis.DataAccess.Manager.EstadoPersona.Interfaces
{
    public interface IEstadoPersonaRepositoryManager
    {
        Task SaveEstadoPersona(DataBaseObjects.EstadoPersona estadoPersona);
        Task<DataBaseObjects.EstadoPersona> GetEstadoPersonaByName(string name);
    }
}
