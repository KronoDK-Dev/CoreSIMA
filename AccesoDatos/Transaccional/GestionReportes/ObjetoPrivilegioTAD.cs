using EntidadNegocio;
using EntidadNegocio.GestionReportes;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.GestionReportes
{
    public class ObjetoPrivilegioTAD : BaseAD, IMantenimientoTAD
    {
        string sConsulta = ConfigurationManager.AppSettings["CONSULTA"];

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
            throw new NotImplementedException();
        }

        public string Modifica(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            ObjetoPrivilegioBE oObjetoPrivilegioBE = (ObjetoPrivilegioBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oObjetoPrivilegioBE.ToString(true));
                string PackagName = "GESTIONREPORTE.RPT_uspTADInsActObjetoPrivilegio";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oObjetoPrivilegioBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                string idResult = Convert.ToString(Sql(SQLVersion.sqlSIMANET).ExecuteNonQuery(PackagName, oObjetoPrivilegioBE.IdObjeto
                                                                                                        , oObjetoPrivilegioBE.IdUsuarioCompartido
                                                                                                        , oObjetoPrivilegioBE.Descripcion
                                                                                                        , oObjetoPrivilegioBE.owner
                                                                                                        , oObjetoPrivilegioBE.IdUsuario
                                                                                                        , oObjetoPrivilegioBE.IdEstado
                                                                                                    ));

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oObjetoPrivilegioBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + idResult
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return idResult;
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oObjetoPrivilegioBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oObjetoPrivilegioBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
        }

        public DataTable ListaAccesos_RptxUsuario(string s_usuario, string sAmbiente, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, s_usuario, sAmbiente, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaAccesos_RptxUsuario";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("V_USUARIO", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = s_usuario;

                oParam[1] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = sAmbiente;

                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, oParam);
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

        public DataTable ListaAccesos_RptxUsuario_v2(string s_usuario, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, s_usuario, UserName);
                string PackageName = sConsulta + ".Pkg_GENERAL.SP_ListaAccesos_RptxUsuario_v2";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                           , oInfoMetodoBE.FullName
                                                                           , NombreMetodo
                                                                           , PackageName
                                                                           , oInfoMetodoBE.VoidParams
                                                                           , ""
                                                                           , Helper.MensajesIngresarMetodo()
                                                                           , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                       );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("s_usuario", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = s_usuario;

                oParam[1] = new OracleParameter("V_USUARIO", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = UserName;

                oParam[2] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackageName, oParam);
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
