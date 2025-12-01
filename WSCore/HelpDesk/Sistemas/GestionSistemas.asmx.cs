using Controladora.HelpDesk.ITIL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.HelpDesk.Sistemas;
using EntidadNegocio.HelpDesk.Sistemas;

namespace WSCore.HelpDesk.Sistemas
{
    /// <summary>
    /// Descripción breve de GestionSistemas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class GestionSistemas : System.Web.Services.WebService
    {
        [WebMethod(Description = "Listar Sistemas Sub SIstemas y Procedimientos")]
        public DataTable SistemasListarAll(string UserName)
        {

            return (new CSistemaProcesoSubProceso()).Listar("0", UserName);
        }

        [WebMethod(Description = "Listar Sistemas y procedimienntos por IdPadre")]
        public DataTable ListarSistemasyProcesos(string IdSistemapadre, string UserName)
        {
            return (new CSistemaProcesoSubProceso()).ListarTodos(IdSistemapadre, UserName);
        }

        [WebMethod(Description = "Detalle Sistemas y procedimienntos por IdPadre")]
        public SistemaProcesoSubProcesoBE ListarSistemasyProcesosDet(string IdSistema, string UserName)
        {
            return (SistemaProcesoSubProcesoBE)(new CSistemaProcesoSubProceso()).Detalle(IdSistema, UserName);
        }

        [WebMethod(Description = "Inserta Modfica SIstema Procedimiento etc")]
        public string SistemaProcedmientoInsAct(string IdSys, string IdPadre, string Nombre, string Descripcion, int IdNivel, int IdUsuario, string UserName)
        {
            SistemaProcesoSubProcesoBE oSistemaProcesoSubProcesoBE = new SistemaProcesoSubProcesoBE();
            oSistemaProcesoSubProcesoBE.IdSys = IdSys;
            oSistemaProcesoSubProcesoBE.IdPadre = IdPadre;
            oSistemaProcesoSubProcesoBE.Nombre = Nombre;
            oSistemaProcesoSubProcesoBE.Descripcion = Descripcion;
            oSistemaProcesoSubProcesoBE.IdNivel = IdNivel;
            oSistemaProcesoSubProcesoBE.IdUsuario = IdUsuario;
            oSistemaProcesoSubProcesoBE.UserName = UserName;
            return (new CSistemaProcesoSubProceso()).ModificaInserta(oSistemaProcesoSubProcesoBE);
        }

        [WebMethod(Description = "Inserta Modfica SIstema Procedimiento etc")]
        public int SistemaProcedmientoDel(string IdSys, int IdUsuario, string UserName)
        {
            return (new CSistemaProcesoSubProceso()).Eliminar(IdSys, IdUsuario.ToString(), UserName);
        }

        [WebMethod(Description = "Listar Elementos de actividad por Tipo de elemento Pre condiciones,Puntos de Ingreso etc")]
        public DataTable ActividadElementos_Listar(string IdActividad, string IdTipoElemento, string UserName)
        {
            return (new CActividadElementos()).ListarTodos(IdActividad, IdTipoElemento, UserName);
        }

        [WebMethod(Description = "Listar Elementos de actividad por Tipo de elemento Pre condiciones,Puntos de Ingreso etc")]
        public ActividadElementosBE ActividadElementos_Detalle(string IdActElemento, string UserName)
        {
            return (ActividadElementosBE)(new CActividadElementos()).Detalle(IdActElemento, UserName);
        }

        [WebMethod(MessageName = "ActividadElementos_Buscar", Description = "Buscar  Elementos de Actividad", EnableSession = true)]
        public DataTable ActividadElementos_Buscar(string Nombre, string IdActividad, string IdTipoElemento, string UserName)
        {
            return (new CActividadElementos()).Buscar(Nombre, IdActividad, IdTipoElemento, UserName);
        }

        [WebMethod(MessageName = "ActividadElementos_Buscar2", Description = "Buscar  Elementos de generales", EnableSession = true)]
        public DataTable ActividadElementos_Buscar2(string Nombre, string UserName)
        {
            return (new CActividadElementos()).Buscar(Nombre, UserName);
        }

        [WebMethod(Description = "Buscar  Elementos de Actividad")]
        public string ActividadElementos_InsMod(string IdActElemento, string IdActividad, string IdActividadElemOrg, string Nombre, string Descripcion, string IdElemento, int IdTipoElemento, int IdUsuario, string UserName)
        {
            ActividadElementosBE oActividadElementosBE = new ActividadElementosBE();
            oActividadElementosBE.IdActElemento = IdActElemento;
            oActividadElementosBE.IdActividad = IdActividad;
            oActividadElementosBE.IdActividadElemOrg = IdActividadElemOrg;
            oActividadElementosBE.Nombre = Nombre;
            oActividadElementosBE.Descripcion = Descripcion;
            oActividadElementosBE.IdElemento = IdElemento;
            oActividadElementosBE.IdTipoElemento = IdTipoElemento;
            oActividadElementosBE.IdUsuario = IdUsuario;
            oActividadElementosBE.UserName = UserName;
            return (new CActividadElementos()).ModificaInserta(oActividadElementosBE);
        }

        [WebMethod(Description = "ELIMINA Elementos de Actividad")]
        public int ActividadElementos_Del(string IdActElemento, int IdUsuario, string UserName)
        {
            return (new CActividadElementos()).Eliminar(IdActElemento, IdUsuario.ToString(), UserName);
        }

        [WebMethod(Description = "Listar Interesados por Actividad")]
        public DataTable ActividadElementos_StakeHolder(string IdActElemento, int IdTipoStakeHolder, string UserName)
        {
            return (new CStakeHolder()).ListarTodos(IdActElemento, IdTipoStakeHolder.ToString(), UserName);
        }

        [WebMethod(Description = "Detalle Interesados por Actividad")]
        public StakeHolderBE ActividadElementos_StakeHolder_Det(string IdStakeHolder, string UserName)
        {
            return (StakeHolderBE)(new CStakeHolder()).Detalle(IdStakeHolder, UserName);
        }

        [WebMethod(Description = "Detalle Interesados por Actividad")]
        public string ActividadElementos_StakeHolder_InsUp(string IdStakeHolder, string IdActividad, string IdPersonal, string Descripcion, int IdTipoStakeHolder, string NombreImg, int IdUsuario, string UserName)
        {
            StakeHolderBE oStakeHolderBE = new StakeHolderBE();
            oStakeHolderBE.IdStakeHolder = IdStakeHolder;
            oStakeHolderBE.IdActividad = IdActividad;
            oStakeHolderBE.IdPersonal = IdPersonal;
            oStakeHolderBE.Descripcion = Descripcion;
            oStakeHolderBE.IdTipoStakeHolder = IdTipoStakeHolder;
            oStakeHolderBE.NombreImg = NombreImg;
            oStakeHolderBE.IdUsuario = IdUsuario;
            oStakeHolderBE.UserName = UserName;
            return (new CStakeHolder()).ModificaInserta(oStakeHolderBE); ;
        }

        [WebMethod(Description = "Eliminar Interesados por Actividad")]
        public int ActividadElementos_StakeHolder_Del(string IdStakeHolder, int IdUsuario, string UserName)
        {
            return (new CStakeHolder()).Eliminar(IdStakeHolder, IdUsuario.ToString(), UserName);
        }

        [WebMethod(Description = "Listado de Comentarios por Actividad")]
        public DataTable ActividadDocumentacion_Listar(string IdActividad, string IdTipoDoc, string IdPadre, string UserName)
        {
            return (new CActividadDocumentacion()).ListarTodos(IdActividad, IdTipoDoc, IdPadre, UserName);
        }

        [WebMethod(Description = "Detalle de Comentarios por Actividad")]
        public ActividadDocumentacionBE ActividadDocumentacion_Detalle(string IdDocumentacion, string UserName)
        {
            return (ActividadDocumentacionBE)(new CActividadDocumentacion()).Detalle(IdDocumentacion, UserName);
        }

        [WebMethod(Description = "Detalle de Comentarios por Actividad")]
        public DataTable ActividaDocumentacionReaccion_Listar(string IdDocumentacion, string UserName)
        {
            return (new CActividadDocumentacionReaccion()).ListarTodos(IdDocumentacion, UserName);
        }

        [WebMethod(Description = "Detalle de Comentarios por Actividad")]
        public string ActividaComentarios_InsAct(string IdDocumento, string IdDocPadre, string IdActividad, int IdTipoDoc, string Descripcion, string IdPersonal, int IdUsuario, string UserName)
        {

            ActividadComentarioBE oActividadComentarioBE = new ActividadComentarioBE();
            oActividadComentarioBE.IdDocumento = IdDocumento;
            oActividadComentarioBE.IdDocPadre = IdDocPadre;
            oActividadComentarioBE.IdActividad = IdActividad;
            oActividadComentarioBE.IdTipoDoc = IdTipoDoc;
            oActividadComentarioBE.Descripcion = Descripcion;
            oActividadComentarioBE.IdPersonal = IdPersonal;
            oActividadComentarioBE.IdUsuario = IdUsuario;
            oActividadComentarioBE.UserName = UserName;

            return (new CActividadDocumentacion()).ModificaInserta(oActividadComentarioBE);
        }

        [WebMethod(Description = "Lista Areas Con servicios Configurads Asociados a contactos o grupos")]
        public DataTable Servicios_ListarAreas(string IdContacto, string UserName)
        {
            return (new CServicios()).ListarAreas(IdContacto, UserName);
        }
    }
}
