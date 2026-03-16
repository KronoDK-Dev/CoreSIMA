using EntidadNegocio;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;
using static AccesoDatos.BaseAD;

namespace AccesoDatos.NoTransaccional.GestionComercial
{ 
    public class SolicitudNTAD : BaseAD, IMantenimientoNTAD
    {
        string sComercial = ConfigurationManager.AppSettings["E_COMERCIAL"];

        public DataTable DetalleSolicitud(string V_AMBIENTE, string V_CEO, string V_ID_SOLICITUD, string V_COD_DIV, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sComercial + ".PKG_COMERCIAL.PR_GET_DET_SOLICITUD";

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
                Param[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_AMBIENTE;

                Param[1] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_CEO;

                Param[2] = new OracleParameter("V_ID_SOLICITUD", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_ID_SOLICITUD;

                Param[3] = new OracleParameter("V_COD_DIV", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_COD_DIV;

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

        public DataTable DetalleSolicitud2(string V_AMBIENTE, string V_CEO, string V_ID_SOLICITUD, string V_COD_DIV, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sComercial + ".PKG_COMERCIAL.PR_GET_DET_SOLICITUD_2";

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
                Param[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_AMBIENTE;

                Param[1] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_CEO;

                Param[2] = new OracleParameter("V_ID_SOLICITUD", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_ID_SOLICITUD;

                Param[3] = new OracleParameter("V_COD_DIV", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_COD_DIV;

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

        public DataTable ListarSolicitudTrabajo(string V_AMBIENTE, string V_FILTRO, string V_CEO, string V_UND_OPER, string V_FEC_STR_INI,    string V_FEC_STR_FIN, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sComercial + ".PKG_COMERCIAL.PR_GET_SOLICITUD";

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
                Param[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_AMBIENTE;

                Param[1] = new OracleParameter("V_FILTRO", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.InputOutput;
                Param[1].Value = V_FILTRO;

                Param[2] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.InputOutput;
                Param[2].Value = V_CEO;

                Param[3] = new OracleParameter("V_UND_OPER", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.InputOutput;
                Param[3].Value = V_UND_OPER;

                Param[4] = new OracleParameter("V_FEC_STR_INI", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_FEC_STR_INI;

                Param[5] = new OracleParameter("V_FEC_STR_FIN", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = V_FEC_STR_FIN;

                Param[6] = new OracleParameter("V_USUARIO", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = UserName;


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

        public DataTable ListarSolicitudTrabajo_SQL(string V_AMBIENTE, string V_FILTRO, string V_CEO, string V_UND_OPER, string V_FEC_STR_INI, string V_FEC_STR_FIN, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_AMBIENTE, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN,UserName);
                string PackagName = "UNISYS.PR_GET_SOLICITUD";
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, V_AMBIENTE, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);

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

        public List<Dictionary<string, object>> ListarSolicitudTrabajo_JSON(string V_AMBIENTE,string V_FILTRO,string V_CEO, string V_UND_OPER, string V_FEC_STR_INI, string V_FEC_STR_FIN,  string UserName)
            {
                try
                {
                    var empty = new List<Dictionary<string, object>>(0);

                    // ====== Trazas
                    StackTrace stack = new StackTrace();
                    string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                    InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(
                        NombreMetodo, V_AMBIENTE, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);

                    string PackagName = "UNISYS.PR_GET_SOLICITUD";

                    LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(
                        UserName,
                        oInfoMetodoBE.FullName,
                        NombreMetodo,
                        PackagName,
                        oInfoMetodoBE.VoidParams,
                        "",
                        Helper.MensajesIngresarMetodo(),
                        Convert.ToString(Enumerados.NivelesErrorLog.I)
                    ));

                    // ====== Ejecución del SP
                    DataSet ds = Sql(SQLVersion.sqlSIMANET)
                        .ExecuteDataSet(PackagName, V_AMBIENTE, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);

                    int irows = (ds != null && ds.Tables != null && ds.Tables.Count > 0) ? ds.Tables[0].Rows.Count : 0;

                    LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(
                        UserName,
                        oInfoMetodoBE.FullName,
                        NombreMetodo,
                        PackagName,
                        "",
                        "rstCount:" + irows.ToString(CultureInfo.InvariantCulture),
                        Helper.MensajesSalirMetodo(),
                        Convert.ToString(Enumerados.NivelesErrorLog.I)
                    ));

                    if (ds == null || ds.Tables.Count == 0)
                        return empty;

                    // ====== Transformación DataTable -> List<Dictionary<string,object>>
                    var dt = ds.Tables[0];
                    var list = new List<Dictionary<string, object>>(dt.Rows.Count);

                    foreach (DataRow row in dt.Rows)
                    {
                        var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

                        foreach (DataColumn c in dt.Columns)
                        {
                            object val = row[c] == DBNull.Value ? null : row[c];

                            // Normaliza DateTime a ISO 8601, mismo patrón que tu ejemplo
                            if (val is DateTime dtVal)
                            {
                                // Si deseas mantener zona local, puedes quitar la 'Z'.
                                val = dtVal.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
                            }

                            dict[c.ColumnName] = val;
                        }

                        list.Add(dict);
                    }

                    return list;
                }
                catch (SqlException sqlEx)
                {
                    LogTransaccional.LanzarSIMAExcepcionDominio(
                        UserName,
                        this.GetType().Name,
                        Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                        Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString()
                            + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + sqlEx.Number.ToString(CultureInfo.InvariantCulture)),
                        "Código de Error:" + sqlEx.Number.ToString(CultureInfo.InvariantCulture)
                            + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1"
                            + Utilitario.Constante.Caracteres.SeperadorSimple + sqlEx.Message
                    );
                    return null;
                }
                catch (Exception ex)
                {
                    LogTransaccional.LanzarSIMAExcepcionDominio(
                        UserName,
                        this.GetType().Name,
                        Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                        Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(),
                        ex.Message
                    );
                    return null;
                }
            }
    public DataTable Lista_Lineas_Usuario(string s_USUARIO, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sComercial + ".PKG_COMERCIAL.PR_GET_LINEAS_POR_USUARIO";

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
                Param[0] = new OracleParameter("V_USUARIO", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = s_USUARIO;

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
            throw new NotImplementedException();
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
