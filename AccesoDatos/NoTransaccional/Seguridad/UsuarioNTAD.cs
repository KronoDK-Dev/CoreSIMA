using EntidadNegocio.Seguridad;
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

namespace AccesoDatos.NoTransaccional.Seguridad
{
    public class UsuarioNTAD : BaseAD
    {
        public DataTable GetUserInfo(int idUser, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name + "()";
                StackFrame frame = stack.GetFrame(0);
                string className = frame.GetMethod().DeclaringType.ToString();

                string PackagName = "USPOBTINFOUSU";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , className
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , "IdUser:" + idUser.ToString() + Utilitario.Constante.Caracteres.SeparadorLinea + "UserName:" + UserName
                                                                                     , "", Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.C))
                                                                 );

                DataSet ds = Sql(SQLVersion.sqlSeguridad).ExecuteDataSet(PackagName, idUser);


                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , className
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.C)));


                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return ds.Tables[0];
            }

            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public UsuarioBE GetDatosUsuario(int idUser)
        {
            string UserName = "";
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, idUser.ToString(), UserName);
                string PackagName = "NTADuspObtenerDatosdeUsuario";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );

                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, idUser);


                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));


                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                DataRow dr = ds.Tables[0].Rows[0];
                UsuarioBE oUsuarioBE = new UsuarioBE();
                oUsuarioBE.ApellidosyNombres = dr["ApellidosyNombres"].ToString();
                oUsuarioBE.Login = dr["Login"].ToString();
                oUsuarioBE.NroDocumento = dr["NroDocDNI"].ToString();
                oUsuarioBE.Area = dr["NombreArea"].ToString();
                oUsuarioBE.Email = dr["Email"].ToString();
                oUsuarioBE.IdPersonal = Convert.ToInt32(dr["IdPersonal"].ToString());

                oUsuarioBE.IdCentroOperativo = dr["IdCentroOperativo"] == DBNull.Value || string.IsNullOrEmpty(dr["IdCentroOperativo"].ToString())
                                                ? 1
                                                : Convert.ToInt32(dr["IdCentroOperativo"].ToString());

                oUsuarioBE.NroCentroOperativo = dr["NroCentroOperativo"] == DBNull.Value || string.IsNullOrEmpty(dr["NroCentroOperativo"].ToString())
                                                ? 1
                                                : Convert.ToInt32(dr["NroCentroOperativo"].ToString());

                oUsuarioBE.CodPersonal = dr["CodPersonal"].ToString();
                oUsuarioBE.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());

                //  Segundo resultset: PaginaInicio (si existe)
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    DataRow drPantalla = ds.Tables[1].Rows[0];
                    oUsuarioBE.Observacion = drPantalla["Pantalla"].ToString();
                    oUsuarioBE.IdEstado = Convert.ToInt32(drPantalla["estado"].ToString());
                }


                return oUsuarioBE;
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }

        }

        public DataTable CodigoUsuario(string s_idUsuario)
        {
            string UserName = "";
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, s_idUsuario.ToString(), UserName);
                string PackagName = "uspNTADConsultarUsuario";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );

                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, s_idUsuario);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));


                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return ds.Tables[0];
                }

            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }

        }

        public int ValidateUser(string login, string password)
        {
            string PackagName = "USPVERIFCTAUSU";
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, login, password);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(login
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , ""
                                                                                        , Helper.MensajesIngresarMetodo(),
                                                                                        Convert.ToString(Enumerados.NivelesErrorLog.I)));

                object usuario = Sql(SQLVersion.sqlSeguridad).ExecuteScalar(PackagName, login, password);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                       , oInfoMetodoBE.FullName
                                                                                       , NombreMetodo
                                                                                       , PackagName
                                                                                       , ""
                                                                                       , oInfoMetodoBE.ToString()
                                                                                       , Helper.MensajesSalirMetodo()
                                                                                       , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                if (usuario != null)
                {
                    LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(login
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , ""
                                                                                        , usuario.ToString()
                                                                                        , Helper.MensajesSalirMetodo(),
                                                                                        Convert.ToString(Enumerados.NivelesErrorLog.I)));
                    return Convert.ToInt32(usuario);
                }
                else
                {
                    LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , ""
                                                                                        , 0.ToString()
                                                                                        , Helper.MensajesSalirMetodo(),
                                                                                        Convert.ToString(Enumerados.NivelesErrorLog.I)));
                    return 0;
                }
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("USER", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return 0;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("USER", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return 0;
            }
        }

        public int ValidateUser(string login)
        {
            string PackagName = "USPVERIFCTAUSUAD";
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, login);
                //Graba en el Log Ingreso a Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UseName"
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , ""
                                                                                        , Helper.MensajesIngresarMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));


                object usuario = Sql(SQLVersion.sqlSeguridad).ExecuteScalar(PackagName, login);

                if (usuario != null)
                {
                    LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , ""
                                                                                        , usuario.ToString()
                                                                                        , Helper.MensajesSalirMetodo(),
                                                                                        Convert.ToString(Enumerados.NivelesErrorLog.C)));
                    return Convert.ToInt32(usuario);
                }
                else
                {
                    LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , ""
                                                                                        , 0.ToString()
                                                                                        , Helper.MensajesSalirMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));
                    return 0;
                }
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("USER", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return 0;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("USER", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return 0;
            }
        }

        public int ValidateUserAD(string login, string password, string cadenaLDAP)
        {
            int iDUser = ValidateUser(login);

            if (iDUser == Utilitario.Constante.Caracteres.ValorConstanteCero)
            {
                return iDUser;
            }
            else
            {
                try
                {
                    AD oAD = new AD(cadenaLDAP);
                    if (oAD.ValidarUsuario(login, password))
                        return iDUser;
                    else
                        return Utilitario.Constante.Caracteres.ValorConstanteCero;
                }
                catch
                {
                    return Utilitario.Constante.Caracteres.ValorConstanteCero;
                }
            }
        }

        public bool VerificaCaducidadUser(int IdUsuario)
        {
            string PackagName = "SEGuspNTADVerificaCaducidad";
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, IdUsuario.ToString());

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , ""
                                                                                        , Helper.MensajesIngresarMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                int Caduca = Convert.ToInt32(Sql(SQLVersion.sqlSeguridad).ExecuteScalar(PackagName, IdUsuario));

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName", oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , Caduca.ToString()
                                                                                        , Helper.MensajesSalirMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));
                return ((Caduca == 0) ? true : false);
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("user", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return false;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("user", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return false;
            }
        }

        public DataTable GetOptionsByProfile(int idSystem, int idProfile, string pagina)
        {
            string PackagName = "USPOBTOPCXPERF";

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, idSystem.ToString(), idProfile.ToString(), pagina);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName", oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , ""
                                                                                        , Helper.MensajesIngresarMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));


                DataSet ds = Sql(SQLVersion.sqlSeguridad).ExecuteDataSet(PackagName, idSystem, idProfile, pagina);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                       , oInfoMetodoBE.FullName
                                                                                       , NombreMetodo
                                                                                       , PackagName
                                                                                       , ""
                                                                                       , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                                                                                       , Helper.MensajesSalirMetodo()
                                                                                       , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return ds.Tables[0];
                }
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("user", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("user", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }


        public DataTable GetPerfilAccesoDirecto(int idSystem, int idUsuario)
        {
            string PackagName = "SEG_uspNTADListaOPPadreAccesoDirecto";

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, idSystem.ToString(), idUsuario.ToString());

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                DataSet ds = Sql(SQLVersion.sqlSeguridad).ExecuteDataSet(PackagName, idSystem, idUsuario);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional("UserName"
                                                                                      , oInfoMetodoBE.FullName
                                                                                      , NombreMetodo
                                                                                      , PackagName
                                                                                      , ""
                                                                                      , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                                                                                      , Helper.MensajesSalirMetodo()
                                                                                      , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return ds.Tables[0];
                }
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("user", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio("user", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }
    }
}
