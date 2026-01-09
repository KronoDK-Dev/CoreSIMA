using EntidadNegocio;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Data;
using Utilitario;

namespace AccesoDatos.Transaccional.GestionFinanciera.Tesoreria
{
    public class ComprobanteRetencionTAD:BaseAD
    {

        public int ActualizarEstado(string TipoDoc, string NroSer, int Estado, int CentroOperativo)
        {
            string UserName = "";
            int IdProceso = 0;
            try
            {
                string PackagName = "";
                if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaCallao))
                { 
                    PackagName = "Pd_Comprobante_Venta_Pkg.ComprobanteEst_Tra";
                    OracleParameter[] Param = new OracleParameter[3];

                    Param[0] = new OracleParameter("p_tip_doc", OracleDbType.Varchar2);
                    Param[0].Direction = ParameterDirection.Input;
                    Param[0].Value = TipoDoc;

                    Param[1] = new OracleParameter("p_nro_ser", OracleDbType.Varchar2);
                    Param[1].Direction = ParameterDirection.Input;
                    Param[1].Value = NroSer;

                    Param[2] = new OracleParameter("p_est_tra", OracleDbType.Int32);
                    Param[2].Direction = ParameterDirection.Input;
                    Param[2].Value = Estado;

                    object id = Oracle(ORACLEVersion.O7).ExecuteScalar(true, PackagName, Param);
                }
                else if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaChimbote))
                { 
                    PackagName = "sp_FECComprobanteEst_Tra";
                    int idResult = Convert.ToInt32(Sql(SQLVersion.sqlDBSimaCH).ExecuteNonQuery(PackagName, TipoDoc, NroSer, Estado));
                }
                else
                { 
                    PackagName = "sp_FECComprobanteEst_Tra";
                    int idResult = Convert.ToInt32(Sql(SQLVersion.sqlDBSimaIQ).ExecuteNonQuery(PackagName, TipoDoc, NroSer, Estado));
                }

               // object OBJ = DBGeneric((Enumerados.CentroOperativo)System.Enum.Parse(typeof(Enumerados.CentroOperativo), CentroOperativo.ToString())).ExecuteNonQuerys(PackagName, Param);
                IdProceso = 1;

                return IdProceso;
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + sqlException.Number.ToString()), "Código de Error:" + sqlException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + sqlException.Message);
                return IdProceso;
            }
            catch (System.Data.OleDb.OleDbException oleDbException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oleDbException.ErrorCode.ToString()), "Código de Error:" + oleDbException.ErrorCode.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oleDbException.Message);
                return IdProceso;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return IdProceso;
            }
        }
   
    }
}
