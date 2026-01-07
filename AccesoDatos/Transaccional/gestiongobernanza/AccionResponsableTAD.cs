using EntidadNegocio;
using EntidadNegocio.GestionGobernanza;
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

namespace AccesoDatos.Transaccional.GestionGobernanza
{
    public class AccionResponsableTAD : BaseAD, IMantenimientoTAD
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
            ObjAccIndRecBE oObjAccIndRecBE = (ObjAccIndRecBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oObjAccIndRecBE.ToString(true));
                string PackagName = "GOBERNANZA.PKG_INDICADOR_TAD.IResponsable";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oObjAccIndRecBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] Param = new OracleParameter[6];

                Param[0] = new OracleParameter("oModo", OracleDbType.Int64);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = 3;

                Param[1] = new OracleParameter("IDITEM", OracleDbType.Int64);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oObjAccIndRecBE.IdItemTabla;

                Param[2] = new OracleParameter("CODAREA", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oObjAccIndRecBE.Nombre;

                Param[3] = new OracleParameter("DESCRIPCION", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oObjAccIndRecBE.Descripcion;


                Param[4] = new OracleParameter("IDACCION", OracleDbType.Int64);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oObjAccIndRecBE.IdItemRelacion;

                Param[5] = new OracleParameter("IdOut", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Output;
                Param[5].Size = 15;

                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Param);

                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oObjAccIndRecBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + ParamsOut.ToString()
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));





                return "1";
            }

            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oObjAccIndRecBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oObjAccIndRecBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
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
