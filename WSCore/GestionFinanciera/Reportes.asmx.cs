using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.GestionFinanciera;

namespace WSCore.GestionFinanciera
{
    /// <summary>
    /// Descripción breve de Reportes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Reportes : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable GenRptAnexosFinanciero(int IdFormato, int Periodo, string RangoMes, int IdUsuario,
            string UserName)
        {
            return (new cReporte()).GenRptAnexosFinanciero(IdFormato, Periodo, RangoMes, IdUsuario,
                UserName);
        }

        [WebMethod]
        public DataTable GenRptAnexosFiltro(string IdProceso, string UserName)
        {
            return (new cReporte()).GenRptAnexosFiltro(IdProceso, UserName);
        }
    }
}
