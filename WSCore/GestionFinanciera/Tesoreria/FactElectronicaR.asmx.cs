using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.GestionFinanciera.Tesoreria;

namespace WSCore.GestionFinanciera.Tesoreria
{
    /// <summary>
    /// Descripción breve de FactElectronicaR
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class FactElectronicaR : System.Web.Services.WebService
    {
        [WebMethod(Description = "Consulta de Comprobantes retención- Detalle")]
        public DataSet ConsultarComprobantedeRetencion(string Ind_Org, int CentroOperativo)
        {
            return (new CComprobanteRetencion()).ConsultarComprobantedeRetencion(Ind_Org, CentroOperativo);
        }
    }
}
