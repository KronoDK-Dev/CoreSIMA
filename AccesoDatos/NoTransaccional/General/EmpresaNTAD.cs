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

namespace AccesoDatos.NoTransaccional.General
{
    public class EmpresaNTAD : BaseAD
    {
        public DataTable ObtenerCredencialEMP(string IdEmp)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, IdEmp.ToString());
                string PackagName = "O7INVOICE.PD_FACT_UTILITARIO_NTAD.ObtCredencialEMP";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserNameVER"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );

                OracleParameter[] Param = new OracleParameter[2];
                Param[0] = new OracleParameter("wIdEmp", OracleDbType.Varchar2);

                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = IdEmp;

                Param[1] = new OracleParameter("Rstdo", OracleDbType.RefCursor);
                Param[1].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.O7).ExecuteDataSet(true, PackagName, Param);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                if (ds != null)
                {
                    return ds.Tables[0];
                }

                return null;
            }
            catch (Oracle.DataAccess.Client.OracleException oException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("oException", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oException.Number.ToString()), "Código de Error:" + oException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oException.Message);
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("ex", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + ex.Message.ToString()), "Código de Error:" + ex.Source.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + ex.Message);
            }

            return null;
        }
    }
}
