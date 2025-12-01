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
using static AccesoDatos.BaseAD;

namespace AccesoDatos.NoTransaccional.GestionTesoreria
{
    public class CobrosNTAD : BaseAD
    {
        readonly string sConsulta = ConfigurationManager.AppSettings["CONSULTA"];

        public DataTable Listar_folios_pendientes_o7(string D_AÑO, string D_MES, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_FOLIOS_PENDIENTES_O7";

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
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
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

        public DataTable Listar_ingresos_contabilizados(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_CONCEPTO, string V_DESDE, string V_EMPRESA_DESDE,
            string V_EMPRESA_HASTA, string V_HASTA, string V_MONEDA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_INGRESOS_CONTABILIZADOS";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[10];
                Param[0] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CENTRO_OPERATIVO;

                Param[1] = new OracleParameter("D_FECHA_DESDE", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_FECHA_DESDE;

                Param[2] = new OracleParameter("D_FECHA_HASTA", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = D_FECHA_HASTA;

                Param[3] = new OracleParameter("V_MONEDA", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_MONEDA;

                Param[4] = new OracleParameter("V_DESDE", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_DESDE;

                Param[5] = new OracleParameter("V_HASTA", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_HASTA;

                Param[6] = new OracleParameter("V_CONCEPTO", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = V_CONCEPTO;

                Param[7] = new OracleParameter("V_EMPRESA_DESDE", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = V_EMPRESA_DESDE;

                Param[8] = new OracleParameter("V_EMPRESA_HASTA", OracleDbType.Varchar2);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = V_EMPRESA_HASTA;

                Param[9] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[9].Direction = ParameterDirection.Output;

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

        public DataTable Listar_ventas_x_orden_trabajo(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_NUMERO_OT,
            string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_VENTAS_X_ORDEN_TRABAJO";

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
                Param[0] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CENTRO_OPERATIVO;

                Param[1] = new OracleParameter("V_DIVISION", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_DIVISION;

                Param[2] = new OracleParameter("V_NUMERO_OT", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_NUMERO_OT;

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

        public DataTable Listar_fact_cobrar_sector_privado(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_Fact_Cobrar_Sector_Privado";

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

        public DataTable Listar_fact_cobrar_sector_marina(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_Fact_Cobrar_Sector_Marina";

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

        public DataTable Listar_Parte_de_Cobranzas(string V_Centro_Operativo, string D_Año, string D_Mes,
            string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_Parte_de_Cobranzas";

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
                Param[0].Value = V_Centro_Operativo;

                Param[1] = new OracleParameter("D_Año", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_Año;

                Param[2] = new OracleParameter("D_Mes", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = D_Mes;

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

        public DataTable Listar_Documentos_por_Cliente(string V_Centro_Operativo, string V_Cliente, string D_Año_Desde,
            string D_Año_Hasta, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_Documentos_por_Cliente";

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
                Param[0] = new OracleParameter("V_Centro_Operativo", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_Centro_Operativo;

                Param[1] = new OracleParameter("V_Cliente", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_Cliente;

                Param[2] = new OracleParameter("D_Año_Desde", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = D_Año_Desde;

                Param[3] = new OracleParameter("D_Año_Hasta", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = D_Año_Hasta;

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

        public DataTable Listar_Fact_Men_X_Linea_Neg(string V_Centro_Operativo, string D_Año, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_Fact_Men_X_Linea_Neg";

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
                Param[0] = new OracleParameter("V_Centro_Operativo", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_Centro_Operativo;

                Param[1] = new OracleParameter("D_Año", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_Año;

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

        public DataTable Listar_Orden_Trabajo_Datos_Gener(string V_Centro_Operativo, string V_Division,
            string V_Numero_OT, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_Orden_Trabajo_Datos_Gener";

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
                Param[0].Value = V_Centro_Operativo;

                Param[1] = new OracleParameter("V_Division", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_Division;

                Param[2] = new OracleParameter("V_Numero_OT", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_Numero_OT;

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

        public DataTable Listar_Anexo_Diques(string V_Centro_Operativo, string V_Division, string V_Numero_OT,
            string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_TESORERIA.SP_Orden_Trabajo_Datos_Gener";

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
                Param[0].Value = V_Centro_Operativo;

                Param[1] = new OracleParameter("V_Division", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_Division;

                Param[2] = new OracleParameter("V_Numero_OT", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_Numero_OT;

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
    }
}
