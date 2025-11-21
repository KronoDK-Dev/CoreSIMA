using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria
{
    public class ComprobanteNTAD : BaseAD
    {
        public DataSet ConsultarPorEstado(string Ind_Org, int IdEstado, int CentroOperativo)
        {
            try
            {
                DataSet ds = new DataSet();

                string PackagName = "";
                if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaCallao))
                {
                    PackagName = "O7INVOICE.PD_COMPROBANTE_VENTA_PKG.ComprobanteXEst";
                    OracleParameter[] Param = new OracleParameter[3];
                    Param[0] = new OracleParameter("p_ind_org", OracleDbType.Varchar2);
                    Param[0].Direction = ParameterDirection.Input;
                    Param[0].Value = Ind_Org;

                    Param[1] = new OracleParameter("Est_Tra", OracleDbType.Int64);
                    Param[1].Direction = ParameterDirection.Input;
                    Param[1].Value = IdEstado;

                    Param[2] = new OracleParameter("Relacion", OracleDbType.RefCursor);
                    Param[2].Direction = ParameterDirection.Output;

                    ds = Oracle(ORACLEVersion.O7).ExecuteDataSet(true, PackagName, Param);
                }
                else if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaChimbote))
                {
                    PackagName = "sp_FECComprobanteCAB";
                    ds = Sql(SQLVersion.sqlDBSimaCH).ExecuteDataSet(PackagName, Ind_Org, IdEstado);
                }
                else
                {
                    PackagName = "sp_FECComprobanteCAB";
                    ds = Sql(SQLVersion.sqlDBSimaIQ).ExecuteDataSet(PackagName, Ind_Org, IdEstado);
                }

                //   ds = DBGeneric((Enumerados.CentroOperativo)System.Enum.Parse(typeof(Enumerados.CentroOperativo), CentroOperativo.ToString())).ExecuteDataSets(PackagName, Param);
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

        public DataSet Consultar(string Ind_Org, int CentroOperativo)
        {
            try
            {
                DataSet ds = new DataSet();

                string PackagName = "";
                if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaCallao))
                {
                    PackagName = "O7INVOICE.PD_COMPROBANTE_VENTA_PKG.Comprobante";
                    OracleParameter[] Param = new OracleParameter[2];
                    Param[0] = new OracleParameter("p_ind_org", OracleDbType.Varchar2);
                    Param[0].Direction = ParameterDirection.Input;
                    Param[0].Value = Ind_Org;

                    Param[1] = new OracleParameter("relacion", OracleDbType.RefCursor);
                    Param[1].Direction = ParameterDirection.Output;

                    ds = Oracle(ORACLEVersion.O7).ExecuteDataSet(true, PackagName, Param);
                }
                else if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaChimbote))
                {
                    PackagName = "sp_FECComprobanteCAB";
                    ds = Sql(SQLVersion.sqlDBSimaCH).ExecuteDataSet(PackagName, Ind_Org);
                }
                else
                {
                    PackagName = "sp_FECComprobanteCAB";
                    ds = Sql(SQLVersion.sqlDBSimaIQ).ExecuteDataSet(PackagName, Ind_Org);
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

        public DataSet Consultar(string Ind_Org, int IdEstado, string TipoDoc, string NroSerie, int CentroOperativo)
        {
            try
            {
                DataSet ds = new DataSet();

                string PackagName = "";
                if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaCallao))
                {
                    PackagName = "O7INVOICE.PD_COMPROBANTE_VENTA_PKG.ComprobanteXEst";

                    OracleParameter[] Param = new OracleParameter[2];
                    Param[0] = new OracleParameter("p_ind_org", OracleDbType.Varchar2);
                    Param[0].Direction = ParameterDirection.Input;
                    Param[0].Value = Ind_Org;

                    Param[1] = new OracleParameter("Est_Tra", OracleDbType.Int64);
                    Param[1].Direction = ParameterDirection.Input;
                    Param[1].Value = IdEstado;
                    ds = Oracle(ORACLEVersion.O7).ExecuteDataSet(true, PackagName, Param);
                }
                else if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaChimbote))
                {
                    PackagName = "sp_FECComprobanteCAB";
                    ds = Sql(SQLVersion.sqlDBSimaCH).ExecuteDataSet(PackagName, Ind_Org, IdEstado);
                }
                else
                {
                    PackagName = "sp_FECComprobanteCAB";
                    ds = Sql(SQLVersion.sqlDBSimaIQ).ExecuteDataSet(PackagName, Ind_Org, IdEstado);
                }

                // ds = DBGeneric((Enumerados.CentroOperativo)System.Enum.Parse(typeof(Enumerados.CentroOperativo), CentroOperativo.ToString())).ExecuteDataSets(PackagName, Param);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        DataView dv = dt.DefaultView;
                        dv.RowFilter = " TIP_DOC='" + TipoDoc + "' and SER_NUM='" + NroSerie + "'";
                        DataTable dtv = Helper.Data.DataViewTODataTable(dv);
                        ds.Tables.Remove(dt);
                        ds.Tables.Add(dtv);
                    }
                }

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
