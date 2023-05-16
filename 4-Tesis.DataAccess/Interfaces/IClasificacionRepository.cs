using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface IClasificacionRepository
    {
        Task SaveClasificacion(Clasificacion clasificacion);
        Task<Clasificacion> GetClasificacionByName(string name);
    }
}
