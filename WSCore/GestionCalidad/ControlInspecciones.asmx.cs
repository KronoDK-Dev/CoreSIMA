using System;
using System.ComponentModel;
using System.Data;
using System.Web.Services;
using Controladora.GestionCalidad;
using EntidadNegocio;
using EntidadNegocio.GestionCalidad;

namespace WSCore.GestionCalidad
{
    /// <summary>
    ///     Descripción breve de ControlInspecciones
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ControlInspecciones : WebService
    {
        [WebMethod(Description = "Listar inpectores por inspeccion")]
        public DataTable Inspeccion_ListarInspectores(string Id1, string UserName)
        {
            return new CInspectores().ListarTodos(Id1, UserName);
        }

        [WebMethod(Description = "Listar Lista responsable de atencion y dar cumplimiento en el area")]
        public DataTable ListarResponsablesPorArea(string Id1, string UserName)
        {
            return new CResponsableArea().ListarTodos(Id1, UserName);
        }

        [WebMethod(Description = "Insertar/Modificar  Inspector")]
        public string Inspeccion_ModificarInsertarInspector(BaseBE oBaseBE)
        {
            return new CInspectores().ModificaInserta(oBaseBE);
        }

        [WebMethod(Description = "Detalle Inspector")]
        public InspectorBE DetalleInspector(string IdInspector)
        {
            return new InspectorBE();
        }


        [WebMethod(Description = "Inserta/Modifica Responsable de área")]
        public string Inspeccion_ModficarInsertarResponsable(BaseBE oBaseBE)
        {
            return new CResponsableArea().ModificaInserta(oBaseBE);
        }

        [WebMethod(Description = "Detalle Responsable de area")]
        public ResponsableAreaBE Inspeccion_DetalleResponsableArea(string IdPersonal)
        {
            return new ResponsableAreaBE();
        }


        [WebMethod(Description = "Listado de Inspecciones por inspector")]
        public DataTable ListarInspeccionesxInspector(string IdInspector, string UserName)
        {
            var oInspectorDetalleBE = new InspectorDetalleBE();
            return new CInspectorInspecciones().ListarTodos(IdInspector, UserName);
        }

        [WebMethod(Description = "Inserta o Modifica Inspecciones por inspector")]
        public string InsertaModificaDetalledeInspeccion(InspectorDetalleBE oInspectorDetalleBE)
        {
            return new CInspectorInspecciones().ModificaInserta(oInspectorDetalleBE);
        }


        [WebMethod(Description = "Listado de Actividades por Proyectos SIMA")]
        public DataTable ListarProyectosActividadSIMA(string IdProyecto, string UserName)
        {
            return new CProyectoActividad().ListarTodos(IdProyecto, UserName);
        }

        [WebMethod(Description = "Buscar Actividad para relacionar al pryecto")]
        public DataTable BuscarActividad(string NombreActividad, string UserName)
        {
            return new CProyectoActividad().Buscar(NombreActividad, UserName);
        }

        [WebMethod(Description = "Buscar Actividad para relacionar al pryecto")]
        public DataTable BuscarAreaEntidad(string NombreAreaEntidad, int IdUsuario, string UserName)
        {
            return new Cinspecciones().BuscarAreaEntidad(NombreAreaEntidad, IdUsuario, UserName);
        }

        [WebMethod(Description = "Buscar Actividad relacionada al pryecto de inspeccion")]
        public DataTable BuscarAreaEntidad_Inspeccion(string NombreAreaEntidad, string UserName)
        {
            return new Cinspecciones().BuscarAreaEntidad_Inspeccion(NombreAreaEntidad, UserName);
        }


        [WebMethod(Description = "Inserta/Modifica Actividad al proyecto")]
        public string ModficarInsertarProyectoActividadSIMA(ProyectoActividadBE oProyectoActividadBE)
        {
            return new CProyectoActividad().ModificaInserta(oProyectoActividadBE);
        }

        [WebMethod(Description = "Detalle Responsable de area")]
        public ProyectoActividadBE DetalleActivadProyecto(string IdProyecto, string IdActividad)
        {
            return new ProyectoActividadBE();
        }

        [WebMethod(Description = "Registra los anexos de la inspeccion")]
        public string AdministrarInspeccionAnexos(InspeccionAnexoBE oInspeccionAnexoBE)
        {
            return new CInspeccionAnexo().ModificaInserta(oInspeccionAnexoBE);
        }

        [WebMethod(Description = "Consulta o Listado  de anexos de la inspeccion")]
        public DataTable ListarInspeccionAnexos(string IdInspeccion, string UserName)
        {
            return new CInspeccionAnexo().ListarTodos(IdInspeccion, UserName);
        }

        [WebMethod(Description = "Consulta o Listado  de usuarios firmante")]
        public DataTable ListarUsuariosFirmantes(string IdInspeccion, string IdUsuarioFirmante, string UserName)
        {
            return new CInspeccionUsuarioFirmante().ListarTodos(IdInspeccion, IdUsuarioFirmante, UserName);
        }

        [WebMethod(Description = "Consulta o Listado  de usuarios firmante Ref Cruzada")]
        public DataTable ListarUsuariosFirmantesRefCruz(string IdInspeccion, string UserName)
        {
            return new CInspeccionUsuarioFirmante().ListarTodos(IdInspeccion, UserName);
        }

        [WebMethod(Description = "Ins Mod Personal Firmante")]
        public string ModificaInsertaUsuariosFirmantes(UsuarioFirmanteBE oUsuarioFirmanteBE)
        {
            return new CInspeccionUsuarioFirmante().ModificaInserta(oUsuarioFirmanteBE);
        }

        [WebMethod(Description = "Inserta o Modifica Personal firmante por tipo")]
        public string InsModPersonalFirmantePorTipo(UsuarioFirmanteBE oUsuarioFirmanteBE)
        {
            return new CInspeccionUsuarioFirmante().ModificaInsertaXTipoFirmante(oUsuarioFirmanteBE);
        }

        [WebMethod(Description = "Creacion o modificacion de Firmas a Usuarios firmantes o aprobadores")]
        public string ModificaInsertaFirmas(UsuarioFirmanteBE oUsuarioFirmanteBE)
        {
            return new CInspeccionUsuarioFirmante().ModificaInsertaFirma(oUsuarioFirmanteBE);
        }

        [WebMethod(Description = "Elimina  usuarios firmante")]
        public int EliminaUsuariosFirmantes(string IdInspeccion, string IdUsuarioFirmante, int IdEsatdo, int IdUsuario,
            string UserName)
        {
            return new CInspeccionUsuarioFirmante().Eliminar(IdInspeccion, IdUsuarioFirmante, IdEsatdo, IdUsuario,
                UserName);
        }

        [WebMethod(Description = "Actualiza Nro de msg Recibidos")]
        public int ActualizaNroMsgRecibidos(UsuarioFirmanteBE oUsuarioFirmanteBE)
        {
            return new CInspeccionUsuarioFirmante().ActualizaNroMsgRecibidos(oUsuarioFirmanteBE);
        }

        [WebMethod(Description = "Aprobacion Inspeccion con firma ")]
        public int FirmaAprobarFromEMail(UsuarioFirmanteBE oUsuarioFirmanteBE)
        {
            return new CInspeccionUsuarioFirmante().FirmaAprobarFromEMail(oUsuarioFirmanteBE);
        }

        [WebMethod(Description = "Cambiar estado de Inspeccion")]
        public int InspeccionCambiarEstado(string IdInspeccion, int IdEstado, int IdUsuario, string UserName)
        {
            return new Cinspecciones().CambiarEstado(IdInspeccion, IdEstado, IdUsuario, UserName);
        }

        [WebMethod(Description = "Busqueda de proyectos de inspeccin")]
        public DataTable BuscarProyectodeInspeccion(string NombreProyecto, string UserName)
        {
            return new Cinspecciones().Buscar(NombreProyecto, UserName);
        }

        [WebMethod(Description =
            "Lista el detalle de respuesta de atencion por parte del responsable de area sobre la inpeccion")]
        public DataTable ListarDetallePorReponsabledeArea(string IdInspeccion, int IdPersonal, string UserName)
        {
            return new CResponsableAreaDetalle().ListarTodos(IdInspeccion, IdPersonal.ToString(), UserName);
        }

        [WebMethod(Description =
            "detalle de respuesta de atencion por parte del responsable de area sobre la inpeccion")]
        public ResponsableAreaDetalleBE DetallePorReponsabledeAreaRpt(string IdDetalleResponsableArea, string UserName)
        {
            return (ResponsableAreaDetalleBE)new CResponsableAreaDetalle().Detalle(IdDetalleResponsableArea, UserName);
        }

        [WebMethod(Description =
            "Lista el detalle de respuesta de atencion por parte del responsable de area sobre la inpeccion")]
        public int DetallePorReponsabledeAreaCambiarEstado(ResponsableAreaDetalleBE oResponsableAreaDetalleBE)
        {
            return new CResponsableAreaDetalle().ActualizaEstado(oResponsableAreaDetalleBE);
        }

        [WebMethod(Description = "Detalle de Respuesta por responsable de area")]
        public int ResponsabledeAreaDetalle_InsertaModifica(ResponsableAreaDetalleBE oResponsableAreaDetalleBE)
        {
            return new CResponsableAreaDetalle().ModificarInsertar(oResponsableAreaDetalleBE);
        }

        [WebMethod(Description = "Resumen por Periodo de Inspoecciones y estados")]
        public DataTable ResumenInspeccionesPorEstado(int Año, int IdUsuario, string UserName)
        {
            return new Cinspecciones().ResumenInspeccionesPorEstado(Año, IdUsuario, UserName);
        }

        [WebMethod(Description = "Resumen por Periodo de Inspoecciones y estados")]
        public DataTable ResumenNoConformeTipoEntidad(int Año, int IdUsuario, string UserName)
        {
            return new Cinspecciones().ResumenInspeccionesPorEstado(Año, IdUsuario, UserName);
        }

        [WebMethod(Description = "Buscar Aprobadores")]
        public DataTable BuscarAprobador(string ApellidosyNombres, string UserName)
        {
            return new CInspeccionUsuarioFirmante().Buscar(ApellidosyNombres, UserName);
        }

        [WebMethod(Description = "Permite Bloquea o desbloquear el registro de inspeccion")]
        public int BloqueaRegistroInspeccion(string IdInspeccion, int Block, string UserName)
        {
            return new Cinspecciones().BloqueaRI(IdInspeccion, Block, UserName);
        }

        #region Inspecciones

        [WebMethod(Description = "Listar inpecciones")]
        public DataTable Inspeccion_Listar(string Id1, int IdUsuario, string UserName)
        {
            return new Cinspecciones().ListarTodos(Id1, IdUsuario, UserName);
        }

        [WebMethod(Description = "Detalle del Registro de Inspeccion")]
        public InspeccionBE Inspeccion_Detalle(string Id1, int IdUsuario, string UserName)
        {
            return (InspeccionBE)new Cinspecciones().Detalle(Id1, IdUsuario, UserName);
        }

        [WebMethod(Description = "Listar inpecciones")]
        public DataTable Inspeccion_ListarPorResponsableArea(string IdPersonal, string UserName)
        {
            return new Cinspecciones().ListarTodosPorResponsableArea(Convert.ToInt32(IdPersonal), UserName);
        }

        [WebMethod(Description = "Mantenimiento de Inspecciones-Insertar")]
        public string Inspeccion_Insertar(InspeccionBE oInspeccionBE)
        {
            return new Cinspecciones().Insertar(oInspeccionBE);
        }

        [WebMethod(Description = "Mantenimiento de Inspecciones-Modificar")]
        public int Inspeccion_Modificar(InspeccionBE oInspeccionBE)
        {
            return new Cinspecciones().Modificar(oInspeccionBE);
        }

        #endregion

        #region El Reporte de la no conformiudades

        [WebMethod(Description = "Resumen de No Conforme por Tipo de Empresas")]
        public DataTable ResumenNoConformeIP_SIMA(int Año, int MesHasta, int IdOrigen, string UserName)
        {
            return new Cinspecciones().ResumenNoConformeIP_SIMA(Año, MesHasta, IdOrigen, UserName);
        }

        [WebMethod(Description = "Resumen de No Conforme por IP")]
        public DataTable ResumenNoConformeIP(int Año, int MesHasta, string UserName)
        {
            return new Cinspecciones().ResumenNoConformeIP(Año, MesHasta, UserName);
        }

        [WebMethod(Description = "Resumen de No Conforme por SIMA")]
        public DataTable ResumenNoConformeSIMA(int Año, int MesHasta, string UserName)
        {
            return new Cinspecciones().ResumenNoConformeSIMA(Año, MesHasta, UserName);
        }

        #endregion

        #region El Reporte de la no conformiudades por Propyecto y IP-SIMA mensual

        [WebMethod(Description = "Resumen de No Conforme por proyecto mensual")]
        public DataTable ResumenNoConformePorProyecto_Mensual(int Año, int MesHasta, string UserName)
        {
            return new Cinspecciones().ResumenNoConformePorProyecto_Mensual(Año, MesHasta, UserName);
        }

        [WebMethod(Description = "Resumen de No Conforme por IP-SIMA mensual")]
        public DataTable ResumenNoConformePorIP_SIMA_Mensual(int Año, int MesHasta, int IdOrigen, string UserName)
        {
            return new Cinspecciones().ResumenNoConformePorIP_SIMA_Mensual(Año, MesHasta, IdOrigen, UserName);
        }

        [WebMethod(Description = "Resumen de No Conforme por Tipo de Inspeccion")]
        public DataTable ResumenNoConformePorTipodeInspeccion(int Año, int MesHasta, string UserName)
        {
            return new Cinspecciones().ResumenNoConformePorTipodeInspeccion(Año, MesHasta, UserName);
        }

        [WebMethod(Description = "Listado de FI solicitando aproacion")]
        public DataTable ListarSolicitudAprobacion(int IdUsuario, string UserName)
        {
            return new CInspeccionUsuarioFirmante().ListarSolicitudAprobacion(IdUsuario, UserName);
        }

        #endregion
    }
}