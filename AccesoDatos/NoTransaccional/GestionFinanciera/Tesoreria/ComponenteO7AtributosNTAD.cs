using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AccesoDatos.BaseAD;

namespace AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria
{
    public class ComponenteO7AtributosNTAD : BaseAD
    {
        public DataSet ListarAtributos(int IdComponente)
        {

            try
            {
                DataSet ds = new DataSet();
                string PackagName = "O7INVOICE.PD_FACT_UTILITARIO_NTAD.ListAttrComponente";

                OracleParameter[] Param = new OracleParameter[2];
                Param[0] = new OracleParameter("IdComponente", OracleDbType.Int64);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = IdComponente;

                Param[1] = new OracleParameter("Rstdo", OracleDbType.RefCursor);
                Param[1].Direction = ParameterDirection.Output;

                ds = Oracle(ORACLEVersion.O7).ExecuteDataSet(true, PackagName, Param);
                // ds = DBGeneric(Enumerados.CentroOperativo.SimaCallao).ExecuteDataSets(PackagName, Param);

                return ds;
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
