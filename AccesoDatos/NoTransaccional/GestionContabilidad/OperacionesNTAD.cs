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
    public class OperacionesNTAD : BaseAD
    {
        readonly string sConsulta = ConfigurationManager.AppSettings["CONSULTA"];

        public DataTable Listar_subdiario_por_cuenta_res(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO,
            string V_CUENTA, string V_SUBDIARIO, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_SUBDIARIO_POR_CUENTA_RES";

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
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_MES;

                Param[2] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_CENTRO_OPERATIVO;

                Param[3] = new OracleParameter("V_CUENTA", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_CUENTA;

                Param[4] = new OracleParameter("V_SUBDIARIO", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_SUBDIARIO;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_libro_caja_y_bancos_sunat(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO,
            string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_LIBRO_CAJA_Y_BANCOS_SUNAT";

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
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_MES;

                Param[2] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_CENTRO_OPERATIVO;

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

        public DataTable Listar_libro_diario_sunat(string N_CEO, string V_ANIO, string V_MES, string V_SUBDIARIOFIN,
            string V_SUBDIARIOINI, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_LIBRO_DIARIO_SUNAT";

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
                Param[0] = new OracleParameter("N_CEO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = N_CEO;

                Param[1] = new OracleParameter("V_ANIO", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_ANIO;

                Param[2] = new OracleParameter("V_MES", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_MES;

                Param[3] = new OracleParameter("V_SUBDIARIOFIN", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_SUBDIARIOFIN;

                Param[4] = new OracleParameter("V_SUBDIARIOINI", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_SUBDIARIOINI;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_libro_mayor_sunat_2digito(string N_CEO, string V_ANIO, string V_MES, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_LIBRO_MAYOR_SUNAT_2DIGITOS";

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
                Param[0] = new OracleParameter("N_CEO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = N_CEO;

                Param[1] = new OracleParameter("V_ANIO", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_ANIO;

                Param[2] = new OracleParameter("V_MES", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_MES;

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

        public DataTable Listar_pdt3500_operaciones3os_da(string N_MNTMIN, string V_ANIO, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_PDT3500_OPERACIONES3OS_DAOT";

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
                Param[0] = new OracleParameter("N_MNTMIN", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = N_MNTMIN;

                Param[1] = new OracleParameter("V_ANIO", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_ANIO;

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

        public DataTable Listar_pdt3550_detalle_operacion(string V_ANIO, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_PDT3550_DETALLE_OPERACIONES";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[2];
                Param[0] = new OracleParameter("V_ANIO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_ANIO;

                Param[1] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[1].Direction = ParameterDirection.Output;

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

        public DataTable Listar_mov_cuenta_91_92(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO,
            string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA,
            string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_MOV_CUENTA_91_92";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[8];
                Param[0] = new OracleParameter("D_FECHA_DESDE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_FECHA_DESDE;

                Param[1] = new OracleParameter("D_FECHA_HASTA", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_FECHA_HASTA;

                Param[2] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_CENTRO_OPERATIVO;

                Param[3] = new OracleParameter("V_CUENTA_DESDE", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_CUENTA_DESDE;

                Param[4] = new OracleParameter("V_CUENTA_HASTA", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_CUENTA_HASTA;

                Param[5] = new OracleParameter("V_SUBDIARIO_DESDE", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_SUBDIARIO_DESDE;

                Param[6] = new OracleParameter("V_SUBDIARIO_HASTA", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = V_SUBDIARIO_HASTA;

                Param[7] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[7].Direction = ParameterDirection.Output;

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

        public DataTable Listar_plan_cuentas_pcge_2019(string V_CTA_FIN, string V_CTA_INI, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_PLAN_CUENTAS_PCGE_2019";

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
                Param[0] = new OracleParameter("V_CTA_FIN", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CTA_FIN;

                Param[1] = new OracleParameter("V_CTA_INI", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_CTA_INI;

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

        public DataTable Listar_movimiento_cuenta_96(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE,
            string V_SUBDIARIO_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_MOVIMIENTO_CUENTA_96";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[8];
                Param[0] = new OracleParameter("D_FECHA_DESDE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_FECHA_DESDE;

                Param[1] = new OracleParameter("D_FECHA_HASTA", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_FECHA_HASTA;

                Param[2] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_CENTRO_OPERATIVO;

                Param[3] = new OracleParameter("V_CUENTA_DESDE", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_CUENTA_DESDE;

                Param[4] = new OracleParameter("V_CUENTA_HASTA", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_CUENTA_HASTA;

                Param[5] = new OracleParameter("V_SUBDIARIO_DESDE", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_SUBDIARIO_DESDE;

                Param[6] = new OracleParameter("V_SUBDIARIO_HASTA", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = V_SUBDIARIO_HASTA;

                Param[7] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[7].Direction = ParameterDirection.Output;

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

        public DataTable Listar_asientos_por_subdiario(string D_DIAFIN, string D_DIAINI, string N_CEO, string V_ANIO,
            string V_ASIENTOFIN, string V_ASIENTOINI, string V_CENTROFIN, string V_CENTROINI, string V_CUENTAFIN,
            string V_CUENTAINI, string V_MES, string V_SUBDIARIO, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_ASIENTOS_POR_SUBDIARIO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[13];
                Param[0] = new OracleParameter("D_DIAFIN", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_DIAFIN;

                Param[1] = new OracleParameter("D_DIAINI", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_DIAINI;

                Param[2] = new OracleParameter("N_CEO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = N_CEO;

                Param[3] = new OracleParameter("V_ANIO", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_ANIO;

                Param[4] = new OracleParameter("V_ASIENTOFIN", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_ASIENTOFIN;

                Param[5] = new OracleParameter("V_ASIENTOINI", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_ASIENTOINI;

                Param[6] = new OracleParameter("V_CENTROFIN", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = V_CENTROFIN;

                Param[7] = new OracleParameter("V_CENTROINI", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = V_CENTROINI;

                Param[8] = new OracleParameter("V_CUENTAFIN", OracleDbType.Varchar2);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = V_CUENTAFIN;

                Param[9] = new OracleParameter("V_CUENTAINI", OracleDbType.Varchar2);
                Param[9].Direction = ParameterDirection.Input;
                Param[9].Value = V_CUENTAINI;

                Param[10] = new OracleParameter("V_MES", OracleDbType.Varchar2);
                Param[10].Direction = ParameterDirection.Input;
                Param[10].Value = V_MES;

                Param[11] = new OracleParameter("V_SUBDIARIO", OracleDbType.Varchar2);
                Param[11].Direction = ParameterDirection.Input;
                Param[11].Value = V_SUBDIARIO;

                Param[12] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[12].Direction = ParameterDirection.Output;

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

        public DataTable Listar_mayor_auxi_pend_doc_res(string D_AÑO, string D_MES, string V_CUENTA,
            string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_MAYOR_AUXI_PEND_DOC_RES";

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
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_MES;

                Param[2] = new OracleParameter("V_CUENTA", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_CUENTA;

                Param[3] = new OracleParameter("V_RELACION_DESDE", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_RELACION_DESDE;

                Param[4] = new OracleParameter("V_RELACION_HASTA", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_RELACION_HASTA;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_mayor_auxi_doc_resu(string D_AÑO, string D_MES, string V_CUENTA_DESDE,
            string V_CUENTA_HASTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_MAYOR_AUXI_DOC_RESU";

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
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_MES;

                Param[2] = new OracleParameter("V_CUENTA_DESDE", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_CUENTA_DESDE;

                Param[3] = new OracleParameter("V_CUENTA_HASTA", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_CUENTA_HASTA;

                Param[4] = new OracleParameter("V_RELACION_DESDE", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_RELACION_DESDE;

                Param[5] = new OracleParameter("V_RELACION_HASTA", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_RELACION_HASTA;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_movimiento_cuenta_97(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE,
            string V_SUBDIARIO_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_MOVIMIENTO_CUENTA_97";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[8];
                Param[0] = new OracleParameter("D_FECHA_DESDE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_FECHA_DESDE;

                Param[1] = new OracleParameter("D_FECHA_HASTA", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_FECHA_HASTA;

                Param[2] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_CENTRO_OPERATIVO;

                Param[3] = new OracleParameter("V_CUENTA_DESDE", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_CUENTA_DESDE;

                Param[4] = new OracleParameter("V_CUENTA_HASTA", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_CUENTA_HASTA;

                Param[5] = new OracleParameter("V_SUBDIARIO_DESDE", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_SUBDIARIO_DESDE;

                Param[6] = new OracleParameter("V_SUBDIARIO_HASTA", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = V_SUBDIARIO_HASTA;

                Param[7] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[7].Direction = ParameterDirection.Output;

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

        public DataTable Listar_mayor_auxiliar_detalle(string D_AÑO, string D_MES, string V_CUENTA_DESDE,
            string V_CUENTA_HASTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_MAYOR_AUXILIAR_DETALLE";

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
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_MES;

                Param[2] = new OracleParameter("V_CUENTA_DESDE", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_CUENTA_DESDE;

                Param[3] = new OracleParameter("V_CUENTA_HASTA", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_CUENTA_HASTA;

                Param[4] = new OracleParameter("V_RELACION_DESDE", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_RELACION_DESDE;

                Param[5] = new OracleParameter("V_SUBDIARIO_DESDE", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_RELACION_HASTA;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_mayor_auxiliar_pend_deta(string D_AÑO, string D_MES, string V_CUENTA,
            string V_DOCUMENTO, string V_RELACION, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_MAYOR_AUXILIAR_PEND_DETA";

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
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_MES;

                Param[2] = new OracleParameter("V_CUENTA", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_CUENTA;

                Param[3] = new OracleParameter("V_DOCUMENTO", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_DOCUMENTO;

                Param[4] = new OracleParameter("V_RELACION", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_RELACION;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_movimiento_por_cuenta(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE,
            string V_SUBDIARIO_HASTA, string V_CC, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_MOVIMIENTO_POR_CUENTA";

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
                Param[0] = new OracleParameter("D_FECHA_DESDE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_FECHA_DESDE;

                Param[1] = new OracleParameter("D_FECHA_HASTA", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_FECHA_HASTA;

                Param[2] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_CENTRO_OPERATIVO;

                Param[3] = new OracleParameter("V_CUENTA_DESDE", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_CUENTA_DESDE;

                Param[4] = new OracleParameter("V_CUENTA_HASTA", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_CUENTA_HASTA;

                Param[5] = new OracleParameter("V_SUBDIARIO_DESDE", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_SUBDIARIO_DESDE;

                Param[6] = new OracleParameter("V_SUBDIARIO_HASTA", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = V_SUBDIARIO_HASTA;

                Param[7] = new OracleParameter("V_CC", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = V_CC;

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

        public DataTable Listar_asientos_por_subdiario_02(string D_DIAFIN, string D_DIAINI, string N_CEO, string V_ANIO,
            string V_ASIENTOFIN, string V_ASIENTOINI, string V_CENTROFIN, string V_CENTROINI, string V_CODDIV,
            string V_CUENTAFIN, string V_CUENTAINI, string V_MES, string V_NROOTS, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_ASIENTOS_POR_SUBDIARIO_020";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[14];
                Param[0] = new OracleParameter("D_DIAFIN", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_DIAFIN;

                Param[1] = new OracleParameter("D_DIAINI", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_DIAINI;

                Param[2] = new OracleParameter("N_CEO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = N_CEO;

                Param[3] = new OracleParameter("V_ANIO", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_ANIO;

                Param[4] = new OracleParameter("V_ASIENTOFIN", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_ASIENTOFIN;

                Param[5] = new OracleParameter("V_ASIENTOINI", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_ASIENTOINI;

                Param[6] = new OracleParameter("V_CENTROFIN", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = V_CENTROFIN;

                Param[7] = new OracleParameter("V_CENTROINI", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = V_CENTROINI;

                Param[8] = new OracleParameter("V_CODDIV", OracleDbType.Varchar2);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = V_CODDIV;

                Param[9] = new OracleParameter("V_CUENTAFIN", OracleDbType.Varchar2);
                Param[9].Direction = ParameterDirection.Input;
                Param[9].Value = V_CUENTAFIN;

                Param[10] = new OracleParameter("V_CUENTAINI", OracleDbType.Varchar2);
                Param[10].Direction = ParameterDirection.Input;
                Param[10].Value = V_CUENTAINI;

                Param[11] = new OracleParameter("V_MES", OracleDbType.Varchar2);
                Param[11].Direction = ParameterDirection.Input;
                Param[11].Value = V_MES;

                Param[12] = new OracleParameter("V_NROOTS", OracleDbType.Varchar2);
                Param[12].Direction = ParameterDirection.Input;
                Param[12].Value = V_NROOTS;

                Param[13] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[13].Direction = ParameterDirection.Output;

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

        public DataTable Listar_asientos_subdiario_resu_c(string D_DIAFIN, string D_DIAINI, string N_CEO, string V_ANIO,
            string V_ASIENTOFIN, string V_ASIENTOINI, string V_CENTROFIN, string V_CENTROINI, string V_CUENTAFIN,
            string V_CUENTAINI, string V_MES, string V_SUBDIARIO, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_ASIENTOS_SUBDIARIO_RESU_CC";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[13];
                Param[0] = new OracleParameter("D_DIAFIN", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_DIAFIN;

                Param[1] = new OracleParameter("D_DIAINI", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_DIAINI;

                Param[2] = new OracleParameter("N_CEO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = N_CEO;

                Param[3] = new OracleParameter("V_ANIO", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_ANIO;

                Param[4] = new OracleParameter("V_ASIENTOFIN", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_ASIENTOFIN;

                Param[5] = new OracleParameter("V_ASIENTOINI", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_ASIENTOINI;

                Param[6] = new OracleParameter("V_CENTROFIN", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = V_CENTROFIN;

                Param[7] = new OracleParameter("V_CENTROINI", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = V_CENTROINI;

                Param[8] = new OracleParameter("V_CUENTAFIN", OracleDbType.Varchar2);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = V_CUENTAFIN;

                Param[9] = new OracleParameter("V_CUENTAINI", OracleDbType.Varchar2);
                Param[9].Direction = ParameterDirection.Input;
                Param[9].Value = V_CUENTAINI;

                Param[10] = new OracleParameter("V_MES", OracleDbType.Varchar2);
                Param[10].Direction = ParameterDirection.Input;
                Param[10].Value = V_MES;

                Param[11] = new OracleParameter("V_SUBDIARIO", OracleDbType.Varchar2);
                Param[11].Direction = ParameterDirection.Input;
                Param[11].Value = V_SUBDIARIO;

                Param[12] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[12].Direction = ParameterDirection.Output;

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

        public DataTable Listar_tabulado_por_subdiarios(string V_ANIO, string V_CUENTA, string V_MES, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_TABULADO_POR_SUBDIARIOS";

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
                Param[0] = new OracleParameter("V_ANIO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_ANIO;

                Param[1] = new OracleParameter("V_CUENTA", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_CUENTA;

                Param[2] = new OracleParameter("V_MES", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_MES;

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

        public DataTable Listar_mayor_auxi_canceladas_det(string D_AÑO, string D_MES, string V_CUENTA,
            string V_DOCUMENTO, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_MAYOR_AUXI_CANCELADAS_DET";

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
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_MES;

                Param[2] = new OracleParameter("V_CUENTA", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_CUENTA;

                Param[3] = new OracleParameter("V_DOCUMENTO", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_DOCUMENTO;

                Param[4] = new OracleParameter("V_RELACION_DESDE", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_RELACION_DESDE;

                Param[5] = new OracleParameter("V_RELACION_HASTA", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_RELACION_HASTA;

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
