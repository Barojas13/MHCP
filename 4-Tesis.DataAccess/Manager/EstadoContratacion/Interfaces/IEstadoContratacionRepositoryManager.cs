using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Manager.EstadoContratacion.Interfaces
{
    public interface IEstadoContratacionRepositoryManager
    {
        Task SaveEstadoContratacion(DataBaseObjects.EstadoContratacion estadoContratacion);
        Task<DataBaseObjects.EstadoContratacion> GetEstadoContratacionByName(string name);
    }
}
