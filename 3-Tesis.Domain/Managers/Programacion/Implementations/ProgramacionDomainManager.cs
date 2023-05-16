using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.Programacion.Interfaces;

namespace _3_Tesis.Domain.Managers.Programacion.Implementations
{
    public class ProgramacionDomainManager : IProgramacionDomainManager
    {
        private static IProgramacionCore _programacionCore;

        public static IProgramacionCore ProgramacionCore
        {
            get
            {
                if (_programacionCore == null)
                {
                    _programacionCore = new ProgramacionCore();
                }
                return _programacionCore;
            }
            set { _programacionCore = value; }
        }

        public async Task SaveProgramacion(_4_Tesis.DataAccess.DataBaseObjects.Programacion programacion)
        {
            await _programacionCore.SaveProgramacion(programacion);
        }
    }
}
