using EntidadNegocio;
using EntidadNegocio.GestionProduccion;
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

namespace AccesoDatos.Transaccional.GestionProduccion
{
    public class ActividadTAD : BaseAD, IMantenimientoTAD
    {
        readonly string sConsulta = ConfigurationManager.AppSettings["CONSULTA"];

        public int Eliminar()
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1, string Id2)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1, string Id2, string Id3)
        {
            throw new NotImplementedException();
        }

        public int Modificar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string Modifica(BaseBE oBaseBE)
        {
            ActividadBE oActividadBE = (ActividadBE)oBaseBE;
            int iRpta;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oActividadBE.ToString(true));
                string PackagName = sConsulta + ".Pkg_Produccion_trans.SP_UPD_Descrip_ATV_OT";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oActividadBE.UserName
                                                                                , oInfoMetodoBE.FullName
                                                                                , NombreMetodo
                                                                                , PackagName
                                                                                , oInfoMetodoBE.VoidParams
                                                                                , ""
                                                                                , Helper.MensajesIngresarMetodo()
                                                                                , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] oParam = new OracleParameter[9];
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = oActividadBE.ambiente;

                oParam[1] = new OracleParameter("n_cod_ot", OracleDbType.Int32);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = oActividadBE.CodigoOT;

                oParam[2] = new OracleParameter("v_cod_div", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = oActividadBE.CodigoDiv;

                oParam[3] = new OracleParameter("V_COD_ATV", OracleDbType.Varchar2);
                oParam[3].Direction = ParameterDirection.Input;
                oParam[3].Value = oActividadBE.CodigoActiv;

                oParam[4] = new OracleParameter("N_NRO_CRV", OracleDbType.Int32);
                oParam[4].Direction = ParameterDirection.Input;
                oParam[4].Value = oActividadBE.NroCrv;

                oParam[5] = new OracleParameter("V_USR_REG", OracleDbType.Varchar2);
                oParam[5].Direction = ParameterDirection.Input;
                oParam[5].Value = oActividadBE.UserReg;

                oParam[6] = new OracleParameter("V_COD_TLL", OracleDbType.Varchar2);
                oParam[6].Direction = ParameterDirection.Input;
                oParam[6].Value = oActividadBE.CodigoTll;

                oParam[7] = new OracleParameter("V_DES_DET", OracleDbType.Varchar2);
                oParam[7].Direction = ParameterDirection.Input;
                oParam[7].Value = oActividadBE.DescripcionD;

                oParam[8] = new OracleParameter("N_result", OracleDbType.Varchar2);
                oParam[8].Direction = ParameterDirection.Output;
                oParam[8].Size = 20;

                /*
                oParam[9] = new OracleParameter("V_msg", OracleDbType.Varchar2);
                oParam[9].Direction = ParameterDirection.Output;
                oParam[9].Size = 20;
                */
                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);
                // int ID = (int)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);
                // el objeto anterior ID no esta retornando valor, asi que, tomaremos el parámetro de salida

                if (ID == "0")
                {
                    IDe = (string)oParam[5].Value;
                }
                else
                {
                    // Parsear el string como JSON
                    JObject json = JObject.Parse(ID);
                    // Extraer el valor de N_result
                    IDe = (string)json["N_result"];
                    // IDe = ID;
                }

                // Extraer el valor de V_msg
                //    string s_mensaje = (string)json["V_msg"];

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oActividadBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + IDe
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return Convert.ToString(IDe);
            }
            catch (OracleException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oActividadBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oActividadBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public string Modifica_cod_atv(BaseBE oBaseBE)
        {
            ActividadBE oActividadBE = (ActividadBE)oBaseBE;

            int iRpta;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oActividadBE.ToString(true)); // pasamos toda la entidad  el metodo de control log
                string PackagName = sConsulta + ".Pkg_Produccion_trans.SP_ACTUALIZA_COD_ACTIVIDAD";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oActividadBE.UserName
                                                                                , oInfoMetodoBE.FullName
                                                                                , NombreMetodo
                                                                                , PackagName
                                                                                , oInfoMetodoBE.VoidParams
                                                                                , ""
                                                                                , Helper.MensajesIngresarMetodo()
                                                                                , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] oParam = new OracleParameter[9];
                oParam[0] = new OracleParameter("V_CEO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = oActividadBE.CodigoCEO;

                oParam[1] = new OracleParameter("V_LINEA", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = oActividadBE.CodigoDiv;

                oParam[2] = new OracleParameter("N_OT", OracleDbType.Int32);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = oActividadBE.CodigoOT;

                oParam[3] = new OracleParameter("V_ACTIVIDAD", OracleDbType.Varchar2);
                oParam[3].Direction = ParameterDirection.Input;
                oParam[3].Value = oActividadBE.CodigoActiv;

                oParam[4] = new OracleParameter("N_CORRELATIVO", OracleDbType.Int32);
                oParam[4].Direction = ParameterDirection.Input;
                oParam[4].Value = oActividadBE.NroCrv;
                //---- utilizamos esta campo de la entidad para pasar el nuevo codigo de la actividad
                oParam[5] = new OracleParameter("V_ACTIVIDAD2", OracleDbType.Varchar2);
                oParam[5].Direction = ParameterDirection.Input;
                oParam[5].Value = oActividadBE.CodigoTll;
                //---- utilizamos esta campo de la entidad para pasar el nuevo correlativo de la actividad
                oParam[6] = new OracleParameter("N_CORRELATIVO2", OracleDbType.Varchar2);
                oParam[6].Direction = ParameterDirection.Input;
                oParam[6].Value = oActividadBE.NroVal;

                oParam[7] = new OracleParameter("V_USUARIO", OracleDbType.Varchar2);
                oParam[7].Direction = ParameterDirection.Input;
                oParam[7].Value = oActividadBE.UserReg;

                oParam[8] = new OracleParameter("N_result", OracleDbType.Varchar2);
                oParam[8].Direction = ParameterDirection.Output;
                oParam[8].Size = 500;

                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);
                // int ID = (int)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);
                // el objeto anterior ID no esta retornando valor, asi que, tomaremos el parámetro de salida

                if (ID == "0")
                {
                    IDe = (string)oParam[8].Value;
                }
                else
                {
                    // Parsear el string como JSON
                    JObject json = JObject.Parse(ID);
                    // Extraer el valor de N_result
                    IDe = (string)json["N_result"];
                    // IDe = ID;
                }

                // Extraer el valor de V_msg
                //    string s_mensaje = (string)json["V_msg"];

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oActividadBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + IDe
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return Convert.ToString(IDe);
            }
            catch (OracleException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oActividadBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oActividadBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public int ModificarInsertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public int Insertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string Inserta(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }
    }
}
