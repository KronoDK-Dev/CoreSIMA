using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;
using static AccesoDatos.BaseAD;

namespace AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria
{
    public class ControlNTAD : BaseAD
    {
        public DataSet VerificaDocNew(string Fec_Ope, int CentroOperativo)
        {
            try
            {
                DataSet ds = new DataSet();

                string PackagName = "";
                if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaCallao))
                {
                    PackagName = "O7INVOICE.PD_FACT_UTILITARIO_NTAD.VerificaFactNew";
                    OracleParameter[] Param = new OracleParameter[2];
                    Param[0] = new OracleParameter("pFEC_OPE", OracleDbType.Varchar2);
                    Param[0].Direction = ParameterDirection.Input;
                    Param[0].Value = Fec_Ope;

                    Param[1] = new OracleParameter("Rstdo", OracleDbType.RefCursor);
                    Param[1].Direction = ParameterDirection.Output;

                    ds = Oracle(ORACLEVersion.O7).ExecuteDataSet(true, PackagName, Param);
                }
                else if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaChimbote))
                {
                    PackagName = "sp_FECVerificaFactNew";
                    ds = Sql(SQLVersion.sqlDBSimaCH).ExecuteDataSet(PackagName, Fec_Ope);
                }
                else
                {
                    PackagName = "sp_FECVerificaFactNew";
                    ds = Sql(SQLVersion.sqlDBSimaIQ).ExecuteDataSet(PackagName, Fec_Ope);
                }
                //ds = DBGeneric((Enumerados.CentroOperativo)System.Enum.Parse(typeof(Enumerados.CentroOperativo), CentroOperativo.ToString())).ExecuteDataSets(PackagName, Param);
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
