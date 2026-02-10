using AccesoDatos.NoTransaccional.General;
using Controladora.General;
using Controladora.Seguridad;
using Controladora.SIMANET.GENERAL;
using Controladora.SIMANET.SeguridadPlanta;
using EntidadNegocio;
using EntidadNegocio.SIMANET.SeguridadPlanta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using static ManejadorException.ManejoExcepcion.Configuracion.Seccion;

namespace WSCore.SIMANET.SeguridadPlanta
{
    /// <summary>
    /// Descripción breve de SIMANET
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Contratista : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable ProgramacionContratista_lst(int NroProgramacion, int Periodo, int IdUsuario, int IdTipoProgramacion,string UserName)
        {
            return (new Ccontratista()).ListarTodos(NroProgramacion, Periodo,IdUsuario, IdTipoProgramacion, UserName);
        }

        [WebMethod]
        public CCTT_ProgramacionBE ProgramacionContratista_det(int NroProgramacion, int Periodo, int IdUsuario, int IdTipoProgramacion, string UserName)
        {
            return (CCTT_ProgramacionBE)(new Ccontratista()).Detalle(NroProgramacion, Periodo, IdUsuario, IdTipoProgramacion, UserName);
        }

        [WebMethod]
        public string ProgramacionContratista_act(int NroProgramacion
                                                    , int Periodo
                                                    , int IdEntidad
                                                    , int IdJefeProyecto
                                                    , string NroRegistroIngreso
                                                    , string NroDocumentodeRef
                                                    , string FechaInicio
                                                    , string FechaTermino
                                                    , string HoraInicio
                                                    , string HoraTermino
                                                    , int IdCIASeguros
                                                    , string FechaInicioPoliza
                                                    , string FechaTerminoPoliza
                                                    , string NroPensionPoliza
                                                    , string NroSaludPoliza
                                                    , string TrabajosARealizar
                                                    , int IdLugardeTrabajo
                                                    , string NombreNave
                                                    , string NombreContacto
                                                    , string Observaciones
                                                    , int IdUsuario
                                                    ,string UserName
        )
        {
            CCTT_ProgramacionBE oCCTT_ProgramacionBE = new CCTT_ProgramacionBE();
            oCCTT_ProgramacionBE.NroProgramacion = NroProgramacion;
			oCCTT_ProgramacionBE.Periodo = Periodo;
			oCCTT_ProgramacionBE.IdEntidad = IdEntidad;
			oCCTT_ProgramacionBE.IdJefeProyecto = IdJefeProyecto;
			oCCTT_ProgramacionBE.NroRegistroIngreso = NroRegistroIngreso;
			oCCTT_ProgramacionBE.NroDocumentodeRef = NroDocumentodeRef;
			oCCTT_ProgramacionBE.FechaInicio = Convert.ToDateTime(FechaInicio);
			oCCTT_ProgramacionBE.FechaTermino = Convert.ToDateTime(FechaTermino);
			oCCTT_ProgramacionBE.HoraInicio = HoraInicio;
			oCCTT_ProgramacionBE.HoraTermino = HoraTermino;
			oCCTT_ProgramacionBE.IdCIASeguros = IdCIASeguros;
			oCCTT_ProgramacionBE.NroPoliza = "S/N";
			oCCTT_ProgramacionBE.FechaInicioPoliza = Convert.ToDateTime(FechaInicioPoliza);
			oCCTT_ProgramacionBE.FechaTerminoPoliza = Convert.ToDateTime(FechaTerminoPoliza);
			oCCTT_ProgramacionBE.NroPensionPoliza = NroPensionPoliza;
			oCCTT_ProgramacionBE.NroSaludPoliza = NroSaludPoliza;
			oCCTT_ProgramacionBE.TrabajosARealizar = TrabajosARealizar;
			oCCTT_ProgramacionBE.IdLugardeTrabajo = IdLugardeTrabajo;
			oCCTT_ProgramacionBE.NombreNave = NombreNave;
			oCCTT_ProgramacionBE.NombreContacto = NombreContacto;
			oCCTT_ProgramacionBE.Observaciones = Observaciones;
			oCCTT_ProgramacionBE.NroOrdenServicio = "S/N";
			oCCTT_ProgramacionBE.IdOrdenServicio = "0";
			oCCTT_ProgramacionBE.IdUsuario = IdUsuario;
            oCCTT_ProgramacionBE.UserName = UserName;

            return (new Ccontratista()).Modificar(oCCTT_ProgramacionBE);

        }





      [WebMethod]
        public DataTable BuscarProveedorXrUC(string NROPROVEEDOR, string UserName)
        {
            return (new CBusqueda()).BuscarProveedor("NRORUC", NROPROVEEDOR, UserName);
        }
        [WebMethod]
        public DataTable BuscarProveedorXRSocial(string RAZONSOCIAL, string UserName)
        {
            return (new CBusqueda()).BuscarProveedor("RAZONSOCIAL", RAZONSOCIAL, UserName); ;
        }

        [WebMethod]
        public DataTable BuscarCiaReguros(string DESCRIPCION, string UserName)
        {
            DataView dv = (new CBusqueda()).BuscarCIASeguro(UserName).DefaultView;
            dv.RowFilter = "DESCRIPCION LIKE '%" + DESCRIPCION + "%'";
            return Utilitario.Helper.Data.DataViewTODataTable(dv);
        }

        [WebMethod]
        public DataTable BuscarPersonalSIMA(string NOMBRES, string UserName)
        {
            return (new Ccontratista()).BuscarPersonalSIMA(NOMBRES,UserName);
        }

        [WebMethod]
        public DataTable BuscarAreaSIMA(string NombreArea, int IdCentroOperativo, string UserName)
        {
            return (new Ccontratista()).BuscarAreaSIMA(IdCentroOperativo, NombreArea, UserName);
        }


        [WebMethod]
        public string ContratistaProgramacion_Ins(int IdEntidad
                                                , int IdJefeProyecto
                                                , string NroRegistroIngreso
                                                , string NroDocumentodeRef
                                                , string FechaInicio
                                                , string FechaTermino
                                                , string HoraInicio
                                                , string HoraTermino
                                                , int IdCIASeguros
                                                , string FechaInicioPoliza
                                                , string FechaTerminoPoliza
                                                , string NroPensionPoliza
                                                , string NroSaludPoliza
                                                , string TrabajosARealizar
                                                , int IdLugardeTrabajo
                                                , string NombreNave
                                                , string NombreContacto
                                                , string Observaciones
                                                , int TipoProgramacion
                                                , int IdUsuario
                                                , string UserName)
         {
            CCTT_ProgramacionBE oCCTT_ProgramacionBE = new CCTT_ProgramacionBE();
                            oCCTT_ProgramacionBE.IdEntidad = IdEntidad;
                            oCCTT_ProgramacionBE.IdJefeProyecto = IdJefeProyecto;
                            oCCTT_ProgramacionBE.NroRegistroIngreso = NroRegistroIngreso;
                            oCCTT_ProgramacionBE.NroDocumentodeRef = NroDocumentodeRef;
                            oCCTT_ProgramacionBE.FechaInicio = Convert.ToDateTime(FechaInicio);
                            oCCTT_ProgramacionBE.FechaTermino = Convert.ToDateTime(FechaTermino);
                            oCCTT_ProgramacionBE.HoraInicio = HoraInicio;
                            oCCTT_ProgramacionBE.HoraTermino = HoraTermino;
                            oCCTT_ProgramacionBE.IdCIASeguros = IdCIASeguros;
                            oCCTT_ProgramacionBE.NroPoliza = "S/N";
                            oCCTT_ProgramacionBE.FechaInicioPoliza = Convert.ToDateTime(FechaInicioPoliza);
                            oCCTT_ProgramacionBE.FechaTerminoPoliza = Convert.ToDateTime(FechaTerminoPoliza);
                            oCCTT_ProgramacionBE.NroPensionPoliza = NroPensionPoliza;
                            oCCTT_ProgramacionBE.NroSaludPoliza = NroSaludPoliza;
                            oCCTT_ProgramacionBE.TrabajosARealizar = TrabajosARealizar;
                            oCCTT_ProgramacionBE.IdLugardeTrabajo = IdLugardeTrabajo;
                            oCCTT_ProgramacionBE.NombreNave = NombreNave;
                            oCCTT_ProgramacionBE.NombreContacto = NombreContacto;
                            oCCTT_ProgramacionBE.Observaciones = Observaciones;
                            oCCTT_ProgramacionBE.NroOrdenServicio = "S/N";
                            oCCTT_ProgramacionBE.IdOrdenServicio = "0";
                            oCCTT_ProgramacionBE.TipoProgramacion = TipoProgramacion;
                            oCCTT_ProgramacionBE.IdUsuario = IdUsuario;
                            oCCTT_ProgramacionBE.UserName = UserName;
            return (new Ccontratista()).Insertar(oCCTT_ProgramacionBE);
        }

        [WebMethod]
        public int  CrearProveedorCliente(int IdTipo,string NroRuc,string RazonSocial,int IdUsuario, string UserName) {
            ProveedorClienteBE oProveedorClienteBE = new ProveedorClienteBE();
            oProveedorClienteBE.IdTipo= IdTipo;
            oProveedorClienteBE.NroRuc = NroRuc;
            oProveedorClienteBE.RazonSocial= RazonSocial;
            oProveedorClienteBE.IdUsuario= IdUsuario;
            oProveedorClienteBE.UserName= UserName;
            return (new CProveedorCliente()).Insertar(oProveedorClienteBE);
        }


        [WebMethod]
        public DataTable BuscarTrabajaor(string NroDNI, string FechaProgIni, string FechaProgFin, string UserName)
        {
            return (new CTrabajador()).BuscarTrabajador("NRODNI", NroDNI,FechaProgIni, FechaProgFin, UserName);
        }

        [WebMethod]
        public DataTable TrabajadorInProgramacion(string NroDNI, int Periodo, int IdProgramacion, string UserName)
        {
            return (new CTrabajador()).TrabajadorInProgramacion(NroDNI, Periodo, IdProgramacion, UserName);
        }
        
        [WebMethod]
        public string  ProgramacionTrabajador_ins(int Periodo, int IdProgramacion, string NroDNI, string FechaInicio,string FechaTermino,string HoraInicio,string HoraTermino,string SCTRSalud,string SCTRPension,int IdUsuario, string UserName)
        {
            CCTT_ProgramacionTrabajadoresContratistaBE oCCTT_ProgramacionTrabajadoresContratistaBE = new CCTT_ProgramacionTrabajadoresContratistaBE();
            oCCTT_ProgramacionTrabajadoresContratistaBE.Periodo = Periodo;
            oCCTT_ProgramacionTrabajadoresContratistaBE.NroProgramacion = IdProgramacion;
            oCCTT_ProgramacionTrabajadoresContratistaBE.NroDNI = NroDNI;
            oCCTT_ProgramacionTrabajadoresContratistaBE.FechaInicio = Convert.ToDateTime(FechaInicio);
            oCCTT_ProgramacionTrabajadoresContratistaBE.FechaTermino = Convert.ToDateTime(FechaTermino);
            oCCTT_ProgramacionTrabajadoresContratistaBE.HoraInicio = HoraInicio;
            oCCTT_ProgramacionTrabajadoresContratistaBE.HoraTermino = HoraTermino;
            oCCTT_ProgramacionTrabajadoresContratistaBE.IdUsuario = IdUsuario;
            oCCTT_ProgramacionTrabajadoresContratistaBE.SCTRSalud = SCTRSalud;
            oCCTT_ProgramacionTrabajadoresContratistaBE.SCTRPension = SCTRPension;
            return (new CProgramacionTrabajador()).ModificaInserta(oCCTT_ProgramacionTrabajadoresContratistaBE);
        }
        [WebMethod]
        public DataTable ProgramacionTrabajador_lst(int Periodo, int IdProgramacion, string NroDNI, string UserName)
        {
            return (new CProgramacionTrabajador()).ListarTodos(IdProgramacion.ToString(), Periodo.ToString(), NroDNI, UserName);
        }

        [WebMethod]
        public DataTable ProgramacionTrabajadorRequisitos_lst(string NroDNI, string UserName)
        {
            return (new CProgramacionTrabajador()).ListarValidaSCTREXAM(NroDNI, UserName);
        }


        [WebMethod]
        public DataTable BuscarTrabajadorxDNI_lst(string NroDNI, string UserName)
        {
            return (new CTrabajador()).BuscarTrabajadorxDNI(NroDNI, UserName);
        }

        [WebMethod]
        public DataTable CalendarioTrabajo_lst(string NroDNI,string Año,string Mes, string UserName)
        {
            return (new CCalendario()).ListaCalendarioLaboral(NroDNI, Año, Mes, UserName);
        }


        [WebMethod]
        public string  CalenadrioAutorizaFeriado_ins(string NroDNI, string FechaAutorizada, int IdPersonalAutoriza, int IdEstado,int IdUsuario,string UserName)
        {
            AutorizaIngFeriadoBE oAutorizaIngFeriadoBE = new AutorizaIngFeriadoBE();
            oAutorizaIngFeriadoBE.NroDNI = NroDNI;
            oAutorizaIngFeriadoBE.FechaAutorizada = Convert.ToDateTime(FechaAutorizada);
            oAutorizaIngFeriadoBE.IdPersonalAutoriza = IdPersonalAutoriza;
            oAutorizaIngFeriadoBE.IdEstado = IdEstado;
            oAutorizaIngFeriadoBE.IdUsuario = IdUsuario;
            oAutorizaIngFeriadoBE.UserName = UserName;

            return (new CAutorizaFeriado()).ModificaInserta(oAutorizaIngFeriadoBE);
        }
    }
}
