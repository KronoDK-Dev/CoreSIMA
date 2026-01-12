using EntidadNegocio;
using EntidadNegocio.GestionCalidad;
using Log;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;
using EntidadNegocio.GestionPersonal;
using System.Data.OleDb;
using System.Data;
using Oracle.DataAccess.Client;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Contracts;
using EntidadNegocio.HelpDesk.ChatBot;
using System.CodeDom;
using EntidadNegocio.GestionReportes;
namespace AccesoDatos.Transaccional.HelpDesk.ChatBot
{
    public class CBMensajeContendidoTAD : BaseAD, IMantenimientoTAD
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
            /*
             * EJEMPLO DE CARGAR EN UN CAMPO CLOB
             * https://es.stackoverflow.com/questions/273947/como-llamar-un-procedimiento-almacenado-de-oracle-desde-c
             */
            MensajeContenidoBE oMensajeContenidoBE = (MensajeContenidoBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oMensajeContenidoBE.ToString(true));
                string PackagName = "SMGENERAL.PKG_WCHAT_SRV_TAD.IDialogo";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oMensajeContenidoBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));


                OracleParameter[] Param = new OracleParameter[10];
                Param[0] = new OracleParameter("ID_MIEMBRO", OracleDbType.Int64);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = Convert.ToInt64(oMensajeContenidoBE.IdMiembro);

                Param[1] = new OracleParameter("TEXT", OracleDbType.Clob);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oMensajeContenidoBE.Texto;

                Param[2] = new OracleParameter("ID_CONTACT_ORG", OracleDbType.Int64);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = Convert.ToInt64(oMensajeContenidoBE.IdContactoOrigen);

                Param[3] = new OracleParameter("ID_CONTACT_DES", OracleDbType.Int64);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = Convert.ToInt64(oMensajeContenidoBE.IdContactoDestino);

                Param[4] = new OracleParameter("IDTBLINFO", OracleDbType.Int64);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oMensajeContenidoBE.IdTablaInfo;

                Param[5] = new OracleParameter("IDINFO", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oMensajeContenidoBE.IdInfo;

                Param[6] = new OracleParameter("USUARIO", OracleDbType.Int64);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = Convert.ToInt64(oMensajeContenidoBE.IdUsuario);

                Param[7] = new OracleParameter("OutIdMsg", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Output;
                Param[7].Size = 20;

                Param[8] = new OracleParameter("OutIdContenido", OracleDbType.Varchar2);
                Param[8].Direction = ParameterDirection.Output;
                Param[8].Size = 20;


                Param[9] = new OracleParameter("OutIdRecip", OracleDbType.Varchar2);
                Param[9].Direction = ParameterDirection.Output;
                Param[9].Size = 20;

                string  ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Param);

                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oMensajeContenidoBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oMensajeContenidoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oMensajeContenidoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
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
            throw new NotImplementedException();
        }

        public int ModificarInsertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }
    }
}
