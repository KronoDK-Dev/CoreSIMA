using EntidadNegocio;
using EntidadNegocio.HelpDesk.ITIL;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.HelpDesk.ITIL
{
    public class ServiciosTAD : BaseAD, IMantenimientoTAD
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
            ServicioBE oServicioBE = (ServicioBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oServicioBE.ToString(true));
                string PackagName = "NSASERVICE.PKG_ITIL_TAD.IServicio";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oServicioBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] Param = new OracleParameter[8];
                Param[0] = new OracleParameter("ID_SERV_PROD", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = oServicioBE.IdServicioProducto;

                Param[1] = new OracleParameter("ID_PADRE", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oServicioBE.IdPadre;

                Param[2] = new OracleParameter("NOMBRE", OracleDbType.Varchar2);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oServicioBE.Nombre;

                Param[3] = new OracleParameter("DESCRIPCION", OracleDbType.Varchar2);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oServicioBE.Descripcion;

                Param[4] = new OracleParameter("INTERNO", OracleDbType.Int64);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = oServicioBE.Interno;

                Param[5] = new OracleParameter("PRODUCTO", OracleDbType.Int64);
                Param[5].Direction = ParameterDirection.Input;
                Param[5].Value = oServicioBE.Producto;

                Param[6] = new OracleParameter("USU_ADD", OracleDbType.Int64);
                Param[6].Direction = ParameterDirection.Input;
                Param[6].Value = oServicioBE.IdUsuario;

                Param[7] = new OracleParameter("IdOut", OracleDbType.Varchar2);
                Param[7].Direction = ParameterDirection.Output;
                Param[7].Size = 15;

                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Param);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oServicioBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oServicioBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oServicioBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
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

        public string AsignarActividad(BaseBE oBaseBE)
        {
            ServicioActividadBE oServicioActividadBE = (ServicioActividadBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oServicioActividadBE.ToString(true));
                string PackagName = "NSASERVICE.PKG_ITIL_TAD.IServicioActividad";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oServicioActividadBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] Param = new OracleParameter[5];
                Param[0] = new OracleParameter("pID_SERV_PROD", OracleDbType.Varchar2);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = oServicioActividadBE.IdServicioProducto;

                Param[1] = new OracleParameter("pID_ACTIVIDAD", OracleDbType.Varchar2);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = oServicioActividadBE.IdActividad;

                Param[2] = new OracleParameter("pID_ESTADO", OracleDbType.Int32);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = oServicioActividadBE.IdEstado;

                Param[3] = new OracleParameter("pUSU_ADD", OracleDbType.Int32);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = oServicioActividadBE.IdUsuario;

                Param[4] = new OracleParameter("IdOut", OracleDbType.Varchar2);
                Param[4].Direction = ParameterDirection.Output;
                Param[4].Size = 15;

                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, Param);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oServicioActividadBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oServicioActividadBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oServicioActividadBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
        }

        public string ServicioArea(BaseBE oBaseBE)
        {
            ServicioAreaBE oServicioAreaBE = (ServicioAreaBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oServicioAreaBE.ToString(true));
                string PackagName = "NSASERVICE.PKG_ITIL_TAD.IServicioArea";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oServicioAreaBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] oParam = new OracleParameter[7];
                oParam[0] = new OracleParameter("pID_SERV_AREA", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = oServicioAreaBE.IdServicioArea;

                oParam[1] = new OracleParameter("pID_SERV_PROD", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = oServicioAreaBE.IdServicioProducto;

                oParam[2] = new OracleParameter("pCOD_EMP", OracleDbType.Char);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = oServicioAreaBE.CodEmp;

                oParam[3] = new OracleParameter("pCOD_SUC", OracleDbType.Char);
                oParam[3].Direction = ParameterDirection.Input;
                oParam[3].Value = oServicioAreaBE.CodSuc;

                oParam[4] = new OracleParameter("pCOD_AREA", OracleDbType.Char);
                oParam[4].Direction = ParameterDirection.Input;
                oParam[4].Value = oServicioAreaBE.CodArea;

                oParam[5] = new OracleParameter("pUSU_ADD", OracleDbType.Int32);
                oParam[5].Direction = ParameterDirection.Input;
                oParam[5].Value = oServicioAreaBE.IdUsuario;

                oParam[6] = new OracleParameter("IdOut", OracleDbType.Varchar2);
                oParam[6].Direction = ParameterDirection.Output;
                oParam[6].Size = 15;

                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oServicioAreaBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oServicioAreaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oServicioAreaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
        }

        public string ServicioResponsable(BaseBE oBaseBE)
        {
            ServicioResponsableBE oServicioResponsableBE = (ServicioResponsableBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE =
                    (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oServicioResponsableBE.ToString(true));
                string PackagName = "NSASERVICE.PKG_ITIL_TAD.IServicioResponsable";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oServicioResponsableBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackagName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                OracleParameter[] oParam = new OracleParameter[6];
                oParam[0] = new OracleParameter("pID_RESPONSABLE", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = oServicioResponsableBE.pID_RESPONSABLE;

                oParam[1] = new OracleParameter("pID_SERV_AREA", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = oServicioResponsableBE.pID_SERV_AREA;

                oParam[2] = new OracleParameter("pID_PERSONAL", OracleDbType.Int32);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = oServicioResponsableBE.pID_PERSONAL;

                oParam[3] = new OracleParameter("pPRINCIPAL", OracleDbType.Int32);
                oParam[3].Direction = ParameterDirection.Input;
                oParam[3].Value = oServicioResponsableBE.pPRINCIPAL;

                oParam[4] = new OracleParameter("pUSU_ADD", OracleDbType.Int32);
                oParam[4].Direction = ParameterDirection.Input;
                oParam[4].Value = oServicioResponsableBE.IdUsuario;

                oParam[5] = new OracleParameter("IdOut", OracleDbType.Varchar2);
                oParam[5].Direction = ParameterDirection.Output;
                oParam[5].Size = 15;

                string ParamsOut = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oServicioResponsableBE.UserName
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
                LogTransaccional.LanzarSIMAExcepcionDominio(oServicioResponsableBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return "-1";
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oServicioResponsableBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return "-1";
            }
        }
    }
}
