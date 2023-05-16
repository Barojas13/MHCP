using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface IPersonaRepository
    {
        Task SavePersona(Persona persona);
        Task<Persona> GetPersonaByName(string name, int idRol, int idModalidad);
        Task<Persona> GetPersonaByNameFirst(string name);
    }
}
