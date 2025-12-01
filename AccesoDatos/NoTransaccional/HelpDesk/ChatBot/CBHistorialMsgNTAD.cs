using EntidadNegocio;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.NoTransaccional.HelpDesk.ChatBot
{
    public class CBHistorialMsgNTAD : BaseAD, IMantenimientoNTAD
    {
        public DataTable ListarTodos()
        {
            throw new NotImplementedException();
        }

        public DataTable ListarTodos(string Id1, string UserName)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, Id1.ToString(), Id2, UserName);

                string PackagName = "SMGENERAL.PKG_WCHAT_SRV_NTAD.IDialogo";

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
                oParam[0] = new OracleParameter("FncReturn", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = "History";

                oParam[1] = new OracleParameter("IdContactOrg", OracleDbType.Int64);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = Convert.ToInt64(Id1);

                oParam[2] = new OracleParameter("IdContactDes", OracleDbType.Int64);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = Convert.ToInt64(Id2);

                oParam[3] = new OracleParameter("rstOut", OracleDbType.RefCursor);
                oParam[3].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackagName, oParam);

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

        public DataTable ListarChatContenido(string IdMsg, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, IdMsg.ToString(), UserName);
                string PackagName = "SMGENERAL.PKG_WCHAT_SRV_NTAD.IDialogo";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("FncReturn", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = "HistoryChat";

                oParam[1] = new OracleParameter("IdMsg", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = IdMsg;

                oParam[2] = new OracleParameter("rstOut", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackagName, oParam);

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

        public DataTable LstHistorialDialogoContenidoLikes(string IdMsg, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, IdMsg.ToString(), UserName);
                string PackagName = "SMGENERAL.PKG_WCHAT_SRV_NTAD.IDialogo";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("FncReturn", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = "HistoryChatLike";

                oParam[1] = new OracleParameter("IdMsg", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = IdMsg;

                oParam[2] = new OracleParameter("rstOut", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackagName, oParam);

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

        public DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName)
        {
            throw new NotImplementedException();
        }

        public DataTable Buscar(string TextFind, string UserName)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1, string UserName)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1, string Id2, string UserName)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1, string Id2, string Id3, string UserName)
        {
            throw new NotImplementedException();
        }
    }
}
