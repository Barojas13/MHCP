using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.Clasificacion.Implementations;
using _3_Tesis.Domain.Managers.Clasificacion.Interfaces;
using _3_Tesis.Domain.Managers.Cumplimiento.Implementations;
using _3_Tesis.Domain.Managers.Cumplimiento.Interfaces;
using _3_Tesis.Domain.Managers.Documento.Implementations;
using _3_Tesis.Domain.Managers.Documento.Interfaces;
using _3_Tesis.Domain.Managers.EstadoActa.Implementations;
using _3_Tesis.Domain.Managers.EstadoActa.Interfaces;
using _3_Tesis.Domain.Managers.EstadoContratacion.Implementations;
using _3_Tesis.Domain.Managers.EstadoContratacion.Interfaces;
using _3_Tesis.Domain.Managers.EstadoPersona.Implementations;
using _3_Tesis.Domain.Managers.EstadoPersona.Interfaces;
using _3_Tesis.Domain.Managers.Item.Implementations;
using _3_Tesis.Domain.Managers.Item.Interfaces;
using _3_Tesis.Domain.Managers.LeerExcel1.Implementations;
using _3_Tesis.Domain.Managers.LeerExcel1.Interfaces;
using _3_Tesis.Domain.Managers.Modalidad.Implementations;
using _3_Tesis.Domain.Managers.Modalidad.Interfaces;
using _3_Tesis.Domain.Managers.Persona.Implementations;
using _3_Tesis.Domain.Managers.Persona.Interfaces;
using _3_Tesis.Domain.Managers.Programacion.Implementations;
using _3_Tesis.Domain.Managers.Programacion.Interfaces;
using _3_Tesis.Domain.Managers.Proyecto.Implementations;
using _3_Tesis.Domain.Managers.Proyecto.Interfaces;
using _3_Tesis.Domain.Managers.Rol.Implementations;
using _3_Tesis.Domain.Managers.Rol.Interfaces;
using _3_Tesis.Domain.Managers.TipoDocumento.Implementations;
using _3_Tesis.Domain.Managers.TipoDocumento.Interfaces;

namespace _3_Tesis.Domain.DesingContext
{
    public class FactoryDomain
    {
        private static FactoryDomain _factoryDomainInstance = null;
        private static IClasificacionDomainManager _clasificacionDomainManager;
        private static ICumplimientoDomainManager _cumplimientoDomainManager;
        private static IDocumentoDomainManager _documentoDomainManager;
        private static IEstadoActaDomainManager _estadoActaDomainManager;
        private static IEstadoContratacionDomainManager _estadoContratacionDomainManager;
        private static IEstadoPersonaDomainManager _estadoPersonaDomainManager;
        private static IItemDomainManager _itemDomainManager;
        private static IModalidadDomainManager _modalidadDomainManager;
        private static IPersonaDomainManager _personaDomainManager;
        private static IProgramacionDomainManager _programacionDomainManager;
        private static IProyectoDomainManager _proyectoDomainManager;
        private static IRolDomainManager _rolDomainManager;
        private static ITipoDocumentoDomainManager _tipoDocumentoDomainManager;
        private static ILeerExcel1DomainManager _leerExcel1DomainManager;

        public static FactoryDomain FactoryDomainInstance
        {
            get
            {
                if (_factoryDomainInstance == null)
                {
                    _factoryDomainInstance = new FactoryDomain();
                }

                return _factoryDomainInstance;
            }
        }

        public static IClasificacionDomainManager ClasificacionDomainManager
        {
            get
            {
                if (_clasificacionDomainManager == null)
                {
                    _clasificacionDomainManager = new ClasificacionDomainManager();
                }
                return _clasificacionDomainManager;
            }
            set { _clasificacionDomainManager = value; }
        }

        public static ICumplimientoDomainManager CumplimientoDomainManager
        {
            get
            {
                if (_cumplimientoDomainManager == null)
                {
                    _cumplimientoDomainManager = new CumplimientoDomainManager();
                }
                return _cumplimientoDomainManager;
            }
            set { _cumplimientoDomainManager = value; }
        }

        public static IDocumentoDomainManager DocumentoDomainManager
        {
            get
            {
                if (_documentoDomainManager == null)
                {
                    _documentoDomainManager = new DocumentoDomainManager();
                }
                return _documentoDomainManager;
            }
            set { _documentoDomainManager = value; }
        }

        public static IEstadoActaDomainManager EstadoActaDomainManager
        {
            get
            {
                if (_estadoActaDomainManager == null)
                {
                    _estadoActaDomainManager = new EstadoActaDomainManager();
                }
                return _estadoActaDomainManager;
            }
            set { _estadoActaDomainManager = value; }
        }

        public static IEstadoContratacionDomainManager EstadoContratacionDomainManager
        {
            get
            {
                if (_estadoContratacionDomainManager == null)
                {
                    _estadoContratacionDomainManager = new EstadoContratacionDomainManager();
                }
                return _estadoContratacionDomainManager;
            }
            set { _estadoContratacionDomainManager = value; }
        }

        public static IEstadoPersonaDomainManager EstadoPersonaDomainManager
        {
            get
            {
                if (_estadoPersonaDomainManager == null)
                {
                    _estadoPersonaDomainManager = new EstadoPersonaDomainManager();
                }
                return _estadoPersonaDomainManager;
            }
            set { _estadoPersonaDomainManager = value; }
        }

        public static IItemDomainManager ItemDomainManager
        {
            get
            {
                if (_itemDomainManager == null)
                {
                    _itemDomainManager = new ItemDomainManager();
                }
                return _itemDomainManager;
            }
            set { _itemDomainManager = value; }
        }

        public static IModalidadDomainManager ModalidadDomainManager
        {
            get
            {
                if (_modalidadDomainManager == null)
                {
                    _modalidadDomainManager = new ModalidadDomainManager();
                }
                return _modalidadDomainManager;
            }
            set { _modalidadDomainManager = value; }
        }

        public static IPersonaDomainManager PersonaDomainManager
        {
            get
            {
                if (_personaDomainManager == null)
                {
                    _personaDomainManager = new PersonaDomainManager();
                }
                return _personaDomainManager;
            }
            set { _personaDomainManager = value; }
        }

        public static IProgramacionDomainManager ProgramacionDomainManager
        {
            get
            {
                if (_programacionDomainManager == null)
                {
                    _programacionDomainManager = new ProgramacionDomainManager();
                }
                return _programacionDomainManager;
            }
            set { _programacionDomainManager = value; }
        }

        public static IProyectoDomainManager ProyectoDomainManager
        {
            get
            {
                if (_proyectoDomainManager == null)
                {
                    _proyectoDomainManager = new ProyectoDomainManager();
                }
                return _proyectoDomainManager;
            }
            set { _proyectoDomainManager = value; }
        }

        public static IRolDomainManager RolDomainManager
        {
            get
            {
                if (_rolDomainManager == null)
                {
                    _rolDomainManager = new RolDomainManager();
                }
                return _rolDomainManager;
            }
            set { _rolDomainManager = value; }
        }

        public static ITipoDocumentoDomainManager TipoDocumentoDomainManager
        {
            get
            {
                if (_tipoDocumentoDomainManager == null)
                {
                    _tipoDocumentoDomainManager = new TipoDocumentoDomainManager();
                }
                return _tipoDocumentoDomainManager;
            }
            set { _tipoDocumentoDomainManager = value; }
        }

        public static ILeerExcel1DomainManager LeerExcel1DomainManager
        {
            get
            {
                if (_leerExcel1DomainManager == null)
                {
                    _leerExcel1DomainManager = new LeerExcel1DomainManager();
                }
                return _leerExcel1DomainManager;
            }
            set { _leerExcel1DomainManager = value; }
        }
    }
}
