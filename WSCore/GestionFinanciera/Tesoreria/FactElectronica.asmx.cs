
using System.Data;
using System.Web.Services;
using Controladora.General;
using Controladora.GestionFinanciera.Tesoreria;

namespace WSCore.GestionFinanciera.Tesoreria
{
    /// <summary>
    /// Descripción breve de FacturacionElectronica
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class FactElectronica : System.Web.Services.WebService
    {

       [WebMethod(Description = "Consulta de Comprobantes")]
        public DataSet ConsultarComprobantes(string Ind_Org, int CentroOperativo)
        {
            return (new CComprobante()).ConsultarComprobantes(Ind_Org, CentroOperativo);
        }
        [WebMethod(Description = "Lista los Comprobantes según el estado solicitado")]
        public DataSet ConsultarComprobatesPorEstado(string Ind_Org, int IdEstado, int CentroOperativo)
        {
            return (new CComprobante()).ConsultarComprobatesPorEstado(Ind_Org, IdEstado, CentroOperativo);
        }
       [WebMethod(Description = "Consulta de Comprobantes x Estado tipo y Nro de serie")]
        public DataSet ConsultarComprobantesXNro(string Ind_Org, int idEstado, string TipoDoc, string NroSerie, int CentroOperativo)
        {
            return (new CComprobante()).ConsultarComprobantesXNro(Ind_Org, idEstado, TipoDoc, NroSerie, CentroOperativo);
        }
 

        [WebMethod(Description = "Consulta Info adicional de Comprobantes")]
        public DataSet ConsultarInfoAdicinalComprobantes(string TipoDoc, string NroSer, int CentroOperativo)
        {
            return (new CComprobanteAdicional()).ConsultarInfoAdicinalComprobantes(TipoDoc, NroSer, CentroOperativo);
        }

       [WebMethod(Description = "Consulta de Comprobantes - Detalle")]
        public DataSet ConsultarComprobantesDetalle(string TipoDoc, string NroSer, int CentroOperativo)
        {
            return (new CComprobanteDetalle()).ConsultarComprobantesDetalle(TipoDoc, NroSer, CentroOperativo);
        }

       [WebMethod(Description = "Consulta de Comprobantes -Detalle Detracción")]
        public DataSet ConsultarComprobantesDetraccion(string TipoDoc, string NroSer, int CentroOperativo)
        {
            return (new CComprobanteDetraccion()).ConsultarComprobantesDetraccion(TipoDoc, NroSer, CentroOperativo);
        }

        [WebMethod(Description = "Consulta de Comprobantes - Anticipo")]
        public DataTable ConsultarComprobantesAnticipo(string TipoDoc, string NroSer, int CentroOperativo)
        {
            return (new CAnticipo()).ConsultarComprobantesAnticipo(TipoDoc, NroSer, CentroOperativo);
        }

         [WebMethod(Description = "Consulta de Comprobantes - Cargo del Anticipo")]
        public DataSet ConsultarComprobantesCargo(string TipoDoc, string NroSer, int CentroOperativo)
        {
            return (new CComprobanteCargo()).ConsultarComprobantesCargo(TipoDoc, NroSer, CentroOperativo);
        }

         [WebMethod(Description = "Consulta Info Comprobante cuota")]
        public DataSet ConsultarComprobanteCuota(string TipoDoc, string NroSer, int CentroOperativo)
        {
            return (new CComprobanteCuota()).ConsultarComprobanteCuota(TipoDoc, NroSer, CentroOperativo);
        }

        [WebMethod(Description = "Consulta de Clientes")]
        public DataSet ConsultarClientes(string CodCli, int CentroOperativo)
        {
            return (new Controladora.GestionComercial.CCliente()).Consultar(CodCli, CentroOperativo);
        }
   
        [WebMethod]
        public DataTable ObtenerCredencialEMP(string IdEmp)
        {
            return (new CEmpresa()).ObtenerCredencialEMP(IdEmp);
        }


        [WebMethod(Description = "Listar Atributos de Componente")]
        public DataSet ListarAtributosComponente(int IdComponente)
        {
            return (new CComponenteO7Atributos()).ListarAtributosComponente(IdComponente);
        }

        [WebMethod(Description = "Verificar Factura Nueva")]
        public DataSet VerificaFacturaNueva(string Fec_Ope, int CentroOperativo)
        {
            return (new CControl()).VerificaFacturaNueva(Fec_Ope, CentroOperativo);
        }

       // #region Transaccionales

        [WebMethod(Description = "Actualiza Estado de Comprobante")]
        public int ActualizarEstadoComprobante(string TipoDoc, string NroSer, int Estado, int CentroOperativo)
        {
            return (new CComprobante()).ActualizarEstadoComprobante(TipoDoc, NroSer, Estado, CentroOperativo);
        }

        [WebMethod(Description = "Actualiza Tabla de Control")]
        public int ActualizarTablaControl(string Ind_Org, string Fec_Ope, int Flg_Accion, int CentroOperativo)
        {
            return (new CControl()).ActualizarTablaControl(Ind_Org, Fec_Ope, Flg_Accion, CentroOperativo);
        }

        [WebMethod(Description = "Consulta Listado de componentes obligatorios")]
        public DataSet ConsultarComponentesAtributosObligatorios()
        {
            return (new CComponenteO7AtributoObligatorio()).ConsultarComponentesAtributosObligatorios();
        }
     
        [WebMethod(Description = "Consulta Listado del Catalogo de valores SUNAT")]
        public DataSet ConsultarCatalogos()
        {
            return (new CComponenteO7Catalogo()).ConsultarCatalogos();
        }
     


        [WebMethod]
        public DataTable TestDataSet()
        {

            DataTable dt = new DataTable("MyDataTable");
            dt.Columns.Add("column1", typeof(System.String));
            dt.Columns.Add("column2", typeof(System.String));

            DataRow dr = dt.NewRow();
            dr["column1"] = "Your Data";
            dr["column2"] = "Your Data";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["column1"] = "Your Data";
            dr["column2"] = "Your Data";
            dt.Rows.Add(dr);

            return dt;
        }


      //  #endregion

    }
}
