using _4_Tesis.DataAccess.Manager.Ares.Implementations;
using _4_Tesis.DataAccess.Manager.Ares.Interfaces;
using _4_Tesis.DataAccess.Manager.Clasificacion.Implementations;
using _4_Tesis.DataAccess.Manager.Clasificacion.Interfaces;
using _4_Tesis.DataAccess.Manager.Cumplimiento.Implementations;
using _4_Tesis.DataAccess.Manager.Cumplimiento.Interfaces;
using _4_Tesis.DataAccess.Manager.Documento.Implementations;
using _4_Tesis.DataAccess.Manager.Documento.Interfaces;
using _4_Tesis.DataAccess.Manager.EstadoActa.Implementations;
using _4_Tesis.DataAccess.Manager.EstadoActa.Interfaces;
using _4_Tesis.DataAccess.Manager.EstadoContratacion.Implementations;
using _4_Tesis.DataAccess.Manager.EstadoContratacion.Interfaces;
using _4_Tesis.DataAccess.Manager.EstadoPersona.Implementations;
using _4_Tesis.DataAccess.Manager.EstadoPersona.Interfaces;
using _4_Tesis.DataAccess.Manager.Item.Implementations;
using _4_Tesis.DataAccess.Manager.Item.Interfaces;
using _4_Tesis.DataAccess.Manager.Modalidad.Implementations;
using _4_Tesis.DataAccess.Manager.Modalidad.Interfaces;
using _4_Tesis.DataAccess.Manager.Persona.Implementations;
using _4_Tesis.DataAccess.Manager.Persona.Interfaces;
using _4_Tesis.DataAccess.Manager.Programacion.Implementations;
using _4_Tesis.DataAccess.Manager.Programacion.Interfaces;
using _4_Tesis.DataAccess.Manager.Proyecto.Implementations;
using _4_Tesis.DataAccess.Manager.Proyecto.Interfaces;
using _4_Tesis.DataAccess.Manager.Rol.Implementations;
using _4_Tesis.DataAccess.Manager.Rol.Interfaces;
using _4_Tesis.DataAccess.Manager.TipoDocumento.Implementations;
using _4_Tesis.DataAccess.Manager.TipoDocumento.Interfaces;

namespace _4_Tesis.DataAccess.DesingContext
{
    public class FactoryDataAccess
    {
        private static FactoryDataAccess _factoryDataAccessInstance = null;
        private static IEstadoActaRepositoryManager _estadoActaRepositoryManager;
        private static ITipoDocumentoRepositoryManager _tipoDocumentoRepositoryManager;
        private static IDocumentoRepositoryManager _documentoRepositoryManager;
        private static IItemRepositoryManager _itemRepositoryManager;
        private static IProyectoRepositoryManager _proyectoRepositoryManager;
        private static IEstadoContratacionRepositoryManager _estadoContratacionRepositoryManager;
        private static IEstadoPersonaRepositoryManager _estadoPersonaRepositoryManager;
        private static IRolRepositoryManager _rolRepositoryManager;
        private static IPersonaRepositoryManager _personaRepositoryManager;
        private static ICumplimientoRepositoryManager _cumplimientoRepositoryManager;
        private static IClasificacionRepositoryManager _clasificacionRepositoryManager;
        private static IModalidadRepositoryManager _modalidadRepositoryManager;
        private static IProgramacionRepositoryManager _programacionRepositoryManager;
        private static IAresRepositoryManager _aresRepositoryManager;

        public static FactoryDataAccess FactoryDataAccessInstance
        {
            get
            {
                if (_factoryDataAccessInstance == null)
                {
                    _factoryDataAccessInstance = new FactoryDataAccess();
                }

                return _factoryDataAccessInstance;
            }
        }

        public static IEstadoActaRepositoryManager EstadoActaRepositoryManager
        {
            get
            {
                if (_estadoActaRepositoryManager == null)
                {
                    _estadoActaRepositoryManager = new EstadoActaRepositoryManager();
                }
                return _estadoActaRepositoryManager;
            }
            set { _estadoActaRepositoryManager = value; }
        }

        public static ITipoDocumentoRepositoryManager TipoDocumentoRepositoryManager
        {
            get
            {
                if (_tipoDocumentoRepositoryManager == null)
                {
                    _tipoDocumentoRepositoryManager = new TipoDocumentoRepositoryManager();
                }
                return _tipoDocumentoRepositoryManager;
            }
            set { _tipoDocumentoRepositoryManager = value; }
        }

        public static IDocumentoRepositoryManager DocumentoRepositoryManager
        {
            get
            {
                if (_documentoRepositoryManager == null)
                {
                    _documentoRepositoryManager = new DocumentoRepositoryManager();
                }
                return _documentoRepositoryManager;
            }
            set { _documentoRepositoryManager = value; }
        }

        public static IItemRepositoryManager ItemRepositoryManager
        {
            get
            {
                if (_itemRepositoryManager == null)
                {
                    _itemRepositoryManager = new ItemRepositoryManager();
                }
                return _itemRepositoryManager;
            }
            set { _itemRepositoryManager = value; }
        }

        public static IProyectoRepositoryManager ProyectoRepositoryManager
        {
            get
            {
                if (_proyectoRepositoryManager == null)
                {
                    _proyectoRepositoryManager = new ProyectoRepositoryManager();
                }
                return _proyectoRepositoryManager;
            }
            set { _proyectoRepositoryManager = value; }
        }

        public static IEstadoContratacionRepositoryManager EstadoContratacionRepositoryManager
        {
            get
            {
                if (_estadoContratacionRepositoryManager == null)
                {
                    _estadoContratacionRepositoryManager = new EstadoContratacionRepositoryManager();
                }
                return _estadoContratacionRepositoryManager;
            }
            set { _estadoContratacionRepositoryManager = value; }
        }

        public static IEstadoPersonaRepositoryManager EstadoPersonaRepositoryManager
        {
            get
            {
                if (_estadoPersonaRepositoryManager == null)
                {
                    _estadoPersonaRepositoryManager = new EstadoPersonaRepositoryManager();
                }
                return _estadoPersonaRepositoryManager;
            }
            set { _estadoPersonaRepositoryManager = value; }
        }

        public static IRolRepositoryManager RolRepositoryManager
        {
            get
            {
                if (_rolRepositoryManager == null)
                {
                    _rolRepositoryManager = new RolRepositoryManager();
                }
                return _rolRepositoryManager;
            }
            set { _rolRepositoryManager = value; }
        }

        public static IPersonaRepositoryManager PersonaRepositoryManager
        {
            get
            {
                if (_personaRepositoryManager == null)
                {
                    _personaRepositoryManager = new PersonaRepositoryManager();
                }
                return _personaRepositoryManager;
            }
            set { _personaRepositoryManager = value; }
        }

        public static ICumplimientoRepositoryManager CumplimientoRepositoryManager
        {
            get
            {
                if (_cumplimientoRepositoryManager == null)
                {
                    _cumplimientoRepositoryManager = new CumplimientoRepositoryManager();
                }
                return _cumplimientoRepositoryManager;
            }
            set { _cumplimientoRepositoryManager = value; }
        }

        public static IClasificacionRepositoryManager ClasificacionRepositoryManager
        {
            get
            {
                if (_clasificacionRepositoryManager == null)
                {
                    _clasificacionRepositoryManager = new ClasificacionRepositoryManager();
                }
                return _clasificacionRepositoryManager;
            }
            set { _clasificacionRepositoryManager = value; }
        }

        public static IModalidadRepositoryManager ModalidadRepositoryManager
        {
            get
            {
                if (_modalidadRepositoryManager == null)
                {
                    _modalidadRepositoryManager = new ModalidadRepositoryManager();
                }
                return _modalidadRepositoryManager;
            }
            set { _modalidadRepositoryManager = value; }
        }

        public static IProgramacionRepositoryManager ProgramacionRepositoryManager
        {
            get
            {
                if (_programacionRepositoryManager == null)
                {
                    _programacionRepositoryManager = new ProgramacionRepositoryManager();
                }
                return _programacionRepositoryManager;
            }
            set { _programacionRepositoryManager = value; }
        }

        public static IAresRepositoryManager AresRepositoryManager
        {
            get
            {
                if (_aresRepositoryManager == null)
                {
                    _aresRepositoryManager = new AresRepositoryManager();
                }
                return _aresRepositoryManager;
            }
            set { _aresRepositoryManager = value; }
        }
    }
}
