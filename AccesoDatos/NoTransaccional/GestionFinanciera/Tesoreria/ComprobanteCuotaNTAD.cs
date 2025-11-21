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
    public class ComprobanteCuotaNTAD : BaseAD
    {
        public DataSet Consultar(string TipoDoc, string NroSer, int CentroOperativo)
        {
            try
            {
                DataSet ds = new DataSet();

                string PackagName = "";
                if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaCallao))
                {
                    PackagName = "O7INVOICE.PD_COMPROBANTE_VENTA_PKG.ComprobanteCuota";

                    OracleParameter[] Param = new OracleParameter[3];
                    Param[0] = new OracleParameter("p_tip_doc", OracleDbType.Varchar2);
                    Param[0].Direction = ParameterDirection.Input;
                    Param[0].Value = TipoDoc;

                    Param[1] = new OracleParameter("p_nro_ser", OracleDbType.Varchar2);
                    Param[1].Direction = ParameterDirection.Input;
                    Param[1].Value = NroSer;

                    Param[2] = new OracleParameter("Relacion", OracleDbType.RefCursor);
                    Param[2].Direction = ParameterDirection.Output;

                    ds = Oracle(ORACLEVersion.O7).ExecuteDataSet(true, PackagName, Param);
                }
                else if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaChimbote))
                {
                    PackagName = "SP_ComprobanteCuota";
                    ds = Sql(SQLVersion.sqlDBSimaCH).ExecuteDataSet(PackagName, TipoDoc, NroSer);
                }
                else
                {
                    PackagName = "SP_ComprobanteCuota";
                    ds = Sql(SQLVersion.sqlDBSimaIQ).ExecuteDataSet(PackagName, TipoDoc, NroSer);
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
