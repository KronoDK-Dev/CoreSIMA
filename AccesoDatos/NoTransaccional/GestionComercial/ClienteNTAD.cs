using EntidadNegocio;
using EntidadNegocio.GestionComercial;
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

namespace AccesoDatos.NoTransaccional.GestionComercial
{
    public class ClienteNTAD : BaseAD, IMantenimientoNTAD
    {
        readonly string sComercial = ConfigurationManager.AppSettings["E_COMERCIAL"];
        readonly string sConsulta = ConfigurationManager.AppSettings["CONSULTA"];

        public DataTable ListarClientes(string N_OPCION, string V_FILTRO, string V_CEO, string V_UND_OPER,
            string UserName, string V_AMBIENTE = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sComercial + ".PKG_COMERCIAL.PR_GET_CLIENTE";

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
                Param[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_AMBIENTE;

                Param[1] = new OracleParameter("N_OPCION", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = N_OPCION;

                Param[2] = new OracleParameter("V_FILTRO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = V_FILTRO;

                Param[3] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = V_CEO;

                Param[4] = new OracleParameter("V_UND_OPER", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = V_UND_OPER;

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

        public BaseBE ListarClientePorId(string V_CLIENTE_ID, string UserName, string sAmbiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sComercial + ".PKG_COMERCIAL.PR_GET_CLIENTE_POR_ID";

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
                Param[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = sAmbiente;
                Param[1] = new OracleParameter("V_CLI_ID", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_CLIENTE_ID;
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

                ClienteBE oClienteBE = new ClienteBE();

                if (ds.Tables[0] != null)
                {
                    DataRow dr = ds.Tables[0].Rows[0];


                    oClienteBE.V_CLIENTE_ID = dr["V_CLIENTE_ID"].ToString();
                    oClienteBE.TIP_CLI = dr["TIP_CLI"].ToString();
                    oClienteBE.NOM_APS = dr["NOM_APS"].ToString();
                    oClienteBE.CIIU = dr["CIIU"].ToString();
                    oClienteBE.PAIS = dr["PAIS"].ToString();
                    oClienteBE.DOCUM_EXT = dr["Docum_Ext"].ToString();
                    oClienteBE.NRO_RUC = Convert.ToInt64(dr["NRO_RUC"]);
                    oClienteBE.COD_PRC = dr["COD_PRC"].ToString();
                    oClienteBE.ENT_CLI = dr["ENT_CLI"].ToString();
                    oClienteBE.UBC_GEO = dr["UBC_GEO"].ToString();
                    oClienteBE.DIR_LGL = dr["DIR_LGL"].ToString();
                    oClienteBE.EST_ATL = dr["EST_ATL"].ToString();
                    oClienteBE.TLX1 = dr["TLX1"].ToString();
                    oClienteBE.TLX2 = dr["TLX2"].ToString();
                    oClienteBE.COD_USR = dr["COD_USR"].ToString();
                    oClienteBE.COD_USR_INA = dr["COD_USR_INA"].ToString();
                    oClienteBE.COD_CLIENTE = dr["cod_cliente"].ToString();
                    oClienteBE.COD_CLI = Convert.ToInt32(dr["COD_CLI"]);
                    oClienteBE.FEC_RGT = Convert.ToDateTime(dr["FEC_RGT"]);
                }

                return oClienteBE;
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

        public DataSet Consultar(string CodCli, int CentroOperativo)
        {
            try
            {
                DataSet ds = new DataSet();
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, CodCli, CentroOperativo.ToString());

                string PackagName = "";
                if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaCallao))
                { PackagName = "INTERFACES.Pd_Comprobante_Venta_Pkg.Cliente"; }
                else if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaChimbote))
                { PackagName = "sp_FECCliente"; }
                else
                { PackagName = "sp_FECCliente"; }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("Facturacion Electronica"
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaCallao))
                {
                    OracleParameter[] Param = new OracleParameter[2];
                    Param[0] = new OracleParameter("p_cod_cli", OracleDbType.Varchar2);
                    Param[0].Direction = ParameterDirection.Input;
                    Param[0].Value = CodCli;

                    Param[1] = new OracleParameter("Relacion", OracleDbType.RefCursor);
                    Param[1].Direction = ParameterDirection.Output;

                    ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackagName, Param);
                }
                else if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaChimbote))
                {
                    ds = Sql(SQLVersion.sqlDBSimaCH).ExecuteDataSet(PackagName, CodCli);
                }
                else if (CentroOperativo == Convert.ToInt32(Enumerados.CentroOperativo.SimaIquitos))
                {
                    ds = Sql(SQLVersion.sqlDBSimaIQ).ExecuteDataSet(PackagName, CodCli);
                }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(""
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , ""
                    , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return ds;
            }
            catch (OracleException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("Facturacion Electronica", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("Facturacion Electronica", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable ListarContactosDeCliente(string X_V_CLIENTE_ID, string V_AMBIENTE = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sComercial + ".PKG_COMERCIAL.PR_GET_CONTACTOS_CLIENTE";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("Listar contactos de cliente"
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[3];
                Param[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_AMBIENTE;

                Param[1] = new OracleParameter("p_V_CLIENTE_ID", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = X_V_CLIENTE_ID;

                Param[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[2].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, Param);
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("Listar contactos de cliente"
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
                LogTransaccional.LanzarSIMAExcepcionDominio("Listar contactos", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("Listar contactos", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable ListarEmbarcaciones(string V_FILTRO, string V_AMBIENTE = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sComercial + ".PKG_COMERCIAL.PR_GET_EMBARCACIONES";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(""
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[3];
                Param[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_AMBIENTE;

                Param[1] = new OracleParameter("V_FILTRO", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_FILTRO;

                Param[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[2].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, Param);
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

        public BaseBE ListarEmbarcacionPorId(string V_EMBARCACION_ID, string UserName, string sAmbiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sComercial + ".PKG_COMERCIAL.PR_GET_EMBARCACION_POR_ID";

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
                Param[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = sAmbiente;
                Param[1] = new OracleParameter("V_EMBARC_ID", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = V_EMBARCACION_ID;
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

                EmbarcacionBE oEmbarcacionBE = new EmbarcacionBE();

                if (ds.Tables[0] != null)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    oEmbarcacionBE.NOM_UND = dr["NOM_UND"].ToString();
                    oEmbarcacionBE.TIP_UND = dr["TIP_UND"].ToString();
                    oEmbarcacionBE.EST_ATL = dr["EST_ATL"].ToString();
                    oEmbarcacionBE.COD_USR = dr["COD_USR"].ToString();
                    oEmbarcacionBE.FEC_USR = dr["FEC_USR"].ToString();
                    oEmbarcacionBE.CODCOPE = dr["CODCOPE"].ToString();
                    oEmbarcacionBE.NOMBREANTERIOR = dr["NOMBREANTERIOR"].ToString();
                    oEmbarcacionBE.TIPO = dr["TIPO"].ToString();
                    oEmbarcacionBE.ASTILLERO_CONSTRUCTOR = dr["ASTILLERO_CONSTRUCTOR"].ToString();
                    oEmbarcacionBE.MATRICULA = dr["MATRICULA"].ToString();
                    oEmbarcacionBE.ID_MATERIAL = dr["ID_MATERIAL"].ToString();
                    oEmbarcacionBE.FEC_INGRESO = dr["FEC_INGRESO"].ToString();
                    oEmbarcacionBE.OBSERVACION = dr["OBSERVACION"].ToString();
                    oEmbarcacionBE.ESLORA = dr["ESLORA"].ToString();
                    oEmbarcacionBE.MANGA = dr["MANGA"].ToString();
                    oEmbarcacionBE.PUNTAL = dr["PUNTAL"].ToString();
                    oEmbarcacionBE.BODEGA = dr["BODEGA"].ToString();
                    oEmbarcacionBE.SISTEMAPESCA = dr["SISTEMAPESCA"].ToString();
                    oEmbarcacionBE.MOTOR = dr["MOTOR"].ToString();
                    oEmbarcacionBE.V_EMBARCACION_ID = dr["V_EMBARCACION_ID"].ToString();
                    oEmbarcacionBE.V_CLIENTE_ID = dr["V_CLIENTE_ID"].ToString();
                    oEmbarcacionBE.CLIENTE = dr["CLIENTE"].ToString();
                    oEmbarcacionBE.COD_UND = dr["COD_UND"].ToString();
                    oEmbarcacionBE.ID_EMBARCACION = dr["ID_EMBARCACION"].ToString();

                }
                return oEmbarcacionBE;
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

        public DataTable ListarDetalleDeEmbarcacionPorID(string X_V_EMBARCACION_ID, string V_AMBIENTE = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sComercial + ".PKG_COMERCIAL.PR_GET_EMBARCACIONDATOS_POR_ID";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("Listar contactos de cliente"
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[3];
                Param[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = V_AMBIENTE;

                Param[1] = new OracleParameter("p_V_EMBARCACION_ID", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = X_V_EMBARCACION_ID;

                Param[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[2].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, Param);
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("Listar contactos de cliente"
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
                LogTransaccional.LanzarSIMAExcepcionDominio("Listar contactos", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("Listar contactos", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public string GEN_EMBARCACION_ID(string P_V_CLIENTE_ID, string V_AMBIENTE = "T")
        {

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sComercial + ".pkg_comercial.PR_GEN_EMBARCACION_ID";

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
                Params[0].Value = V_AMBIENTE;

                Params[1] = new OracleParameter("P_V_CLIENTE_ID", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = P_V_CLIENTE_ID;

                Params[2] = new OracleParameter("p_next_corr", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Output;
                Params[2].Size = 30;

                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);

                if (string.IsNullOrWhiteSpace(ID))
                {
                    IDe = "0";
                }
                else
                {
                    JObject json = JObject.Parse(ID);
                    IDe = (string)json["p_next_corr"];
                }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(""
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , ""
                    , "Return ID:" + IDe
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return IDe;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return "FALLO EN PROCESAMIENTO";
            }
        }

        public DataTable BusquedaEmbarcacionyCliente(string V_NOMBRE, string V_AMBIENTE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, V_AMBIENTE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_UnidadesYcliente";

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

                oParam[1] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = V_AMBIENTE;

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

        public DataTable listaclientesxcodxdescr(string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CODIGO.ToString(), V_DESCRIPCION, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTACLIENTESXCODXDESCR";

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

        public DataTable listaunidxcliexcodxdescr(string V_CLIENTE, string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_CLIENTE.ToString(), V_CODIGO.ToString(), V_DESCRIPCION, UserName, v_ambiente);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_LISTAUNIDXCLIEXCODXDESCR";

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
                oParam[0] = new OracleParameter("V_CLIENTE", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = V_CLIENTE;
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

        public DataTable ListaBuscarCliente2(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_BuscarCliente2";

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

        public DataTable ListaBuscarCliente3(string V_NOMBRE, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, V_NOMBRE, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_BuscarCliente3";

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
