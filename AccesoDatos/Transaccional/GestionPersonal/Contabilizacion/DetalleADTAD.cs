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
    public class DetalleADTAD : BaseAD
    {
        public int Insertar(BaseBE oBaseBE)
        {
            int IdProceso = 0;
            try
            {

                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBaseBE.ToString());
                string PackagName = "INTERFACES.PR_PERSONAL_TAD.InsDetalleAD";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));



                DetalleADBE oDetalleADBE = (DetalleADBE)oBaseBE;

                OracleParameter[] Param = new OracleParameter[22];
                Param[0] = new OracleParameter("CODEMP", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = oDetalleADBE.Codemp;

                Param[1] = new OracleParameter("CODSUC", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oDetalleADBE.Codsuc;

                Param[2] = new OracleParameter("NUMASTO", OracleDbType.Int64);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oDetalleADBE.Numasto;

                Param[3] = new OracleParameter("NUMITEM_MOV", OracleDbType.Int64);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oDetalleADBE.Numitem_mov;

                Param[4] = new OracleParameter("DIAASTO", OracleDbType.Int64);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oDetalleADBE.Diaasto;

                Param[5] = new OracleParameter("MESASTO", OracleDbType.Int64);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oDetalleADBE.Mesasto;

                Param[6] = new OracleParameter("ANOASTO", OracleDbType.Int64);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oDetalleADBE.Anoasto;

                Param[7] = new OracleParameter("CBCPTO", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = oDetalleADBE.Cbcpto;

                Param[8] = new OracleParameter("SUCMOV", OracleDbType.Varchar2);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = oDetalleADBE.Sucmov;

                Param[9] = new OracleParameter("TIPCTA", OracleDbType.Varchar2);
                Param[9].Direction = ParameterDirection.Input;
                Param[9].Value = oDetalleADBE.Tipcta;

                Param[10] = new OracleParameter("CODGRUP", OracleDbType.Varchar2);
                Param[10].Direction = ParameterDirection.Input;
                Param[10].Value = oDetalleADBE.Codgrup;

                Param[11] = new OracleParameter("CODCTA", OracleDbType.Varchar2);
                Param[11].Direction = ParameterDirection.Input;
                Param[11].Value = oDetalleADBE.Codcta;

                Param[12] = new OracleParameter("CODSUB_CTA", OracleDbType.Varchar2);
                Param[12].Direction = ParameterDirection.Input;
                Param[12].Value = oDetalleADBE.Codsub_cta;

                Param[13] = new OracleParameter("DIGV", OracleDbType.Varchar2);
                Param[13].Direction = ParameterDirection.Input;
                Param[13].Value = oDetalleADBE.Digv;

                Param[14] = new OracleParameter("NUMDOC_ANA", OracleDbType.Varchar2);
                Param[14].Direction = ParameterDirection.Input;
                Param[14].Value = oDetalleADBE.Numdoc_ana;

                Param[15] = new OracleParameter("PDIST", OracleDbType.Int64);
                Param[15].Direction = ParameterDirection.Input;
                Param[15].Value = ((oDetalleADBE.Pdist.Length == 0) ? "0" : oDetalleADBE.Pdist);

                Param[16] = new OracleParameter("DIGV_D", OracleDbType.Varchar2);
                Param[16].Direction = ParameterDirection.Input;
                Param[16].Value = oDetalleADBE.Digv_d;

                Param[17] = new OracleParameter("PDES", OracleDbType.Varchar2);
                Param[17].Direction = ParameterDirection.Input;
                Param[17].Value = oDetalleADBE.Pdes;

                Param[18] = new OracleParameter("INDD_H", OracleDbType.Varchar2);
                Param[18].Direction = ParameterDirection.Input;
                Param[18].Value = oDetalleADBE.Indd_h;

                Param[19] = new OracleParameter("VALMOV", OracleDbType.Double);
                Param[19].Direction = ParameterDirection.Input;
                Param[19].Value = oDetalleADBE.Valmov;

                Param[20] = new OracleParameter("PCC", OracleDbType.Varchar2);
                Param[20].Direction = ParameterDirection.Input;
                Param[20].Value = oDetalleADBE.Pcc;

                Param[21] = new OracleParameter("VALMEX", OracleDbType.Double);
                Param[21].Direction = ParameterDirection.Input;
                Param[21].Value = oDetalleADBE.Valmex;

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
