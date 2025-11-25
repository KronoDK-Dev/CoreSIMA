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
    public class CostoPlanillaTAD : BaseAD
    {
        public int Insertar(BaseBE oBaseBE)
        {

            int IdProceso = 0;
            try
            {

                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBaseBE.ToString());

                string PackagName = "INTERFACES.PKG_COSTOS_TAD.actPagoPlanilla";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));



                CostoPlanillaBE oCostoPlanillaBE = (CostoPlanillaBE)oBaseBE;

                OracleParameter[] Param = new OracleParameter[12];

                Param[0] = new OracleParameter("CODEMP", OracleDbType.Int64);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = oCostoPlanillaBE.CodEmp;

                Param[1] = new OracleParameter("ANOPRC", OracleDbType.Int64);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oCostoPlanillaBE.AnoPrc;

                Param[2] = new OracleParameter("MESPRC", OracleDbType.Int64);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oCostoPlanillaBE.MesPrc;

                Param[3] = new OracleParameter("CODDIV", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oCostoPlanillaBE.CodDiv;

                Param[4] = new OracleParameter("CODOTS", OracleDbType.Int64);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oCostoPlanillaBE.CodOts;

                Param[5] = new OracleParameter("CNTNOR", OracleDbType.Double);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oCostoPlanillaBE.CntNor;

                Param[6] = new OracleParameter("MNTNOR", OracleDbType.Double);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oCostoPlanillaBE.MntNor;

                Param[7] = new OracleParameter("CNTSBT", OracleDbType.Double);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = oCostoPlanillaBE.CntSbt;

                Param[8] = new OracleParameter("MNTSBT", OracleDbType.Double);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = oCostoPlanillaBE.MntSbt;

                Param[9] = new OracleParameter("CNTINC", OracleDbType.Double);
                Param[9].Direction = ParameterDirection.Input;
                Param[9].Value = oCostoPlanillaBE.CntInc;

                Param[10] = new OracleParameter("MNTINC", OracleDbType.Double);
                Param[10].Direction = ParameterDirection.Input;
                Param[10].Value = oCostoPlanillaBE.MntInc;

                Param[11] = new OracleParameter("CODCC", OracleDbType.Varchar2);
                Param[11].Direction = ParameterDirection.Input;
                Param[11].Value = oCostoPlanillaBE.CodCC;

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

        public int Eliminar(int CODEMP, int ANOPRC, int MESPRC)
        {
            int IdProceso = 0;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, CODEMP.ToString(), ANOPRC.ToString(), MESPRC.ToString());

                string PackagName = "INTERFACES.PKG_COSTOS_TAD.eliPagoPlanilla";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] Param = new OracleParameter[3];
                Param[0] = new OracleParameter("CODEMP", OracleDbType.Int64);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = CODEMP;

                Param[1] = new OracleParameter("ANOPRC", OracleDbType.Int64);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = ANOPRC;

                Param[2] = new OracleParameter("MESPRC", OracleDbType.Int64);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = MESPRC;

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
