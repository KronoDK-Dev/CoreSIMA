using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log;
using Oracle.DataAccess.Client;
using Utilitario;

namespace AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria
{
    public class InterbancarioNTAD : BaseAD
    {
        public DataTable CabeceraLotePago(string Estado, string UserName)
        {
            try
            {
                string name = new StackTrace().GetFrame(0).GetMethod().Name;
                InfoMetodoBE infoMetodoBe = this.MetodoInfo(name, UserName);
                string str = "Pkg_Planilla_Proveedores.SP_Planilla_Pago_Cabecera";
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, infoMetodoBe.VoidParams, "", Helper.MensajesIngresarMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                OracleParameter[] Params = new OracleParameter[2]
                {
                    new OracleParameter("pEst_atl", OracleDbType.Varchar2),
                    null
                };
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = (object)Estado;
                Params[1] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Params[1].Direction = ParameterDirection.Output;
                DataSet dataSet = BaseAD.Oracle(BaseAD.ORACLEVersion.O7).ExecuteDataSet(true, str, Params);
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, "", "rstCount:" + dataSet.Tables[0].Rows.Count.ToString(), Helper.MensajesSalirMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                return dataSet.Tables[0];
            }
            catch (SqlException ex)
            {
                string user = UserName;
                string name = this.GetType().Name;
                string origen = Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString();
                string str1 = Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString();
                string ceros = Constante.LogCtrl.CEROS;
                int number = ex.Number;
                string str2 = number.ToString();
                string str3 = Helper.Cadena.CortarTextoDerecha(5, ceros + str2);
                string codError = str1 + str3;
                string[] strArray = new string[6];
                strArray[0] = "Código de Error:";
                number = ex.Number;
                strArray[1] = number.ToString();
                strArray[2] = Constante.Caracteres.SeperadorSimple;
                strArray[3] = "Número de Línea:1";
                strArray[4] = Constante.Caracteres.SeperadorSimple;
                strArray[5] = ex.Message;
                string excepcion = string.Concat(strArray);
                LogTransaccional.LanzarSIMAExcepcionDominio(user, name, origen, codError, excepcion);
                return (DataTable)null;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return (DataTable)null;
            }
        }

        public DataTable CabeceraLotePago(string LotePago, string Estado, string UserName)
        {
            try
            {
                string name = new StackTrace().GetFrame(0).GetMethod().Name;
                InfoMetodoBE infoMetodoBe = this.MetodoInfo(name, LotePago.ToString(), UserName);
                string str = "Pkg_Planilla_Proveedores.SP_Planilla_Pago_Cabecera";
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, infoMetodoBe.VoidParams, "", Helper.MensajesIngresarMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                OracleParameter[] Params = new OracleParameter[3]
                {
                    new OracleParameter("p_nro_lot", OracleDbType.Varchar2),
                    null,
                    null
                };
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = (object)LotePago;
                Params[1] = new OracleParameter("pEst_atl", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = (object)Estado;
                Params[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Params[2].Direction = ParameterDirection.Output;
                DataSet dataSet = BaseAD.Oracle(BaseAD.ORACLEVersion.O7).ExecuteDataSet(true, str, Params);
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, "", "rstCount:" + dataSet.Tables[0].Rows.Count.ToString(), Helper.MensajesSalirMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                return dataSet.Tables[0];
            }
            catch (SqlException ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Constante.LogCtrl.CEROS + ex.Number.ToString()), $"Código de Error:{ex.Number.ToString()}{Constante.Caracteres.SeperadorSimple}Número de Línea:1{Constante.Caracteres.SeperadorSimple}{ex.Message}");
                return (DataTable)null;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return (DataTable)null;
            }
        }

        public DataTable DetalleLotePago(string LotePago, string UserName)
        {
            try
            {
                string name = new StackTrace().GetFrame(0).GetMethod().Name;
                InfoMetodoBE infoMetodoBe = this.MetodoInfo(name, LotePago.ToString(), UserName);
                string str = "Pkg_Planilla_Proveedores.SP_Planilla_Pago_Detalle";
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, infoMetodoBe.VoidParams, "", Helper.MensajesIngresarMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                OracleParameter[] Params = new OracleParameter[2]
                {
        new OracleParameter("p_nro_lot", OracleDbType.Varchar2),
        null
                };
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = (object)LotePago;
                Params[1] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Params[1].Direction = ParameterDirection.Output;
                DataSet dataSet = BaseAD.Oracle(BaseAD.ORACLEVersion.O7).ExecuteDataSet(true, str, Params);
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, "", "rstCount:" + dataSet.Tables[0].Rows.Count.ToString(), Helper.MensajesSalirMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                return dataSet.Tables[0];
            }
            catch (SqlException ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Constante.LogCtrl.CEROS + ex.Number.ToString()), $"Código de Error:{ex.Number.ToString()}{Constante.Caracteres.SeperadorSimple}Número de Línea:1{Constante.Caracteres.SeperadorSimple}{ex.Message}");
                return (DataTable)null;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return (DataTable)null;
            }
        }
    }
}
