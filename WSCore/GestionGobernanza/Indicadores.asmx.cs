using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.GestionGobernanza;
using EntidadNegocio.GestionGobernanza;

namespace WSCore.GestionGobernanza
{
    /// <summary>
    /// Descripción breve de Indicadores
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Indicadores : System.Web.Services.WebService
    {
        [WebMethod]
        public int Objetivo_ins(int IdItem, string Nombre, string Descripcion, int IdVersion, string UserName)
        {
            ObjAccIndRecBE oObjAccIndRecBE = new ObjAccIndRecBE();
            oObjAccIndRecBE.IdItemTabla = IdItem;
            oObjAccIndRecBE.Nombre = Nombre;
            oObjAccIndRecBE.Descripcion = Descripcion;
            oObjAccIndRecBE.IdItemRelacion = IdVersion;
            oObjAccIndRecBE.UserName = UserName;
            return (new CObjetivo()).ModificarInsertar(oObjAccIndRecBE);
        }

        [WebMethod]
        public int Objetivo_del(int IdItem, string UserName)
        {
            return (new CObjetivo()).Eliminar("81", IdItem.ToString(), UserName);
        }

        [WebMethod]
        public string Accion_ins(int IdItem, string Nombre, string Descripcion, int IdObjetivo, string UserName)
        {
            ObjAccIndRecBE oObjAccIndRecBE = new ObjAccIndRecBE();
            oObjAccIndRecBE.IdItemTabla = IdItem;
            oObjAccIndRecBE.Nombre = Nombre;
            oObjAccIndRecBE.Descripcion = Descripcion;
            oObjAccIndRecBE.IdItemRelacion = IdObjetivo;
            oObjAccIndRecBE.UserName = UserName;
            return (new CActividad()).ModificaInserta(oObjAccIndRecBE);
        }

        [WebMethod]
        public string Reesposable_ins(int IdItem, string CodigoArea, string Descripcion, int IdAccion, string UserName)
        {
            ObjAccIndRecBE oObjAccIndRecBE = new ObjAccIndRecBE();
            oObjAccIndRecBE.IdItemTabla = IdItem;
            oObjAccIndRecBE.Nombre = CodigoArea;
            oObjAccIndRecBE.Descripcion = Descripcion;
            oObjAccIndRecBE.IdItemRelacion = IdAccion;
            oObjAccIndRecBE.UserName = UserName;
            return (new CAccionResponsable()).ModificaInserta(oObjAccIndRecBE);
        }

        [WebMethod]
        public string Indicador_ins(int IdItem, string Nombre, string Descripcion, int IdAccion, string UserName)
        {
            ObjAccIndRecBE oObjAccIndRecBE = new ObjAccIndRecBE();
            oObjAccIndRecBE.IdItemTabla = IdItem;
            oObjAccIndRecBE.Nombre = Nombre;
            oObjAccIndRecBE.Descripcion = Descripcion;
            oObjAccIndRecBE.IdItemRelacion = IdAccion;
            oObjAccIndRecBE.UserName = UserName;
            return (new CAccionIndicador()).ModificaInserta(oObjAccIndRecBE);
        }

        [WebMethod]
        public DataTable ListarObjetivosoAcciones(int IdTblObjetivo, int IdObjetivo, string UserName)
        {
            return (new CObjetivosAcciones()).ListarTodos(IdTblObjetivo.ToString(), IdObjetivo.ToString(), UserName);
        }

        [WebMethod]
        public DataTable ListarAccioneResponsable(int IdTblObjetivo, int IdObjetivo, string UserName)
        {
            return (new CAccionResponsable()).ListarTodos(IdTblObjetivo.ToString(), IdObjetivo.ToString(), UserName);
        }

        [WebMethod]
        public DataTable ListarAccioneResponsableTodos(int IdTblObjetivo, int IdObjetivo, string UserName)
        {
            return (new CAccionResponsable()).ListarTodos(IdTblObjetivo.ToString(), IdObjetivo.ToString(), "", UserName);
        }

        [WebMethod]
        public DataTable ListarAccioneIndicadores(int IdTblObjetivo, int IdObjetivo, string UserName)
        {
            return (new CAccionIndicador()).ListarTodos(IdTblObjetivo.ToString(), IdObjetivo.ToString(), UserName);
        }

        [WebMethod]
        public DataTable ListarIndicadorCondicion(int IdArea, int IdIndicador, string UserName)
        {
            return (new CIndicadorConfigCondicion()).ListarTodosCondicion(IdArea, IdIndicador, UserName);
        }

        [WebMethod]
        public string AreaInforComplementaria_ins(int IdAreaInfo, string FuenteInforma, int IdArea, string IdTipo, string IdSentido, string IdPeridoMedicion, string IdProceso, string UserName)
        {
            ObjAccIndRecBE oObjAccIndRecBE = new ObjAccIndRecBE();
            oObjAccIndRecBE.IdItemTabla = IdAreaInfo;
            oObjAccIndRecBE.Nombre = FuenteInforma;
            oObjAccIndRecBE.IdItemRelacion = IdArea;
            oObjAccIndRecBE.Val2 = IdTipo;
            oObjAccIndRecBE.Val4 = IdSentido;
            oObjAccIndRecBE.Val6 = IdPeridoMedicion;
            oObjAccIndRecBE.Val8 = IdProceso;
            oObjAccIndRecBE.UserName = UserName;

            return (new CAreaInfoComplementa()).ModificaInserta(oObjAccIndRecBE);
        }

        [WebMethod]
        public string AreaCondicionIndicador_ins(int IdItemConfig, string Condicion, int IdAreaInfo, string IdColor, string UserName)
        {
            ObjAccIndRecBE oObjAccIndRecBE = new ObjAccIndRecBE();
            oObjAccIndRecBE.IdItemTabla = IdItemConfig;
            oObjAccIndRecBE.Nombre = Condicion;
            oObjAccIndRecBE.IdItemRelacion = IdAreaInfo;
            oObjAccIndRecBE.Val2 = IdColor;
            oObjAccIndRecBE.UserName = UserName;

            return (new CIndicadorConfigCondicion()).ModificaInserta(oObjAccIndRecBE);
        }

        [WebMethod]
        public DataTable AreaindicadorPlazo_lst(int IdAreaInfoComplet, int IdTipoPlazo, string UserName)
        {
            return (new CAreaIndicadorPlazo()).ListarTodos(IdAreaInfoComplet.ToString(), IdTipoPlazo.ToString(), UserName);
        }

        [WebMethod]
        public string AreaindicadorPlazo_ins(int IdItemMetaArea, string Meta, int IdAreaInfoComplet, string IdTipoDetMeta, string UserName)
        {
            ObjAccIndRecBE oObjAccIndRecBE = new ObjAccIndRecBE();
            oObjAccIndRecBE.IdItemTabla = IdItemMetaArea;
            oObjAccIndRecBE.Nombre = Meta;
            oObjAccIndRecBE.IdItemRelacion = IdAreaInfoComplet;
            oObjAccIndRecBE.Val2 = IdTipoDetMeta.ToString();
            return (new CAreaIndicadorPlazo()).ModificaInserta(oObjAccIndRecBE);
        }
    }
}
