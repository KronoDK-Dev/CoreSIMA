using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria
{
    public class ComponenteO7AtributoObligatorioNTAD : BaseAD
    {
        public DataSet Listar()
        {
            try
            {
                DataSet ds = new DataSet();
                string PackagName = "O7INVOICE.PD_FACT_UTILITARIO_NTAD.ListAttrObligComponente";
                OracleParameter[] Param = new OracleParameter[1];
                Param[0] = new OracleParameter("Rstdo", OracleDbType.RefCursor);
                Param[0].Direction = ParameterDirection.Output;

                ds = Oracle(ORACLEVersion.O7).ExecuteDataSet(true, PackagName, Param);
                // ds = DBGeneric(Enumerados.CentroOperativo.SimaCallao).ExecuteDataSets(PackagName);

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
