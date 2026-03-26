using EntidadNegocio;
using EntidadNegocio.GestionComercial;
using EntidadNegocio.GestionProduccion;
using EntidadNegocio.GestionProyecto;
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
using static AccesoDatos.BaseAD;

namespace AccesoDatos.Transaccional.GestionProyecto
{
    public class ProyectoTAD : BaseAD
    {
        readonly string sComercial = ConfigurationManager.AppSettings["E_COMERCIAL"];
        string s_pto;

        public string InsertarProyecto(BaseBE oBaseBE, string opcion, string sAmbiente = "T")
        {
            EntidadNegocio.GestionComercial.ProyectoBE oProyectoBE = (EntidadNegocio.GestionComercial.ProyectoBE)oBaseBE;
            // string sComercial = ConfigurationManager.AppSettings["E_COMERCIAL"];
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oProyectoBE.ToString(true));
                string PackageName = sComercial + ".pkg_comercial.PR_INS_UPD_PROYECTO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oProyectoBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );
                OracleParameter[] Params = new OracleParameter[33];

                Params[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = sAmbiente;

                Params[1] = new OracleParameter("p_ACCION", OracleDbType.Int32);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = Convert.ToInt32(opcion);

                Params[2] = new OracleParameter("p_COD_CEO", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = oProyectoBE.COD_CEO;

                Params[3] = new OracleParameter("p_COD_PRY", OracleDbType.Varchar2);
                Params[3].Direction = ParameterDirection.Input;
                Params[3].Value = oProyectoBE.COD_PRY;

                Params[4] = new OracleParameter("p_COD_PROY_CH", OracleDbType.Varchar2);
                Params[4].Direction = ParameterDirection.Input;
                Params[4].Value = oProyectoBE.COD_PROY_CH;

                Params[5] = new OracleParameter("p_COD_DIV", OracleDbType.Varchar2);
                Params[5].Direction = ParameterDirection.Input;
                Params[5].Value = oProyectoBE.COD_DIV;

                Params[6] = new OracleParameter("p_DES_PRY", OracleDbType.Varchar2);
                Params[6].Direction = ParameterDirection.Input;
                Params[6].Value = oProyectoBE.DES_PRY;

                Params[7] = new OracleParameter("p_COD_ALM", OracleDbType.Varchar2);
                Params[7].Direction = ParameterDirection.Input;
                Params[7].Value = oProyectoBE.COD_ALM;

                Params[8] = new OracleParameter("p_EST_ATL", OracleDbType.Varchar2);
                Params[8].Direction = ParameterDirection.Input;
                Params[8].Value = oProyectoBE.EST_ATL;

                Params[9] = new OracleParameter("p_NRO_VAL_PRY", OracleDbType.Varchar2);
                Params[9].Direction = ParameterDirection.Input;
                Params[9].Value = oProyectoBE.NRO_VAL_PRY;

                Params[10] = new OracleParameter("p_USR_REG", OracleDbType.Varchar2);
                Params[10].Direction = ParameterDirection.Input;
                Params[10].Value = oProyectoBE.USR_REG;

                Params[11] = new OracleParameter("p_PRY_JDE", OracleDbType.Varchar2);
                Params[11].Direction = ParameterDirection.Input;
                Params[11].Value = oProyectoBE.PRY_JDE;

                Params[12] = new OracleParameter("p_EST_PRY", OracleDbType.Varchar2);
                Params[12].Direction = ParameterDirection.Input;
                Params[12].Value = oProyectoBE.EST_PRY;

                Params[13] = new OracleParameter("p_TIPO_PRY", OracleDbType.Int32);
                Params[13].Direction = ParameterDirection.Input;
                Params[13].Value = string.IsNullOrEmpty(oProyectoBE.TIPO_PRY) ? (object)DBNull.Value : Convert.ToInt32(oProyectoBE.TIPO_PRY);

                Params[14] = new OracleParameter("p_FECINI_PRY", OracleDbType.Date);
                Params[14].Direction = ParameterDirection.Input;
                Params[14].Value = string.IsNullOrEmpty(oProyectoBE.FECINI_PRY) ? (object)DBNull.Value : Convert.ToDateTime(oProyectoBE.FECINI_PRY);

                Params[15] = new OracleParameter("p_FECFIN_PRY", OracleDbType.Date);
                Params[15].Direction = ParameterDirection.Input;
                Params[15].Value = string.IsNullOrEmpty(oProyectoBE.FECFIN_PRY) ? (object)DBNull.Value : Convert.ToDateTime(oProyectoBE.FECFIN_PRY);

                Params[16] = new OracleParameter("p_V_PRY_UNDOPER", OracleDbType.Varchar2);
                Params[16].Direction = ParameterDirection.Input;
                Params[16].Value = oProyectoBE.V_PRY_UNDOPER;

                Params[17] = new OracleParameter("p_V_PRY_SUBLINEA", OracleDbType.Varchar2);
                Params[17].Direction = ParameterDirection.Input;
                Params[17].Value = oProyectoBE.V_PRY_SUBLINEA;

                Params[18] = new OracleParameter("p_V_CLIENTE_ID", OracleDbType.Varchar2);
                Params[18].Direction = ParameterDirection.Input;
                Params[18].Value = oProyectoBE.V_CLIENTE_ID;

                Params[19] = new OracleParameter("p_V_PRY_COD_JEFEPROY", OracleDbType.Varchar2);
                Params[19].Direction = ParameterDirection.Input;
                Params[19].Value = oProyectoBE.V_PRY_COD_JEFEPROY;

                Params[20] = new OracleParameter("p_N_PRY_MONTO_SINIMP", OracleDbType.Decimal);
                Params[20].Direction = ParameterDirection.Input;
                Params[20].Value = string.IsNullOrEmpty(oProyectoBE.N_PRY_MONTO_SINIMP) ? (object)DBNull.Value : Convert.ToDecimal(oProyectoBE.N_PRY_MONTO_SINIMP);

                Params[21] = new OracleParameter("p_V_PRY_CODMONEDA", OracleDbType.Varchar2);
                Params[21].Direction = ParameterDirection.Input;
                Params[21].Value = oProyectoBE.V_PRY_CODMONEDA;

                Params[22] = new OracleParameter("p_N_PRY_ESLORA", OracleDbType.Decimal);
                Params[22].Direction = ParameterDirection.Input;
                Params[22].Value = string.IsNullOrEmpty(oProyectoBE.N_PRY_ESLORA) ? (object)DBNull.Value : Convert.ToDecimal(oProyectoBE.N_PRY_ESLORA);

                Params[23] = new OracleParameter("p_N_PRY_MANGA", OracleDbType.Decimal);
                Params[23].Direction = ParameterDirection.Input;
                Params[23].Value = string.IsNullOrEmpty(oProyectoBE.N_PRY_MANGA) ? (object)DBNull.Value : Convert.ToDecimal(oProyectoBE.N_PRY_MANGA);

                Params[24] = new OracleParameter("p_N_PRY_PUNTAL", OracleDbType.Decimal);
                Params[24].Direction = ParameterDirection.Input;
                Params[24].Value = string.IsNullOrEmpty(oProyectoBE.N_PRY_PUNTAL) ? (object)DBNull.Value : Convert.ToDecimal(oProyectoBE.N_PRY_PUNTAL);

                Params[25] = new OracleParameter("p_N_PRY_BODEGA", OracleDbType.Decimal);
                Params[25].Direction = ParameterDirection.Input;
                Params[25].Value = string.IsNullOrEmpty(oProyectoBE.N_PRY_BODEGA) ? (object)DBNull.Value : Convert.ToDecimal(oProyectoBE.N_PRY_BODEGA);

                Params[26] = new OracleParameter("p_V_PRY_ESTACIONW", OracleDbType.Varchar2);
                Params[26].Direction = ParameterDirection.Input;
                Params[26].Value = oProyectoBE.V_PRY_ESTACIONW;

                Params[27] = new OracleParameter("p_V_PRY_AUDITORIA", OracleDbType.Varchar2);
                Params[27].Direction = ParameterDirection.Input;
                Params[27].Value = oProyectoBE.V_PRY_AUDITORIA;

                Params[28] = new OracleParameter("p_V_PRY_OBSERVACIONES", OracleDbType.Varchar2);
                Params[28].Direction = ParameterDirection.Input;
                Params[28].Value = oProyectoBE.V_PRY_OBSERVACIONES;

                Params[29] = new OracleParameter("p_V_CORREO", OracleDbType.Varchar2);
                Params[29].Direction = ParameterDirection.Input;
                Params[29].Value = oProyectoBE.CORREO;

                Params[30] = new OracleParameter("p_V_CASCO", OracleDbType.Varchar2);
                Params[30].Direction = ParameterDirection.Input;
                Params[30].Value = oProyectoBE.NROCASCO;

                Params[31] = new OracleParameter("p_V_PRY_CONVENIO", OracleDbType.Varchar2);
                Params[31].Direction = ParameterDirection.Input;
                Params[31].Value = oProyectoBE.V_PRY_Convenio;


                Params[32] = new OracleParameter("p_RESULTADO", OracleDbType.Varchar2);
                Params[32].Direction = ParameterDirection.Output;
                Params[32].Size = 25;

                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);
                // int ID = (int)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);
                // el objeto anterior ID no esta retornando valor, asi que, tomaremos el parámetro de salida

                if (string.IsNullOrWhiteSpace(ID))
                {
                    IDe = "0"; // si hay error en la captura del valor de retorno
                }
                else
                {
                    //Parsear el string como JSON
                    JObject json = JObject.Parse(ID);
                    IDe = (string)json["p_RESULTADO"]; // Extraer el valor de respuesta

                }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oProyectoBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oProyectoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return "FALLO EN PROCESAMIENTO";
            }
        }

        public string InsertarAdendaProyecto(BaseBE oBaseBE, string opcion, string sAmbiente = "T")
        {

            AdendaProyectoBE oAdendaProyectoBE = (AdendaProyectoBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oAdendaProyectoBE.ToString(true));
                string PackageName = sComercial + ".pkg_comercial.PR_INS_UPD_ADENDA";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oAdendaProyectoBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );
                OracleParameter[] Params = new OracleParameter[8];

                Params[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = sAmbiente;

                Params[1] = new OracleParameter("p_ACCION", OracleDbType.Int32);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = Convert.ToInt32(opcion);

                Params[2] = new OracleParameter("p_COD_PRY", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = oAdendaProyectoBE.V_PROYADE_CODPRY;

                Params[3] = new OracleParameter("p_ADENDA", OracleDbType.Int32);
                Params[3].Direction = ParameterDirection.Input;
                Params[3].Value = string.IsNullOrEmpty(oAdendaProyectoBE.N_PROYADE_NROADENDA) ? (object)DBNull.Value : Convert.ToInt32(oAdendaProyectoBE.N_PROYADE_NROADENDA);

                Params[4] = new OracleParameter("p_MONTO", OracleDbType.Decimal);
                Params[4].Direction = ParameterDirection.Input;
                Params[4].Value = string.IsNullOrEmpty(oAdendaProyectoBE.N_PROYADE_MONTO) ? (object)DBNull.Value : Convert.ToDecimal(oAdendaProyectoBE.N_PROYADE_MONTO);

                Params[5] = new OracleParameter("p_MONEDA", OracleDbType.Varchar2);
                Params[5].Direction = ParameterDirection.Input;
                Params[5].Value = oAdendaProyectoBE.V_PROYADE_MONEDA;

                Params[6] = new OracleParameter("p_FECINI_PRY", OracleDbType.Date);
                Params[6].Direction = ParameterDirection.Input;
                Params[6].Value = string.IsNullOrEmpty(oAdendaProyectoBE.D_PROYADE_FECHA) ? (object)DBNull.Value : Convert.ToDateTime(oAdendaProyectoBE.D_PROYADE_FECHA);

                Params[7] = new OracleParameter("p_RESULTADO", OracleDbType.Varchar2);
                Params[7].Direction = ParameterDirection.Output;
                Params[7].Size = 25;

                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);
                // int ID = (int)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);
                // el objeto anterior ID no esta retornando valor, asi que, tomaremos el parámetro de salida

                if (string.IsNullOrWhiteSpace(ID))
                {
                    IDe = "0"; // si hay error en la captura del valor de retorno
                }
                else
                {
                    //Parsear el string como JSON
                    JObject json = JObject.Parse(ID);
                    IDe = (string)json["p_RESULTADO"]; // Extraer el valor de respuesta

                }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oAdendaProyectoBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oAdendaProyectoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return "FALLO EN PROCESAMIENTO";
            }
        }
        public string DEL_ADENDAPROYECTO(string P_CODPRY, string P_NROADENDA, string UserName, string V_AMBIENTE = "T")
        {

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);
                string PackageName = sComercial + ".pkg_comercial.PR_DEL_ADENDAPROYECTO";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
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
                Params[0].Value = V_AMBIENTE;

                Params[1] = new OracleParameter("P_CODPRY", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = P_CODPRY;

                Params[2] = new OracleParameter("P_NROADENDA", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = P_NROADENDA;

                Params[3] = new OracleParameter("p_RESULTADO", OracleDbType.Varchar2);
                Params[3].Direction = ParameterDirection.Output;
                Params[3].Size = 30;

                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);
                // int ID = (int)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);
                // el objeto anterior ID no esta retornando valor, asi que, tomaremos el parámetro de salida

                if (string.IsNullOrWhiteSpace(ID))
                {
                    IDe = "0"; // si hay error en la captura del valor de retorno
                }
                else
                {
                    //Parsear el string como JSON
                    JObject json = JObject.Parse(ID);
                    IDe = (string)json["p_RESULTADO"]; // Extraer el valor de respuesta

                }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return "FALLO EN PROCESAMIENTO";
            }
        }

        public string Ins_upd_ColaboradorProy(BaseBE oBaseBE)
        {
            ColaboradorProyectoBE oBE = (ColaboradorProyectoBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;
                s_pto = "_0";
                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBE.ToString(true));
                string PackageName = sComercial + ".pkg_comercial.PR_INS_UPD_COLABORADORES_PRY";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oBE.UserName, oInfoMetodoBE.FullName, NombreMetodo, PackageName, oInfoMetodoBE.VoidParams, "", Helper.MensajesIngresarMetodo(), Convert.ToString(Enumerados.NivelesErrorLog.I)));
                s_pto = "_1";
                OracleParameter[] Params = new OracleParameter[10];


                s_pto = "_1A";
                Params[0] = new OracleParameter("N_ACCION", OracleDbType.Int32);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = Convert.ToInt32(oBE.N_ACCION);
                s_pto = "_1B";
                Params[1] = new OracleParameter("V_SUCURSAL", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.V_COLPROY_SUCURSAL) };
                s_pto = "_1C";
                Params[2] = new OracleParameter("V_PROYECTO", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.V_COLPROY_PROYECTO) };
                s_pto = "_1D";
                Params[3] = new OracleParameter("V_FEC_INGRESO", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.DT_COLPROY_INGRESO) };
                s_pto = "_1E";
                Params[4] = new OracleParameter("V_PR", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.V_COLPROY_PR) };
                s_pto = "_1F";
                Params[5] = new OracleParameter("V_CODTRA", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.V_COLPROY_CODTRA) };
                s_pto = "_1G";
                string fechaCeseStr = oBE.DT_COLPROY_CESE != null ? oBE.DT_COLPROY_CESE.ToString() : null;
                Params[6] = new OracleParameter("V_FEC_CESE", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = fechaCeseStr };
                s_pto = "_1H";
                Params[7] = new OracleParameter("V_USUARIO_AUDI", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.UserName) };
                s_pto = "_1I";
                Params[8] = new OracleParameter("V_ESTACIONW", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.Estacion) };


                s_pto = "_1J";
                Params[9] = new OracleParameter("V_RESULTADO", OracleDbType.Varchar2);
                Params[9].Direction = ParameterDirection.Output;
                Params[9].Size = 10; // Este tamaño influye en el tamaño del procedimiento almacenado

                s_pto = "_2";
                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);
                s_pto = "_3";
                string IDe = string.IsNullOrWhiteSpace(ID) ? "0" : (string)JObject.Parse(ID)["V_RESULTADO"];

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oBE.UserName, oInfoMetodoBE.FullName, NombreMetodo, PackageName, "", "Return ID: " + IDe, Helper.MensajesSalirMetodo(), Convert.ToString(Enumerados.NivelesErrorLog.I)));
                return IDe;
            }
            catch (Exception ex)
            {
                string msgError = "FALLO EN PROCESAMIENTO DAL (" + s_pto + ")";
                // LogTransaccional.LanzarSIMAExcepcionDominio(oBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                //  return "FALLO EN PROCESAMIENTO " + s_pto;
                throw new Exception(msgError + " - " + ex.Message); // Propagamos el error hacia el WebMethod
            }
        }

        public string Del_ColaboradorProy(BaseBE oBaseBE)
        {
            ColaboradorProyectoBE oBE = (ColaboradorProyectoBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBE.ToString(true));
                string PackageName = sComercial + ".pkg_comercial.PR_DEL_COLABORADORES_PRY";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oBE.UserName, oInfoMetodoBE.FullName, NombreMetodo, PackageName, oInfoMetodoBE.VoidParams, "", Helper.MensajesIngresarMetodo(), Convert.ToString(Enumerados.NivelesErrorLog.I)));

                s_pto = "0";
                OracleParameter[] Params = new OracleParameter[7];

                s_pto = "_1A";
                Params[0] = new OracleParameter("V_SUCURSAL", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.V_COLPROY_SUCURSAL) };
                s_pto = "_1B";
                Params[1] = new OracleParameter("V_PROYECTO", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.V_COLPROY_PROYECTO) };
                s_pto = "_1D";
                Params[2] = new OracleParameter("V_FEC_INGRESO", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.DT_COLPROY_INGRESO) };
                s_pto = "_1C";
                Params[3] = new OracleParameter("V_PR", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.V_COLPROY_PR) };
                s_pto = "_1E";
                Params[4] = new OracleParameter("V_USUARIO_AUDI", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.UserName) };
                s_pto = "_1F";
                Params[5] = new OracleParameter("V_ESTACIONW", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = Convert.ToString(oBE.Estacion) };

                s_pto = "_1G";
                Params[6] = new OracleParameter("V_RESULTADO", OracleDbType.Varchar2, 60) { Direction = ParameterDirection.Output };



                s_pto = "_2";
                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);
                string IDe = string.IsNullOrWhiteSpace(ID) ? "0" : (string)JObject.Parse(ID)["V_RESULTADO"];

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oBE.UserName, oInfoMetodoBE.FullName, NombreMetodo, PackageName, "", "Return ID: " + IDe, Helper.MensajesSalirMetodo(), Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return IDe;
            }
            catch (Exception ex)
            {
                string msgError = "FALLO EN PROCESAMIENTO DAL (" + s_pto + ")";
                // LogTransaccional.LanzarSIMAExcepcionDominio(oBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                //return "FALLO EN PROCESAMIENTO";
                throw new Exception(msgError + " - " + ex.Message); // Propagamos el error hacia el WebMethod
            }
        }


        public string InsertarUsuarioProyecto(string userId, string proyId, string UserName)
        {
            try
            {
                string PackageName = sComercial + ".pkg_comercial.PR_INS_USUARIO_PROYECTO";
                OracleParameter[] Params = new OracleParameter[4];

                // Parámetro 1: USERID
                Params[0] = new OracleParameter("V_USERID", OracleDbType.Varchar2);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = userId;

                // Parámetro 2: PROYID
                Params[1] = new OracleParameter("V_PROYID", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = proyId;

                // Parámetro 3: USERREG
                Params[2] = new OracleParameter("V_USERREG", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = UserName;

                // Parámetro 4: Resultado (opcional, si quieres devolver algo)
                Params[3] = new OracleParameter("V_RESULTADO", OracleDbType.Varchar2);
                Params[3].Direction = ParameterDirection.Output;
                Params[3].Size = 50;

                // Ejecutar el SP
                string result = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);

                // Si el método devuelve JSON, parsear
                if (!string.IsNullOrWhiteSpace(result))
                {
                    JObject json = JObject.Parse(result);
                    return (string)json["V_RESULTADO"];
                }


                // Si no hay salida, tomar directamente el parámetro
                return Params[3].Value?.ToString() ?? "OK";


            }
            catch (OracleException ex)
            {
                // Captura error ORA-20001 (registro duplicado)
                if (ex.Number == 20001)
                {
                    return "Registro duplicado";
                }
                return "Error: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Fallo en procesamiento: " + ex.Message;
            }
        }


        public string InsUpdDel_ProyectoPresupuesto(ProyectoPresupuestoBE oBE)
        {
            try
            {
                string PackageName = sComercial + ".PKG_COMERCIAL.PR_CRUD_PROYECTO_PRESUPUESTO";

                // 12 parámetros en total, exactamente como tu SP:
                OracleParameter[] Params = new OracleParameter[12];

               // 1) N_ACCION (1=INS, 2=UPD, 3=DEL)
                    Params[0] = new OracleParameter("N_ACCION", OracleDbType.Int32)
                    { Direction = ParameterDirection.Input, Value = oBE.N_ACCION };

                // 2) 3) PK
                Params[1] = new OracleParameter("V_CodProyecto", OracleDbType.Varchar2)
                { Direction = ParameterDirection.Input, Value = oBE.V_FTPresupuesto_CodProyecto };

                Params[2] = new OracleParameter("V_Sucursal", OracleDbType.Varchar2)
                { Direction = ParameterDirection.Input, Value = oBE.V_FTPresupuesto_Sucursal };

                // 4)–7) Costos (NUMBER(18,2))
                Params[3] = new OracleParameter("N_CostoMOB", OracleDbType.Decimal)
                { Direction = ParameterDirection.Input, Value = (object)oBE.N_FTPresupuesto_CostoMOB ?? DBNull.Value };

                Params[4] = new OracleParameter("N_CostoMAT", OracleDbType.Decimal)
                { Direction = ParameterDirection.Input, Value = (object)oBE.N_FTPresupuesto_CostoMAT ?? DBNull.Value };

                Params[5] = new OracleParameter("N_CostoSER", OracleDbType.Decimal)
                { Direction = ParameterDirection.Input, Value = (object)oBE.N_FTPresupuesto_CostoSER ?? DBNull.Value };

                Params[6] = new OracleParameter("N_CostoIND", OracleDbType.Decimal)
                { Direction = ParameterDirection.Input, Value = (object)oBE.N_FTPresupuesto_CostoIND ?? DBNull.Value };

                // 8)–10) Auditoría
                Params[7] = new OracleParameter("V_USUARIO_AUDI", OracleDbType.Varchar2)
                { Direction = ParameterDirection.Input, Value = (object)oBE.V_FTPresupuesto_USUARIO_AUDI ?? DBNull.Value };

                Params[8] = new OracleParameter("V_ESTACIONW", OracleDbType.Varchar2)
                { Direction = ParameterDirection.Input, Value = (object)oBE.V_FTPresupuesto_ESTACIONW ?? DBNull.Value };

                Params[9] = new OracleParameter("V_AUDITORIA", OracleDbType.Varchar2)
                { Direction = ParameterDirection.Input, Value = (object)oBE.V_FTPresupuesto_AUDITORIA ?? DBNull.Value };

                // 11) OUT: V_RESULTADO
                    Params[10] = new OracleParameter("V_RESULTADO", OracleDbType.Varchar2)
                    { Direction = ParameterDirection.Output, Size = 50 };

                    // 12) OUT: cRegistros (aunque no se usa en 1/2/3 debe declararse)
                    Params[11] = new OracleParameter("cRegistros", OracleDbType.RefCursor)
                    { Direction = ParameterDirection.Output };

               
                    // Ejecutar (siguiendo TU patrón: true)
                    string result = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);

                    // Si viene JSON, parsear; si no, tomar el OUT directamente
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        JObject json = JObject.Parse(result);
                        return (string)json["V_RESULTADO"];
                    }
                    return Params[10].Value?.ToString() ?? "OK";
               
                

            }
            catch (OracleException ex)
            {
                // Manejo análogo a tu patrón de InsertarUsuarioProyecto
                if (ex.Number == 20001) return "Registro duplicado";
                return "Error: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Fallo en procesamiento: " + ex.Message;
            }
        }

    }
}
