using EntidadNegocio;
using EntidadNegocio.HelpDesk.ChatBot;
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

namespace AccesoDatos.Transaccional.HelpDesk.ChatBot
{
    public class CBContactoGrupoTAD : BaseAD, IMantenimientoTAD
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

        public int Insertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string Inserta(BaseBE oBaseBE)
        {
            CBContactoGrupoBE oCBContactoGrupoBE = (CBContactoGrupoBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oCBContactoGrupoBE.ToString(true));
                string PackagName = "SMGENERAL.PKG_WCHAT_SRV_TAD.IContacto";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCBContactoGrupoBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));


                OracleParameter[] Param = new OracleParameter[9];
                Param[0] = new OracleParameter("IDCONTACTO", OracleDbType.Int64);
                Param[0].Direction = ParameterDirection.InputOutput;
                Param[0].Value = Convert.ToInt64(oCBContactoGrupoBE.IdContacto);

                Param[1] = new OracleParameter("ISGRUPO", OracleDbType.Int64);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = Convert.ToInt64(oCBContactoGrupoBE.IsGrupo);

                Param[2] = new OracleParameter("NOMBRE_GRUPO", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oCBContactoGrupoBE.NombreGrupo;

                Param[3] = new OracleParameter("FOTO_GRUPO", OracleDbType.Clob);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oCBContactoGrupoBE.FotoGrupo;

                Param[4] = new OracleParameter("USUARIO", OracleDbType.Int64);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = Convert.ToInt64(oCBContactoGrupoBE.IdUsuario);

                Param[5] = new OracleParameter("LIB_JS_SRVBROKER", OracleDbType.Varchar2);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oCBContactoGrupoBE.LIB_JS_SRVBROKER;

                Param[6] = new OracleParameter("DESCRIPCION", OracleDbType.Varchar2);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oCBContactoGrupoBE.Descripcion;

                Param[7] = new OracleParameter("IDPERSONAL", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Input;
                Param[7].Value = oCBContactoGrupoBE.CodPersonal;

                Param[8] = new OracleParameter("OUTIDMIEMBRO", OracleDbType.Int64);
                Param[8].Direction = ParameterDirection.Output;
                //Param[4].Value = oCBContactoGrupoBE.IdMiembro;


                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Param);

                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oCBContactoGrupoBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oCBContactoGrupoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oCBContactoGrupoBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
        }

        public string ActualizaEstado(string CodPersonal,int IdEstado,string UserName)
        {
            
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, CodPersonal, IdEstado.ToString(), UserName);
                string PackagName = "SMGENERAL.PKG_WCHAT_SRV_TAD.IContactoEstado";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));


                OracleParameter[] Param = new OracleParameter[2];
                Param[0] = new OracleParameter("pCODPERSONAL", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.InputOutput;
                Param[0].Value = CodPersonal;

                Param[1] = new OracleParameter("pIDESTADO", OracleDbType.Int64);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = Convert.ToInt64(IdEstado);


                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Param);

                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
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
