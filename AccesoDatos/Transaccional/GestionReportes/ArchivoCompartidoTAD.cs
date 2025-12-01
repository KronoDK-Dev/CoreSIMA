using EntidadNegocio;
using EntidadNegocio.GestionReportes;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.GestionReportes
{
    public class ArchivoCompartidoTAD : BaseAD, IMantenimientoTAD
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
            ArchivoCompartidoBE oArchivoCompartidoBE = (ArchivoCompartidoBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE =
                    (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oArchivoCompartidoBE.ToString(true));
                string PackagName = "GESTIONREPORTE.RPT_uspTADCompartirArchivo";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oArchivoCompartidoBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                string idResult = Convert.ToString(Sql(SQLVersion.sqlSIMANET).ExecuteNonQuery(PackagName,
                    oArchivoCompartidoBE.IdCompartido
                    , oArchivoCompartidoBE.IdObjeto
                    , oArchivoCompartidoBE.IdUsuarioComp
                    , oArchivoCompartidoBE.IdUsuario
                    , oArchivoCompartidoBE.IdEstado
                ));

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oArchivoCompartidoBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , ""
                    , "Return ID:" + idResult
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return idResult;
            }
            catch (SqlException sqlException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oArchivoCompartidoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + sqlException.Number.ToString()), "Código de Error:" + sqlException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + sqlException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oArchivoCompartidoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
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
