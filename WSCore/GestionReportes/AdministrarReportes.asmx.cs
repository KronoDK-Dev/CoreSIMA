using Controladora.GestionGobernanza;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.GestionReportes;
using EntidadNegocio.GestionReportes;

namespace WSCore.GestionReportes
{
    /// <summary>
    /// Descripción breve de AdministrarReportes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class AdministrarReportes : System.Web.Services.WebService
    {
        [WebMethod(Description = "Listar Reportes implementados relacionados por IdPadre")]
        public DataTable ListarObjetos(string IdPadre, string UserName)
        {
            return (new CExploradorReporte()).ListarTodos(IdPadre, UserName);
        }

        [WebMethod(Description = "Listar Reportes por usuario y sus accesos")]
        public DataTable ListarReportePorUsuario(string IdUsuario, string UserName)
        {
            return (new CExploradorReporte()).ListarTodosPorUsuario(IdUsuario, UserName);
        }

        [WebMethod(Description = "Listar Objeto parametro dependientes")]
        public DataTable ListarObjetosDependentes(string IdObjeto, string UserName)
        {
            return (new CExploradorReporte()).ListarTodosDependientes(IdObjeto, UserName);
        }

        [WebMethod(Description = "Listar Los Atributos de un control inculado a un párametro")]
        public DataTable ListarCtrlAttrParametro(string IdObjeto, string IdAtributoPadre, int IdTipoControl, string UserName)
        {
            return (new CObjetoConfigAttr()).ListarTodos(IdObjeto, IdAtributoPadre, IdTipoControl, UserName);
        }

        [WebMethod(Description = "Listar Informacion del Reporte")]
        public DataTable ListarInformacionReporte(string IdObjeto, string UserName)
        {
            return (new CExploradorReporte()).ListarInfoReport(IdObjeto, UserName);
        }

        [WebMethod(Description = "Buscar Usuario por nombre")]
        public DataTable BuscarUsuariosxNombre(string ApellidosyNombres, string UserName)
        {
            return (new CUsuarioReporte()).Buscar(ApellidosyNombres, UserName);
        }

        [WebMethod(Description = "Listar Archivo compratido")]
        public DataTable ListarUsuariosCompartidoFile(string NombreArchivo, string UserName)
        {
            return (new CArchivoCompartido()).ListarTodos(NombreArchivo, UserName);
        }

        [WebMethod(Description = "Inserta o modifica el archivo generado del reporte")]
        public string ModificaInsertaArchivo(ArchivoCompartidoBE oArchivoCompartidoBE)
        {
            return (new CArchivoCompartido()).ModificaInserta(oArchivoCompartidoBE);
        }

        [WebMethod(Description = "Inserta o modifica Privilegios de objetos")]
        public string ModificaInsertaObjetoPrivilegio(ObjetoPrivilegioBE oObjetoPrivilegioBE)
        {
            return (new CObjetoPrivilegio()).ModificaInserta(oObjetoPrivilegioBE);
        }

        [WebMethod(Description = "Lista de Usuario por reporte Compartido")]
        public DataTable ListarUsuariosxReporteCompartido(int IdObjeto, string UserName)
        {
            return (new CObjetoReporteCompartido()).ListarTodos(IdObjeto, 0, UserName);
        }

        [WebMethod(Description = "Detalle de Usuario por reporte Compartido")]
        public ObjetoReporteCompartidoBE DetalleReporteCompartido(int IdObjeto, int IdUsuario, string UserName)
        {
            ObjetoReporteCompartidoBE oObjetoReporteCompartidoBE = (ObjetoReporteCompartidoBE)(new CObjetoReporteCompartido()).Detalle(IdObjeto, IdUsuario, UserName);
            return oObjetoReporteCompartidoBE;
        }

        [WebMethod(Description = "Detalle de cabecera del reporte")]
        public DataTable ListarCabeceradeReporte(int IdObjeto, string UserName)
        {
            return (new CExploradorReporte()).ListarHeader(IdObjeto.ToString(), UserName);

        }

        [WebMethod(Description = "Listar Reportes Compartidos por Usuario")]
        public DataTable ListarReportesCompartidosPorUsuario(int IdUsuario, int IdObjetoPadre, string UserName)
        {
            return (new CExploradorReporte()).ListarTodosCompartidos(IdUsuario, IdObjetoPadre, UserName);

        }

        [WebMethod(Description = "Lista Los atributos con sus repectivos valores de los objetos vinculados a sus parámetros")]
        public DataTable ListarObjetoAttributoValor(int IdObjeto, int IdTipoControl, int IdAtributoPadre, string UserName)
        {
            return (new CObjetoConfigAttr()).ListarTodos(IdObjeto.ToString(), IdTipoControl.ToString(), IdAtributoPadre.ToString(), UserName);
        }

        [WebMethod(Description = "Insertar objetos de gestion de reporte")]
        public int InsertarObjeto(ObjetoBE oObjetoBE)
        {
            return (new CObjeto()).Insertar(oObjetoBE);
        }

        [WebMethod(Description = "Insertar Valores de los atributos de configuracion del obejeto vinculado al parametros del metodo que solventara la data al reporte")]
        public int InsModObjetoConfigAtrributosValor(ObjetoConfigAttrBE oObjetoConfigAttrBE)
        {
            return (new CObjetoConfigAttr()).ModificarInsertar(oObjetoConfigAttrBE);
        }

        [WebMethod(Description = "Realiza un  BK de los parametros dek metodo que vicula al reporte .rpt para la carga de sus datos")]
        public int BackupParam(string Guid, string IdObjeto, string UserName)
        {
            int idResul = (new CObjeto()).BackupParam(Guid, IdObjeto, UserName);
            if (idResul == 1)
            {
                (new CObjeto()).EliminaParam(Guid, UserName);
            }

            return idResul;
        }

        [WebMethod(Description = "Realiza un  BK de los parametros dek metodo que vicula al reporte .rpt para la carga de sus datos")]
        public int BackupConfigParam(string Guid, string IdObjeto, string UserName)
        {
            int idResul = (new CObjeto()).BackupConfigParam(Guid, IdObjeto, UserName);

            return idResul;
        }

        [WebMethod(Description = "Mapeoo de Datos para exportar")]
        public int MapearDatosInsertaModifica(ObjetoMapeoExportBE oObjetoMapeoExportBE)
        {
            int idResul = (new CObjetoMapeoExport()).ModificarInsertar(oObjetoMapeoExportBE);

            return idResul;
        }

        [WebMethod(Description = "Listar Mapeo")]
        public DataTable MapearDatosListarTodos(int IdObjeto, string UserName)
        {
            return (new CObjetoMapeoExport()).ListarTodos(IdObjeto.ToString(), UserName);
        }

        [WebMethod(Description = "Admin Report Mover item Reporte")]
        public string ReporteAdoptarHijo(int IdObjeto, int IdPadreNuevo, int Orden, string UserName)
        {
            return (new CObjeto()).AsignaPadreAdoptivo(IdObjeto, IdPadreNuevo, Orden, UserName);
        }

        [WebMethod(Description = "Lista Accesos a reportes por Usuario")]
        public DataTable ListaAccesos_RptxUsuario(string v_usuario, string v_ambiente, string UserName)
        {
            return (new CObjetoPrivilegio()).ListaAccesos_RptxUsuario(v_usuario, v_ambiente, UserName);
        }

        [WebMethod(Description = "Lista Accesos a reportes por Usuario v2")]
        public DataTable ListaAccesos_RptxUsuario_v2(string s_usuario, string UserName)
        {
            return (new CObjetoPrivilegio()).ListaAccesos_RptxUsuario_v2(s_usuario, UserName);
        }
    }
}
