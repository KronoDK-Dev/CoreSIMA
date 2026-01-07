using EntidadNegocio;
using EntidadNegocio.HelpDesk;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.HelpDesk
{
    public class ArchivoAdjuntoTAD : BaseAD, IMantenimientoTAD
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
            ArchivoAdjuntoBE oArchivoAdjuntoBE = (ArchivoAdjuntoBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oArchivoAdjuntoBE.ToString(true));
                string PackagName = "NSASERVICE.PKG_HD_TAD.IArchivoRqr";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oArchivoAdjuntoBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] Param = new OracleParameter[7];

                Param[0] = new OracleParameter("oModo", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = 3;

                Param[1] = new OracleParameter("ID_ATTACH", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oArchivoAdjuntoBE.IdFile;


                Param[2] = new OracleParameter("ID_REQU", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oArchivoAdjuntoBE.IdRequerimiento;



                Param[3] = new OracleParameter("NOMBRE", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oArchivoAdjuntoBE.Nombre;

                Param[4] = new OracleParameter("DESCRIPCION", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oArchivoAdjuntoBE.Descripcion;


                Param[5] = new OracleParameter("USU_AD", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oArchivoAdjuntoBE.IdUsuario;


                Param[6] = new OracleParameter("IdOut", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Output;
                Param[6].Size = 15;

                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Param);
              

                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oArchivoAdjuntoBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + ParamsOut.ToString()
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));





                return ParamsOut;
            }

            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oArchivoAdjuntoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oArchivoAdjuntoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
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
