using Controladora.GestionLogistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.HelpDesk.ITIL;
using EntidadNegocio.HelpDesk.ITIL;

namespace WSCore.HelpDesk.ITIL
{
    /// <summary>
    /// Descripción breve de GestiondeConfiguracion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class GestiondeConfiguracion : System.Web.Services.WebService
    {
        [WebMethod(Description = "Buscar Servicio")]
        public DataTable BuscarServicioPorNombre(string Nombre, string UserName)
        {
            return (new CServicios()).Buscar(Nombre, UserName);
        }

        [WebMethod(Description = "Detalle de Servicios y/o proudctos")]
        public ServicioBE ServicioDetalle(string IdServicio, string UserName)
        {
            return (ServicioBE)(new CServicios()).Detalle(IdServicio, UserName);
        }

        [WebMethod(Description = "Listar Servicios y proudctos")]
        public DataTable ServicioListarAll(string UserName)
        {

            return (new CServicios()).Listar("0", UserName);
        }

        [WebMethod(Description = "Listar Servicios y proudctos por IdPadre")]
        public DataTable ListarServiosyProductos(string IdServicioPadre, string UserName)
        {
            return (new CServicios()).ListarTodos(IdServicioPadre, UserName);
        }

        [WebMethod(Description = "Listar Servicios y proudctos por area")]
        public DataTable ListarServiosPorArea(string IdServicioPadre, string CodigoArea, string IdTipoServicio, string UserName)
        {
            return (new CServicios()).ListarServiciosPorArea(IdServicioPadre, CodigoArea, IdTipoServicio, UserName);
        }

        [WebMethod(Description = "Mantenimientos de servicios")]
        public string ServiciosModificaInserta(string IdServicioProducto, string IdPadre, string Nombre, string Descripcion, int Interno, int Producto, int IdUsuario, string UserName)
        {
            ServicioBE oServicioBE = new ServicioBE();
            oServicioBE.IdServicioProducto = IdServicioProducto;
            oServicioBE.IdPadre = IdPadre;
            oServicioBE.Nombre = Nombre;
            oServicioBE.Descripcion = Descripcion;
            oServicioBE.Interno = Interno;
            oServicioBE.Producto = Producto;
            oServicioBE.IdUsuario = IdUsuario;
            oServicioBE.UserName = UserName;
            return (new CServicios()).ModificaInserta(oServicioBE);
        }

        [WebMethod(Description = "Mantenimientos de Procedimiento por activiudad")]
        public string ProcedimientoModificaInserta(string IdAccion, string IdAccionRel, string IdAccionTo, int IdTipoOj, string AccionesBasicas
                                                   , string Atributo, int Orden, string IdActividad, int IdUsuario, string UserName)
        {
            ProcedimientoBE oProcedimientoBE = new ProcedimientoBE();

            oProcedimientoBE.IdAccion = IdAccion;
            oProcedimientoBE.IdAccionRel = IdAccionRel;
            oProcedimientoBE.IdAccionTo = IdAccionTo;
            oProcedimientoBE.IdTipoObj = IdTipoOj;
            oProcedimientoBE.AccionBasica = AccionesBasicas;
            oProcedimientoBE.Orden = Orden;
            oProcedimientoBE.IdActividad = IdActividad;
            oProcedimientoBE.IdUsuario = IdUsuario;
            oProcedimientoBE.UserName = UserName;
            oProcedimientoBE.Atributo = Atributo;

            return (new CProcedimiento()).ModificarInserta(oProcedimientoBE);
        }

        [WebMethod(Description = "Listado de acciones del procedimiento  por activiudad")]
        public DataTable ProcedimientoListarPorActividad(string IdActividad, string UserName)
        {
            return (new CProcedimiento()).ListarTodos("0", IdActividad, UserName);
        }

        [WebMethod(Description = "Listado de tareas por actividad")]
        public DataTable ProcedimientoListarTareaPorActividad(string IdActividad, string UserName)
        {
            return (new CProcedimiento()).ListarTodos("10", IdActividad, UserName);
        }

        [WebMethod(Description = "Eliminar Acción de procedimiento  por activiudad")]
        public string ProcedimientoDelAccionXActividad(string IdAccion, int IdUsuario, string UserName)
        {
            return (new CProcedimiento()).Eliminar(IdAccion, IdUsuario, UserName).ToString();
        }

        [WebMethod(Description = "Listado las Notas de una accion del procedimiento  por activiudad")]
        public DataTable ProcedimientoNotaListarPorAccion(string IdAccion, string IdNota, string UserName)
        {
            return (new CProcedimientoNota()).ListarTodos(IdAccion, IdNota, UserName);
        }

        [WebMethod(Description = "Detalle las Notas de una accion del procedimiento  por activiudad")]
        public ProcedimientoNotaBE ProcedimientoNotaDetallePorAccion(string IdAccion, string IdNota, string UserName)
        {
            ProcedimientoNotaBE oProcedimientoNotaBE = (ProcedimientoNotaBE)(new CProcedimientoNota()).Detalle(IdAccion, IdNota, UserName);
            return oProcedimientoNotaBE;
        }

        [WebMethod(Description = "Inserta Detalle las Notas")]
        public string ProcedimientoNotaIns(string IdAccion, string IdNota, string Titulo, string Descripcion, int IdTipoNota, int IdUsuario, string UserName)
        {
            ProcedimientoNotaBE oProcedimientoNotaBE = new ProcedimientoNotaBE();
            oProcedimientoNotaBE.IdAccion = IdAccion;
            oProcedimientoNotaBE.IdNota = IdNota;
            oProcedimientoNotaBE.Titulo = Titulo;
            oProcedimientoNotaBE.Descripcion = Descripcion;
            oProcedimientoNotaBE.IdTipoNota = IdTipoNota;
            oProcedimientoNotaBE.IdUsuario = IdUsuario;
            oProcedimientoNotaBE.UserName = UserName;
            return (new CProcedimientoNota()).ModificaInserta(oProcedimientoNotaBE);
        }

        [WebMethod(Description = "Eliminar Nota")]
        public int ProcedimientoNotaDel(string IdNota, int IdUsuario, string UserName)
        {
            return (new CProcedimientoNota()).Eliminar(IdNota, IdUsuario.ToString(), UserName);
        }

        [WebMethod(Description = "Listar Areas por Servicio")]
        public DataTable ListarAreasXServicio(string IdServProd, string UserName)
        {
            return (new CServicios()).ListarAreasXServicio(IdServProd, UserName);
        }

        [WebMethod(Description = "Listar Actividades por Servicio")]
        public DataTable ListarActvXServicio(string IdServProd, string UserName)
        {
            return (new CServicios()).ListarActvXServicio(IdServProd, UserName);
        }

        [WebMethod(Description = "Listar Responsables por Servicio")]
        public DataTable ListarRespxServicio(string IdServProd, string UserName)
        {
            return (new CServicios()).ListarRespxServicio(IdServProd, UserName);
        }

        [WebMethod(Description = "Listar Actividades por Servicio Chck")]
        public DataTable ListarActvChck(string IdSistemaPadre, string IdServProd, string UserName)
        {
            return (new CServicios()).ListarActvChck(IdSistemaPadre, IdServProd, UserName);
        }

        [WebMethod(Description = "Asignar o remover Actividad a Servicio")]
        public string ServicioAsignarActividad(string IdServicioProducto, string IdActividad, int Estado, int IdUsuario, string UserName)
        {
            ServicioActividadBE oServicioActividadBE = new ServicioActividadBE();
            oServicioActividadBE.IdServicioProducto = IdServicioProducto;
            oServicioActividadBE.IdActividad = IdActividad;
            oServicioActividadBE.IdEstado = Estado;
            oServicioActividadBE.IdUsuario = IdUsuario;
            oServicioActividadBE.UserName = UserName;

            return (new CServicios()).AsignarActividad(oServicioActividadBE);
        }

        [WebMethod(Description = "MANTENIMIENTO DE AREAS X SERVICIO")]
        public string ServicioArea(string IdServicioArea, string IdServicioProducto, string CodEmp, string CodSuc, string CodArea, int IdUsuario, string UserName)
        {
            ServicioAreaBE oServicioAreaBE = new ServicioAreaBE();
            oServicioAreaBE.IdServicioArea = IdServicioArea;
            oServicioAreaBE.IdServicioProducto = IdServicioProducto;
            oServicioAreaBE.CodEmp = CodEmp;
            oServicioAreaBE.CodSuc = CodSuc;
            oServicioAreaBE.CodArea = CodArea;
            oServicioAreaBE.IdUsuario = IdUsuario;
            oServicioAreaBE.UserName = UserName;

            return (new CServicios()).ServicioArea(oServicioAreaBE);
        }

        [WebMethod(Description = "MANTENIMIENTO DE RESPONSABLE")]
        public string ServicioResponsable(string IdResponsable, string IdServArea, int IdPersonal, int Principal,
            int IdUsuario, string UserName)
        {
            ServicioResponsableBE oServicioResponsableBE = new ServicioResponsableBE();
            oServicioResponsableBE.pID_RESPONSABLE = IdResponsable;
            oServicioResponsableBE.pID_SERV_AREA = IdServArea;
            oServicioResponsableBE.pID_PERSONAL = IdPersonal;
            oServicioResponsableBE.pPRINCIPAL = Principal;
            oServicioResponsableBE.IdUsuario = IdUsuario;
            oServicioResponsableBE.UserName = UserName;

            return (new CServicios()).ServicioResponsable(oServicioResponsableBE);
        }
    }
}
