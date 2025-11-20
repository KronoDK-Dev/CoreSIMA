using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;
using static AccesoDatos.BaseAD;

namespace AccesoDatos.NoTransaccional.GestionCostos
{
    public class VentasNTAD : BaseAD
    {
        readonly string sConsulta = ConfigurationManager.AppSettings["CONSULTA"];

        public DataTable Listar_Ventas_diferidas_x_OT_detalle(string V_PERIODO, string V_CENTRO_OPERATIVO,
            string V_DIVISION, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_COSTOS.SP_Ventas_DifeLineaNegocioDet";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[4];

                Param[0] = new OracleParameter("V_Centro_Operativo", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CENTRO_OPERATIVO;

                Param[1] = new OracleParameter("D_Periodo", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_PERIODO;

                Param[2] = new OracleParameter("V_Linea_Negocio", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_DIVISION;


                Param[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[3].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, Param);
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , ""
                    , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    // Manejo del error o mensaje de advertencia
                    return null;
                }


            }
            catch (OracleException oracleException)
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

        public DataTable Listar_Ventas_diferidas_x_Doc_detalle(string V_PERIODO, string V_CENTRO_OPERATIVO, string V_DIVISION, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_COSTOS.SP_Ventas_Dife_LineaNeg_OT_Doc";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[4];
                Param[0] = new OracleParameter("V_Centro_Operativo", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CENTRO_OPERATIVO;

                Param[1] = new OracleParameter("D_Periodo", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_PERIODO;

                Param[2] = new OracleParameter("V_Linea_Negocio", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_DIVISION;

                Param[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[3].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, Param);
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , ""
                    , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                return ds.Tables[0];
            }
            catch (OracleException oracleException)
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
