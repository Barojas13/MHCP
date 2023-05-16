using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.Persona.Interfaces;

namespace _3_Tesis.Domain.Managers.Persona.Implementations
{
    public class PersonaDomainManager : IPersonaDomainManager
    {
        private static IPersonaCore _personaCore;

        public static IPersonaCore PersonaCore
        {
            get
            {
                if (_personaCore == null)
                {
                    _personaCore = new PersonaCore();
                }
                return _personaCore;
            }
            set { _personaCore = value; }
        }

        public async Task SavePersona(_4_Tesis.DataAccess.DataBaseObjects.Persona persona)
        {
            await _personaCore.SavePersona(persona);
        }
    }
}
