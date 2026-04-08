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
    public class ProgramacionEquiposTAD : BaseAD, IMantenimientoTAD
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
        public int Eliminar(string Periodo, string IdProgramacion, string IdItem,int IdUsuario,string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, Periodo, IdProgramacion, IdItem, UserName);
                string PackagName = "CCTTuspTADeliProgramacion_CtrlEquipos";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName
                                                                                    , Periodo
                                                                                    , IdProgramacion
                                                                                    , IdItem
                                                                                    , IdUsuario
                                                                                   );

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
                return -1;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return -1;
            }
        }

        public string Inserta(BaseBE oBaseBE)
        {
            CCTT_Programacion_CtrlEquiposBE oCCTT_Programacion_CtrlEquiposBE = (CCTT_Programacion_CtrlEquiposBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oCCTT_Programacion_CtrlEquiposBE.ToString(true));
                string PackagName = "CCTTuspTADinsProgramacion_CtrlEquipos";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_Programacion_CtrlEquiposBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.NroProgramacion
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.Periodo
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.Codigo
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.Descripcion
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.Cantidad
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.IdTipoInOut
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.NroProgramacionRel
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.PeriodoRel
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.IdUsuario
                                                                                        );

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_Programacion_CtrlEquiposBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_Programacion_CtrlEquiposBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_Programacion_CtrlEquiposBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
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
        

        public int Insertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string Modifica(BaseBE oBaseBE)
        {
            CCTT_Programacion_CtrlEquiposBE oCCTT_Programacion_CtrlEquiposBE = (CCTT_Programacion_CtrlEquiposBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oCCTT_Programacion_CtrlEquiposBE.ToString(true));
                string PackagName = "CCTTuspTADactProgramacion_CtrlEquipos";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_Programacion_CtrlEquiposBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                object idResult = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.NroProgramacion
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.Periodo
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.NroItem
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.Codigo
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.Descripcion
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.Cantidad
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.IdTipoInOut
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.NroProgramacionRel
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.PeriodoRel
                                                                                    , oCCTT_Programacion_CtrlEquiposBE.IdUsuario
                                                                                        );

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCCTT_Programacion_CtrlEquiposBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_Programacion_CtrlEquiposBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oCCTT_Programacion_CtrlEquiposBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            return "";
        }
    }
}