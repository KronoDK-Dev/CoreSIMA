using EntidadNegocio;
using EntidadNegocio.HelpDesk;
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

namespace AccesoDatos.Transaccional.HelpDesk
{
    public class PlanTrabajoActividadTareaHistorialTAD : BaseAD, IMantenimientoTAD
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
            PlanTrabajoActividadTareaHistorialBE oPlanTrabajoActividadTareaHistorialBE = new PlanTrabajoActividadTareaHistorialBE();
            oPlanTrabajoActividadTareaHistorialBE.IdHistorial = Id1;
            oPlanTrabajoActividadTareaHistorialBE.IdTarea = "";
            oPlanTrabajoActividadTareaHistorialBE.Nombre = "";
            oPlanTrabajoActividadTareaHistorialBE.Descripcion = "";
            oPlanTrabajoActividadTareaHistorialBE.IdTipoAccion = 0;
            oPlanTrabajoActividadTareaHistorialBE.IdTipoTiempo = 0;
            oPlanTrabajoActividadTareaHistorialBE.valTipoTime = 0;
            oPlanTrabajoActividadTareaHistorialBE.IdUsuario = Convert.ToInt32(Id2);
            oPlanTrabajoActividadTareaHistorialBE.UserName = Id3;

            ModificaInserta(2, oPlanTrabajoActividadTareaHistorialBE);
            return 1;
        }

        public int Modificar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string Modifica(BaseBE oBaseBE)
        {
            return ModificaInserta(3, oBaseBE);
        }

        public string ModificaInserta(int Modo, BaseBE oBaseBE)
        {
            PlanTrabajoActividadTareaHistorialBE oPlanTrabajoActividadTareaHistorialBE = (PlanTrabajoActividadTareaHistorialBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oPlanTrabajoActividadTareaHistorialBE.ToString(true));
                string PackagName = "NSASERVICE.PKG_HD_ATENCION_TAD.iPlanCronogramaActTaskHst";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oPlanTrabajoActividadTareaHistorialBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] Param = new OracleParameter[10];
                Param[0] = new OracleParameter("oModo", OracleDbType.Int64);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = Modo;

                Param[1] = new OracleParameter("ID_HISTORY", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oPlanTrabajoActividadTareaHistorialBE.IdHistorial;

                Param[2] = new OracleParameter("ID_TAREA", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oPlanTrabajoActividadTareaHistorialBE.IdTarea;

                Param[3] = new OracleParameter("NOMBRE", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oPlanTrabajoActividadTareaHistorialBE.Nombre;

                Param[4] = new OracleParameter("DESCRIPCION", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oPlanTrabajoActividadTareaHistorialBE.Descripcion;

                Param[5] = new OracleParameter("IDTIPOACCION", OracleDbType.Int64);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oPlanTrabajoActividadTareaHistorialBE.IdTipoAccion;

                Param[6] = new OracleParameter("IDTIPOTIME", OracleDbType.Int64);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oPlanTrabajoActividadTareaHistorialBE.IdTipoTiempo;

                Param[7] = new OracleParameter("VALTIME", OracleDbType.Double);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = oPlanTrabajoActividadTareaHistorialBE.valTipoTime;

                Param[8] = new OracleParameter("USU_AD", OracleDbType.Int64);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = oPlanTrabajoActividadTareaHistorialBE.IdUsuario;

                Param[9] = new OracleParameter("IdOut", OracleDbType.Varchar2);
                Param[9].Direction = ParameterDirection.Output;
                Param[9].Size = 15;

                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Param);
                ParamsOut = Param[9].Value.ToString();

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oPlanTrabajoActividadTareaHistorialBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oPlanTrabajoActividadTareaHistorialBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oPlanTrabajoActividadTareaHistorialBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
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
