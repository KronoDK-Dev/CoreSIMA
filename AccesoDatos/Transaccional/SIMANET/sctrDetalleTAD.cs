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

namespace AccesoDatos.Transaccional.SIMANET
{
    public class sctrDetalleTAD : BaseAD, IMantenimientoTAD
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
            CCTT_SctrDetalleBE oCCTT_SctrDetalleBE = (CCTT_SctrDetalleBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oCCTT_SctrDetalleBE.ToString(true));
                string PackagName = "CCTTuspTADinsactSCTR_Detalle_ns";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_SctrDetalleBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName
                                                                                , oCCTT_SctrDetalleBE.IdSCTR
                                                                                , oCCTT_SctrDetalleBE.IdDetalleSCTR
                                                                                , oCCTT_SctrDetalleBE.NroDNI
                                                                                , oCCTT_SctrDetalleBE.IdEstado
                                                                                , oCCTT_SctrDetalleBE.IdUsuario
                                                                                );

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_SctrDetalleBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_SctrDetalleBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_SctrDetalleBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
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
            CCTT_SctrDetalleBE oCCTT_SctrDetalleBE = (CCTT_SctrDetalleBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oCCTT_SctrDetalleBE.ToString(true));
                string PackagName = "CCTTuspTADinsactSCTR_Detalle2";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_SctrDetalleBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName
                                                                                , oCCTT_SctrDetalleBE.IdSCTR
                                                                                , oCCTT_SctrDetalleBE.IdDetalleSCTR
                                                                                , oCCTT_SctrDetalleBE.NroDNI
                                                                                , oCCTT_SctrDetalleBE.tFechaInicio
                                                                                , oCCTT_SctrDetalleBE.tFechaVence
                                                                                , oCCTT_SctrDetalleBE.IdEstado
                                                                                , oCCTT_SctrDetalleBE.Observacion
                                                                                , oCCTT_SctrDetalleBE.IdUsuario
                                                                                );

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_SctrDetalleBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_SctrDetalleBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_SctrDetalleBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
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
