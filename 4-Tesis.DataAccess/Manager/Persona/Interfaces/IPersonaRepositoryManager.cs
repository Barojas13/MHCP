namespace _4_Tesis.DataAccess.Manager.Persona.Interfaces
{
    public interface IPersonaRepositoryManager
    {
        Task SavePersona(DataBaseObjects.Persona persona);
        Task<DataBaseObjects.Persona> GetPersonaByName(string name, int idRol, int idModalidad);
        Task<DataBaseObjects.Persona> GetPersonaByNameFirst(string name);
    }
}
