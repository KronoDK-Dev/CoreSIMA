using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.NoTransaccional.GestionLogistica
{
    public class ProyectosNTAD : BaseAD
    {
        readonly string sConsulta = ConfigurationManager.AppSettings["CONSULTA"];

        public DataTable Listar_PRY_PAG_TOT(string Centro_Operativo, string división, string Proyecto, string Nro_Orden,
            string Procedencia, string Tipo_Orden, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo);

                string PackageName = sConsulta + ".Pkg_LOGISTICA.SP_PRY_PAG_TOT";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Param = new OracleParameter[7];
                Param[0] = new OracleParameter("Centro_Operativo", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Output;
                Param[0].Value = Centro_Operativo;

                Param[1] = new OracleParameter("división", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Output;
                Param[1].Value = división;

                Param[2] = new OracleParameter("Proyecto", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Output;
                Param[2].Value = Proyecto;

                Param[3] = new OracleParameter("Nro_Orden", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Output;
                Param[3].Value = Nro_Orden;

                Param[4] = new OracleParameter("Procedencia", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Output;
                Param[4].Value = Procedencia;

                Param[5] = new OracleParameter("Tipo_Orden", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Output;
                Param[5].Value = Tipo_Orden;

                Param[6] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                Param[6].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, Param);
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , ""
                    , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                return ds.Tables[0];
            }
            catch (OracleException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }
    }
}
