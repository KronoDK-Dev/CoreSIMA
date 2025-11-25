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

namespace AccesoDatos.Transaccional.GestionPersonal.Contabilizacion
{
    public class EncabADTAD : BaseAD
    {
        public int Eliminar(string codEmp, string codSuc, string Año, string mes, string SubDiario)
        {
            int IdProceso = 0;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, codEmp.ToString(), codSuc.ToString(), Año.ToString(), mes.ToString(), SubDiario.ToString());
                string PackagName = "INTERFACES.PR_PERSONAL_TAD.EliEncabDetalleAD";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] Param = new OracleParameter[5];
                Param[0] = new OracleParameter("CODEMP", OracleDbType.Int64);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = codEmp;

                Param[1] = new OracleParameter("CODSUC", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = codSuc;

                Param[2] = new OracleParameter("ANOASTO", OracleDbType.Int64);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = Año;

                Param[3] = new OracleParameter("MESASTO", OracleDbType.Int64);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = mes;

                Param[4] = new OracleParameter("SUBDIARIO", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = SubDiario;

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
                LogTransaccional.LanzarSIMAExcepcionDominio("AccesoDatos:OrdendePagoCtaCtableTAD:Insertar", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oException.Number.ToString()), "Código de Error:" + oException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oException.Message);
                return IdProceso;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("AccesoDatos:OrdendePagoCtaCtableTAD:Insertar", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + ex.Message.ToString()), "Código de Error:" + ex.Message.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + ex.Message.ToString());
                return IdProceso;
            }
        }

        public int Insertar(BaseBE oBaseBE)
        {
            int IdProceso = 0;
            
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBaseBE.ToString());
                string PackagName = "INTERFACES.PR_PERSONAL_TAD.InsEncabAD";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                EncabADBE oEncabAD = (EncabADBE)oBaseBE;

                OracleParameter[] Param = new OracleParameter[23];
                Param[0] = new OracleParameter("CODEMP", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = oEncabAD.Codemp;

                Param[1] = new OracleParameter("CODSUC", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oEncabAD.Codsuc;

                Param[2] = new OracleParameter("NUMASTO", OracleDbType.Int64);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oEncabAD.Numasto;

                Param[3] = new OracleParameter("DIAASTO", OracleDbType.Int64);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oEncabAD.Diaasto;

                Param[4] = new OracleParameter("MESASTO", OracleDbType.Int64);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oEncabAD.Mesasto;

                Param[5] = new OracleParameter("ANOASTO", OracleDbType.Int64);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oEncabAD.Anoasto;

                Param[6] = new OracleParameter("TIPMON", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oEncabAD.Tipmon;

                Param[7] = new OracleParameter("CBCPTO", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = oEncabAD.Cbcpto;

                Param[8] = new OracleParameter("PGLOSA", OracleDbType.Varchar2);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = oEncabAD.Pglosa;

                Param[9] = new OracleParameter("VALASTO", OracleDbType.Double);
                Param[9].Direction = ParameterDirection.Input;
                Param[9].Value = oEncabAD.Valasto;

                Param[10] = new OracleParameter("NUMITEM_ASTO", OracleDbType.Int64);
                Param[10].Direction = ParameterDirection.Input;
                Param[10].Value = oEncabAD.Numitem_asto;

                Param[11] = new OracleParameter("TIPASTO", OracleDbType.Varchar2);
                Param[11].Direction = ParameterDirection.Input;
                Param[11].Value = oEncabAD.Tipasto;

                Param[12] = new OracleParameter("INDCM", OracleDbType.Varchar2);
                Param[12].Direction = ParameterDirection.Input;
                Param[12].Value = oEncabAD.Indcm;

                Param[13] = new OracleParameter("INDIPR", OracleDbType.Varchar2);
                Param[13].Direction = ParameterDirection.Input;
                Param[13].Value = oEncabAD.Indipr;

                Param[14] = new OracleParameter("INDPRS", OracleDbType.Varchar2);
                Param[14].Direction = ParameterDirection.Input;
                Param[14].Value = oEncabAD.Indprs;

                Param[15] = new OracleParameter("INDCRM", OracleDbType.Varchar2);
                Param[15].Direction = ParameterDirection.Input;
                Param[15].Value = oEncabAD.Indcrm;

                Param[16] = new OracleParameter("USUARIOING", OracleDbType.Varchar2);
                Param[16].Direction = ParameterDirection.Input;
                Param[16].Value = oEncabAD.Usuarioing;

                Param[17] = new OracleParameter("USUARIOAUT", OracleDbType.Varchar2);
                Param[17].Direction = ParameterDirection.Input;
                Param[17].Value = oEncabAD.Usuarioaut;

                Param[18] = new OracleParameter("VALASTO_ME", OracleDbType.Double);
                Param[18].Direction = ParameterDirection.Input;
                Param[18].Value = oEncabAD.Valasto_me;

                Param[19] = new OracleParameter("DIACMB", OracleDbType.Int64);
                Param[19].Direction = ParameterDirection.Input;
                Param[19].Value = oEncabAD.Diacmb;

                Param[20] = new OracleParameter("MESCMB", OracleDbType.Int64);
                Param[20].Direction = ParameterDirection.Input;
                Param[20].Value = oEncabAD.Mescmb;

                Param[21] = new OracleParameter("ANOCMB", OracleDbType.Int64);
                Param[21].Direction = ParameterDirection.Input;
                Param[21].Value = oEncabAD.Anocmb;

                Param[22] = new OracleParameter("TIPCMB", OracleDbType.Varchar2);
                Param[22].Direction = ParameterDirection.Input;
                Param[22].Value = oEncabAD.Tipcmb;

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
                LogTransaccional.LanzarSIMAExcepcionDominio("AccesoDatos:EncabADTAD:Insertar", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oException.Number.ToString()), "Código de Error:" + oException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oException.Message);
                return IdProceso;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("AccesoDatos:EncabADTAD:Insertar", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + ex.Message.ToString()), "Código de Error:" + ex.Message.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + ex.Message.ToString());
                return IdProceso;
            }
        }
    }
}
