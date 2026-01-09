using Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.NoTransaccional.GestionFinanciera
{
    public class Reportes : BaseAD
    {
        public DataTable GenRptAnexosFinanciero(int IdFormato, int Periodo, string RangoMes, int IdUsuario,
            string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string methodName = stack.GetFrame(0).GetMethod().Name;

                string packageName = "dbo.NQ_SP_MESES_CONTABLE_PROCESO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(
                    UserName,
                    methodName,
                    packageName,
                    "",
                    "",
                    "",
                    Helper.MensajesIngresarMetodo(),
                    Convert.ToString(Enumerados.NivelesErrorLog.I)
                ));

                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@IdFormato", SqlDbType.Int);
                parameters[0].Value = IdFormato;
                parameters[1] = new SqlParameter("@Periodo", SqlDbType.Int);
                parameters[1].Value = Periodo;
                parameters[2] = new SqlParameter("@Meses", SqlDbType.NVarChar);
                parameters[2].Value = RangoMes;
                parameters[3] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                parameters[3].Value = IdUsuario;

                var ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(packageName, parameters);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , ""
                    , methodName
                    , packageName
                    , parameters.ToString()
                    , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                return ds.Tables[0];
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable GenRptAnexosFiltro(string IdProceso, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string methodName = stack.GetFrame(0).GetMethod().Name;

                string packageName = "dbo.NQ_SP_REP_FILTRO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(
                    UserName,
                    methodName,
                    packageName,
                    "",
                    "",
                    "",
                    Helper.MensajesIngresarMetodo(),
                    Convert.ToString(Enumerados.NivelesErrorLog.I)
                ));

                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdProceso", SqlDbType.NVarChar);
                parameters[0].Value = IdProceso;

                var ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(packageName, parameters);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , ""
                    , methodName
                    , packageName
                    , parameters.ToString()
                    , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                return ds.Tables[0];
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }
    }
}
