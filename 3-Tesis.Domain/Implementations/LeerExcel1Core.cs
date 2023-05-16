using _3_Tesis.Domain.Interfaces;
using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.DesingContext;
using _5_Tesis.TransverseInfraestructure.Implementations;
using _5_Tesis.TransverseInfraestructure.Interfaces;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace _3_Tesis.Domain.Implementations
{
    public class LeerExcel1Core : ILeerExcel1Core
    {
        private static IObjectConverterHelper _objectConverterHelper;

        public static IObjectConverterHelper ObjectConverterHelper
        {
            get
            {
                if (_objectConverterHelper == null)
                {
                    _objectConverterHelper = new ObjectConverterHelper();
                }
                return _objectConverterHelper;
            }
            set { _objectConverterHelper = value; }
        }

        public async Task LeerExcel1(IFormFile formFile)
        {
            int IdItem = 0;
            int IdProyecto = 0;
            int IdRol = 0;
            int IdModalidad = 0;
            int IdPersona = 0;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(formFile.OpenReadStream()))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;

                for (int row = 1; row <= rowCount; row++)
                {
                    if (row > 1)
                    {
                        for (int col = 1; col <= colCount; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Value;
                            cellValue = cellValue != null ? RemoveDiacritics(cellValue.ToString().ToUpper()) : "N/A";

                            switch (col)
                            {
                                case 1:
                                    Item getItem = await FactoryDataAccess.ItemRepositoryManager.GetItemByName(cellValue.ToString());

                                    if (getItem == null)
                                    {
                                        Item item = new Item();
                                        item.nombre_item = cellValue.ToString();

                                        await FactoryDataAccess.ItemRepositoryManager.SaveItem(item);
                                        getItem = await FactoryDataAccess.ItemRepositoryManager.GetItemByName(cellValue.ToString());

                                    }

                                    IdItem = getItem.id_item;

                                    break;
                                case 2:
                                    Proyecto getProyecto = await FactoryDataAccess.ProyectoRepositoryManager.GetProyectoByNameAndItemId(cellValue.ToString(), IdItem);

                                    if (getProyecto == null)
                                    {
                                        Proyecto proyecto = new Proyecto();
                                        proyecto.id_item = IdItem;
                                        proyecto.nombre_proyecto = cellValue.ToString();

                                        await FactoryDataAccess.ProyectoRepositoryManager.SaveProyecto(proyecto);
                                        getProyecto = await FactoryDataAccess.ProyectoRepositoryManager.GetProyectoByNameAndItemId(cellValue.ToString(), IdItem);
                                    }

                                    IdProyecto = getProyecto.id_proyecto;

                                    break;
                                case 4:
                                    object modalidad = worksheet.Cells[row, 6].Value;

                                    if (modalidad != null)
                                    {
                                        object tarifa = worksheet.Cells[row, 7].Value;

                                        if (tarifa != null)
                                        {
                                            Rol getRol = await FactoryDataAccess.RolRepositoryManager.GetRolByName(cellValue.ToString());

                                            if (getRol == null)
                                            {
                                                Rol rol = new Rol();
                                                rol.nombre_rol = cellValue.ToString();

                                                string valorConvertido = tarifa.ToString();

                                                if (modalidad.ToString().ToUpper() == "PRESENCIAL")
                                                {
                                                    rol.tarifa_presecial = Convert.ToDecimal(valorConvertido);
                                                }
                                                else if (modalidad.ToString().ToUpper() == "VIRTUAL")
                                                {
                                                    rol.tarifa_virtual = Convert.ToDecimal(valorConvertido);
                                                }
                                                else if (modalidad.ToString().ToUpper() == "HIBRIDO")
                                                {
                                                    rol.tarifa_hibrido = Convert.ToDecimal(valorConvertido);
                                                }

                                                await FactoryDataAccess.RolRepositoryManager.SaveRol(rol);
                                            }
                                            else
                                            {
                                                string valorConvertido = tarifa.ToString();

                                                if (modalidad.ToString().ToUpper() == "PRESENCIAL" && getRol.tarifa_presecial == null)
                                                {
                                                    getRol.tarifa_presecial = Convert.ToDecimal(valorConvertido);
                                                }
                                                else if (modalidad.ToString().ToUpper() == "VIRTUAL" && getRol.tarifa_virtual == null)
                                                {
                                                    getRol.tarifa_virtual = Convert.ToDecimal(valorConvertido);
                                                }
                                                else if (modalidad.ToString().ToUpper() == "HIBRIDO")
                                                {
                                                    getRol.tarifa_hibrido = Convert.ToDecimal(valorConvertido);
                                                }

                                                await FactoryDataAccess.RolRepositoryManager.UpdateRol(getRol);
                                            }

                                            getRol = await FactoryDataAccess.RolRepositoryManager.GetRolByName(cellValue.ToString());
                                            IdRol = getRol.id_rol;
                                        }
                                    }

                                    break;
                                case 5:
                                    string valorIdModalidad = ConvetirCamposVacios(worksheet.Cells[row, 6].Value);
                                    IdModalidad = await MetodoModalidad(valorIdModalidad.ToUpper());
                                    Persona getPersona = await FactoryDataAccess.PersonaRepositoryManager.GetPersonaByName(cellValue.ToString(), IdRol, IdModalidad);

                                    if (getPersona == null)
                                    {
                                        Persona getPersonaSola = await FactoryDataAccess.PersonaRepositoryManager.GetPersonaByNameFirst(cellValue.ToString());

                                        if (getPersonaSola != null)
                                        {
                                            Persona persona = new Persona();
                                            persona.nombre_persona = cellValue.ToString();
                                            persona.id_rol = IdRol;
                                            persona.id_item = IdItem;
                                            persona.id_proyecto = IdProyecto;
                                            persona.id_modalidad = IdModalidad;
                                            persona.fecha_solicitud = getPersonaSola.fecha_solicitud;
                                            persona.fecha_envio = getPersonaSola.fecha_envio;
                                            persona.fecha_supervisores = getPersonaSola.fecha_supervisores;
                                            persona.fecha_aprobacion = getPersonaSola.fecha_aprobacion;
                                            persona.fecha_contratacion = getPersonaSola.fecha_contratacion;
                                            string valorFechaIngreso = ConvetirCamposVacios(worksheet.Cells[row, 8].Value);
                                            persona.fecha_ingreso = valorFechaIngreso == "N/A" ? null : DateTime.Parse(valorFechaIngreso);
                                            string valorFechaFin = ConvetirCamposVacios(worksheet.Cells[row, 9].Value);
                                            persona.fecha_fin = valorFechaFin == "N/A" ? null : DateTime.Parse(valorFechaFin);
                                            persona.id_clasificacion = getPersonaSola.id_clasificacion;
                                            persona.id_cumplimiento = getPersonaSola.id_cumplimiento;
                                            persona.id_estado_persona = getPersonaSola.id_estado_persona;
                                            persona.id_estado_contratacion = getPersonaSola.id_estado_contratacion;

                                            await FactoryDataAccess.PersonaRepositoryManager.SavePersona(persona);
                                        }
                                    }

                                    getPersona = await FactoryDataAccess.PersonaRepositoryManager.GetPersonaByName(cellValue.ToString(), IdRol, IdModalidad);
                                    IdPersona = getPersona == null ? 0 : getPersona.id_persona;
                                    break;
                                case 10:
                                    Programacion programacion = new Programacion();
                                    programacion.id_item = IdItem;
                                    programacion.id_proyecto = IdProyecto;
                                    programacion.id_rol = IdRol;
                                    programacion.id_persona = IdPersona == 0 ? null : IdPersona;
                                    programacion.id_modalidad = IdModalidad;
                                    programacion.A2022_12 = Convert.ToInt32(worksheet.Cells[row, 10].Value);
                                    programacion.A2023_01 = Convert.ToInt32(worksheet.Cells[row, 11].Value);
                                    programacion.A2023_02 = Convert.ToInt32(worksheet.Cells[row, 12].Value);
                                    programacion.A2023_03 = Convert.ToInt32(worksheet.Cells[row, 13].Value);
                                    programacion.A2023_04 = Convert.ToInt32(worksheet.Cells[row, 14].Value);
                                    programacion.A2023_05 = Convert.ToInt32(worksheet.Cells[row, 15].Value);
                                    programacion.A2023_06 = Convert.ToInt32(worksheet.Cells[row, 16].Value);
                                    programacion.A2023_07 = Convert.ToInt32(worksheet.Cells[row, 17].Value);
                                    programacion.A2023_08 = Convert.ToInt32(worksheet.Cells[row, 18].Value);
                                    programacion.A2023_09 = Convert.ToInt32(worksheet.Cells[row, 19].Value);
                                    programacion.A2023_10 = Convert.ToInt32(worksheet.Cells[row, 20].Value);
                                    programacion.A2023_11 = Convert.ToInt32(worksheet.Cells[row, 21].Value);
                                    programacion.A2023_12 = Convert.ToInt32(worksheet.Cells[row, 22].Value);
                                    programacion.A2024_01 = Convert.ToInt32(worksheet.Cells[row, 23].Value);
                                    programacion.A2024_02 = Convert.ToInt32(worksheet.Cells[row, 24].Value);
                                    programacion.A2024_03 = Convert.ToInt32(worksheet.Cells[row, 25].Value);
                                    programacion.A2024_04 = Convert.ToInt32(worksheet.Cells[row, 26].Value);
                                    programacion.A2024_05 = Convert.ToInt32(worksheet.Cells[row, 27].Value);
                                    programacion.A2024_06 = Convert.ToInt32(worksheet.Cells[row, 28].Value);
                                    programacion.A2024_07 = Convert.ToInt32(worksheet.Cells[row, 29].Value);
                                    programacion.A2024_08 = Convert.ToInt32(worksheet.Cells[row, 30].Value);
                                    programacion.A2024_09 = Convert.ToInt32(worksheet.Cells[row, 31].Value);
                                    programacion.A2024_10 = Convert.ToInt32(worksheet.Cells[row, 32].Value);

                                    await FactoryDataAccess.ProgramacionRepositoryManager.SaveProgramacion(programacion);

                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public static string RemoveDiacritics(string texto)
        {
            string normalizedString = texto.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(normalizedString[i]);
                }
            }

            return stringBuilder.ToString();
        }

        public async Task<int> MetodoModalidad(string cellValue)
        {
            Modalidad getModalidad = await FactoryDataAccess.ModalidadRepositoryManager.GetModalidadByName(cellValue.ToString());

            if (getModalidad == null)
            {
                Modalidad modalidad = new Modalidad();
                modalidad.nombre_modalidad = cellValue.ToString();

                await FactoryDataAccess.ModalidadRepositoryManager.SaveModalidad(modalidad);
                getModalidad = await FactoryDataAccess.ModalidadRepositoryManager.GetModalidadByName(cellValue.ToString());
            }

            return getModalidad.id_modalidad;
        }

        public async Task LeerExcel2(IFormFile formFile)
        {
            int IdRol = 0;
            int IdItem = 0;
            int IdProyecto = 0;
            int IdClasificacion = 0;
            int IdCumplimiento = 0;
            int IdEstadoPersona = 0;
            int IdEstadoContratacion = 0;
            int IdModalidad = 0;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(formFile.OpenReadStream()))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;

                for (int row = 1; row <= rowCount; row++)
                {
                    if (row > 6)
                    {
                        for (int col = 1; col <= colCount; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Value;

                            cellValue = cellValue != null ? RemoveDiacritics(cellValue.ToString().ToUpper()) : "N/A";

                            switch (col)
                            {
                                case 2:

                                    object modalidad = worksheet.Cells[row, 6].Value;

                                    if (modalidad != null)
                                    {
                                        object tarifa = worksheet.Cells[row, 24].Value;

                                        if (tarifa != null)
                                        {
                                            Rol getRol = await FactoryDataAccess.RolRepositoryManager.GetRolByName(cellValue.ToString());

                                            if (getRol == null)
                                            {
                                                Rol rol = new Rol();
                                                rol.nombre_rol = cellValue.ToString();

                                                string valorConvertido = tarifa.ToString();

                                                if (modalidad.ToString().ToUpper() == "PRESENCIAL")
                                                {
                                                    rol.tarifa_presecial = Convert.ToDecimal(valorConvertido);
                                                }
                                                else if (modalidad.ToString().ToUpper() == "VIRTUAL")
                                                {
                                                    rol.tarifa_virtual = Convert.ToDecimal(valorConvertido);
                                                }
                                                else if(modalidad.ToString().ToUpper() == "HIBRIDO")
                                                {
                                                    rol.tarifa_hibrido = Convert.ToDecimal(valorConvertido);
                                                }

                                                await FactoryDataAccess.RolRepositoryManager.SaveRol(rol);
                                            }
                                            else
                                            {
                                                string valorConvertido = tarifa.ToString();

                                                if (modalidad.ToString().ToUpper() == "PRESENCIAL" && getRol.tarifa_presecial == null)
                                                {
                                                    getRol.tarifa_presecial = Convert.ToDecimal(valorConvertido);
                                                }
                                                else if (modalidad.ToString().ToUpper() == "VIRTUAL" && getRol.tarifa_virtual == null)
                                                {
                                                    getRol.tarifa_virtual = Convert.ToDecimal(valorConvertido);
                                                }
                                                else if (modalidad.ToString().ToUpper() == "HIBRIDO")
                                                {
                                                    getRol.tarifa_hibrido = Convert.ToDecimal(valorConvertido);
                                                }

                                                await FactoryDataAccess.RolRepositoryManager.UpdateRol(getRol);
                                            }

                                            getRol = await FactoryDataAccess.RolRepositoryManager.GetRolByName(cellValue.ToString());
                                            IdRol = getRol.id_rol;
                                        }
                                    }

                                    break;
                                case 3:
                                    Item getItem = await FactoryDataAccess.ItemRepositoryManager.GetItemByName(cellValue.ToString());

                                    if (getItem == null)
                                    {
                                        Item item = new Item();
                                        item.nombre_item = cellValue.ToString();

                                        await FactoryDataAccess.ItemRepositoryManager.SaveItem(item);
                                        getItem = await FactoryDataAccess.ItemRepositoryManager.GetItemByName(cellValue.ToString());

                                    }

                                    IdItem = getItem.id_item;

                                    break;
                                case 4:
                                    Proyecto getProyecto = await FactoryDataAccess.ProyectoRepositoryManager.GetProyectoByNameAndItemId(cellValue.ToString(), IdItem);

                                    if (getProyecto == null)
                                    {
                                        Proyecto proyecto = new Proyecto();
                                        proyecto.id_item = IdItem;
                                        proyecto.nombre_proyecto = cellValue.ToString();

                                        await FactoryDataAccess.ProyectoRepositoryManager.SaveProyecto(proyecto);
                                        getProyecto = await FactoryDataAccess.ProyectoRepositoryManager.GetProyectoByNameAndItemId(cellValue.ToString(), IdItem);
                                    }

                                    IdProyecto = getProyecto.id_proyecto;

                                    break;
                                case 6:

                                    string valor = worksheet.Cells[row, col].Value != null ? worksheet.Cells[row, col].Value.ToString() : "N/A";
                                    IdModalidad = await MetodoModalidad(valor.ToUpper());

                                    break;
                                case 7:
                                    Clasificacion getClasificacion = await FactoryDataAccess.ClasificacionRepositoryManager.GetClasificacionByName(cellValue.ToString());

                                    if (getClasificacion == null)
                                    {
                                        Clasificacion clasificacion = new Clasificacion();
                                        clasificacion.nombre_clasificacion = cellValue.ToString();

                                        await FactoryDataAccess.ClasificacionRepositoryManager.SaveClasificacion(clasificacion);
                                        getClasificacion = await FactoryDataAccess.ClasificacionRepositoryManager.GetClasificacionByName(cellValue.ToString());
                                    }

                                    IdClasificacion = getClasificacion.id_clasificacion;

                                    break;
                                case 11:
                                    Cumplimiento getCumplimiento = await FactoryDataAccess.CumplimientoRepositoryManager.GetCumplimientoByName(cellValue.ToString());

                                    if (getCumplimiento == null)
                                    {
                                        Cumplimiento cumplimiento = new Cumplimiento();
                                        cumplimiento.nombre_cumplimiento = cellValue.ToString();

                                        await FactoryDataAccess.CumplimientoRepositoryManager.SaveCumplimiento(cumplimiento);
                                        getCumplimiento = await FactoryDataAccess.CumplimientoRepositoryManager.GetCumplimientoByName(cellValue.ToString());
                                    }

                                    IdCumplimiento = getCumplimiento.id_cumplimiento;

                                    break;
                                case 12:
                                    EstadoPersona getEstadoPersona = await FactoryDataAccess.EstadoPersonaRepositoryManager.GetEstadoPersonaByName(cellValue.ToString());

                                    if (getEstadoPersona == null)
                                    {
                                        EstadoPersona estadoPersona = new EstadoPersona();
                                        estadoPersona.nombre_estado_persona = cellValue.ToString();

                                        await FactoryDataAccess.EstadoPersonaRepositoryManager.SaveEstadoPersona(estadoPersona);
                                        getEstadoPersona = await FactoryDataAccess.EstadoPersonaRepositoryManager.GetEstadoPersonaByName(cellValue.ToString());
                                    }

                                    IdEstadoPersona = getEstadoPersona.id_estado_persona;

                                    break;
                                case 13:
                                    EstadoContratacion getEstadoContratacion = await FactoryDataAccess.EstadoContratacionRepositoryManager.GetEstadoContratacionByName(cellValue.ToString());

                                    if (getEstadoContratacion == null)
                                    {
                                        EstadoContratacion estadoContratacion = new EstadoContratacion();
                                        estadoContratacion.nombre_estado_contratacion = cellValue.ToString();

                                        await FactoryDataAccess.EstadoContratacionRepositoryManager.SaveEstadoContratacion(estadoContratacion);
                                        getEstadoContratacion = await FactoryDataAccess.EstadoContratacionRepositoryManager.GetEstadoContratacionByName(cellValue.ToString());
                                    }

                                    IdEstadoContratacion = getEstadoContratacion.id_estado_contratacion;

                                    break;
                                case 14:
                                    Persona getPersona = await FactoryDataAccess.PersonaRepositoryManager.GetPersonaByName(cellValue.ToString(), IdRol, IdModalidad);

                                    if (getPersona == null)
                                    {
                                        Persona persona = new Persona();
                                        string valorNombrePersona = ConvetirCamposVacios(worksheet.Cells[row, 1].Value);
                                        persona.nombre_persona = RemoveDiacritics(valorNombrePersona.ToUpper());
                                        persona.id_rol = IdRol == 0 ? null : IdRol;
                                        persona.id_item = IdItem;
                                        persona.id_proyecto = IdProyecto;
                                        persona.id_modalidad = IdModalidad;
                                        persona.id_clasificacion = IdClasificacion;
                                        persona.id_estado_persona = IdEstadoPersona;
                                        persona.id_estado_contratacion = IdEstadoContratacion;
                                        persona.id_cumplimiento = IdCumplimiento;
                                        string valorFechaSolicitud = ConvetirCamposVacios(worksheet.Cells[row, 8].Value);
                                        persona.fecha_solicitud = valorFechaSolicitud == "N/A" ? null : DateTime.Parse(valorFechaSolicitud);
                                        string valorFechaEnvio = ConvetirCamposVacios(worksheet.Cells[row, 15].Value);
                                        persona.fecha_envio = valorFechaEnvio == "N/A" ? null : DateTime.Parse(valorFechaEnvio);
                                        string valorFechaSupervisores = ConvetirCamposVacios(worksheet.Cells[row, 16].Value);
                                        persona.fecha_supervisores = valorFechaSupervisores == "N/A" ? null : DateTime.Parse(valorFechaSupervisores);
                                        string valorFechaAprobacion = ConvetirCamposVacios(worksheet.Cells[row, 17].Value);
                                        persona.fecha_aprobacion = valorFechaAprobacion == "N/A" ? null : DateTime.Parse(valorFechaAprobacion);
                                        string valorFechaContratacion = ConvetirCamposVacios(worksheet.Cells[row, 18].Value);
                                        persona.fecha_contratacion = valorFechaContratacion == "N/A" ? null : DateTime.Parse(valorFechaContratacion);
                                        string valorFechaIngreso = ConvetirCamposVacios(worksheet.Cells[row, 19].Value);
                                        persona.fecha_ingreso = valorFechaIngreso == "N/A" ? null : DateTime.Parse(valorFechaIngreso);
                                        string valorFechaFin = ConvetirCamposVacios(worksheet.Cells[row, 20].Value);
                                        persona.fecha_fin = valorFechaFin == "N/A" ? null : DateTime.Parse(valorFechaFin);
                                        string valorResponsable = ConvetirCamposVacios(worksheet.Cells[row, 21].Value);
                                        persona.responsable = valorResponsable.ToUpper();
                                        string valorTarifa = ConvetirCamposVacios(worksheet.Cells[row, 24].Value);
                                        string valorBitacora = ConvetirCamposVacios(worksheet.Cells[row, 26].Value);
                                        persona.bitacora = valorBitacora.ToUpper();

                                        await FactoryDataAccess.PersonaRepositoryManager.SavePersona(persona);
                                    }

                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private string ConvetirCamposVacios(object valor)
        {
            return valor != null ? valor.ToString() : "N/A";
        }

        public async Task LeerExcel3(IFormFile formFile)
        {
            int IdItem = 0;
            int IdProyecto = 0;
            int IdTipoDocumento = 0;
            int IdEstadoActa = 0;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(formFile.OpenReadStream()))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;

                for (int row = 1; row <= rowCount; row++)
                {
                    if (row > 1)
                    {
                        for (int col = 1; col <= colCount; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Value;

                            cellValue = cellValue != null ? RemoveDiacritics(cellValue.ToString().ToUpper()) : "N/A";

                            switch (col)
                            {
                                case 3:
                                    Item getItem = await FactoryDataAccess.ItemRepositoryManager.GetItemByName(cellValue.ToString());

                                    if (getItem == null)
                                    {
                                        Item item = new Item();
                                        item.nombre_item = cellValue.ToString();

                                        await FactoryDataAccess.ItemRepositoryManager.SaveItem(item);
                                        getItem = await FactoryDataAccess.ItemRepositoryManager.GetItemByName(cellValue.ToString());

                                    }

                                    IdItem = getItem.id_item;

                                    break;
                                case 4:
                                    Proyecto getProyecto = await FactoryDataAccess.ProyectoRepositoryManager.GetProyectoByNameAndItemId(cellValue.ToString(), IdItem);

                                    if (getProyecto == null)
                                    {
                                        Proyecto proyecto = new Proyecto();
                                        proyecto.id_item = IdItem;
                                        proyecto.nombre_proyecto = cellValue.ToString();

                                        await FactoryDataAccess.ProyectoRepositoryManager.SaveProyecto(proyecto);
                                        getProyecto = await FactoryDataAccess.ProyectoRepositoryManager.GetProyectoByNameAndItemId(cellValue.ToString(), IdItem);
                                    }

                                    IdProyecto = getProyecto.id_proyecto;

                                    break;
                                case 5:
                                    TipoDocumento getTipoDocumento = await FactoryDataAccess.TipoDocumentoRepositoryManager.GetTipoDocumentoByName(cellValue.ToString());

                                    if (getTipoDocumento == null)
                                    {
                                        TipoDocumento tipoDocumento = new TipoDocumento();
                                        tipoDocumento.nombre_tipo_documento = cellValue.ToString();

                                        await FactoryDataAccess.TipoDocumentoRepositoryManager.SaveTipoDocumento(tipoDocumento);
                                        getTipoDocumento = await FactoryDataAccess.TipoDocumentoRepositoryManager.GetTipoDocumentoByName(cellValue.ToString());
                                    }

                                    IdTipoDocumento = getTipoDocumento.id_tipo_documento;

                                    break;
                                case 10:
                                    EstadoActa getEstadoActa = await FactoryDataAccess.EstadoActaRepositoryManager.GetEstadoActaByName(cellValue.ToString());

                                    if (getEstadoActa == null)
                                    {
                                        EstadoActa estadoActa = new EstadoActa();
                                        estadoActa.nombre_estado_acta = cellValue.ToString();

                                        await FactoryDataAccess.EstadoActaRepositoryManager.SaveEstadoActa(estadoActa);
                                        getEstadoActa = await FactoryDataAccess.EstadoActaRepositoryManager.GetEstadoActaByName(cellValue.ToString());
                                    }

                                    IdEstadoActa = getEstadoActa.id_estado_acta;

                                    break;
                                case 11:
                                    Documento documento = new Documento();
                                    string valorNombreDocumento = ConvetirCamposVacios(worksheet.Cells[row, 1].Value);
                                    documento.nombre_documento = RemoveDiacritics(valorNombreDocumento.ToUpper());
                                    documento.id_proyecto = IdProyecto;
                                    documento.id_item = IdItem;
                                    documento.id_tipo_documento = IdTipoDocumento;
                                    documento.id_estado_acta = IdEstadoActa;
                                    string valorMes = ConvetirCamposVacios(worksheet.Cells[row, 6].Value);
                                    documento.mes = RemoveDiacritics(valorMes.ToUpper());
                                    string valorFechaReunion = ConvetirCamposVacios(worksheet.Cells[row, 8].Value);
                                    documento.fecha_reunion = valorFechaReunion == "N/A" ? null : DateTime.Parse(valorFechaReunion);
                                    string valorResponsable = ConvetirCamposVacios(worksheet.Cells[row, 9].Value);
                                    documento.responsable = RemoveDiacritics(valorResponsable.ToUpper());
                                    string valorFechaEnvioRev = ConvetirCamposVacios(worksheet.Cells[row, 12].Value);
                                    documento.fecha_envio_rev = valorFechaEnvioRev == "N/A" ? null : DateTime.Parse(valorFechaEnvioRev);
                                    string valorFechaApro = ConvetirCamposVacios(worksheet.Cells[row, 15].Value);
                                    documento.fecha_apro = valorFechaApro == "N/A" ? null : DateTime.Parse(valorFechaApro);
                                    string valorFechaEnvioFir = ConvetirCamposVacios(worksheet.Cells[row, 18].Value);
                                    documento.fecha_envio_fir = valorFechaEnvioFir == "N/A" ? null : DateTime.Parse(valorFechaEnvioFir);
                                    string valorFechaCargue = ConvetirCamposVacios(worksheet.Cells[row, 19].Value);
                                    documento.fecha_cargue = valorFechaCargue == "N/A" ? null : DateTime.Parse(valorFechaCargue);
                                    string valorObservaciones = ConvetirCamposVacios(worksheet.Cells[row, 20].Value);
                                    documento.observaciones = RemoveDiacritics(valorObservaciones);
                                    string valorLinkEditable = ConvetirCamposVacios(worksheet.Cells[row, 21].Value);
                                    documento.link_editable = valorLinkEditable;
                                    string valorLinkConsulta = ConvetirCamposVacios(worksheet.Cells[row, 22].Value);
                                    documento.link_consulta = valorLinkConsulta;
                                    string valorLinkSharepoint = ConvetirCamposVacios(worksheet.Cells[row, 24].Value);
                                    documento.link_sharepoint_aws = valorLinkSharepoint;

                                    await FactoryDataAccess.DocumentoRepositoryManager.SaveDocumento(documento);

                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public async Task LeerExcel4(IFormFile formFile)
        {
            int IdPersona = 0;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(formFile.OpenReadStream()))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;

                for (int row = 1; row <= rowCount; row++)
                {
                    if (row > 1)
                    {
                        for (int col = 1; col <= colCount; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Value;

                            cellValue = cellValue != null ? RemoveDiacritics(cellValue.ToString().ToUpper()) : "N/A";

                            switch (col)
                            {
                                case 1:
                                    Persona getPersonaSola = await FactoryDataAccess.PersonaRepositoryManager.GetPersonaByNameFirst(cellValue.ToString());

                                    if (getPersonaSola != null)
                                    {
                                        IdPersona = getPersonaSola.id_persona;
                                    }

                                    break;
                                case 2:
                                    Ares ares = new Ares();
                                    ares.id_persona = IdPersona != 0 ? IdPersona : null;
                                    ares.A2023_01 = Convert.ToInt32(worksheet.Cells[row, 2].Value);
                                    ares.A2023_02 = Convert.ToInt32(worksheet.Cells[row, 3].Value);
                                    ares.A2023_03 = Convert.ToInt32(worksheet.Cells[row, 4].Value);
                                    ares.A2023_04 = Convert.ToInt32(worksheet.Cells[row, 5].Value);
                                    ares.A2023_05 = Convert.ToInt32(worksheet.Cells[row, 6].Value);
                                    ares.A2023_06 = Convert.ToInt32(worksheet.Cells[row, 7].Value);
                                    ares.A2023_07 = Convert.ToInt32(worksheet.Cells[row, 8].Value);
                                    ares.A2023_08 = Convert.ToInt32(worksheet.Cells[row, 9].Value);
                                    ares.A2023_09 = Convert.ToInt32(worksheet.Cells[row, 10].Value);
                                    ares.A2023_10 = Convert.ToInt32(worksheet.Cells[row, 11].Value);
                                    ares.A2023_11 = Convert.ToInt32(worksheet.Cells[row, 12].Value);
                                    ares.A2023_12 = Convert.ToInt32(worksheet.Cells[row, 13].Value);
                                    ares.A2024_01 = Convert.ToInt32(worksheet.Cells[row, 14].Value);
                                    ares.A2024_02 = Convert.ToInt32(worksheet.Cells[row, 15].Value);
                                    ares.A2024_03 = Convert.ToInt32(worksheet.Cells[row, 16].Value);
                                    ares.A2024_04 = Convert.ToInt32(worksheet.Cells[row, 17].Value);
                                    ares.A2024_05 = Convert.ToInt32(worksheet.Cells[row, 18].Value);
                                    ares.A2024_06 = Convert.ToInt32(worksheet.Cells[row, 19].Value);
                                    ares.A2024_07 = Convert.ToInt32(worksheet.Cells[row, 20].Value);
                                    ares.A2024_08 = Convert.ToInt32(worksheet.Cells[row, 21].Value);
                                    ares.A2024_09 = Convert.ToInt32(worksheet.Cells[row, 22].Value);
                                    ares.A2024_10 = Convert.ToInt32(worksheet.Cells[row, 23].Value);

                                    await FactoryDataAccess.AresRepositoryManager.SaveAres(ares);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
