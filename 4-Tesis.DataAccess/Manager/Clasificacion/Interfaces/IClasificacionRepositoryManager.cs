namespace _4_Tesis.DataAccess.Manager.Clasificacion.Interfaces
{
    public interface IClasificacionRepositoryManager
    {
        Task SaveClasificacion(DataBaseObjects.Clasificacion clasificacion);
        Task<DataBaseObjects.Clasificacion> GetClasificacionByName(string name);
    }
}
