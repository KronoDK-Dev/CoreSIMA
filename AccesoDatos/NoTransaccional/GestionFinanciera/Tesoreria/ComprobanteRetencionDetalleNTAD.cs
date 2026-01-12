using Log;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Utilitario;
using Oracle.DataAccess.Client;

namespace AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria
{
    public class ComprobanteRetencionDetalleNTAD:BaseAD
    {
        public DataSet ConsultarItems(string TipoDoc, string NroSerie, int IdCentroOPerativo)
        {
           //No implementado por que la llamada lo hace la clase comprobante detalle para ambos casos
            return null;
        }
    
    }
}
