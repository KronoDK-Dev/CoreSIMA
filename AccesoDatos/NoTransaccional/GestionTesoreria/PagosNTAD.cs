using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.NoTransaccional.GestionTesoreria
{
    public class PagosNTAD : BaseAD
    {
        readonly string sConsulta = ConfigurationManager.AppSettings["CONSULTA"];

        public DataTable Listar_cheque_giradoxnum(string V_CENTRO_OPERATIVO, string V_CHEQUE_NUMERO, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_CHEQUE_GIRADOXNUM";

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
                Param[0] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CENTRO_OPERATIVO;

                Param[1] = new OracleParameter("V_CHEQUE_NUMERO", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_CHEQUE_NUMERO;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() +
                    Helper.Cadena.CortarTextoDerecha(5,
                        Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()),
                    "Código de Error:" + oracleException.Number.ToString() +
                    Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" +
                    Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_cheques_egresos_directos(string D_AÑO, string D_MES_DESDE, string D_MES_HASTA,
            string V_CENTRO_OPERATIVO, string V_MONEDA, string V_TIPO_DE_OPERACION, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_CHEQUES_EGRESOS_DIRECTOS";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[7];
                Param[0] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CENTRO_OPERATIVO;

                Param[1] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_AÑO;

                Param[2] = new OracleParameter("D_MES_DESDE", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = D_MES_DESDE;

                Param[3] = new OracleParameter("D_MES_HASTA", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = D_MES_HASTA;

                Param[4] = new OracleParameter("V_MONEDA", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_MONEDA;

                Param[5] = new OracleParameter("V_TIPO_DE_OPERACION", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_TIPO_DE_OPERACION;

                Param[6] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[6].Direction = ParameterDirection.Output;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() +
                    Helper.Cadena.CortarTextoDerecha(5,
                        Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()),
                    "Código de Error:" + oracleException.Number.ToString() +
                    Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" +
                    Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_cheques_emitidos_resumen(string D_AÑO, string V_CENTRO_OPERATIVO, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_CHEQUES_EMITIDOS_RESUMEN";

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
                Param[0] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CENTRO_OPERATIVO;

                Param[1] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_AÑO;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() +
                    Helper.Cadena.CortarTextoDerecha(5,
                        Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()),
                    "Código de Error:" + oracleException.Number.ToString() +
                    Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" +
                    Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_cheques_giradosxprove_det(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_CHEQUES_GIRADOSXPROVE_DET";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[6];
                Param[0] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CENTRO_OPERATIVO;

                Param[1] = new OracleParameter("V_RELACION_DESDE", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_RELACION_DESDE;

                Param[2] = new OracleParameter("V_RELACION_HASTA", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_RELACION_HASTA;

                Param[3] = new OracleParameter("D_FECHA_DESDE", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = D_FECHA_DESDE;

                Param[4] = new OracleParameter("D_FECHA_HASTA", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = D_FECHA_HASTA;

                Param[5] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[5].Direction = ParameterDirection.Output;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() +
                    Helper.Cadena.CortarTextoDerecha(5,
                        Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()),
                    "Código de Error:" + oracleException.Number.ToString() +
                    Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" +
                    Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_cheques_giradosxprove_res(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO,
            string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_CHEQUES_GIRADOSXPROVE_RES";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[6];
                Param[0] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CENTRO_OPERATIVO;

                Param[1] = new OracleParameter("V_RELACION_DESDE", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_RELACION_DESDE;

                Param[2] = new OracleParameter("V_RELACION_HASTA", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_RELACION_HASTA;

                Param[3] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = D_AÑO;

                Param[4] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = D_MES;

                Param[5] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[5].Direction = ParameterDirection.Output;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() +
                    Helper.Cadena.CortarTextoDerecha(5,
                        Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()),
                    "Código de Error:" + oracleException.Number.ToString() +
                    Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" +
                    Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_cheques_por_observacion(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_OBSERVACION, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_CHEQUES_POR_OBSERVACION";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[5];
                Param[0] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CENTRO_OPERATIVO;

                Param[1] = new OracleParameter("D_FECHA_DESDE", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_FECHA_DESDE;

                Param[2] = new OracleParameter("D_FECHA_HASTA", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = D_FECHA_HASTA;

                Param[3] = new OracleParameter("V_OBSERVACION", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_OBSERVACION;

                Param[4] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[4].Direction = ParameterDirection.Output;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() +
                    Helper.Cadena.CortarTextoDerecha(5,
                        Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()),
                    "Código de Error:" + oracleException.Number.ToString() +
                    Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" +
                    Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_lote_de_detrac_por_doc(string V_CENTRO_OPERATIVO, string V_NUMERO_DE_LOTE,
            string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_LOTE_DE_DETRAC_POR_DOC";

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
                Param[0] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CENTRO_OPERATIVO;

                Param[1] = new OracleParameter("V_NUMERO_DE_LOTE", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_NUMERO_DE_LOTE;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() +
                    Helper.Cadena.CortarTextoDerecha(5,
                        Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()),
                    "Código de Error:" + oracleException.Number.ToString() +
                    Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" +
                    Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_fact_pagar_pendientes(string V_RECURSO, string V_RUC, string V_PROYECTO,
            string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_FACT_PAGAR_PENDIENTES";

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
                Param[0] = new OracleParameter("V_RECURSO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_RECURSO;

                Param[1] = new OracleParameter("V_RUC", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_RUC;

                Param[2] = new OracleParameter("V_PROYECTO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_PROYECTO;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() +
                    Helper.Cadena.CortarTextoDerecha(5,
                        Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()),
                    "Código de Error:" + oracleException.Number.ToString() +
                    Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" +
                    Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_fact_por_pagar_doc(string D_AÑO, string D_MES, string V_RELACION_DESDE,
            string V_RELACION_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_FACT_POR_PAGAR_DOC";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[5];
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_MES;

                Param[2] = new OracleParameter("V_RELACION_DESDE", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_RELACION_DESDE;

                Param[3] = new OracleParameter("V_RELACION_HASTA", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_RELACION_HASTA;

                Param[4] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[4].Direction = ParameterDirection.Output;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() +
                    Helper.Cadena.CortarTextoDerecha(5,
                        Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()),
                    "Código de Error:" + oracleException.Number.ToString() +
                    Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" +
                    Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_facturas_por_pagar_total(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_Facturas_por_Pagar_Total";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[1];
                Param[0] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[0].Direction = ParameterDirection.Output;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() +
                    Helper.Cadena.CortarTextoDerecha(5,
                        Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()),
                    "Código de Error:" + oracleException.Number.ToString() +
                    Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" +
                    Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name,
                    Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_pago_proveedores(string V_SUCURSAL, string V_RUC_INI, string V_RUC_FIN,
            string v_fecha_ini, string v_fecha_fin, string v_operacion, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_SUCURSAL, V_RUC_INI, V_RUC_FIN, v_fecha_ini, v_fecha_fin, v_operacion, UserName);
                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_Pago_proveedores";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );
                OracleParameter[] oParam = new OracleParameter[7];

                oParam[0] = new OracleParameter("V_SUCURSAL", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_SUCURSAL;

                oParam[1] = new OracleParameter("V_RUC_INI", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_RUC_INI;

                oParam[2] = new OracleParameter("V_RUC_FIN", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = V_RUC_FIN;

                oParam[3] = new OracleParameter("v_fecha_ini", OracleDbType.Varchar2);
                oParam[3].Direction = ParameterDirection.Input;
                oParam[3].Value = v_fecha_ini;

                oParam[4] = new OracleParameter("v_fecha_fin", OracleDbType.Varchar2);
                oParam[4].Direction = ParameterDirection.Input;
                oParam[4].Value = v_fecha_fin;

                oParam[5] = new OracleParameter("v_operacion", OracleDbType.Varchar2);
                oParam[5].Direction = ParameterDirection.Input;
                oParam[5].Value = v_operacion;

                oParam[6] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[6].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, oParam);
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

        public DataTable Listar_pago_Facturas(string V_SUCURSAL, string V_RUC_INI, string V_RUC_FIN, string v_fecha_ini, string v_fecha_fin,
                                              string v_operacion, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_SUCURSAL, V_RUC_INI, V_RUC_FIN, v_fecha_ini, v_fecha_fin, v_operacion, UserName);
                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_Pago_facturas";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );
                OracleParameter[] oParam = new OracleParameter[7];

                oParam[0] = new OracleParameter("V_SUCURSAL", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_SUCURSAL;

                oParam[1] = new OracleParameter("V_RUC_INI", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_RUC_INI;

                oParam[2] = new OracleParameter("V_RUC_FIN", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = V_RUC_FIN;

                oParam[3] = new OracleParameter("v_fecha_ini", OracleDbType.Varchar2);
                oParam[3].Direction = ParameterDirection.Input;
                oParam[3].Value = v_fecha_ini;

                oParam[4] = new OracleParameter("v_fecha_fin", OracleDbType.Varchar2);
                oParam[4].Direction = ParameterDirection.Input;
                oParam[4].Value = v_fecha_fin;

                oParam[5] = new OracleParameter("v_operacion", OracleDbType.Varchar2);
                oParam[5].Direction = ParameterDirection.Input;
                oParam[5].Value = v_operacion;

                oParam[6] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[6].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, oParam);
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

        public DataTable ListaLineas(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_ListaLineas";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );
                OracleParameter[] oParam = new OracleParameter[1];

                oParam[0] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[0].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, oParam);
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


        public DataTable ListaProyectosSinDep(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_ListaProyectosSinDep";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[2];

                oParam[0] = new OracleParameter("V_NOMBRE", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_NOMBRE;
                oParam[1] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[1].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, oParam);
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
