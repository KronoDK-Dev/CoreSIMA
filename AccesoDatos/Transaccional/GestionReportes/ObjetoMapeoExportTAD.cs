using EntidadNegocio;
using EntidadNegocio.GestionReportes;
using Log;
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
    public class ObjetoMapeoExportTAD : BaseAD, IMantenimientoTAD
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
            throw new NotImplementedException();
        }

        public int ModificarInsertar(BaseBE oBaseBE)
        {
            ObjetoMapeoExportBE oObjetoMapeoExportBE = (ObjetoMapeoExportBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oObjetoMapeoExportBE.ToString(true));
                string PackagName = "GESTIONREPORTE.CALuspTADInsActObjetoMapeoExport";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oObjetoMapeoExportBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                int idResult = Convert.ToInt32(Sql(SQLVersion.sqlSIMANET).ExecuteNonQuery(PackagName, oObjetoMapeoExportBE.IdDataField
                                                                                                        , oObjetoMapeoExportBE.IdDataFieldPadre
                                                                                                        , oObjetoMapeoExportBE.Nombre
                                                                                                        , oObjetoMapeoExportBE.Alias
                                                                                                        , oObjetoMapeoExportBE.Descripcion
                                                                                                        , oObjetoMapeoExportBE.Tipo
                                                                                                        , oObjetoMapeoExportBE.FieldCompute
                                                                                                        , oObjetoMapeoExportBE.Exportar
                                                                                                        , oObjetoMapeoExportBE.Orden
                                                                                                        , oObjetoMapeoExportBE.Prioridad
                                                                                                        , oObjetoMapeoExportBE.IdObjeto
                                                                                                        , oObjetoMapeoExportBE.IdUsuario
                                                                                                        , oObjetoMapeoExportBE.IdEstado
                                                                                                    ));

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oObjetoMapeoExportBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oObjetoMapeoExportBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return -1;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oObjetoMapeoExportBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return -1;
            }
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
