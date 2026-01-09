using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.GestionFinanciera.Tesoreria
{
    public class ControlTAD : BaseAD
    {
        public int Actualizar(string Ind_Org, string Fec_Ope, int Flg_Accion, int CentroOperativo)
        {
            int IdProceso = 0;

            try
            {
                string PackagName = "";
                if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaCallao))
                {
                    PackagName = "O7INVOICE.PD_FACT_UTILITARIO_TAD.actFACT_CTRL_R_EST";
                    OracleParameter[] Param = new OracleParameter[3];
                    Param[0] = new OracleParameter("PIND_ORG", OracleDbType.Varchar2);
                    Param[0].Direction = ParameterDirection.Input;
                    Param[0].Value = Ind_Org;

                    Param[1] = new OracleParameter("PFEC_OPE", OracleDbType.Varchar2);
                    Param[1].Direction = ParameterDirection.Input;
                    Param[1].Value = Fec_Ope;

                    Param[2] = new OracleParameter("PFLG_ACCION", OracleDbType.Int64);
                    Param[2].Direction = ParameterDirection.Input;
                    Param[2].Value = Flg_Accion;
                    object id = Oracle(ORACLEVersion.O7).ExecuteScalar(true, PackagName, Param);

                }
                else if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaChimbote))
                {
                    PackagName = "sp_FEC_CTRL_R_EST";
                    int idResult = Convert.ToInt32(Sql(SQLVersion.sqlDBSimaCH).ExecuteNonQuery(PackagName, Ind_Org, Fec_Ope, Flg_Accion));
                }
                else
                {
                    PackagName = "sp_FEC_CTRL_R_EST";
                    int idResult = Convert.ToInt32(Sql(SQLVersion.sqlDBSimaIQ).ExecuteNonQuery(PackagName, Ind_Org, Fec_Ope, Flg_Accion));
                }
                // object OBJ = DBGeneric((Enumerados.CentroOperativo)System.Enum.Parse(typeof(Enumerados.CentroOperativo), CentroOperativo.ToString())).ExecuteNonQuerys(PackagName, Param);
                IdProceso = 1;

                return IdProceso;
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                // Helper.Archivo.Log("AccesoDatos:ControlTAD:Actualizar", sqlException.Message);
                return IdProceso;
            }
            catch (System.Data.OleDb.OleDbException oleDbException)
            {
                //Helper.Archivo.Log("AccesoDatos:ControlTAD:Actualizar", oleDbException.Message);
                return IdProceso;
            }
            catch (Exception ex)
            {
                //Helper.Archivo.Log("AccesoDatos:ControlTAD:Actualizar", ex.Message);
                return IdProceso;
            }
        }
    }
}
