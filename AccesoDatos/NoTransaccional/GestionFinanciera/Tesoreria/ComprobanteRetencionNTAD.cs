using Log;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Utilitario;
using Oracle.DataAccess.Client;

namespace AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria
{
    public class ComprobanteRetencionNTAD:BaseAD
    {

        public DataSet Consultar(string Ind_Org,int CentroOperativo)
        {
            try
            {
                return (new ComprobanteNTAD()).Consultar(Ind_Org, CentroOperativo); 
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                ;
            }
            catch (System.Data.OleDb.OleDbException oleDbException)
            {
                ;
            }

            catch (Exception ex)
            {
                ;
            }
            return null;
        }

       
    }
}
