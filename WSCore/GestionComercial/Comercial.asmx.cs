using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSCore.GestionComercial
{
    /// <summary>
    /// Descripción breve de Comercial
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Comercial : System.Web.Services.WebService
    {

        // Composición, encapsulamos
        private readonly Cliente _cliente = new Cliente();
        private readonly Solicitud _solicitud = new Solicitud();

        [WebMethod(Description = "Busca clientes (proxy Cliente.asmx)")]
        public DataTable BuscarCliente(string RazonSocialCliente, string UserName)
        {
            return _cliente.BuscarCliente(RazonSocialCliente, UserName);
        }

        [WebMethod(Description = "Lista Solicitudes de Trabajo")]
        public DataTable ListarSolicitudTrabajo(
    string V_AMBIENTE, string V_FILTRO, string V_CEO, string V_UND_OPER,
    string V_FEC_STR_INI, string V_FEC_STR_FIN, string UserName)
        {
            return _solicitud.ListarSolicitudTrabajo(
                V_AMBIENTE, V_FILTRO, V_CEO, V_UND_OPER,
                V_FEC_STR_INI, V_FEC_STR_FIN, UserName);
        }

    }
}
