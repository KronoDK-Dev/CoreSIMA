using Log;
using Newtonsoft.Json.Linq;
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

namespace AccesoDatos.NoTransaccional.General
{
    public class InformacionGeneralNTAD : BaseAD
    {
        string sConsulta = ConfigurationManager.AppSettings["CONSULTA"];

        public InformacionGeneralNTAD(){}

        public DataTable BuscarCentrosCosto(string NombreCC, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, NombreCC.ToString(), UserName);
                string PackagName = "CONSULTA.Pkg_General.SP_SP_ListaCC_xNombre"; // CONSULTA.PKG_LOGISTICA.SP_CENTROCOSTO

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );

                string packageName = "CONSULTA.Pkg_General.SP_SP_ListaCC_xNombre";
                Dictionary<string, object> parameters = new Dictionary<string, object>();


                OracleParameter[] oParam = new OracleParameter[2];
                oParam[0] = new OracleParameter("NOMBRE_CC", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = NombreCC;
                oParam[1] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[1].Direction = ParameterDirection.Output;


                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, packageName, oParam);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , ""
                    , "rstCount:" /*ds.Tables[0].Rows.Count.ToString()*/
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I)));

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

        public DataTable BuscarCentrosCosto(string N_COD_EMP, string V_NOMBRE_CC, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, N_COD_EMP.ToString(), V_NOMBRE_CC.ToString(), UserName);
                string PackageName = sConsulta + ".Pkg_General.SP_SP_ListaCC_xCEO_Nombre";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("N_COD_EMP", OracleDbType.Int32);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = N_COD_EMP;
                oParam[1] = new OracleParameter("V_NOMBRE_CC", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_NOMBRE_CC;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable ListarCentroOperativoPorPerfil(string IdUsuario, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, IdUsuario.ToString(), UserName);
                string PackagName = "GENuspNTADListarCentroOperativoAccesoUsuario";
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, IdUsuario);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , ""
                    , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I)));

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

        #region Metodos Victor

        public DataTable listactactexcodbanco(string V_NOMBRE, string V_CODIGO, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, V_CODIGO, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTACTACTEXCODBANCO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[4];
                oParam[0] = new OracleParameter("V_NOMBRE", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_NOMBRE;
                oParam[1] = new OracleParameter("V_CODIGO", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_CODIGO;
                oParam[2] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = v_ambiente;
                oParam[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[3].Direction = ParameterDirection.Output;

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

        public DataTable listabancosxcodxdescr(string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_DESCRIPCION, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTABANCOSXCODXDESCR";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_DESCRIPCION;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = v_ambiente;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable listaproyectosxdcxausxdes(string V_CODIGO, string V_DESCRIPCION, string V_DESTINO_COMPRA, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CODIGO.ToString(), V_DESCRIPCION.ToString(), V_DESTINO_COMPRA, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAPROYECTOSXDCXAUSXDESCR";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[5];
                oParam[0] = new OracleParameter("V_DESTINO_COMPRA", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_DESTINO_COMPRA;
                oParam[1] = new OracleParameter("V_CODIGO", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_CODIGO;
                oParam[2] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = V_DESCRIPCION;
                oParam[3] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[3].Direction = ParameterDirection.Input;
                oParam[3].Value = v_ambiente;
                oParam[4] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[4].Direction = ParameterDirection.Output;

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

        public DataTable listatalleresxcodxdescr(string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_DESCRIPCION, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTATALLERESXCODXDESCR";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_DESCRIPCION;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = v_ambiente;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable listatrabxcodxdescr(string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CODIGO.ToString(), V_DESCRIPCION, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTATRABXCODXDESCR";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[4];
                oParam[0] = new OracleParameter("V_CODIGO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CODIGO;
                oParam[1] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_DESCRIPCION;
                oParam[2] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = v_ambiente;
                oParam[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[3].Direction = ParameterDirection.Output;

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

        public DataTable listacc_xceo(string N_COD_EMP, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, N_COD_EMP, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTACC_XCEO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("N_COD_EMP", OracleDbType.Int32);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = N_COD_EMP;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = v_ambiente;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable listalineas_negxceo(string V_CEO, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CEO, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTALINEAS_NEGXCEO";

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
                oParam[0] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CEO;
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

        public DataTable listalotedetraccxcodigo(string V_CODIGO, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CODIGO, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTALOTEDETRACCXCODIGO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_CODIGO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CODIGO;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = v_ambiente;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable listaliquidacionesxanio(string V_ANIO, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_ANIO, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTALIQUIDACIONESXANIO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_ANIO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_ANIO;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = v_ambiente;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable listaclasematxcodxdescrip(string V_NOMBRE, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTACLASEMATXCODXDESCRIP";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];

                oParam[0] = new OracleParameter("V_NOMBRE", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_NOMBRE;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = v_ambiente;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable listamatxcodxdescrip(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaMATxCodxDescrip";

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

        public DataTable listacotizocxcodxdescrip(string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CODIGO.ToString(), V_DESCRIPCION, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTACOTIZOCXCODXDESCRIP";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[4];
                oParam[0] = new OracleParameter("V_CODIGO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CODIGO;
                oParam[1] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_DESCRIPCION;
                oParam[2] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = v_ambiente;
                oParam[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[3].Direction = ParameterDirection.Output;

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

        public DataTable listapgamxcodxdescrip(string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CODIGO.ToString(), V_DESCRIPCION, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAPGAMXCODXDESCRIP";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[4];
                oParam[0] = new OracleParameter("V_CODIGO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CODIGO;
                oParam[1] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_DESCRIPCION;
                oParam[2] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = v_ambiente;
                oParam[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[3].Direction = ParameterDirection.Output;

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

        public DataTable listaproyectosxcodxdescri(string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CODIGO.ToString(), V_DESCRIPCION, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAPROYECTOSXCODXDESCRIP";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[4];
                oParam[0] = new OracleParameter("V_CODIGO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CODIGO;
                oParam[1] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_DESCRIPCION;
                oParam[2] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = v_ambiente;
                oParam[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[3].Direction = ParameterDirection.Output;

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

        public DataTable listatipo_servicios(string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_DESCRIPCION, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTATIPO_SERVICIOS";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_DESCRIPCION;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = v_ambiente;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable listacartolasxanioxmesxmo(string V_ANIO, string V_MES, string V_MONEDA, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_ANIO.ToString(), V_MES.ToString(), V_MONEDA, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTACARTOLASXANIOXMESXMON";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[5];
                oParam[0] = new OracleParameter("V_ANIO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_ANIO;
                oParam[1] = new OracleParameter("V_MES", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_MES;
                oParam[2] = new OracleParameter("V_MONEDA", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = V_MONEDA;
                oParam[3] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[3].Direction = ParameterDirection.Input;
                oParam[3].Value = v_ambiente;
                oParam[4] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[4].Direction = ParameterDirection.Output;

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

        public DataTable sp_listacc_xceo_nombre(string N_COD_EMP, string V_NOMBRE_CC, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, N_COD_EMP.ToString(), V_NOMBRE_CC, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_SP_LISTACC_XCEO_NOMBRE";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[4];
                oParam[0] = new OracleParameter("N_COD_EMP", OracleDbType.Int32);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = N_COD_EMP;
                oParam[1] = new OracleParameter("V_NOMBRE_CC", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_NOMBRE_CC;
                oParam[2] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = v_ambiente;
                oParam[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[3].Direction = ParameterDirection.Output;

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

        public DataTable sp_listacc_xnombre(string NOMBRE_CC, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, NOMBRE_CC, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_SP_LISTACC_XNOMBRE";

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
                oParam[0] = new OracleParameter("NOMBRE_CC", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = NOMBRE_CC;
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

        public DataTable listaprov_pdtepagoxrucxde(string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CODIGO.ToString(), V_DESCRIPCION, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAPROV_PDTEPAGOXRUCXDESC";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[4];
                oParam[0] = new OracleParameter("V_CODIGO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CODIGO;
                oParam[1] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_DESCRIPCION;
                oParam[2] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = v_ambiente;
                oParam[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[3].Direction = ParameterDirection.Output;

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

        public DataTable listaproyec_pdtepagoxdesc(string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_DESCRIPCION, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAPROYEC_PDTEPAGOXDESC";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_DESCRIPCION;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = v_ambiente;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable listacentro_opera01(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTACENTRO_OPERA01";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listacentro_costos02(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTACENTRO_COSTOS02";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listaalmacenes24(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAALMACENES24";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listatipo_stock25(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTATIPO_STOCK25";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listaprocedencia_compra26(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAPROCEDENCIA_COMPRA26";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listafin_compra27(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAFIN_COMPRA27";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listaestado_ocompra28(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAESTADO_OCOMPRA28";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listaclasif_rotacionmat29(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTACLASIF_ROTACIONMAT29";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listalineas_simaperu30(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTALINEAS_SIMAPERU30";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listatipo_ocompra31(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTATIPO_OCOMPRA31";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listadest_valesm32(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTADEST_VALESM32";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listatipo_recurso33(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTATIPO_RECURSO33";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listadecisión34(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTADECISIÓN34";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listadecision68(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaDecision68";

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

        public DataTable listaestado_registro35(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAESTADO_REGISTRO35";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listatipo_proveedor36(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTATIPO_PROVEEDOR36";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listatipo_reportot37(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTATIPO_REPORTOT37";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listaestado_ot38(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAESTADO_OT38";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listatipo_reportacti39(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTATIPO_REPORTACTI39";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listameses40(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAMESES40";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listamonedas41(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAMONEDAS41";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable listatipo_egresos42(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTATIPO_EGRESOS42";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable ListaLineas(string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaLineas";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_ambiente;
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

        public DataTable SP_ListaLineas_NegxCEO(string V_CODIGO, string UserName, string v_ambiente = "T", string V_UNI_OPE = "")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CODIGO, UserName, v_ambiente, V_UNI_OPE);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaLineas_NegxCEO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[4];
                oParam[0] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CODIGO;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = v_ambiente;
                oParam[2] = new OracleParameter("V_UNI_OPE", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = V_UNI_OPE;
                oParam[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[3].Direction = ParameterDirection.Output;


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

        public DataTable ListaUnidad_OpexCEO(string V_CODIGO, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CODIGO, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaUnidad_OpexCEO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CODIGO;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = v_ambiente;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;


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

        public DataTable ListaLineasNegxCEOxUO(string V_CEO, string V_UNDOPE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CEO, V_UNDOPE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaLineasNegxCEOxUO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CEO;
                oParam[1] = new OracleParameter("V_UNDOPE", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_UNDOPE;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;


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

        public DataTable ListaLineaxCEOxSubLinea(string V_CEO, string V_SUBLINEA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CEO, V_SUBLINEA, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaLineaxCEOxSubLinea";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                Dictionary<string, object> parameters = new Dictionary<string, object>();

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CEO;
                oParam[1] = new OracleParameter("V_SUBLINEA", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_SUBLINEA;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;


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

        public DataTable ListaSubLineasNegxCEOxUOxL(string V_CEO, string V_UNDOPE, string V_LINEA, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CEO, V_UNDOPE, V_LINEA, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaSubLineasNegxCEOxUOxL";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[4];
                oParam[0] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CEO;
                oParam[1] = new OracleParameter("V_UNDOPE", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_UNDOPE;
                oParam[2] = new OracleParameter("V_LINEA", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = V_LINEA;
                oParam[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[3].Direction = ParameterDirection.Output;


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

        public DataTable ListaSubLineasCallao(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaSubLineasCallao";

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

        public DataTable ListaUserUnisysxNom(string v_descripcion, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, v_descripcion, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaUserUnisysxNom";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];

                oParam[0] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = v_descripcion;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = v_ambiente;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable ListaContabCuentas(string V_NOMBRE, string V_PERIODO, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, V_PERIODO, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaContabCuenta";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];

                oParam[0] = new OracleParameter("V_PERIODO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_PERIODO;
                oParam[1] = new OracleParameter("V_NOMBRE", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_NOMBRE;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable ListaContabCuentaSinPeriodo(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaContabCuentaSinPeriodo";

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

        public DataTable ListaContabCuentaMayor(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaContabCuentaMayor";

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

        public DataTable ListaSubDiario(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaSubDiario";

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

        public DataTable ListaProveedores(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaProveedores";

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

        public DataTable TipoDocumento(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_TipoDocumento";

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

        public DataTable TipoPlanillaMOB(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_TipoPlanilla";

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

        public DataTable ListaAreasUsuariaxLN(string sLinea, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, sLinea, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaAreaUsuariaxLN";

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
                oParam[0] = new OracleParameter("V_LINEA", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = sLinea;
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

        public DataTable TipoConformidadPlanMOB(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_TipoConformidad";

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

        public DataTable TipoBien(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_TipoBien";

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

        public DataTable TipoOrden(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_TipoOrden";

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

        public DataTable ListaProyectosSinDep(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaProyectosSinDep";

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

        public DataTable ListaProyectosxLinea(string S_Nombre, string S_Linea, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, S_Nombre, S_Linea, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaProyectosxLinea";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];

                oParam[0] = new OracleParameter("V_NOMBRE", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = S_Nombre;
                oParam[1] = new OracleParameter("V_LINEA", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = S_Linea;

                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable ListaUnidades(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaUnidades";

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

        public DataTable ListaUnidades2(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaUnidades2";

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

        public DataTable ListaMeses50(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaMeses50";

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

        public DataTable ListaMonedaMulti(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaMonedasMulti";

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

        public DataTable BuscarRecursos35(string V_DESCRIPCION, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_DESCRIPCION, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_BuscarRecursos35";

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

                oParam[0] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_DESCRIPCION;
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

        public DataTable TipoDocumentoLt(string V_DESCRIPCION, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_DESCRIPCION, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_TipoDocumentoLt";

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

                oParam[0] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_DESCRIPCION;
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

        public DataTable OrigenLt(string V_DESCRIPCION, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_DESCRIPCION, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_OrigenLt";

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

                oParam[0] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_DESCRIPCION;
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

        public DataTable Origen(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_Origen";

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

        public DataTable ListaDoc_Estado(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaDoc_Estado";

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

        public DataTable ListaTipo_GastosDOT(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaTipo_GastosDOT";

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

        public DataTable LineasNegocioLt(string V_DESCRIPCION, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_DESCRIPCION, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaLineas_SIMAPERU30Multi";

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

                oParam[0] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_DESCRIPCION;
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

        public DataTable listalineas_simaperu30Multi(string V_DESCRIPCION, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_DESCRIPCION, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaLineas_SIMAPERU30Multi";

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

                oParam[0] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_DESCRIPCION;
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

        public DataTable Lista_CodigoCorte(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_Lista_CodigoCorte";

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

        public DataTable Listar_GrupoBienesDropdown(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_Lista_GrupoBienes";

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

        public DataTable Listar_SubGrupoBienesDropdown(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_Lista_SubGrupoBienes";

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

        public DataTable Listar_SubGrupoBienesT(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_Lista_SubGrupoBienesT";

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

        public DataTable Listar_EmbarquePorOC(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_Lista_EmbarquePorOC";

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

        public DataTable Listar_TipoMOB(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_Lista_TipoMOB";

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

        public DataTable Listar_UsuariosPorNombre(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_Lista_UsuariosPorNombre";

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

        public DataTable Listar_CodigoOT(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_Lista_CodigoOT";

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

        public DataTable Listar_NumeroVDE(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_Lista_NumeroVDE";

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

        public DataTable Listar_NumeroGuiaPorOC(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_Lista_NumeroGuia";

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

        public DataTable Listar_ESTADO_VDE(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_Lista_ESTADO_VDE";

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

        public DataTable Listar_TipoCentroCosto(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_TipoCentroCosto";

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

        public DataTable ListaTipo_Trabajo(string UserName, string sAmbiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, sAmbiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaTipo_Trabajo";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = sAmbiente;
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

        public DataTable ListaEstado_SolTrabxCEO(string V_CEO, string UserName, string sAmbiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CEO, UserName, sAmbiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaEstado_SolTrabxCEO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CEO;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = sAmbiente;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable ListaTipo_SolTrab(string UserName, string sAmbiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, sAmbiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.sp_ListaTipo_SolTrab";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = sAmbiente;
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

        public DataTable ListaClase_Trabajo(string UserName, string sAmbiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, sAmbiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaClase_Trabajo";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = sAmbiente;
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

        public DataTable ListaDiques(string V_CEO, string UserName, string sAmbiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CEO, UserName, sAmbiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaDiques";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CEO;
                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = sAmbiente;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable ListaTipo_TarifaDique(string UserName, string sAmbiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName, sAmbiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaTipo_TarifaDique";

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
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = sAmbiente;
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

        public DataTable ListaSubLinea_Trabajo(string s_SubCEO, string s_LineaTrab, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, s_SubCEO, s_LineaTrab, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaSubLinea_Trabajo";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("c_subCEO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = s_SubCEO;
                oParam[1] = new OracleParameter("c_linea", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = s_LineaTrab;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable Lista_AreaUsuariaxLNxCLS(string V_LINEA, string V_ClaseT, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_LINEA, V_ClaseT, UserName);
                string PackageName = "UNISYS_V2.PKG_GENERAL.PR_Lista_AreaUsuariaxLNxCLS";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                Dictionary<string, object> parameters = new Dictionary<string, object>();

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_LINEA", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_LINEA;
                oParam[1] = new OracleParameter("V_ClaseT", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_ClaseT;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable Lista_SG_ELE_TAB(string V_TAB, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_TAB, UserName);
                string PackageName = "UNISYS_V2.PKG_GENERAL.PR_LISTA_SG_ELE_TAB";

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
                oParam[0] = new OracleParameter("V_TAB", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_TAB;
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

        public DataTable Lista_PAIS_DPT_PROV_DIST(string V_OPCION, string V_VAR, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_OPCION, V_VAR, UserName);
                string PackageName = "UNISYS_V2.PKG_GENERAL.PR_LST_PAIS_DPT_PROV_DIST";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_OPCION", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_OPCION;
                oParam[1] = new OracleParameter("V_VAR", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_VAR;
                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

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

        public DataTable Lista_get_tabgeneral(string N_TAB, string C_ESTA, string UserName, string sAmbiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, N_TAB, C_ESTA, UserName, sAmbiente);
                string PackageName = "UNISYS_V2.PKG_GENERAL.PR_GET_TABGENERAL";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[4];
                oParam[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = sAmbiente;
                oParam[1] = new OracleParameter("N_TAB", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = N_TAB;
                oParam[2] = new OracleParameter("C_ESTA", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = C_ESTA;
                oParam[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[3].Direction = ParameterDirection.Output;

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

        public DataTable Lista_get_ciiu(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = "UNISYS_V2.PKG_GENERAL.PR_GET_CIIU";

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

        public string LISTA_DESCRIP_ERRORES(string c_errores, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, c_errores, UserName);
                string PackageName = "UNISYS_V2.PKG_GENERAL.PR_LISTA_DESCRIP_ERRORES";

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

                oParam[0] = new OracleParameter("v_variable", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = c_errores;

                oParam[1] = new OracleParameter("v_resultado", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Output;
                oParam[1].Size = 4000;
                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, oParam);

                if (string.IsNullOrWhiteSpace(ID))
                {
                    IDe = "0"; 
                }
                else
                {
                    
                    JObject json = JObject.Parse(ID);
                    IDe = (string)json["v_resultado"];

                }
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                            , oInfoMetodoBE.FullName
                                                                            , NombreMetodo
                                                                            , PackageName
                                                                            , ""
                                                                            , "Return ID:" + IDe
                                                                            , Helper.MensajesSalirMetodo()
                                                                            , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                        );

                return IDe;
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

        public string GetCodUbigeoByDesc(string ubigeo_desc, string sAmbiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, ubigeo_desc, sAmbiente);
                string PackageName = "UNISYS_V2.PKG_GENERAL.PR_GET_COD_UBIGEO_BY_DESC";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(""
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Params = new OracleParameter[3];

                Params[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = sAmbiente;

                Params[1] = new OracleParameter("V_UBIGEO_DESC", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = ubigeo_desc;

                Params[2] = new OracleParameter("V_COD_UBC", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Output;
                Params[2].Size = 25;

                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);
                // int ID = (int)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);
                // el objeto anterior ID no esta retornando valor, asi que, tomaremos el parámetro de salida

                if (string.IsNullOrWhiteSpace(ID))
                {
                    ID = "0"; // si hay error en la captura del valor de retorno
                }
                else
                {
                    //Parsear el string como JSON
                    JObject json = JObject.Parse(ID);
                    ID = (string)json["V_COD_UBC"]; // Extraer el valor de respuesta

                }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(""
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , ""
                    , "Return cod ubigeo:" + ID
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return ID;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return "FALLO EN PROCESAMIENTO";
            }
        }

        public DataTable listaTipoProyecto(string V_CEO, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CEO, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaTipoProyecto";

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

                oParam[0] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CEO;
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

        public DataTable Lista_ColumnasExcel(string V_PROCEDIMIENTO)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_PROCEDIMIENTO);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaColumnasExcel";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(""
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Params = new OracleParameter[2];

                Params[0] = new OracleParameter("V_Procedimiento", OracleDbType.Varchar2);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = V_PROCEDIMIENTO;

                Params[1] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Params[1].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, Params);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(""
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
                LogTransaccional.LanzarSIMAExcepcionDominio("", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable TipoImpresora(string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_TipoImpresora";

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

        public DataTable ListaOperaciones_Lst(string V_DESCRIPCION, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_DESCRIPCION, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaOperaciones_Lst";

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

                oParam[0] = new OracleParameter("V_DESCRIPCION", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_DESCRIPCION;
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

        public DataTable Listar_Reg_TabGeneral(string V_COD_TABLA, string V_ESTADO, string V_ORDEN, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_COD_TABLA.ToString(), V_ESTADO.ToString(), V_ORDEN.ToString(), UserName);
                string PackagName = sConsulta + ".Pkg_General.SP_Lista_Registros_Gen";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] oParam = new OracleParameter[4];
                oParam[0] = new OracleParameter("V_COD_TABLA", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_COD_TABLA;
                oParam[1] = new OracleParameter("V_ESTADO", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_ESTADO;
                oParam[2] = new OracleParameter("V_ORDEN", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = V_ORDEN;

                oParam[3] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[3].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackagName, oParam);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
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

        #endregion
    }
}
