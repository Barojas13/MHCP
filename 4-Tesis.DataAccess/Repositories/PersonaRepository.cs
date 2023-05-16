using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;
using Microsoft.EntityFrameworkCore;

namespace _4_Tesis.DataAccess.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public PersonaRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task<Persona> GetPersonaByName(string name, int idRol, int idModalidad)
        {
            Persona persona = new Persona();

            try
            {
                return await _eTLCRMContext.Persona.FirstAsync(a => a.nombre_persona == name && a.id_rol == idRol && a.id_modalidad == idModalidad);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Persona> GetPersonaByNameFirst(string name)
        {
            Persona persona = new Persona();

            try
            {
                return await _eTLCRMContext.Persona.FirstAsync(a => a.nombre_persona == name);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task SavePersona(Persona persona)
        {
            try
            {
                await _eTLCRMContext.Persona.AddAsync(persona);
                await _eTLCRMContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
