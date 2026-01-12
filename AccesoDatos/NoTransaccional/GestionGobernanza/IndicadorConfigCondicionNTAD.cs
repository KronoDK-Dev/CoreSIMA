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

namespace AccesoDatos.NoTransaccional.GestionGobernanza
{
    public class IndicadorConfigCondicionNTAD : BaseAD, IMantenimientoNTAD
    {
        public DataTable Buscar(string TextFind, string UserName)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1, string UserName)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1, string Id2, string UserName)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1, string Id2, string Id3, string UserName)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarTodos()
        {
            throw new NotImplementedException();
        }
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return null;
        }

      


        public DataTable ListarTodosCondicion(int IdArea,int IdIndicador, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, IdArea.ToString(), IdIndicador.ToString(), UserName);

                // string PackagName = "GOBERNANZA.PKG_INDICADOR_NTAD.IIndicadorCondicion";
                string PackagName = "GOBERNANZA.PKG_INDICADOR_NTAD.IAreaIndiCondicion";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                    , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
 

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("pIdArea", OracleDbType.Int64);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = IdArea;

                oParam[1] = new OracleParameter("pIdIndicador", OracleDbType.Int64);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = IdIndicador;

                oParam[2] = new OracleParameter("rstOut", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackagName, oParam);


                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));




                return ds.Tables[0];
            }

            catch (SqlException oracleException)
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

        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName)
        {
            throw new NotImplementedException();
        }
    }
}
