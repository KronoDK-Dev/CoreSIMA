using EntidadNegocio;
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
    public class ProgramacionTrabajadorTAD : BaseAD, IMantenimientoTAD
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
            throw new NotImplementedException();
        }
        public int Eliminar(BaseBE oBaseBE)
        {
            CCTT_ProgramacionTrabajadoresContratistaBE oCCTT_ProgramacionTrabajadoresContratistaBE = (CCTT_ProgramacionTrabajadoresContratistaBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oCCTT_ProgramacionTrabajadoresContratistaBE.ToString(true));
                string PackagName = "CCTTuspTADActProgramacionTrabajadoresContratista";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionTrabajadoresContratistaBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.NroProgramacion
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.Periodo
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.NroDNI
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.Observacion
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.IdEstado
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.IdUsuario
                                                                                        );

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionTrabajadoresContratistaBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_ProgramacionTrabajadoresContratistaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return -1;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_ProgramacionTrabajadoresContratistaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return -1;
            }

        }
        public string Inserta(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public int Insertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string Modifica(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
             CCTT_ProgramacionTrabajadoresContratistaBE oCCTT_ProgramacionTrabajadoresContratistaBE = (CCTT_ProgramacionTrabajadoresContratistaBE)oBaseBE;
             try
             {
                 StackTrace stack = new StackTrace();
                 string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                 InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oCCTT_ProgramacionTrabajadoresContratistaBE.ToString(true));
                 string PackagName = "CCTT_uspTADInsActAreadeVisita";


                 LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionTrabajadoresContratistaBE.UserName
                                                                                      , oInfoMetodoBE.FullName
                                                                                      , NombreMetodo
                                                                                      , PackagName
                                                                                      , oInfoMetodoBE.VoidParams
                                                                                      , ""
                                                                                      , Helper.MensajesIngresarMetodo()
                                                                                      , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                  );
                 object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName
                                                                                     , oCCTT_ProgramacionTrabajadoresContratistaBE.NroProgramacion
                                                                                     , oCCTT_ProgramacionTrabajadoresContratistaBE.Periodo
                                                                                     , oCCTT_ProgramacionTrabajadoresContratistaBE.NroDNI
                                                                                     , oCCTT_ProgramacionTrabajadoresContratistaBE.FechaInicio
                                                                                     , oCCTT_ProgramacionTrabajadoresContratistaBE.FechaTermino
                                                                                     , oCCTT_ProgramacionTrabajadoresContratistaBE.HoraInicio
                                                                                     , oCCTT_ProgramacionTrabajadoresContratistaBE.HoraTermino
                                                                                     , oCCTT_ProgramacionTrabajadoresContratistaBE.IdUsuario
                                                                                     , oCCTT_ProgramacionTrabajadoresContratistaBE.SCTRSalud
                                                                                     , oCCTT_ProgramacionTrabajadoresContratistaBE.SCTRPension
                                                                                         );

                 LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionTrabajadoresContratistaBE.UserName
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
                 LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_ProgramacionTrabajadoresContratistaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                 return "-1";
             }
             catch (Exception exception)
             {
                 LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_ProgramacionTrabajadoresContratistaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                 return "-1";
             }
            
        }


        public string Reprogramar(BaseBE oBaseBE)
        {
            CCTT_ProgramacionTrabajadoresContratistaBE oCCTT_ProgramacionTrabajadoresContratistaBE = (CCTT_ProgramacionTrabajadoresContratistaBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oCCTT_ProgramacionTrabajadoresContratistaBE.ToString(true));
                string PackagName = "CCTT_uspTADInsActAreadeVisita";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionTrabajadoresContratistaBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.NroProgramacion
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.Periodo
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.NroDNI
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.FechaInicio
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.FechaTermino
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.HoraInicio
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.HoraTermino
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.IdUsuario
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.SCTRSalud//24-07-2023
                                                                                    , oCCTT_ProgramacionTrabajadoresContratistaBE.SCTRPension
                                                                                        );

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionTrabajadoresContratistaBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_ProgramacionTrabajadoresContratistaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_ProgramacionTrabajadoresContratistaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
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
