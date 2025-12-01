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

namespace AccesoDatos.Transaccional.Seguridad
{
    public class UsuarioTAD : BaseAD
    {
        readonly string sComercial = ConfigurationManager.AppSettings["E_COMERCIAL"];

        public int AsignarSucursal(int i_IdUsuario, int i_IdCentro, string s_UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, i_IdUsuario.ToString(), i_IdCentro.ToString(), s_UserName);
                string PackagName = "GESTIONREPORTE.InsertaCEO_Usuarios"; // CALIDAD.CALuspTADActInspeccionCambioEstado

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(s_UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                int idResult = Convert.ToInt32(Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName
                                                                                , i_IdUsuario
                                                                                , i_IdCentro
                                                                                ));

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(s_UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + idResult
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return idResult;
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(s_UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return -1;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(s_UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return -1;
            }
        }

        public string AsignarLineaUsuario(string sUserId, string sUnidado_clase, string slinea, string sSublinea, string UserName)
        {
            try
            {
                string PackageName = sComercial + ".pkg_comercial.PR_INS_ASIGNA_CEO_USUARIO";
                OracleParameter[] Params = new OracleParameter[5];

                Params[0] = new OracleParameter("V_USERID", OracleDbType.Varchar2);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = sUserId;

                Params[1] = new OracleParameter("V_UNIDADOPE", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = sUnidado_clase;

                Params[2] = new OracleParameter("V_LINEA", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = slinea;

                Params[3] = new OracleParameter("V_SUBLINEA", OracleDbType.Varchar2);
                Params[3].Direction = ParameterDirection.Input;
                Params[3].Value = sSublinea;

                Params[4] = new OracleParameter("V_RESULTADO", OracleDbType.Varchar2);
                Params[4].Direction = ParameterDirection.Output;
                Params[4].Size = 50;

                string result = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(false, PackageName, Params);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    JObject json = JObject.Parse(result);
                    return (string)json["V_RESULTADO"];
                }

                return Params[4].Value?.ToString() ?? "OK";
            }
            catch (OracleException ex)
            {
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
    }
}
