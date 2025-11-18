using EntidadNegocio.GestionCalidad;
using EntidadNegocio;
using Log;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.NoTransaccional.GestionCalidad
{
    public class ResponsableAreaDetalleNTAD : BaseAD, IMantenimientoNTAD
    {
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
            DataTable dt = ListarTodos("0", "0", Id1, UserName);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                ResponsableAreaDetalleBE oResponsableAreaDetalleBE = new ResponsableAreaDetalleBE();
                oResponsableAreaDetalleBE.IdDetalleResponsableArea = dr["IdDetalleResponsableArea"].ToString();
                oResponsableAreaDetalleBE.IdPersonal = Convert.ToInt32(dr["IdPersonal"].ToString());
                oResponsableAreaDetalleBE.FechaRpta = Convert.ToDateTime(dr["FechaRpta"].ToString());
                if (dr["FechaEnvio"].ToString().Length > 0) oResponsableAreaDetalleBE.FechaEnvio = Convert.ToDateTime(dr["FechaEnvio"].ToString());
                if (dr["FechaLectura"].ToString().Length > 0) oResponsableAreaDetalleBE.FechaLectura = Convert.ToDateTime(dr["FechaLectura"].ToString());
                oResponsableAreaDetalleBE.Observacion = dr["Observacion"].ToString();
                oResponsableAreaDetalleBE.IdEstado = Convert.ToInt32(dr["IdEstado"].ToString());
                oResponsableAreaDetalleBE.NombreEstado = dr["NombreEstado"].ToString();
                oResponsableAreaDetalleBE.ImgEstado = dr["var5"].ToString();
                return oResponsableAreaDetalleBE;
            }
            return null;
        }

        public BaseBE Detalle(string Id1, string Id2, string UserName)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1, string Id2, string Id3, string UserName)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarTodos()
        {
            throw new NotImplementedException();
        }

        public DataTable ListarTodos(string Id1, string UserName)
        {
            throw new NotImplementedException();
        }
        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return ListarTodos(Id1, Id2, "0", UserName);
        }
        public DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, Id1.ToString(), Id2.ToString(), Id3.ToString(), UserName);
                string PackagName = "CALIDAD.CALuspNTADListarDetellePorResponsableArea";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );

                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, Id1, Id2, Id3);


                //Graba en el Log Salida del Metodo
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


    }
}
