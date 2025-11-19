using EntidadNegocio;
using EntidadNegocio.GestionComercial;
using Log;
using Newtonsoft.Json.Linq;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.GestionComercial
{
    public class ClienteTAD : BaseAD
    {
        string sComercial = ConfigurationManager.AppSettings["E_COMERCIAL"];

        public string InsertarCliente(BaseBE oBaseBE, string accion, string sAmbiente = "T")
        {
            ClienteBE oClienteBE = (ClienteBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oClienteBE.ToString(true));
                string PackageName = sComercial + ".pkg_comercial.PR_INS_UPD_CLIENTE";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oClienteBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Params = new OracleParameter[20];
                Params[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = sAmbiente;

                Params[1] = new OracleParameter("V_TIP_CLI", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = (object)oClienteBE.TIP_CLI;

                Params[2] = new OracleParameter("V_NOM_APS", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = (object)oClienteBE.NOM_APS;

                Params[3] = new OracleParameter("V_CIIU", OracleDbType.Varchar2);
                Params[3].Direction = ParameterDirection.Input;
                Params[3].Value = (object)oClienteBE.CIIU;

                Params[4] = new OracleParameter("V_PAIS", OracleDbType.Varchar2);
                Params[4].Direction = ParameterDirection.Input;
                Params[4].Value = (object)oClienteBE.PAIS;

                Params[5] = new OracleParameter("V_DOCUM_EXT", OracleDbType.Varchar2);
                Params[5].Direction = ParameterDirection.Input;
                Params[5].Value = (object)oClienteBE.DOCUM_EXT;

                Params[6] = new OracleParameter("V_NRO_RUC", OracleDbType.Int64);
                Params[6].Direction = ParameterDirection.Input;
                Params[6].Value = (object)oClienteBE.NRO_RUC;

                Params[7] = new OracleParameter("V_COD_PRC", OracleDbType.Varchar2);
                Params[7].Direction = ParameterDirection.Input;
                Params[7].Value = (object)oClienteBE.COD_PRC;

                Params[8] = new OracleParameter("V_ENT_CLI", OracleDbType.Varchar2);
                Params[8].Direction = ParameterDirection.Input;
                Params[8].Value = (object)oClienteBE.ENT_CLI;

                Params[9] = new OracleParameter("V_UBC_GEO", OracleDbType.Varchar2);
                Params[9].Direction = ParameterDirection.Input;
                Params[9].Value = (object)oClienteBE.UBC_GEO;

                Params[10] = new OracleParameter("V_DIR_LGL", OracleDbType.Varchar2);
                Params[10].Direction = ParameterDirection.Input;
                Params[10].Value = (object)oClienteBE.DIR_LGL;

                Params[11] = new OracleParameter("V_EST_ATL", OracleDbType.Varchar2);
                Params[11].Direction = ParameterDirection.Input;
                Params[11].Value = (object)oClienteBE.EST_ATL;

                Params[12] = new OracleParameter("V_TLX1", OracleDbType.Varchar2);
                Params[12].Direction = ParameterDirection.Input;
                Params[12].Value = (object)oClienteBE.TLX1;

                Params[13] = new OracleParameter("V_TLX2", OracleDbType.Varchar2);
                Params[13].Direction = ParameterDirection.Input;
                Params[13].Value = (object)oClienteBE.TLX2;

                Params[14] = new OracleParameter("V_ACCION", OracleDbType.Varchar2);//Si es 2 actualiza registro, si es 1 genera un registro nuevo
                Params[14].Direction = ParameterDirection.Input;
                Params[14].Value = accion;

                Params[15] = new OracleParameter("X_V_CLIENTE_ID", OracleDbType.Varchar2);
                Params[15].Direction = ParameterDirection.Input;
                Params[15].Value = (object)oClienteBE.V_CLIENTE_ID;
                
                Params[16] = new OracleParameter("V_USERNAME", OracleDbType.Varchar2);
                Params[16].Direction = ParameterDirection.Input;
                Params[16].Value = (object)oClienteBE.COD_USR;

                Params[17] = new OracleParameter("X_COD_USR_INA", OracleDbType.Varchar2);
                Params[17].Direction = ParameterDirection.Input;
                Params[17].Value = (object)oClienteBE.COD_USR_INA;

                Params[18] = new OracleParameter("X_V_CLI_AUDITORIA", OracleDbType.Varchar2);
                Params[18].Direction = ParameterDirection.Input;
                Params[18].Value = (object)oClienteBE.V_CLI_AUDITORIA;
                
                Params[19] = new OracleParameter("o_cliente_id", OracleDbType.Varchar2);
                Params[19].Direction = ParameterDirection.Output;
                Params[19].Size = 25;

                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);

                if (string.IsNullOrWhiteSpace(ID))
                {
                    IDe = "0";
                }
                else
                {
                    JObject json = JObject.Parse(ID);
                    IDe = (string)json["o_cliente_id"];
                }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oClienteBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oClienteBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return "FALLO EN PROCESAMIENTO";
            }
        }

        public string InsertarContactoCliente(BaseBE oBaseBE, string opcion, string sAmbiente = "T")
        {
            ContactoClienteBE oContactoClienteBE = (ContactoClienteBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oContactoClienteBE.ToString(true));
                string PackageName = sComercial + ".pkg_comercial.PR_INS_UPD_CONTACT_CLIENTE";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oContactoClienteBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Params = new OracleParameter[12];
                Params[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = sAmbiente;

                Params[1] = new OracleParameter("p_C_CLIE_CODCARGO", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = (object)oContactoClienteBE.C_CLIE_CODCARGO;

                Params[2] = new OracleParameter("p_C_CLIE_NOMBRE", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = (object)oContactoClienteBE.C_CLIE_NOMBRE;

                Params[3] = new OracleParameter("p_C_CLIE_TELEF1", OracleDbType.Varchar2);
                Params[3].Direction = ParameterDirection.Input;
                Params[3].Value = (object)oContactoClienteBE.C_CLIE_TELEF1;

                Params[4] = new OracleParameter("p_C_CLIE_TELEF2", OracleDbType.Varchar2);
                Params[4].Direction = ParameterDirection.Input;
                Params[4].Value = (object)oContactoClienteBE.C_CLIE_TELEF2;

                Params[5] = new OracleParameter("p_C_CLIE_FECHANAC", OracleDbType.Varchar2);
                Params[5].Direction = ParameterDirection.Input;
                Params[5].Value = (object)oContactoClienteBE.C_CLIE_FECHANAC;

                Params[6] = new OracleParameter("p_C_CLIE_EMAIL", OracleDbType.Varchar2);
                Params[6].Direction = ParameterDirection.Input;
                Params[6].Value = (object)oContactoClienteBE.C_CLIE_EMAIL;

                Params[7] = new OracleParameter("p_C_CLIE_TIPOENVIO", OracleDbType.Varchar2);
                Params[7].Direction = ParameterDirection.Input;
                Params[7].Value = (object)oContactoClienteBE.C_CLIE_TIPOENVIO;

                Params[8] = new OracleParameter("p_V_CLIENTE_ID", OracleDbType.Varchar2);
                Params[8].Direction = ParameterDirection.Input;
                Params[8].Value = (object)oContactoClienteBE.V_CLIENTE_ID;

                Params[9] = new OracleParameter("p_N_CLIE_IDCONTACTO", OracleDbType.Int32);
                Params[9].Direction = ParameterDirection.Input;
                Params[9].Value = (object)oContactoClienteBE.N_CLIE_IDCONTACTO;

                Params[10] = new OracleParameter("V_OPCION", OracleDbType.Varchar2);
                Params[10].Direction = ParameterDirection.Input;
                Params[10].Value = opcion;

                Params[11] = new OracleParameter("CONFIRMACION", OracleDbType.Varchar2);
                Params[11].Direction = ParameterDirection.Output;
                Params[11].Size = 25;

                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);

                if (string.IsNullOrWhiteSpace(ID))
                {
                    IDe = "0";
                }
                else
                {
                    JObject json = JObject.Parse(ID);
                    IDe = (string)json["CONFIRMACION"];
                }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oContactoClienteBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oContactoClienteBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return "FALLO EN PROCESAMIENTO";
            }
        }

        public string InsertarEmbarcacion(BaseBE oBaseBE, string opcion, string sAmbiente = "T")
        {
            EmbarcacionBE oEmbarcacionBE = (EmbarcacionBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oEmbarcacionBE.ToString(true));
                string PackageName = sComercial + ".pkg_comercial.PR_INS_UPD_EMBARCACION";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oEmbarcacionBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Params = new OracleParameter[23];
                Params[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = sAmbiente;

                Params[1] = new OracleParameter("p_ACCION", OracleDbType.Int32);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = Convert.ToInt32(opcion);

                Params[2] = new OracleParameter("p_NOM_UND", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = oEmbarcacionBE.NOM_UND;

                Params[3] = new OracleParameter("p_TIP_UND", OracleDbType.Varchar2);
                Params[3].Direction = ParameterDirection.Input;
                Params[3].Value = oEmbarcacionBE.TIP_UND;

                Params[4] = new OracleParameter("p_EST_ATL", OracleDbType.Varchar2);
                Params[4].Direction = ParameterDirection.Input;
                Params[4].Value = oEmbarcacionBE.EST_ATL;

                Params[5] = new OracleParameter("p_COD_USR", OracleDbType.Varchar2);
                Params[5].Direction = ParameterDirection.Input;
                Params[5].Value = oEmbarcacionBE.COD_USR;

                Params[6] = new OracleParameter("p_CODCOPE", OracleDbType.Char);
                Params[6].Direction = ParameterDirection.Input;
                Params[6].Value = oEmbarcacionBE.CODCOPE;

                Params[7] = new OracleParameter("p_NOMBREANTERIOR", OracleDbType.Varchar2);
                Params[7].Direction = ParameterDirection.Input;
                Params[7].Value = oEmbarcacionBE.NOMBREANTERIOR;

                Params[8] = new OracleParameter("p_TIPO", OracleDbType.Char);
                Params[8].Direction = ParameterDirection.Input;
                Params[8].Value = oEmbarcacionBE.TIPO;

                Params[9] = new OracleParameter("p_ASTILLERO_CONSTRUCTOR", OracleDbType.Varchar2);
                Params[9].Direction = ParameterDirection.Input;
                Params[9].Value = oEmbarcacionBE.ASTILLERO_CONSTRUCTOR;

                Params[10] = new OracleParameter("p_MATRICULA", OracleDbType.Varchar2);
                Params[10].Direction = ParameterDirection.Input;
                Params[10].Value = oEmbarcacionBE.MATRICULA;

                Params[11] = new OracleParameter("p_ID_MATERIAL", OracleDbType.Int32);
                Params[11].Direction = ParameterDirection.Input;
                Params[11].Value = string.IsNullOrEmpty(oEmbarcacionBE.ID_MATERIAL) ? (object)DBNull.Value : Convert.ToInt32(oEmbarcacionBE.ID_MATERIAL);

                Params[12] = new OracleParameter("p_FEC_INGRESO", OracleDbType.Date);
                Params[12].Direction = ParameterDirection.Input;
                Params[12].Value = string.IsNullOrEmpty(oEmbarcacionBE.FEC_INGRESO) ? (object)DBNull.Value : Convert.ToDateTime(oEmbarcacionBE.FEC_INGRESO);

                Params[13] = new OracleParameter("p_OBSERVACION", OracleDbType.Varchar2);
                Params[13].Direction = ParameterDirection.Input;
                Params[13].Value = oEmbarcacionBE.OBSERVACION;

                Params[14] = new OracleParameter("p_ESLORA", OracleDbType.Decimal);
                Params[14].Direction = ParameterDirection.Input;
                Params[14].Value = string.IsNullOrEmpty(oEmbarcacionBE.ESLORA) ? (object)DBNull.Value : Convert.ToDecimal(oEmbarcacionBE.ESLORA);

                Params[15] = new OracleParameter("p_MANGA", OracleDbType.Decimal);
                Params[15].Direction = ParameterDirection.Input;
                Params[15].Value = string.IsNullOrEmpty(oEmbarcacionBE.MANGA) ? (object)DBNull.Value : Convert.ToDecimal(oEmbarcacionBE.MANGA);

                Params[16] = new OracleParameter("p_PUNTAL", OracleDbType.Decimal);
                Params[16].Direction = ParameterDirection.Input;
                Params[16].Value = string.IsNullOrEmpty(oEmbarcacionBE.PUNTAL) ? (object)DBNull.Value : Convert.ToDecimal(oEmbarcacionBE.PUNTAL);

                Params[17] = new OracleParameter("p_BODEGA", OracleDbType.Decimal);
                Params[17].Direction = ParameterDirection.Input;
                Params[17].Value = string.IsNullOrEmpty(oEmbarcacionBE.BODEGA) ? (object)DBNull.Value : Convert.ToDecimal(oEmbarcacionBE.BODEGA);

                Params[18] = new OracleParameter("p_SISTEMAPESCA", OracleDbType.Char);
                Params[18].Direction = ParameterDirection.Input;
                Params[18].Value = oEmbarcacionBE.SISTEMAPESCA;

                Params[19] = new OracleParameter("p_MOTOR", OracleDbType.Varchar2);
                Params[19].Direction = ParameterDirection.Input;
                Params[19].Value = oEmbarcacionBE.MOTOR;

                Params[20] = new OracleParameter("p_V_EMBARCACION_ID", OracleDbType.Varchar2);
                Params[20].Direction = ParameterDirection.Input;
                Params[20].Value = oEmbarcacionBE.V_EMBARCACION_ID;

                Params[21] = new OracleParameter("p_V_CLIENTE_ID", OracleDbType.Varchar2);
                Params[21].Direction = ParameterDirection.Input;
                Params[21].Value = oEmbarcacionBE.V_CLIENTE_ID;

                Params[22] = new OracleParameter("CONFIRMACION", OracleDbType.Varchar2);
                Params[22].Direction = ParameterDirection.Output;
                Params[22].Size = 25;

                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);

                if (string.IsNullOrWhiteSpace(ID))
                {
                    IDe = "0";
                }
                else
                {
                    JObject json = JObject.Parse(ID);
                    IDe = (string)json["CONFIRMACION"];
                }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oEmbarcacionBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oEmbarcacionBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return "FALLO EN PROCESAMIENTO";
            }
        }

        public string InsertarDetalleEmbarcacion(BaseBE oBaseBE, string sAmbiente = "T")
        {
            DetalleEmbarcacionBE oDetalleEmbarcacionBE = (DetalleEmbarcacionBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oDetalleEmbarcacionBE.ToString(true));
                string PackageName = sComercial + ".pkg_comercial.PR_INS_UPD_EMBARCACIONESDATOS ";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oDetalleEmbarcacionBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Params = new OracleParameter[7];
                Params[0] = new OracleParameter("P_AMBIENTE", OracleDbType.Varchar2);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = sAmbiente; // Variable string que almacena el ambiente ('T', 'P', etc.)

                Params[1] = new OracleParameter("P_V_EMBARCACION_ID", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = oDetalleEmbarcacionBE.V_EMBARCACION_ID; // Variable string con el ID de la embarcación

                Params[2] = new OracleParameter("P_N_IDAREA", OracleDbType.Int32);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = string.IsNullOrEmpty(oDetalleEmbarcacionBE.N_IDAREA) ? (object)DBNull.Value : int.Parse(oDetalleEmbarcacionBE.N_IDAREA);

                Params[3] = new OracleParameter("P_N_VALOR", OracleDbType.Decimal);
                Params[3].Direction = ParameterDirection.Input;
                Params[3].Value = string.IsNullOrEmpty(oDetalleEmbarcacionBE.N_VALOR) ? (object)DBNull.Value : decimal.Parse(oDetalleEmbarcacionBE.N_VALOR); // Convertir la cadena `nValor` a número decimal

                Params[4] = new OracleParameter("P_DA_FECHAREGISTRO", OracleDbType.Date);
                Params[4].Direction = ParameterDirection.Input;
                Params[4].Value = string.IsNullOrEmpty(oDetalleEmbarcacionBE.DA_FECHAREGISTRO) ? (object)DBNull.Value : DateTime.Parse(oDetalleEmbarcacionBE.DA_FECHAREGISTRO); // Convertir la cadena `fechaRegistro` a tipo DateTime

                Params[5] = new OracleParameter("P_C_UM", OracleDbType.Char);
                Params[5].Direction = ParameterDirection.Input;
                Params[5].Value = oDetalleEmbarcacionBE.C_UM; // Variable string con la unidad de medida (Ejemplo: 'KG', 'LT')

                Params[6] = new OracleParameter("CONFIRMACION", OracleDbType.Varchar2);
                Params[6].Direction = ParameterDirection.Output;
                Params[6].Size = 25;
                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);

                if (string.IsNullOrWhiteSpace(ID))
                {
                    IDe = "0";
                }
                else
                {
                    JObject json = JObject.Parse(ID);
                    IDe = (string)json["CONFIRMACION"];
                }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oDetalleEmbarcacionBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oDetalleEmbarcacionBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return "FALLO EN PROCESAMIENTO";
            }
        }

        public string EliminarContactoCliente(string v_cliente_id, string contacto_id, string sAmbiente = "T")
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sComercial + ".pkg_comercial.PR_DEL_CONTACT_CLIENTE";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(""
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Params = new OracleParameter[4];
                Params[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = sAmbiente;

                Params[1] = new OracleParameter("p_V_CLIENTE_ID", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = v_cliente_id;

                Params[2] = new OracleParameter("p_N_CLIE_IDCONTACTO", OracleDbType.Int32);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = contacto_id;

                Params[3] = new OracleParameter("CONFIRMACION", OracleDbType.Varchar2);
                Params[3].Direction = ParameterDirection.Output;
                Params[3].Size = 25;

                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);

                if (string.IsNullOrWhiteSpace(ID))
                {
                    IDe = "0";
                }
                else
                {
                    //Parsear el string como JSON
                    JObject json = JObject.Parse(ID);
                    IDe = (string)json["CONFIRMACION"];

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
    }
}
