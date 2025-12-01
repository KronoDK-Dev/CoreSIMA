using EntidadNegocio;
using EntidadNegocio.GestionPersonal;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.GestionPersonal
{
    public class DatosFijosTAD : BaseAD, IMantenimientoTAD
    {
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
            int num = 0;
            DatosFijosBE datosFijosBe = (DatosFijosBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBaseBE.ToString());
                string PackagName = "INTERFACES.PE_DATOSFIJOS_TAD.Actualizar";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("DatosFijosTAD"
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] Params = new OracleParameter[17];

                Params[0] = new OracleParameter("ano_prc", OracleDbType.Int32);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = (object)datosFijosBe.Ano_prc;

                Params[1] = new OracleParameter("cod_emp", OracleDbType.Int32);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = (object)datosFijosBe.Cod_emp;

                Params[2] = new OracleParameter("cod_itm", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = (object)datosFijosBe.Cod_itm;

                Params[3] = new OracleParameter("dv_rol", OracleDbType.Varchar2);
                Params[3].Direction = ParameterDirection.Input;
                Params[3].Value = (object)datosFijosBe.Dv_rol;

                Params[4] = new OracleParameter("mes_prc", OracleDbType.Int32);
                Params[4].Direction = ParameterDirection.Input;
                Params[4].Value = (object)datosFijosBe.Mes_prc;

                Params[5] = new OracleParameter("mnt_itm", OracleDbType.Double);
                Params[5].Direction = ParameterDirection.Input;
                Params[5].Value = (object)datosFijosBe.Mnt_itm;

                Params[6] = new OracleParameter("nivel_fun", OracleDbType.Varchar2);
                Params[6].Direction = ParameterDirection.Input;
                Params[6].Value = (object)datosFijosBe.Nivel_fun;

                Params[7] = new OracleParameter("rol", OracleDbType.Int32);
                Params[7].Direction = ParameterDirection.Input;
                Params[7].Value = (object)datosFijosBe.Rol;

                Params[8] = new OracleParameter("tip_itm", OracleDbType.Varchar2);
                Params[8].Direction = ParameterDirection.Input;
                Params[8].Value = (object)datosFijosBe.Tip_itm;

                Params[9] = new OracleParameter("mon_itm", OracleDbType.Varchar2);
                Params[9].Direction = ParameterDirection.Input;
                Params[9].Value = (object)datosFijosBe.Mon_itm;

                Params[10] = new OracleParameter("ano_ini_vig", OracleDbType.Int32);
                Params[10].Direction = ParameterDirection.Input;
                Params[10].Value = (object)datosFijosBe.Ano_ini_vig;

                Params[11] = new OracleParameter("mes_ini_vig", OracleDbType.Int32);
                Params[11].Direction = ParameterDirection.Input;
                Params[11].Value = (object)datosFijosBe.Mes_ini_vig;

                Params[12] = new OracleParameter("ano_trm_vig", OracleDbType.Int32);
                Params[12].Direction = ParameterDirection.Input;
                Params[12].Value = (object)datosFijosBe.Ano_trm_vig;

                Params[13] = new OracleParameter("mes_trm_vig", OracleDbType.Int32);
                Params[13].Direction = ParameterDirection.Input;
                Params[13].Value = (object)datosFijosBe.Mes_ini_vig;

                Params[14] = new OracleParameter("cc", OracleDbType.Varchar2);
                Params[14].Direction = ParameterDirection.Input;
                Params[14].Value = (object)datosFijosBe.Cc;

                Params[15] = new OracleParameter("mon_alt_itm", OracleDbType.Varchar2);
                Params[15].Direction = ParameterDirection.Input;
                Params[15].Value = (object)datosFijosBe.Mon_alt_itm;

                Params[16] = new OracleParameter("nro_cuo", OracleDbType.Int32);
                Params[16].Direction = ParameterDirection.Input;
                Params[16].Value = (object)datosFijosBe.Nro_cuo;

                Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Params);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("DatosFijosTAD"
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , ""
                    , "Return ID:" + "1"
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return 1;
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("DatosFijosTAD", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return -1;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("DatosFijosTAD", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return -1;
            }
        }

        public string Modifica(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
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
