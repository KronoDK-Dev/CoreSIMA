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
    public class EstadosNTAD : BaseAD
    {
        readonly string sConsulta = ConfigurationManager.AppSettings["CONSULTA"];

        public DataTable Listar_estado_finan_casillas_txt(string D_AÑO, string V_CASILLA, string V_MONTO_MINIMO,
            string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_ESTADO_FINAN_CASILLAS_TXT";

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
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Int32);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("V_CASILLA", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_CASILLA;

                Param[2] = new OracleParameter("V_MONTO_MINIMO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_MONTO_MINIMO;

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

        public DataTable Listar_mayor_auxi_cuenta_resumen(string D_AÑO, string D_MES, string V_CUENTA_DESDE,
            string V_CUENTA_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_MAYOR_AUXI_CUENTA_RESUMEN";

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
                Param[0] = new OracleParameter("V_CUENTA_DESDE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CUENTA_DESDE;

                Param[1] = new OracleParameter("V_CUENTA_HASTA", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_CUENTA_HASTA;

                Param[2] = new OracleParameter("D_AÑO", OracleDbType.Int32);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = D_AÑO;

                Param[3] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = D_MES;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_mayor_auxi_Rela_Resu(string D_AÑO, string D_MES, string V_CUENTA_DESDE,
            string V_CUENTA_HASTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_Mayor_Auxi_Rela_Resu";

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
                Param[0] = new OracleParameter("V_CUENTA_DESDE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_CUENTA_DESDE;

                Param[1] = new OracleParameter("V_CUENTA_HASTA", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_CUENTA_HASTA;

                Param[2] = new OracleParameter("D_AÑO", OracleDbType.Int32);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = D_AÑO;

                Param[3] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = D_MES;

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

        public DataTable Listar_analisis_cuentas_nat(string D_AÑO, string D_MES_DESDE, string D_MES_HASTA,
            string V_CENTRO_OPERATIVO, string V_CTA_MAYOR_DESDE, string V_CTA_MAYOR_HASTA, string V_C_COSTO_DESDE,
            string V_C_COSTO_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_ANALISIS_CUENTAS_NAT";

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
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Int32);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("D_MES_DESDE", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_MES_DESDE;

                Param[2] = new OracleParameter("D_MES_HASTA", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = D_MES_HASTA;

                Param[3] = new OracleParameter("V_CENTRO_OPERATIVO", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_CENTRO_OPERATIVO;

                Param[4] = new OracleParameter("V_CTA_MAYOR_DESDE", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_CTA_MAYOR_DESDE;

                Param[5] = new OracleParameter("V_CTA_MAYOR_HASTA", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_CTA_MAYOR_HASTA;

                Param[6] = new OracleParameter("V_C_COSTO_DESDE", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = V_C_COSTO_DESDE;

                Param[7] = new OracleParameter("V_C_COSTO_HASTA", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = V_C_COSTO_HASTA;

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

        public DataTable Listar_mayor_auxi_pend_rel_res(string D_AÑO, string D_MES, string V_CUENTA,
            string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_MAYOR_AUXI_PEND_REL_RES";

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
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Int32);
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

        public DataTable Listar_conci_bancaria_resumen(string D_AÑO, string D_MES, string V_COD_BCO,
            string V_CUENTA_CORRIENTE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_CONCI_BANCARIA_RESUMEN";

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
                Param[0] = new OracleParameter("D_AÑO", OracleDbType.Int32);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = D_AÑO;

                Param[1] = new OracleParameter("D_MES", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = D_MES;

                Param[2] = new OracleParameter("V_COD_BCO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_COD_BCO;

                Param[3] = new OracleParameter("V_CUENTA_CORRIENTE", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_CUENTA_CORRIENTE;

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_Estado_del_Proceso(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_Estado_del_Proceso";

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable Listar_Mayor_Auxiliar_Pendientes_por_Cuenta_Resumen(string V_Cuenta_Desde,
            string V_Cuenta_Hasta, string D_Año, string D_Mes, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sConsulta + ".Pkg_CONTABILIDAD.SP_MaXAuxiliar_PendCuenta_Res";

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
                Param[0] = new OracleParameter("V_Cuenta_Desde", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_Cuenta_Desde;

                Param[1] = new OracleParameter("V_Cuenta_Hasta", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_Cuenta_Hasta;

                Param[2] = new OracleParameter("D_Año", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = D_Año;

                Param[3] = new OracleParameter("D_Mes", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = D_Mes;

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
