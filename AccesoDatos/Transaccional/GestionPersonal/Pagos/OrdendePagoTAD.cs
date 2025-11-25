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
    public class OrdendePagoTAD : BaseAD
    {
        public int Insertar(BaseBE oBaseBE)
        {
            int IdProceso = 0;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBaseBE.ToString());
                string PackagName = "INTERFACES.BC_ORDEDEPAGO_TAD.Insertar";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OrdendePagoBE oOrdendePagoBE = (OrdendePagoBE)oBaseBE;

                OracleParameter[] Param = new OracleParameter[15];

                Param[0] = new OracleParameter("CODEMP", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = oOrdendePagoBE.CodEmp;

                Param[1] = new OracleParameter("FOLRQR", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oOrdendePagoBE.Folrqr;

                Param[2] = new OracleParameter("USRSOL", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oOrdendePagoBE.UsrSol;

                Param[3] = new OracleParameter("RUTBNF", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oOrdendePagoBE.Rutbnf;

                Param[4] = new OracleParameter("BNFRQR", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oOrdendePagoBE.Bnfrqr;

                Param[5] = new OracleParameter("MNTRQR", OracleDbType.Double);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oOrdendePagoBE.Mntrqr;

                Param[6] = new OracleParameter("CODMON", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oOrdendePagoBE.Codmon;

                Param[7] = new OracleParameter("DIARQR", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = oOrdendePagoBE.Diarqr;

                Param[8] = new OracleParameter("MESRQR", OracleDbType.Varchar2);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = oOrdendePagoBE.Mesrqr;

                Param[9] = new OracleParameter("ANORQR", OracleDbType.Varchar2);
                Param[9].Direction = ParameterDirection.Input;
                Param[9].Value = oOrdendePagoBE.Anorqr;

                Param[10] = new OracleParameter("SLDPDT", OracleDbType.Double);
                Param[10].Direction = ParameterDirection.Input;
                Param[10].Value = oOrdendePagoBE.Sdpdt;

                Param[11] = new OracleParameter("OBS1", OracleDbType.Varchar2);
                Param[11].Direction = ParameterDirection.Input;
                Param[11].Value = oOrdendePagoBE.Obs1;

                Param[12] = new OracleParameter("MNTOFC_RQR", OracleDbType.Double);
                Param[12].Direction = ParameterDirection.Input;
                Param[12].Value = oOrdendePagoBE.Mntofcrqr;

                Param[13] = new OracleParameter("BCSTM_DST", OracleDbType.Varchar2);
                Param[13].Direction = ParameterDirection.Input;
                Param[13].Value = oOrdendePagoBE.Bcstmdst;

                Param[14] = new OracleParameter("TIPCMB", OracleDbType.Double);
                Param[14].Direction = ParameterDirection.Input;
                Param[14].Value = oOrdendePagoBE.Tipcmb;

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
                LogTransaccional.LanzarSIMAExcepcionDominio("AccesoDatos:OrdendePagoTAD:Insertar", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oException.Number.ToString()), "Código de Error:" + oException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oException.Message);
                return IdProceso;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("AccesoDatos:OrdendePagoTAD:Insertar", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + ex.Message.ToString()), "Código de Error:" + ex.Message.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + ex.Message.ToString());
                return IdProceso;
            }
        }
    }
}
