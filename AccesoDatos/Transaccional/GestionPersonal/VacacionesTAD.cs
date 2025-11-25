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

namespace AccesoDatos.Transaccional.GestionPersonal
{
    public class VacacionesTAD : BaseAD
    {
        public int Insertar(BaseBE oBaseBE)
        {
            int IdProceso = 0;
            try
            {

                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBaseBE.ToString());
                string PackagName = "INTERFACES.PE_VACACIONES_TAD.Insertar";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                VacacionesBE oVacacionesBE = (VacacionesBE)oBaseBE;
                OracleParameter[] Param = new OracleParameter[11];
                Param[0] = new OracleParameter("COD_EMP", OracleDbType.Int64);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = oVacacionesBE.Cod_emp;

                Param[1] = new OracleParameter("ROL", OracleDbType.Int64);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oVacacionesBE.Rol;

                Param[2] = new OracleParameter("DV_ROL", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oVacacionesBE.Dv_rol;

                Param[3] = new OracleParameter("PER_VAC", OracleDbType.Int64);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oVacacionesBE.Per_vac;

                Param[4] = new OracleParameter("DIA_TDO", OracleDbType.Int64);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oVacacionesBE.Dia_tdo;

                Param[5] = new OracleParameter("ANO_INI", OracleDbType.Int64);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oVacacionesBE.Ano_ini;

                Param[6] = new OracleParameter("MES_INI", OracleDbType.Int64);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oVacacionesBE.Mes_ini;

                Param[7] = new OracleParameter("DIA_INI", OracleDbType.Int64);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = oVacacionesBE.Dia_ini;

                Param[8] = new OracleParameter("ANO_TER", OracleDbType.Int64);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = oVacacionesBE.Ano_ter;

                Param[9] = new OracleParameter("MES_TER", OracleDbType.Int64);
                Param[9].Direction = ParameterDirection.Input;
                Param[9].Value = oVacacionesBE.Mes_ter;

                Param[10] = new OracleParameter("DIA_TER", OracleDbType.Int64);
                Param[10].Direction = ParameterDirection.Input;
                Param[10].Value = oVacacionesBE.Dia_ter;

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

        public int Eliminar(BaseBE oBaseBE)
        {
            int IdProceso = 0;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBaseBE.ToString());
                string PackagName = "INTERFACES.PE_VACACIONES_TAD.Eliminar";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                VacacionesBE oVacacionesBE = (VacacionesBE)oBaseBE;
                OracleParameter[] Param = new OracleParameter[11];
                Param[0] = new OracleParameter("pCOD_EMP", OracleDbType.Int64);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = oVacacionesBE.Cod_emp;

                Param[1] = new OracleParameter("pROL", OracleDbType.Int64);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oVacacionesBE.Rol;

                Param[2] = new OracleParameter("pDV_ROL", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oVacacionesBE.Dv_rol;

                Param[3] = new OracleParameter("pPER_VAC", OracleDbType.Int64);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oVacacionesBE.Per_vac;

                Param[4] = new OracleParameter("pDIA_TDO", OracleDbType.Int64);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oVacacionesBE.Dia_tdo;

                Param[5] = new OracleParameter("pANO_INI", OracleDbType.Int64);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oVacacionesBE.Ano_ini;

                Param[6] = new OracleParameter("pMES_INI", OracleDbType.Int64);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oVacacionesBE.Mes_ini;

                Param[7] = new OracleParameter("pDIA_INI", OracleDbType.Int64);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = oVacacionesBE.Dia_ini;

                Param[8] = new OracleParameter("pANO_TER", OracleDbType.Int64);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = oVacacionesBE.Ano_ter;

                Param[9] = new OracleParameter("pMES_TER", OracleDbType.Int64);
                Param[9].Direction = ParameterDirection.Input;
                Param[9].Value = oVacacionesBE.Mes_ter;

                Param[10] = new OracleParameter("pDIA_TER", OracleDbType.Int64);
                Param[10].Direction = ParameterDirection.Input;
                Param[10].Value = oVacacionesBE.Dia_ter;

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
