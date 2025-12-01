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
    public class PlandeTrabajoTAD : BaseAD, IMantenimientoTAD
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
            PlandeTrabajoBE oPlandeTrabajoBE = new PlandeTrabajoBE();
            oPlandeTrabajoBE.IdPlan = Id1;
            oPlandeTrabajoBE.IdServicioArea = "";
            oPlandeTrabajoBE.IdPersonalAtencion = 0;
            oPlandeTrabajoBE.Descripcion = "";
            oPlandeTrabajoBE.IdTipo = 0;
            oPlandeTrabajoBE.IdRequerimiento = "";
            ModificaInserta(2, oPlandeTrabajoBE);
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

        public string ModificaInserta(BaseBE oBaseBE)
        {
            return ModificaInserta(3, oBaseBE);
        }

        public string ModificaInserta(int Modo, BaseBE oBaseBE)
        {
            PlandeTrabajoBE oPlandeTrabajoBE = (PlandeTrabajoBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oPlandeTrabajoBE.ToString(true));
                string PackagName = "NSASERVICE.PKG_HD_ATENCION_TAD.IPlanTrabajo";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oPlandeTrabajoBE.UserName
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

                Param[1] = new OracleParameter("ID_PLAN", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oPlandeTrabajoBE.IdPlan;

                Param[2] = new OracleParameter("ID_SERV_AREA", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oPlandeTrabajoBE.IdServicioArea;

                Param[3] = new OracleParameter("ID_RESP_ATE", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oPlandeTrabajoBE.IdResponsableAtencion;

                Param[4] = new OracleParameter("NOMBRE", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oPlandeTrabajoBE.Nombre;

                Param[5] = new OracleParameter("DESCRIPCION", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oPlandeTrabajoBE.Descripcion;

                Param[6] = new OracleParameter("IDTIPO", OracleDbType.Int64);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oPlandeTrabajoBE.IdTipo;

                Param[7] = new OracleParameter("ID_RQR", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = oPlandeTrabajoBE.IdRequerimiento;

                Param[8] = new OracleParameter("USU_AD", OracleDbType.Varchar2);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = oPlandeTrabajoBE.IdUsuario;

                Param[9] = new OracleParameter("IdOut", OracleDbType.Varchar2);
                Param[9].Direction = ParameterDirection.Output;
                Param[9].Size = 15;

                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Param);
                //ParamsOut = Param[7].Value.ToString();
                
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oPlandeTrabajoBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oPlandeTrabajoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oPlandeTrabajoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
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
