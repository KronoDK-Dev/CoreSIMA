using Controladora.GestionLogistica;
using EntidadNegocio.GestionProduccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.GestionProduccion;

namespace WSCore.GestionProduccion
{
    /// <summary>
    /// Descripción breve de Proyectos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Proyectos : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable ListarProyectosSIMA(string IdProyecto, string UserName)
        {
            return (new CProyectos()).ListarTodos(IdProyecto, UserName);
        }

        [WebMethod]
        public ProyectoBE DetalleProyectosSIMA(string IdProyecto, string UserName)
        {
            return (ProyectoBE)(new CProyectos()).Detalle(IdProyecto, UserName);
        }

        [WebMethod(Description = "Buscar Proyectos para calidad")]
        public DataTable BuscarPryectoPor(int TipoBusqueda, string Citerio, string UserName)
        {
            return (new CProyectos()).Buscar(TipoBusqueda, Citerio, UserName);
        }

        [WebMethod(Description = "Inserta y Modifica Proyecto en el MOdulo de calidad")]
        public int InsertaModificaProyecto(ProyectoBE oProyectoBE)
        {
            return (new CProyectos()).ModificarInsertar(oProyectoBE);
        }

        [WebMethod(Description = "Inserta proyecto por CLIENTE")]
        public int ProyectoInsAct(int IdProyecto, string Codigo, string Nombre, string Descripcion, int IdCliente,
            int IdLN, int IdEstado, int IdUsuario, string UserName)
        {
            try
            {
                ProyectoBE oProyectoBE = new ProyectoBE();
                oProyectoBE.IdProyecto = IdProyecto;
                oProyectoBE.CodigoProy = Codigo;
                oProyectoBE.Nombre = Nombre;
                oProyectoBE.Descripcion = Descripcion;
                oProyectoBE.IdCliente = IdCliente;
                oProyectoBE.IdLN = IdLN;
                oProyectoBE.IdUsuario = IdUsuario;
                oProyectoBE.IdEstado = IdEstado;
                return InsertaModificaProyecto(oProyectoBE);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
