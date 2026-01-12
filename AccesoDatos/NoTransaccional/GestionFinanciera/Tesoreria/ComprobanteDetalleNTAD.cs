using Log;
using System;
using System.Data.SqlClient;
using System.Data;
using Utilitario;
using Oracle.DataAccess.Client;

namespace AccesoDatos.NoTransaccional.Tesoreria
{
    public class ComprobanteDetalleNTAD:BaseAD
    {
        public DataSet Consultar(string TipoDoc, string NroSer, int CentroOperativo)
        {
            try
            {
                DataSet ds = new DataSet();

                string PackagName = "";
                if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaCallao)){ 
                    PackagName = "O7INVOICE.Pd_Comprobante_Venta_Pkg.ComprobanteDetalle";
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
                else if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaChimbote)){ 
                    PackagName = "sp_FECComprobanteDET";
                    ds = Sql(SQLVersion.sqlDBSimaCH).ExecuteDataSet(PackagName, TipoDoc, NroSer);
                }
                else{ 
                    PackagName = "sp_FECComprobanteDET";
                    ds = Sql(SQLVersion.sqlDBSimaIQ).ExecuteDataSet(PackagName, TipoDoc, NroSer);
                }
                //ds = DBGeneric((Enumerados.CentroOperativo)System.Enum.Parse(typeof(Enumerados.CentroOperativo), CentroOperativo.ToString())).ExecuteDataSets(PackagName, Param);
                return ds;
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                //Helper.Archivo.Log("AccesoDatos:ComprobanteDetalleNTAD.:Consultar", sqlException.Message);
            }
            catch (System.Data.OleDb.OleDbException oleDbException)
            {
                //Helper.Archivo.Log("AccesoDatos:ComprobanteDetalleNTAD.:Consultar", oleDbException.Message);
            }
            catch (Exception ex)
            {
                //Helper.Archivo.Log("AccesoDatos:ComprobanteDetalleNTAD.:Consultar", ex.Message);
            }
            return null;
        }
     
    }
}
