using EntidadNegocio;
using EntidadNegocio.HelpDesk;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.HelpDesk
{
    public class PlanTrabajoActividadTAD : BaseAD, IMantenimientoTAD
    {
        public int Eliminar()
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1, string Id2, string Id3)
        {
            PlanCronogramaActividadBE oPlanCronogramaActividadBE = new PlanCronogramaActividadBE();
            oPlanCronogramaActividadBE.IdConogramaActividad = Id1;
            oPlanCronogramaActividadBE.IdConogramaActividadPadre = "0";
            oPlanCronogramaActividadBE.Descripcion = "";
            oPlanCronogramaActividadBE.IdActividad = "";
            oPlanCronogramaActividadBE.IdPlan = "";
            oPlanCronogramaActividadBE.IdUsuario = Convert.ToInt32(Id2);
            oPlanCronogramaActividadBE.UserName = Id3;
            ModificaInserta(2, oPlanCronogramaActividadBE);
            return 1;
        }

        public int Eliminar(string Id1, string Id2)
        {
            throw new NotImplementedException();
        }

        public string Inserta(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public int Insertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string Modifica(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }
        public string ModificaInserta(int Modo, BaseBE oBaseBE)
        {
            PlanCronogramaActividadBE oPlanCronogramaActividadBE = (PlanCronogramaActividadBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oPlanCronogramaActividadBE.ToString(true));
                string PackagName = "NSASERVICE.PKG_HD_ATENCION_TAD.IPlanCronogramaActividad";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oPlanCronogramaActividadBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] Param = new OracleParameter[8];

                Param[0] = new OracleParameter("oModo", OracleDbType.Int64);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = Modo;

                Param[1] = new OracleParameter("ID_ITEM", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oPlanCronogramaActividadBE.IdConogramaActividad;

                Param[2] = new OracleParameter("ID_ITEM_PADRE", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oPlanCronogramaActividadBE.IdConogramaActividadPadre;

                Param[3] = new OracleParameter("DESCRIPCION", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oPlanCronogramaActividadBE.Descripcion;

                Param[4] = new OracleParameter("ID_ACTIVIDAD", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oPlanCronogramaActividadBE.IdActividad;

                
                Param[5] = new OracleParameter("ID_PLAN", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oPlanCronogramaActividadBE.IdPlan;

                Param[6] = new OracleParameter("USU_AD", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oPlanCronogramaActividadBE.IdUsuario;

                Param[7] = new OracleParameter("IdOut", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Output;
                Param[7].Size = 15;

                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Param);
                ParamsOut = Param[7].Value.ToString();

                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oPlanCronogramaActividadBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + ParamsOut.ToString()
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));





                return ParamsOut;
            }

            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oPlanCronogramaActividadBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oPlanCronogramaActividadBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
        }
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return ModificaInserta(3, oBaseBE);
        }

        public int Modificar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public int ModificarInsertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }
    }
}
