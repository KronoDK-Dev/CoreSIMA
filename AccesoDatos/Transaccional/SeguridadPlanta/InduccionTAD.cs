using EntidadNegocio;
using EntidadNegocio.GestionCalidad;
using EntidadNegocio.HelpDesk;
using EntidadNegocio.SeguridadPlanta;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.SeguridadPlanta
{
    public class InduccionTAD : BaseAD, IMantenimientoTAD
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
            return null;
        }
        public string ModificaInsertaTrabajador(personal opersonal)
        {
              try
              {
                  StackTrace stack = new StackTrace();
                  string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                  InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, opersonal.ToString());
                  string PackagName = "CCTTuspTADinsActTrabajador";

                  LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("JobsSystem"
                                                                                       , oInfoMetodoBE.FullName
                                                                                       , NombreMetodo
                                                                                       , PackagName
                                                                                       , oInfoMetodoBE.VoidParams
                                                                                       , ""
                                                                                       , Helper.MensajesIngresarMetodo()
                                                                                       , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                   );
                  string nrodoc = opersonal.nroDoc.Replace("\"", "");

                  string idResult = Convert.ToString(Sql(SQLVersion.sqlSIMANET).ExecuteNonQuery(PackagName, nrodoc
                                                                                                          , opersonal.apPaterno
                                                                                                          , opersonal.apMaterno
                                                                                                          , opersonal.Nombres
                                                                                                          , 1
                                                                                                      ));



                  //Graba en el Log Salida del Metodo
                  LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("JobsSystem"
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
                  LogTransaccional.LanzarSIMAExcepcionDominio("JobsSystem", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                  return "-1";
              }
              catch (Exception exception)
              {
                  LogTransaccional.LanzarSIMAExcepcionDominio("JobsSystem", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                  return "-1";
              }
            return "";
        }
        public string ModificaInsertar(personal opersonal)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, opersonal.ToString());
                string PackagName = "CCTT_uspTADInsCCTT_EvaluacionSI";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("JobsSystem"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );

                //Inserta o actualiza trabajador en el maestro
                ModificaInsertaTrabajador(opersonal);


                string[] dFecha = opersonal.fechaInicio.Split('/');
                
                DateTime dFI = Convert.ToDateTime(opersonal.fechaInicio);
                DateTime dFT = Convert.ToDateTime(opersonal.fechaVencimiento);
                string nrodoc = opersonal.nroDoc.Replace("\"", "");

                string nYear = DateTime.Now.Year.ToString();
                string nYearMonth = nYear + DateTime.Now.Month.ToString().PadLeft(2, '0');
                int Nota = Int32.Parse(opersonal.notaProm.Split('.')[0]);

                string idResult = Convert.ToString(Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName, nrodoc
                                                                                                        , dFI
                                                                                                        , dFT
                                                                                                        , Convert.ToInt32(opersonal.aprobado)
                                                                                                        , Nota
                                                                                                        , nYearMonth
                                                                                                        , -1
                                                                                                        , nYear
                                                                                                        , "0000"
                                                                                                    ));

               
                
                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("JobsSystem"
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
                LogTransaccional.LanzarSIMAExcepcionDominio("JobsSystem", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("JobsSystem", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
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
