using EntidadNegocio;
using EntidadNegocio.SIMANET.SeguridadPlanta;
using Log;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO; // para File.Move
using Utilitario;
// no usadas
/*
using static AccesoDatos.BaseAD;
using static Utilitario.Helper;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
*/

namespace AccesoDatos.Transaccional.GestionSeguridadPlanta
{
    public class VisitasTAD: BaseAD
    {
        //readonly string sComercial = ConfigurationManager.AppSettings["E_COMERCIAL"];
        private string VSTRutaLocalTMP // origen
        {
            get { return ConfigurationManager.AppSettings["RutaLocaVSTTMP"].ToString(); }
        }
        private string VSTRutaLocal // destino
        {
            get { return ConfigurationManager.AppSettings["RutaLocaVST"].ToString(); }
        }
        public string Inserta(BaseBE oBaseBE, string LstCorreos = "", string LstAnexos = "")
        {
            // Manejo de transacciones en Microsoft.Practices.EnterpriseLibrary.Data.
           string sCodigo="";
            ProgramacionBE oCCTT_ProgramacionBE = (ProgramacionBE)oBaseBE;
            Database db = Sql(SQLVersion.sqlSIMANET);


           using (DbConnection cn = db.CreateConnection())
           { cn.Open();
              using (DbTransaction tran = cn.BeginTransaction())
              {


                    // Este metodo insertará en varias tablas, usando dos procedemientos almcenados
                    // por lo que se hará uso de transacciones para asegurar la integridad de los datos. Si el primer procedimiento se ejecuta correctamente pero el segundo falla, se hará un rollback de toda la transacción para evitar datos inconsistentes.

                    try
                    {
                      //  StackTrace stack = new StackTrace();// Costo de rendimiento alto,   StackTrace es caro(usa reflexión + metadatos del runtime)
                      //  string NombreMetodo = stack.GetFrame(0).GetMethod().Name;
                        string NombreMetodo = nameof(Inserta);
                        InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oCCTT_ProgramacionBE.ToString(true));

                        /* **************************************** */
                        /* **** (1) Inserta los Cabera Visita ****  */
                        /* **************************************** */

                        #region "visita"
                        string PackagName = "CVSTuspTADinsProgramacionVisita";

                        LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionBE.UserName
                                                                                              , oInfoMetodoBE.FullName
                                                                                              , NombreMetodo
                                                                                              , PackagName
                                                                                              , oInfoMetodoBE.VoidParams
                                                                                              , ""
                                                                                              , Helper.MensajesIngresarMetodo()
                                                                                              , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                          );

                        //object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName,
                        //  db.ExecuteScalar es propio de la libreria: Microsoft.Practices.EnterpriseLibrary.Data
                        object idResult = db.ExecuteScalar(tran, PackagName,
                                        oCCTT_ProgramacionBE.ID_TIPO_VISITA,
                                        oCCTT_ProgramacionBE.ID_ENTIDAD,
                                        oCCTT_ProgramacionBE.ID_LUGAR_TRABAJO,
                                        oCCTT_ProgramacionBE.FECHA_INICIO,
                                        oCCTT_ProgramacionBE.FECHA_TERMINO,
                                        oCCTT_ProgramacionBE.HORA_INICIO,
                                        oCCTT_ProgramacionBE.HORA_TERMINO,
                                        oCCTT_ProgramacionBE.ID_CIA_SEGUROS,
                                        oCCTT_ProgramacionBE.NRO_POLIZA,
                                        oCCTT_ProgramacionBE.OBSERVACIONES,
                                        oCCTT_ProgramacionBE.IdUsuario,
                                        oCCTT_ProgramacionBE.TIPO_PROGRAMACION,
                                        oCCTT_ProgramacionBE.IdUsuario,
                                        oCCTT_ProgramacionBE.IdEstado
                                         );

                        LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionBE.UserName
                                                                                              , oInfoMetodoBE.FullName
                                                                                              , NombreMetodo
                                                                                              , PackagName
                                                                                              , oInfoMetodoBE.VoidParams
                                                                                              , sCodigo
                                                                                              , Helper.MensajesSalirMetodo()
                                                                                              , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                          );
                        if (idResult == null || idResult == DBNull.Value)
                        {
                            throw new Exception("El SP principal no retornó el ID de programación.");
                        }

                   #endregion

                        //----------------
                        sCodigo = idResult.ToString();

                        /* ************************************* */
                        /* *** (2) Inserta los  contactos  ****  */
                        /* ************************************* */

                        #region "Correos"
                        if (!string.IsNullOrWhiteSpace(LstCorreos))
                        {


                        string[] EmailContacto = LstCorreos.Split('*'); //caracter separador para los contactos es el asterisco (*)
                        string CADENA;
                        CorreosConocimientoBE oCCTT_EMailConocimientoBE = new CorreosConocimientoBE();
                        //    CCTT_EMailConocimientoBE oCCTT_EMailConocimientoBE = new CCTT_EMailConocimientoBE();

                        for (int c = 0; c < EmailContacto.Length; c++)
                        {
                            CADENA = EmailContacto[c].Trim();
                            if (CADENA.Length > 0)
                            {
                                string[] ContactoAtributos = EmailContacto[c].Split(';');
                                
                                    if (ContactoAtributos.Length == 0) // validamos datos
                                      throw new Exception("Formato inválido en LstCorreos");
                                    // llenamos la entidad
                                    oCCTT_EMailConocimientoBE.Periodo = oCCTT_ProgramacionBE.PERIODO;
                                oCCTT_EMailConocimientoBE.NroProgramacion = Convert.ToInt32(sCodigo);
                                oCCTT_EMailConocimientoBE.IdPersonal = Convert.ToInt32(ContactoAtributos[0]);
                                oCCTT_EMailConocimientoBE.Enviado = 0;
                                oCCTT_EMailConocimientoBE.IdEstado = 1;
                                //----- INSERCCION DE CORREOS ----

                                PackagName = "CCTT_uspNTADinsactEMailConocimiento";
                                object idResult2 = db.ExecuteScalar(tran, PackagName,
                                      oCCTT_ProgramacionBE.PERIODO,
                                      oCCTT_EMailConocimientoBE.NroProgramacion,
                                      oCCTT_EMailConocimientoBE.IdPersonal,
                                      oCCTT_EMailConocimientoBE.Enviado,
                                      oCCTT_EMailConocimientoBE.IdEstado,
                                      oCCTT_ProgramacionBE.IdUsuario
                                       );
                                // en caso falle:

                                if (idResult2 == null || idResult2 == DBNull.Value)
                                {
                                    throw new Exception("Error al insertar correo de conocimiento");
                                }

                                    LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_ProgramacionBE.UserName
                                                                    , oInfoMetodoBE.FullName
                                                                    , NombreMetodo
                                                                    , PackagName
                                                                    , oInfoMetodoBE.VoidParams
                                                                    , idResult2.ToString()
                                                                    , Helper.MensajesSalirMetodo()
                                                                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                );

                                }
                        }

  
                        }
                        #endregion
                        //-----------


                        /* ****************************************** */
                        /* *** (3) Inserta los archivos adjuntos ***  */
                        /* ****************************************** */

                        #region "Anexos"
                        if (!string.IsNullOrWhiteSpace(LstAnexos)) // solo si hay anexos, se procesan
                        {
                            string[] LstAnexosArray = LstAnexos.Split('@');
                            string CADENA;
                            AnexosBE oCCTT_ArchivosAnexoBE = new AnexosBE();
                            for (int c = 0; c <= LstAnexosArray.Length - 1; c++)
                            {
                                CADENA = LstAnexosArray[c].Trim();
                                if (CADENA.Length > 0)
                                {
                                    string[] AnexoAtributo = LstAnexosArray[c].Split(';');
                                    
                                    oCCTT_ArchivosAnexoBE.Periodo = oCCTT_ProgramacionBE.PERIODO;
                                    oCCTT_ArchivosAnexoBE.NroProgramacion = Convert.ToInt32(sCodigo);
                                    oCCTT_ArchivosAnexoBE.NroArchivo = Convert.ToInt32(AnexoAtributo[0]);
                                    oCCTT_ArchivosAnexoBE.Nombre = Convert.ToString(AnexoAtributo[1]);
                                    
                                    // CCTTuspTADinsactCCTT_ArchivosAnexo - CCTT_ArchivosAnexo
                                    
                                    /*Mover Archivos*/
                                    string NFile = VSTRutaLocalTMP + oCCTT_ProgramacionBE.IdUsuario.ToString() + oCCTT_ArchivosAnexoBE.Nombre;
                                    string NFileFinal = VSTRutaLocal + oCCTT_ProgramacionBE.PERIODO.ToString() + sCodigo.ToString() + oCCTT_ArchivosAnexoBE.Nombre;
                                    try
                                    {
                                        File.Move(NFile, NFileFinal);
                                    }
                                    catch (Exception ex)
                                    {
                                        string msg = ex.Message;
                                    }

                                }
                            }

                        }

                            #endregion

                        tran.Commit(); // para transacción.
                        return sCodigo;

                    }
                    catch (SqlException sqlException)
                    {
                        LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_ProgramacionBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + sqlException.Number.ToString()), "Código de Error:" + sqlException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + sqlException.Message);
                        tran.Rollback(); // para transacción.
                        return "-1";
                    }
                    catch (Exception exception)
                    {
                        LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_ProgramacionBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                        tran.Rollback(); // para transacción.
                        return "-1";
                    }

                    // ----- fin de transacción
                }
            }
        }


        public string Copiar(int Periodo, int IdProgramacion, int IdUsuario, string UserName)
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
                object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName, Periodo, IdProgramacion, IdUsuario);

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




    }
}
