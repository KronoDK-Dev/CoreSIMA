using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.GestionPresupuesto;

namespace WSCore.GestionPresupuesto
{
    /// <summary>
    /// Descripción breve de Presupuesto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Presupuesto : System.Web.Services.WebService
    {
        [WebMethod(Description = "5. Detalle_OC_OS. Detalle_OC_OS")]
        public DataTable Listar_Cheques_por_OC_OS(string V_Centro_Operativo, string D_Año, string D_Mes,
            string V_Origen, string UserName)
        {
            return (new cPresupuesto()).Listar_Cheques_por_OC_OS(V_Centro_Operativo, D_Año, D_Mes, V_Origen, UserName);
        }
    }
}
