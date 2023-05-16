using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.Persona.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.Persona.Implementations
{
    public class PersonaRepositoryManager : IPersonaRepositoryManager
    {
        private static IPersonaRepository _personaRepository;

        public static IPersonaRepository PersonaRepository
        {
            get
            {
                if (_personaRepository == null)
                {
                    _personaRepository = new PersonaRepository();
                }
                return _personaRepository;
            }
            set { _personaRepository = value; }
        }

        public async Task<DataBaseObjects.Persona> GetPersonaByName(string name, int idRol, int idModalidad)
        {
            return await PersonaRepository.GetPersonaByName(name, idRol, idModalidad);
        }

        public async Task<DataBaseObjects.Persona> GetPersonaByNameFirst(string name)
        {
            return await PersonaRepository.GetPersonaByNameFirst(name);
        }

        public async Task SavePersona(DataBaseObjects.Persona persona)
        {
            await PersonaRepository.SavePersona(persona);
        }
    }
}
