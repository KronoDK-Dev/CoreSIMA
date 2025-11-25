using EntidadNegocio;
using EntidadNegocio.GestionPersonal;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.GestionPersonal.Pagos
{
    public class OrdendePagoCtaCtableTAD : BaseAD
    {
        public int Insertar(BaseBE oBaseBE)
        {
            int IdProceso = 0;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBaseBE.ToString());
                string PackagName = "INTERFACES.BC_ORDEDEPAGO_TAD.InsertarCtaCtable";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OrdendePagoCtactableBE oOrdendePagoCtactableBE = (OrdendePagoCtactableBE)oBaseBE;

                OracleParameter[] Param = new OracleParameter[13];
                Param[0] = new OracleParameter("CODEMP", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = oOrdendePagoCtactableBE.Codemp;

                Param[1] = new OracleParameter("FOLCHQ", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oOrdendePagoCtactableBE.Folchq;

                Param[2] = new OracleParameter("ITMCNL_CHQ", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oOrdendePagoCtactableBE.Itmcnlchq;

                Param[3] = new OracleParameter("PCUENTA", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oOrdendePagoCtactableBE.Cuenta;

                Param[4] = new OracleParameter("NRODOC_ANA", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oOrdendePagoCtactableBE.Nrodocana;

                Param[5] = new OracleParameter("PDIST", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oOrdendePagoCtactableBE.Dist;

                Param[6] = new OracleParameter("PDES", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oOrdendePagoCtactableBE.Des;

                Param[7] = new OracleParameter("INDD_H", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = oOrdendePagoCtactableBE.Inddh;

                Param[8] = new OracleParameter("VALMOV", OracleDbType.Double);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = oOrdendePagoCtactableBE.Valmov;

                Param[9] = new OracleParameter("PCC", OracleDbType.Varchar2);
                Param[9].Direction = ParameterDirection.Input;
                Param[9].Value = oOrdendePagoCtactableBE.Cc;

                Param[10] = new OracleParameter("VAL_MEX", OracleDbType.Double);
                Param[10].Direction = ParameterDirection.Input;
                Param[10].Value = oOrdendePagoCtactableBE.Valmex;

                Param[11] = new OracleParameter("TIPCMB", OracleDbType.Double);
                Param[11].Direction = ParameterDirection.Input;
                Param[11].Value = oOrdendePagoCtactableBE.Tipcmb;

                Param[12] = new OracleParameter("VALORG", OracleDbType.Double);
                Param[12].Direction = ParameterDirection.Input;
                Param[12].Value = oOrdendePagoCtactableBE.Valorg;

                object id = Oracle(ORACLEVersion.O7).ExecuteScalar(true, PackagName, Param);

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
                LogTransaccional.LanzarSIMAExcepcionDominio("AccesoDatos:OrdendePagoCtaCtableTAD:Insertar", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oException.Number.ToString()), "Código de Error:" + oException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oException.Message);
                return IdProceso;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("AccesoDatos:OrdendePagoCtaCtableTAD:Insertar", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + ex.Message.ToString()), "Código de Error:" + ex.Message.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + ex.Message.ToString());
                return IdProceso;
            }
        }

        public int InsertaTablaFinal()
        {
            int IdProceso = 0;
            try
            { 
                object id = Oracle(ORACLEVersion.O7).ExecuteScalar(true, "INTERFACES.InsertaRequerimientoPago");

                IdProceso = 1;
                return IdProceso;
            }
            catch (OracleException oException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("AccesoDatos:OrdendePagoCtaCtableTAD:InsertaTablaFinal", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oException.Number.ToString()), "Código de Error:" + oException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oException.Message);
                return IdProceso;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("AccesoDatos:OrdendePagoCtaCtableTAD:InsertaTablaFinal", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + ex.Message.ToString()), "Código de Error:" + ex.Message.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + ex.Message.ToString());
                return IdProceso;
            }
        }
    }
}
