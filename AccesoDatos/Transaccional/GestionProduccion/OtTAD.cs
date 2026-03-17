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
    public class OtTAD : BaseAD, IMantenimientoTAD
    {
        readonly string sConsulta = ConfigurationManager.AppSettings["CONSULTA"];
        readonly string sComercial = ConfigurationManager.AppSettings["E_COMERCIAL"];
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
            OtBE oOtBE = (OtBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oOtBE.ToString(true)); // pasamos toda la entidad  el metodo de control log
                string PackagName = sConsulta + ".Pkg_Produccion_trans.SP_UPD_Descrip_OT";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oOtBE.UserName
                                                                                , oInfoMetodoBE.FullName
                                                                                , NombreMetodo
                                                                                , PackagName
                                                                                , oInfoMetodoBE.VoidParams
                                                                                , ""
                                                                                , Helper.MensajesIngresarMetodo()
                                                                                , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] oParam = new OracleParameter[7];
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = oOtBE.ambiente;

                oParam[1] = new OracleParameter("n_cod_ot", OracleDbType.Int32);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = oOtBE.CodigoOT;

                oParam[2] = new OracleParameter("v_cod_div", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = oOtBE.CodigoDiv;

                oParam[3] = new OracleParameter("V_DES_DET", OracleDbType.Varchar2);
                oParam[3].Direction = ParameterDirection.Input;
                oParam[3].Value = oOtBE.DescripcionD;

                oParam[4] = new OracleParameter("V_USR_REG", OracleDbType.Varchar2);
                oParam[4].Direction = ParameterDirection.Input;
                oParam[4].Value = oOtBE.UserReg;

                oParam[5] = new OracleParameter("N_result", OracleDbType.Varchar2);
                oParam[5].Direction = ParameterDirection.Output;
                oParam[5].Size = 20;

                oParam[6] = new OracleParameter("V_msg", OracleDbType.Varchar2);
                oParam[6].Direction = ParameterDirection.Output;
                oParam[6].Size = 20;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);
                // int ID = (int)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);
                // el objeto anterior ID no esta retornando valor, asi que, tomaremos el parámetro de salida
                string IDe;
                if (ID == "0")
                {
                    IDe = (string)oParam[5].Value;
                }
                else
                {
                    IDe = ID;
                }

                // Parsear el string como JSON
                JObject json = JObject.Parse(IDe);
                // Extraer el valor de N_result
                IDe = (string)json["N_result"];

                // Extraer el valor de V_msg
                string s_mensaje = (string)json["V_msg"];

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oOtBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oOtBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oOtBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
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

        public string ExcluyeOT_ReporteBI(string V_Sucursal, string V_Linea, string V_OT, string UserName)
        {
            try
            {
                // Si el SP está en paquete, usa:
                // string PackageName = sComercial + ".PKG_comercial.PR_Excluye_OT_ReporteBI";
                // Si el SP es standalone:
                string PackageName = sComercial + ".PKG_comercial.PR_Excluye_OT_ReporteBI";

                // PR_Excluye_OT_ReporteBI(
                //   V_Sucursal IN VARCHAR2,
                //   V_Linea    IN VARCHAR2,
                //   V_OT       IN VARCHAR2,
                //   V_RESULTADO OUT VARCHAR2)

                OracleParameter[] Params = new OracleParameter[4];

                // IN
                Params[0] = new OracleParameter("V_Sucursal", OracleDbType.Varchar2)
                { Direction = ParameterDirection.Input, Value = (object)V_Sucursal ?? DBNull.Value };

                Params[1] = new OracleParameter("V_Linea", OracleDbType.Varchar2)
                { Direction = ParameterDirection.Input, Value = (object)V_Linea ?? DBNull.Value };

                Params[2] = new OracleParameter("V_OT", OracleDbType.Varchar2)
                { Direction = ParameterDirection.Input, Value = (object)V_OT ?? DBNull.Value };

                // OUT
                Params[3] = new OracleParameter("V_RESULTADO", OracleDbType.Varchar2)
                { Direction = ParameterDirection.Output, Size = 50 };

                // Ejecuta según tu helper
                string result = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);

                // Si tu capa puede devolver JSON, intenta leerlo; si no, toma el OUT directamente
                if (!string.IsNullOrWhiteSpace(result))
                {
                    try
                    {
                        var json = JObject.Parse(result);
                        return (string)json["V_RESULTADO"];
                    }
                    catch
                    {
                        // No era JSON, continúa con OUT
                    }
                }

                return Params[3].Value?.ToString() ?? "0"; // "1"=actualizó, "0"=sin cambio/error
            }
            catch (OracleException ex)
            {
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
