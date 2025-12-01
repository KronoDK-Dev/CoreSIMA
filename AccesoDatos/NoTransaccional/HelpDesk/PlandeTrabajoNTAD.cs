using EntidadNegocio;
using EntidadNegocio.HelpDesk;
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

namespace AccesoDatos.NoTransaccional.HelpDesk
{
    public class PlandeTrabajoNTAD : BaseAD, IMantenimientoNTAD
    {
        public DataTable ListarTodos()
        {
            throw new NotImplementedException();
        }

        public DataTable ListarTodos(string Id1, string UserName)
        {
            return ListarPlan("0", Id1, UserName);
        }

        public DataTable ListarPlan(string IdPlan, string Id1, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, IdPlan, Id1.ToString(), UserName);
                string PackagName = "NSASERVICE.PKG_HD_ATENCION_NTAD.iPlanTrabajo";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );

                OracleParameter[] oParam = new OracleParameter[3];
                oParam[0] = new OracleParameter("PIDPLAN", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = IdPlan;

                oParam[1] = new OracleParameter("PID_REQU", OracleDbType.Varchar2);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = Id1;

                oParam[2] = new OracleParameter("rstOut", OracleDbType.RefCursor);
                oParam[2].Direction = ParameterDirection.Output;

                DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackagName, oParam);
                
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

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

        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName)
        {
            throw new NotImplementedException();
        }

        public DataTable Buscar(string TextFind, string UserName)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1, string UserName)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1, string Id2, string UserName)
        {
            DataRow dr = ListarPlan(Id1, Id2, UserName).Rows[0];
            PlandeTrabajoBE oPlandeTrabajoBE = new PlandeTrabajoBE();
            oPlandeTrabajoBE.IdPlan = dr["ID_PLAN"].ToString();
            oPlandeTrabajoBE.IdRequerimiento = dr["ID_RQR"].ToString();
            oPlandeTrabajoBE.IdServicioArea = dr["ID_SERV_AREA"].ToString();
            oPlandeTrabajoBE.IdPersonalAtencion = Convert.ToInt32(dr["ID_PERSONALATE"].ToString());
            oPlandeTrabajoBE.IdResponsableAtencion = dr["ID_RESP_ATE"].ToString();
            oPlandeTrabajoBE.ApellidosyNombres = dr["APELLIDOSYNOMBRES"].ToString();
            oPlandeTrabajoBE.NroDNI = dr["NRODOCDNI"].ToString();
            oPlandeTrabajoBE.Nombre = dr["NOMBRE"].ToString();
            oPlandeTrabajoBE.Descripcion = dr["DESCRIPCION"].ToString();
            oPlandeTrabajoBE.IdTipo = Convert.ToInt32(dr["IDTIPO"].ToString());
            oPlandeTrabajoBE.Avance = Convert.ToInt32(dr["AVANCE"].ToString());
            return oPlandeTrabajoBE;
        }

        public BaseBE Detalle(string Id1, string Id2, string Id3, string UserName)
        {
            throw new NotImplementedException();
        }
    }
}
