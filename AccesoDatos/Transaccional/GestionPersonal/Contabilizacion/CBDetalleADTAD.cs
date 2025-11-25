using EntidadNegocio;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadNegocio.GestionPersonal;
using Utilitario;

namespace AccesoDatos.Transaccional.GestionPersonal.Contabilizacion
{
    public class CBDetalleADTAD : BaseAD
    {
        public int TanferenciaFinal(BaseBE oBaseBE)
        {
            int IdProceso = 0;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBaseBE.ToString());
                string PackagName = "INTERFACES.INSERTAASIENTOCONTABLE";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                EncabADBE oEncabAD = (EncabADBE)oBaseBE;

                OracleParameter[] Param = new OracleParameter[4];
                Param[0] = new OracleParameter("p_cod_emp", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = oEncabAD.Codemp;

                Param[1] = new OracleParameter("p_ano_asto", OracleDbType.Int64);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oEncabAD.Anoasto;

                Param[2] = new OracleParameter("p_mes_asto", OracleDbType.Int64);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oEncabAD.Mesasto;

                Param[3] = new OracleParameter("p_cb_cpto", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oEncabAD.Cbcpto;

                object id = Oracle(ORACLEVersion.O7).ExecuteNonQuery(true, PackagName, Param);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + id
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                IdProceso = 1;

                return IdProceso;
            }
            catch (OracleException oException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("AccesoDatos:DetalleADTAD:Insertar", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oException.Number.ToString()), "Código de Error:" + oException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oException.Message);
                return IdProceso;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("AccesoDatos:DetalleADTAD:Insertar", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + ex.Message.ToString()), "Código de Error:" + ex.Message.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + ex.Message.ToString());
                return IdProceso;
            }
        }
    }
}
