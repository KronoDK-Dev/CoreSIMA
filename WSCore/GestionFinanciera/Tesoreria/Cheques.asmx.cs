using Controladora.GestionFinanciera.Tesoreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSCore.GestionFinanciera.Tesoreria
{
    /// <summary>
    /// Descripción breve de Cheques
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Cheques : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable ListarConfiguracioCheque(int IdFormato,string UserName)
        {
            return (new CChequeDiseño()).ListarTodos(IdFormato.ToString(), UserName);
        }

        [WebMethod]
        public DataTable ListarRelacion(int CodCeo, int año,string CodBco,string CtaCte,string Moneda,int Impreso,string UserName)
        {
            return (new CChequeEmitido()).ListarAll(CodCeo, año, CodBco, CtaCte, Moneda, Impreso, UserName);
        }

        [WebMethod]
        public string ActEstadoCheque(string CodigoBanco, string CodigoCtaCte, string NroCheque, string NroFolio, string Moneda, string Yymmdd, int Impreso, string UserName)
        {
            return (new CChequeEmitido()).ActEstadoCheque(CodigoBanco, CodigoCtaCte, NroCheque, NroFolio, Moneda, Yymmdd, Impreso, UserName);
        }
        [WebMethod]
        public string ActBeneficiario(int Año, string CodigoBanco, string NroFolio, string Moneda, string CodigoCtaCte, string Beneficiario, string UserName)
        {
            return (new CChequeEmitido()).ActBeneficiario(Año, CodigoBanco, NroFolio, Moneda, CodigoCtaCte, Beneficiario, UserName);
        }


        [WebMethod]
        public DataTable ListarEntidadFinanciera( string UserName)
        {
            return (new CChequeEmitido()).ListarBancos(UserName);
        }
        [WebMethod]
        public DataTable ListarEntidadFinancieraxUsuario(int idUsuario,string UserName)
        {
            return (new CChequeEmitido()).ListarBancosxUsuario(idUsuario,UserName);
        }
        [WebMethod]
        public DataTable ListarCuentasBancariasxEntidadFinanciera(string CodBco, string Moneda, string UserName)
        {
            return (new CChequeEmitido()).ListarCtasBancos(CodBco, Moneda,  UserName);
        }


        [WebMethod]
        public string InsActBancoxUsuario(int IdUsuario, int IdEntidad, string UserName)
        {
            return (new CChequeEmitido()).InsActBancoxUsuario(IdUsuario, IdEntidad, UserName);
        }

    }
}
