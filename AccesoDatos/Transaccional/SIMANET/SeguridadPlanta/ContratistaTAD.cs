using EntidadNegocio;
using EntidadNegocio.GestionCalidad;
using EntidadNegocio.SIMANET.SeguridadPlanta;
using Log;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.SIMANET.SeguridadPlanta
{
    public class ContratistaTAD : BaseAD, IMantenimientoTAD
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
            return 0;
        }

        public int Eliminar(int Periodo, int IdProgramacion, int IdUsuario, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, Periodo.ToString(), IdProgramacion.ToString(), IdUsuario.ToString(), UserName);
                string PackagName = "CCTTuspTADEliProgramacion";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName,IdProgramacion,Periodo,IdUsuario);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + idResult
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return 1;
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return-1;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return -1;
            }
        }


        public string  Copiar(int Periodo, int IdProgramacion, int IdUsuario, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, Periodo.ToString(), IdProgramacion.ToString(), IdUsuario.ToString(), UserName);
                string PackagName = "CCTT_ProgramacionCopiar";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName,  Periodo, IdProgramacion, IdUsuario);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + idResult
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return idResult.ToString();
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
        }


        public string Inserta(BaseBE oBaseBE)
        {
            CCTT_ProgramacionBE oCCTT_ProgramacionBE = (CCTT_ProgramacionBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oCCTT_ProgramacionBE.ToString(true));
                string PackagName = "CCTTuspTADinsProgramacion";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName
                                                                              , oCCTT_ProgramacionBE.IdEntidad
                                                                            , oCCTT_ProgramacionBE.IdJefeProyecto
                                                                            , oCCTT_ProgramacionBE.NroRegistroIngreso
                                                                            , oCCTT_ProgramacionBE.NroDocumentodeRef
                                                                            , oCCTT_ProgramacionBE.FechaInicio
                                                                            , oCCTT_ProgramacionBE.FechaTermino
                                                                            , oCCTT_ProgramacionBE.HoraInicio
                                                                            , oCCTT_ProgramacionBE.HoraTermino
                                                                            , oCCTT_ProgramacionBE.IdCIASeguros
                                                                            , oCCTT_ProgramacionBE.NroPoliza
                                                                            , oCCTT_ProgramacionBE.FechaInicioPoliza
                                                                            , oCCTT_ProgramacionBE.FechaTerminoPoliza
                                                                            , oCCTT_ProgramacionBE.NroPensionPoliza
                                                                            , oCCTT_ProgramacionBE.NroSaludPoliza
                                                                            , oCCTT_ProgramacionBE.TrabajosARealizar
                                                                            , oCCTT_ProgramacionBE.IdLugardeTrabajo
                                                                            , oCCTT_ProgramacionBE.NombreNave
                                                                            , oCCTT_ProgramacionBE.NombreContacto
                                                                            , oCCTT_ProgramacionBE.Observaciones
                                                                            , oCCTT_ProgramacionBE.NroOrdenServicio
                                                                            , oCCTT_ProgramacionBE.IdOrdenServicio
                                                                            , oCCTT_ProgramacionBE.TipoProgramacion
                                                                            , oCCTT_ProgramacionBE.IdUsuario
                                                                                );

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + idResult
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return idResult.ToString();
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_ProgramacionBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_ProgramacionBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
        }

        public int Insertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string Modifica(BaseBE oBaseBE)
        {
            CCTT_ProgramacionBE oCCTT_ProgramacionBE = (CCTT_ProgramacionBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oCCTT_ProgramacionBE.ToString(true));
                string PackagName = "CCTTuspTADactProgramacion";
                                     

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName
                                                                              , oCCTT_ProgramacionBE.NroProgramacion
                                                                                , oCCTT_ProgramacionBE.Periodo
                                                                                , oCCTT_ProgramacionBE.IdEntidad
                                                                                , oCCTT_ProgramacionBE.IdJefeProyecto
                                                                                , oCCTT_ProgramacionBE.NroRegistroIngreso
                                                                                , oCCTT_ProgramacionBE.NroDocumentodeRef
                                                                                , oCCTT_ProgramacionBE.FechaInicio
                                                                                , oCCTT_ProgramacionBE.FechaTermino
                                                                                , oCCTT_ProgramacionBE.HoraInicio
                                                                                , oCCTT_ProgramacionBE.HoraTermino
                                                                                , oCCTT_ProgramacionBE.IdCIASeguros
                                                                                , oCCTT_ProgramacionBE.NroPoliza
                                                                                , oCCTT_ProgramacionBE.FechaInicioPoliza
                                                                                , oCCTT_ProgramacionBE.FechaTerminoPoliza
                                                                                , oCCTT_ProgramacionBE.FechaInicioPolizaS
                                                                                , oCCTT_ProgramacionBE.FechaTerminoPolizaS
                                                                                , oCCTT_ProgramacionBE.NroPensionPoliza
                                                                                , oCCTT_ProgramacionBE.NroSaludPoliza
                                                                                , oCCTT_ProgramacionBE.TrabajosARealizar
                                                                                , oCCTT_ProgramacionBE.IdLugardeTrabajo
                                                                                , oCCTT_ProgramacionBE.NombreNave
                                                                                , oCCTT_ProgramacionBE.NombreContacto
                                                                                , oCCTT_ProgramacionBE.Observaciones
                                                                                , oCCTT_ProgramacionBE.NroOrdenServicio
                                                                                , oCCTT_ProgramacionBE.IdOrdenServicio
                                                                                , oCCTT_ProgramacionBE.IdUsuario
                                                                                );

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + idResult
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return "1";
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_ProgramacionBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_ProgramacionBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
        }

        public int Modificar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public int ModificarInsertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }
    }
}
