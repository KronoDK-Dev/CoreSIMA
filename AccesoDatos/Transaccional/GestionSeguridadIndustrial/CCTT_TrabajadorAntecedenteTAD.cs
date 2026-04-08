using EntidadNegocio;
using EntidadNegocio.GestionSeguridadIndustrial;
using Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.GestionSeguridadIndustrial
{
    public class CCTT_TrabajadorAntecedenteTAD : BaseAD, IMantenimientoTAD
    {
        public int Eliminar()
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1)
        {
            try
            {
                string PackagName = "CCTTuspTADeliAntecedenteTrabajadorContratista";

                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, Id1);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(Id1
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , ""
                                                                                        , Helper.MensajesIngresarMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                var result = Sql(SQLVersion.sqlSIMANET).ExecuteNonQuery(PackagName, Id1);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(Id1
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , ""
                                                                                        , Helper.MensajesSalirMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                return result;
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(Id1, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return -1;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(Id1, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return -1;
            }
        }

        public int Eliminar(string Id1, string Id2)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1, string Id2, string Id3)
        {
            throw new NotImplementedException();
        }

        public string InsertaAnexo(BaseBE oBaseBE)
        {
            AntecedenteAnexoBE oAntecedenteAnexoBE = (AntecedenteAnexoBE)oBaseBE;

            try
            {
                string PackagName = "CCTTuspTADinsAntecedenteAnexoTrabajadorContratista";

                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBaseBE.ToString());

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oAntecedenteAnexoBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                string retorno = "-1";

                try
                {
                    retorno = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName,
                        oAntecedenteAnexoBE.IdAnexo,
                        oAntecedenteAnexoBE.NombreArchivo,
                        oAntecedenteAnexoBE.IdAntecedente,
                        oAntecedenteAnexoBE.IdEstado,
                        oAntecedenteAnexoBE.IdUsuario).ToString();

                    return retorno;
                }
                catch
                {
                    return retorno;
                }
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oAntecedenteAnexoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oAntecedenteAnexoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
        }

        public string Inserta(BaseBE oBaseBE)
        {
            AntecedenteTrabajadorContratistaBE trabajadorContratistaBE = (AntecedenteTrabajadorContratistaBE)oBaseBE;

            try
            {
                string PackagName = "CCTTuspTADinsAntecedenteTrabajadorContratista";

                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBaseBE.ToString());

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(trabajadorContratistaBE.UserName
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , ""
                                                                                        , Helper.MensajesIngresarMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                var result = Sql(SQLVersion.sqlSIMANET).ExecuteScalar(PackagName, trabajadorContratistaBE.NroDNI,
                    trabajadorContratistaBE.Fecha, trabajadorContratistaBE.Hora,trabajadorContratistaBE.IdLugardeTrabajo,
                    trabajadorContratistaBE.LugarCritico, trabajadorContratistaBE.IdTipoAntecedente, trabajadorContratistaBE.Descripcion,
                    trabajadorContratistaBE.IdProveedor, trabajadorContratistaBE.Contratista,trabajadorContratistaBE.IdJefeDirecto,
                    trabajadorContratistaBE.IdPersonalFamiliar, trabajadorContratistaBE.IdParentesco, trabajadorContratistaBE.DescripcioEvento,
                    trabajadorContratistaBE.IdPersonalInterviene, trabajadorContratistaBE.IngresoPermitido,trabajadorContratistaBE.Extension,
                    trabajadorContratistaBE.IdUsuario);

                return result.ToString();
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(trabajadorContratistaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(trabajadorContratistaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
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
            throw new NotImplementedException();
        }

        public int Modificar(BaseBE oBaseBE)
        {
            AntecedenteTrabajadorContratistaBE trabajadorContratistaBE = (AntecedenteTrabajadorContratistaBE)oBaseBE;

            try
            {
                string PackagName = "CCTTuspTADactAntecedenteTrabajadorContratista";

                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oBaseBE.ToString());

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(trabajadorContratistaBE.UserName
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , ""
                                                                                        , Helper.MensajesIngresarMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                var result = Sql(SQLVersion.sqlSIMANET).ExecuteNonQuery(PackagName, trabajadorContratistaBE.IdAntecedente,
                    trabajadorContratistaBE.NroDNI, trabajadorContratistaBE.Fecha, trabajadorContratistaBE.Hora,
                    trabajadorContratistaBE.IdLugardeTrabajo, trabajadorContratistaBE.IdTipoAntecedente, trabajadorContratistaBE.Descripcion,
                    trabajadorContratistaBE.IdProveedor, trabajadorContratistaBE.Contratista, trabajadorContratistaBE.IdJefeDirecto,
                    trabajadorContratistaBE.IdPersonalFamiliar, trabajadorContratistaBE.IdParentesco, trabajadorContratistaBE.DescripcioEvento,
                    trabajadorContratistaBE.IdPersonalInterviene, trabajadorContratistaBE.IngresoPermitido, trabajadorContratistaBE.Extension,
                    trabajadorContratistaBE.IdUsuario);

                return result;
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(trabajadorContratistaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return -1;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(trabajadorContratistaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return -1;
            }
        }

        public int ModificarInsertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }
    }
}