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

namespace AccesoDatos.General
{
    public class ClaseExtendNTAD : BaseAD
    {
        public DataTable ListarPropiedades(string NombreClase, string UserName)
        {
            try
            {
                string name = new StackTrace().GetFrame(0).GetMethod().Name;
                InfoMetodoBE infoMetodoBe = this.MetodoInfo(name, NombreClase.ToString(), UserName);
                string str = "PKG_SIM_INTERFACE_NTAD.CLASEBE";
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName, infoMetodoBe.FullName, name, str, infoMetodoBe.VoidParams, "", Helper.MensajesIngresarMetodo(), Convert.ToString((object)Enumerados.NivelesErrorLog.I)));
                OracleParameter[] Params = new OracleParameter[3]
                {
        new OracleParameter("FncOut", OracleDbType.Varchar2),
        null,
        null
                };
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = (object)"Property";
                Params[1] = new OracleParameter("ValRef", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = (object)NombreClase;
                Params[2] = new OracleParameter("CurRST", OracleDbType.RefCursor);
                Params[2].Direction = ParameterDirection.Output;
                return BaseAD.Oracle(BaseAD.ORACLEVersion.O7).ExecuteDataSet(true, str, Params).Tables[0];
            }
            catch (SqlException ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Constante.LogCtrl.CEROS + ex.Number.ToString()), $"Código de Error:{ex.Number.ToString()}{Constante.Caracteres.SeperadorSimple}Número de Línea:1{Constante.Caracteres.SeperadorSimple}{ex.Message}");
                return (DataTable)null;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return (DataTable)null;
            }
        }
    }
}
