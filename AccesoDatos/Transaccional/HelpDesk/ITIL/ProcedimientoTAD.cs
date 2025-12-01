using EntidadNegocio;
using EntidadNegocio.HelpDesk.ITIL;
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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace AccesoDatos.Transaccional.HelpDesk.ITIL
{
    public class ProcedimientoTAD : BaseAD, IMantenimientoTAD
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
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, Id1, Id2, Id3);
                string PackagName = "NSASERVICE.PKG_ITIL_TAD.IDelProcedimientoAccion";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(Id2
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] Param = new OracleParameter[2];
                Param[0] = new OracleParameter("pID_ACCION", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = Id1;

                Param[1] = new OracleParameter("pUSU_DEL", OracleDbType.Int64);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = Id2;

                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Param);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(Id2
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + ParamsOut.ToString()
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return 1;
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(Id2, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return -1;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(Id2, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return -1;
            }
        }

        public int Modificar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string Modifica(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string ModificaInserta(int Modo, BaseBE oBaseBE)
        {
            ProcedimientoBE oProcedimientoBE = (ProcedimientoBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oProcedimientoBE.ToString(true));
                string PackagName = "NSASERVICE.PKG_ITIL_TAD.IProcedimiento";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oProcedimientoBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] Param = new OracleParameter[11];
                Param[0] = new OracleParameter("oModo", OracleDbType.Int64);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = Modo;

                Param[1] = new OracleParameter("pID_ACCION", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oProcedimientoBE.IdAccion;

                Param[2] = new OracleParameter("pID_ACCION_REL", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oProcedimientoBE.IdAccionRel;

                Param[3] = new OracleParameter("pID_ACCION_TO", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oProcedimientoBE.IdAccionTo;

                Param[4] = new OracleParameter("pIDTIPOOBJ", OracleDbType.Int64);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oProcedimientoBE.IdTipoObj;

                Param[5] = new OracleParameter("pACCION_BASICA", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oProcedimientoBE.AccionBasica;

                Param[6] = new OracleParameter("pATRIBUTOS", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oProcedimientoBE.Atributo;

                Param[7] = new OracleParameter("pORDEN", OracleDbType.Int64);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = oProcedimientoBE.Orden;

                Param[8] = new OracleParameter("pID_ACTIVIDAD", OracleDbType.Varchar2);
                Param[8].Direction = ParameterDirection.Input;
                Param[8].Value = oProcedimientoBE.IdActividad;

                Param[9] = new OracleParameter("pUSU_ADD", OracleDbType.Int64);
                Param[9].Direction = ParameterDirection.Input;
                Param[9].Value = oProcedimientoBE.IdUsuario;

                Param[10] = new OracleParameter("IdOut", OracleDbType.Varchar2);
                Param[10].Direction = ParameterDirection.Output;
                Param[10].Size = 15;

                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Param);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oProcedimientoBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oProcedimientoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oProcedimientoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
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
