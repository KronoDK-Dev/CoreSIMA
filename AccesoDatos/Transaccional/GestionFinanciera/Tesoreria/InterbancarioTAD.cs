using EntidadNegocio;
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

namespace AccesoDatos.Transaccional.GestionFinanciera.Tesoreria
{
    public class InterbancarioTAD : BaseAD, IMantenimientoTAD
    {
        public int CabActulizaEstado(string Nrlote, int Estado, string UserName)
        {
            try
            {
                string name = new StackTrace().GetFrame(0).GetMethod().Name;
                InfoMetodoBE infoMetodoBe = this.MetodoInfo(name, Nrlote, Estado.ToString(), UserName);
                string str = "Pkg_Planilla_Proveedores.SP_Pago_Cabecera_Enviado";
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, infoMetodoBe.VoidParams, "", Helper.MensajesIngresarMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                OracleParameter[] Params = new OracleParameter[2]
                {
        new OracleParameter("p_nro_lot", OracleDbType.Varchar2),
        null
                };
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = (object)Nrlote;
                Params[1] = new OracleParameter("p_enviado", OracleDbType.Int32);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = (object)Estado;
                object obj = BaseAD.Oracle(BaseAD.ORACLEVersion.O7).ExecuteScalar(true, str, Params);
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, "", "Return ID:" + obj?.ToString(), Helper.MensajesSalirMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                return 1;
            }
            catch (SqlException ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Constante.LogCtrl.CEROS + ex.Number.ToString()), $"Código de Error:{ex.Number.ToString()}{Constante.Caracteres.SeperadorSimple}Número de Línea:1{Constante.Caracteres.SeperadorSimple}{ex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return -1;
            }
        }

        public int CabActulizaEstado(string Nrlote, int Estado, string Mensaje, string UserName)
        {
            try
            {
                string name = new StackTrace().GetFrame(0).GetMethod().Name;
                InfoMetodoBE infoMetodoBe = this.MetodoInfo(name, Nrlote, Estado.ToString(), Mensaje, UserName);
                string str = "Pkg_Planilla_Proveedores.SP_Pago_Cabecera_Estado";
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, infoMetodoBe.VoidParams, "", Helper.MensajesIngresarMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                OracleParameter[] Params = new OracleParameter[3]
                {
        new OracleParameter("p_nro_lot", OracleDbType.Varchar2),
        null,
        null
                };
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = (object)Nrlote;
                Params[1] = new OracleParameter("p_mensaje", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = (object)Mensaje;
                Params[2] = new OracleParameter("p_estado", OracleDbType.Int32);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = (object)Estado;
                object obj = BaseAD.Oracle(BaseAD.ORACLEVersion.O7).ExecuteScalar(true, str, Params);
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, "", "Return ID:" + obj?.ToString(), Helper.MensajesSalirMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                return 1;
            }
            catch (SqlException ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Constante.LogCtrl.CEROS + ex.Number.ToString()), $"Código de Error:{ex.Number.ToString()}{Constante.Caracteres.SeperadorSimple}Número de Línea:1{Constante.Caracteres.SeperadorSimple}{ex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return -1;
            }
        }

        public int DetActulizaEstado(string Nrlote, string NroPrv, string Observacion, string UserName)
        {
            try
            {
                string name = new StackTrace().GetFrame(0).GetMethod().Name;
                InfoMetodoBE infoMetodoBe = this.MetodoInfo(name, Nrlote, NroPrv, Observacion, UserName);
                string str = "Pkg_Planilla_Proveedores.SP_Pago_Detalle_Observacion";
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, infoMetodoBe.VoidParams, "", Helper.MensajesIngresarMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                OracleParameter[] Params = new OracleParameter[3]
                {
        new OracleParameter("p_nro_lot", OracleDbType.Varchar2),
        null,
        null
                };
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = (object)Nrlote;
                Params[1] = new OracleParameter("p_cod_prv", OracleDbType.Int64);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = (object)NroPrv;
                Params[2] = new OracleParameter("p_observa", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = (object)Observacion;
                object obj = BaseAD.Oracle(BaseAD.ORACLEVersion.O7).ExecuteScalar(true, str, Params);
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, "", "Return ID:" + obj?.ToString(), Helper.MensajesSalirMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                return 1;
            }
            catch (SqlException ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Constante.LogCtrl.CEROS + ex.Number.ToString()), $"Código de Error:{ex.Number.ToString()}{Constante.Caracteres.SeperadorSimple}Número de Línea:1{Constante.Caracteres.SeperadorSimple}{ex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return -1;
            }
        }

        public int Eliminar() => throw new NotImplementedException();

        public int Eliminar(string Id1) => throw new NotImplementedException();

        public int Eliminar(string Id1, string Id2) => throw new NotImplementedException();

        public int Eliminar(string Id1, string Id2, string Id3) => throw new NotImplementedException();

        public string Inserta(BaseBE oBaseBE) => throw new NotImplementedException();

        public int Insertar(BaseBE oBaseBE) => throw new NotImplementedException();

        public string Modifica(BaseBE oBaseBE) => throw new NotImplementedException();

        public string ModificaInserta(BaseBE oBaseBE) => throw new NotImplementedException();

        public int Modificar(BaseBE oBaseBE) => throw new NotImplementedException();

        public int ModificarInsertar(BaseBE oBaseBE) => throw new NotImplementedException();
    }
}
