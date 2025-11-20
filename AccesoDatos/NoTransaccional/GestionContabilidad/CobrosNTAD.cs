using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.NoTransaccional.GestionContabilidad
{
    public class CobrosNTAD : BaseAD
    {
        readonly string sConsulta = ConfigurationManager.AppSettings["CONSULTA"];

        public DataTable Listar_reg_ventas_sunat_conso_pl(string D_AÑO, string D_MES, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_REG_VENTAS_SUNAT_CONSO_PLE";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[3];
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Int32);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_MES;

                Param[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[2].Direction = ParameterDirection.Output;
               
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

        public DataTable Listar_reg_ventas_sunat_pdb_txt(string D_AÑO, string D_MES, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_REG_VENTAS_SUNAT_PDB_TXT";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[3];
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Int32);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_MES;

                Param[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[2].Direction = ParameterDirection.Output;

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

        public DataTable Listar_registro_de_ventas(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO,
            string V_CONCEPTO, string V_LINEA_NEGOCIO, string V_ORIGEN, string V_SERIE, string V_TIPO_DOCUMENTO,
            string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_REGISTRO_DE_VENTAS";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[9];
                Param[0] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Int32);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CENTRO_OPERATIVO;

                Param[1] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_AÑO;

                Param[2] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = D_MES;

                Param[3] = new OracleParameter("V_TIPO_DOCUMENTO", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_TIPO_DOCUMENTO;

                Param[4] = new OracleParameter("V_LINEA_NEGOCIO", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_LINEA_NEGOCIO;

                Param[5] = new OracleParameter("V_ORIGEN", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_ORIGEN;

                Param[6] = new OracleParameter("V_SERIE", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = V_SERIE;

                Param[7] = new OracleParameter("V_CONCEPTO", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = V_CONCEPTO;

                Param[8] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[8].Direction = ParameterDirection.Output;

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
