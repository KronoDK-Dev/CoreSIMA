using EntidadNegocio;
using EntidadNegocio.SIMANET.SeguridadPlanta;
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

namespace AccesoDatos.NoTransaccional.SIMANET.SeguridadPlanta
{
    public class ContratistaNTAD : BaseAD, IMantenimientoNTAD
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
            throw new NotImplementedException();
        }

        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            throw new NotImplementedException();
        }
        public DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName)
        {
            return null;
        }
        public DataTable BuscarPersonalSIMA(string Nombres, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, Nombres, UserName);

                // string PackagName = "GOBERNANZA.PKG_INDICADOR_NTAD.IIndicadorCondicion";
                string PackagName = "CYPuspNTADConsultarPersonalPorNombre";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                    , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );



                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, Nombres);


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


        public DataTable BuscarAreaSIMA(int idCentroOperativo,string NombresArea, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, idCentroOperativo.ToString(),NombresArea, UserName);

                string PackagName = "GENuspNTADConsultarAreaXNombre";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                    , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );



                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, idCentroOperativo, NombresArea);


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


        public BaseBE Detalle(int NroProgramacion, int Periodo, int IdUsuario, int IdTipoProgramacion, string UserName)
        { 
            try
            {
                //Graba en el Log Ingreso a Metodo
                DataTable dt = ListarTodos(NroProgramacion, Periodo, IdUsuario, IdTipoProgramacion, UserName);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    DataRow dr = dt.Rows[0];
                    CCTT_ProgramacionBE oCCTT_ProgramacionBE = new CCTT_ProgramacionBE();
                    oCCTT_ProgramacionBE.NroProgramacion = Convert.ToInt32(dr["NroProgramacion"].ToString());
                    oCCTT_ProgramacionBE.Periodo = Convert.ToInt32(dr["Periodo"].ToString());
                    oCCTT_ProgramacionBE.IdEntidad = Convert.ToInt32(dr["idEntidad"].ToString());
                    oCCTT_ProgramacionBE.NroRuc = Convert.ToString(dr["NroProveedor"].ToString());
                    oCCTT_ProgramacionBE.RazonSocial = Convert.ToString(dr["RazonSocialProveedor"].ToString());
                    oCCTT_ProgramacionBE.FechaInicio = Convert.ToDateTime(dr["FechaInicio"].ToString());
                    oCCTT_ProgramacionBE.FechaTermino = Convert.ToDateTime(dr["FechaTermino"].ToString());
                    oCCTT_ProgramacionBE.HoraInicio = dr["HoraInicio"].ToString();
                    oCCTT_ProgramacionBE.HoraTermino = dr["HoraTermino"].ToString();

                    oCCTT_ProgramacionBE.IdJefeProyecto = Convert.ToInt32(dr["idJefeProyecto"].ToString());
                    oCCTT_ProgramacionBE.ApellidosyNombres = Convert.ToString(dr["JefeProyectoNombres"].ToString());

                    oCCTT_ProgramacionBE.NroRegistroIngreso = dr["NroRegistroIngreso"].ToString();
                    oCCTT_ProgramacionBE.NroDocumentodeRef = dr["NroDocumentodeRef"].ToString();
                    oCCTT_ProgramacionBE.IdCIASeguros = Convert.ToInt32(dr["idCIASeguros"].ToString());
                    oCCTT_ProgramacionBE.NombreCIASeguros = Convert.ToString(dr["NombreCIASeguros"].ToString());

                    oCCTT_ProgramacionBE.FechaInicioPoliza = Convert.ToDateTime(dr["FechaInicioPoliza"].ToString());
                    oCCTT_ProgramacionBE.FechaTerminoPoliza = Convert.ToDateTime(dr["FechaTerminoPoliza"].ToString());

                    oCCTT_ProgramacionBE.FechaInicioPolizaS = Convert.ToDateTime(dr["FechaInicioPolizaS"].ToString());
                    oCCTT_ProgramacionBE.FechaTerminoPolizaS = Convert.ToDateTime(dr["FechaTerminoPolizaS"].ToString());

                    oCCTT_ProgramacionBE.NroPensionPoliza = dr["NroPensionPoliza"].ToString();
                    oCCTT_ProgramacionBE.NroSaludPoliza = dr["NroSaludPoliza"].ToString();
                    oCCTT_ProgramacionBE.TrabajosARealizar = dr["TrabajosARealizar"].ToString();
                    oCCTT_ProgramacionBE.IdArea = Convert.ToInt32(dr["idArea"].ToString());
                    oCCTT_ProgramacionBE.NombreArea = dr["NombreArea"].ToString();

                    oCCTT_ProgramacionBE.NombreNave = dr["NombreNave"].ToString();
                    oCCTT_ProgramacionBE.NombreContacto = dr["ContactoNombres"].ToString();

                    oCCTT_ProgramacionBE.Observaciones = dr["Observaciones"].ToString();

                    oCCTT_ProgramacionBE.NroOrdenServicio = dr["NroDoc"].ToString();
                    oCCTT_ProgramacionBE.IdOrdenServicio = dr["IdOS"].ToString();

                    return oCCTT_ProgramacionBE;
                }
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
        public DataTable ListarTodos(int NroProgramacion, int Periodo,int IdUsuario, int IdTipoProgramacion, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, NroProgramacion.ToString(),  Periodo.ToString(), IdUsuario.ToString(), IdTipoProgramacion.ToString(), UserName);

                // string PackagName = "GOBERNANZA.PKG_INDICADOR_NTAD.IIndicadorCondicion";
                string PackagName = "CCTTuspNTADConsultarProgramacionContratista";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                    , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );


              
                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, NroProgramacion, Periodo, IdUsuario, IdTipoProgramacion);


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









    }
}
