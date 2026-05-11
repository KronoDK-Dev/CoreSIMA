using Controladora.GestionPersonal.EvaluacionDesem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSCore.GestionPersonal.EvaluacionDesem
{
    /// <summary>
    /// Descripción breve de EvaluacionDesempenio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class EvaluacionDesempenio : System.Web.Services.WebService
    {

        [WebMethod(Description = "Busca los Objetivos para una evaluación de Desempeño x Descripcion")]
        public DataTable BuscarObjetivosxDescripcion(string V_DESCRIPCION, string UserName)
        {
            return (new CEvaluacionDesempenio()).BuscarObjetivosxDescripcion(V_DESCRIPCION, UserName);
        }


        [WebMethod(Description = "Actualiza el acceso de evaluación")]
        public string ActualizarAccesoEvaluacion(string V_TIPO_EVAL, int V_VALOR, string V_OPCION, string V_DNI_JEFE, string UserName)
        {
            return (new CEvaluacionDesempenio()).ActualizarAccesoEvaluacion(V_TIPO_EVAL, V_VALOR, V_OPCION, V_DNI_JEFE, UserName);
        }

    }
}
