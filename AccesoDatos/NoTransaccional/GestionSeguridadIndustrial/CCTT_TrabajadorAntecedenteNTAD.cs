using EntidadNegocio;
using EntidadNegocio.GestionSeguridadIndustrial;
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
using static Utilitario.Constante.Formato;

namespace AccesoDatos.NoTransaccional.GestionSeguridadIndustrial
{
    public class CCTT_TrabajadorAntecedenteNTAD : BaseAD
    {
        public DataTable Listar(string IdAntecedente, string UserName)
        {
            try
            {
                string PackagName = "CCTTuspNTADConsultarAntecedente";

                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, IdAntecedente, UserName);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , ""
                                                                                        , Helper.MensajesIngresarMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                SqlParameter[] Params = new SqlParameter[1];
                Params[0] = new SqlParameter("IdAntecedente", SqlDbType.VarChar);
                Params[0].Value = (object)IdAntecedente;

                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(true,PackagName, Params);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , ""
                                                                                        , Helper.MensajesSalirMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));

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

        public BaseBE Detalle(string IdAntecedente, string UserName)
        {
            try
            {
                string PackagName = "CCTTuspNTADConsultarAntecedente";

                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, IdAntecedente, UserName);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , ""
                                                                                        , Helper.MensajesIngresarMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                SqlParameter[] Params = new SqlParameter[1];
                Params[0] = new SqlParameter("@IdAntecedente", SqlDbType.VarChar, 10);
                Params[0].Value = (object)IdAntecedente;

                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(true,PackagName, Params);

                AntecedenteTrabajadorContratistaBE oAntecedenteTrabajadorContratistaBE = new AntecedenteTrabajadorContratistaBE();
                if (ds.Tables[0] != null)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    oAntecedenteTrabajadorContratistaBE.IdAntecedente = row["IdAntecedente"].ToString();
                    oAntecedenteTrabajadorContratistaBE.ApellidosyNombres = row["ApellidosyNombres"].ToString();
                    oAntecedenteTrabajadorContratistaBE.NroDNI = row["NroDNI"].ToString();
                    oAntecedenteTrabajadorContratistaBE.IdProveedor = Convert.ToInt32(row["IdProveedor"].ToString());
                    oAntecedenteTrabajadorContratistaBE.RazonSocial = row["RazonSocial"].ToString();
                    oAntecedenteTrabajadorContratistaBE.IdLugardeTrabajo = Convert.ToInt32(row["IdLugardeTrabajo"].ToString());
                    oAntecedenteTrabajadorContratistaBE.NombreLugardeTrabajo = row["NombreArea"].ToString();
                    oAntecedenteTrabajadorContratistaBE.IdTipoAntecedente = Convert.ToInt32(row["IdTipoAntecedente"].ToString());
                    oAntecedenteTrabajadorContratistaBE.Fecha = Convert.ToDateTime(row["Fecha"].ToString());
                    oAntecedenteTrabajadorContratistaBE.Hora = row["Hora"].ToString();
                    oAntecedenteTrabajadorContratistaBE.Descripcion = row["Descripcion"].ToString();
                    oAntecedenteTrabajadorContratistaBE.Contratista = Convert.ToInt32(row["Contratista"].ToString());
                    oAntecedenteTrabajadorContratistaBE.IdJefeDirecto = row["IdJefeDirecto"].ToString();
                    oAntecedenteTrabajadorContratistaBE.NombresJefeDirecto = row["NombresJefeDirecto"].ToString();
                    oAntecedenteTrabajadorContratistaBE.IdPersonalFamiliar = Convert.ToInt32(row["IdPersonalFamiliar"].ToString());
                    oAntecedenteTrabajadorContratistaBE.NombresFamiliar = row["NombresFamiliar"].ToString();
                    oAntecedenteTrabajadorContratistaBE.IdParentesco = Convert.ToInt32(row["IdParentesco"].ToString());
                    oAntecedenteTrabajadorContratistaBE.NombresParentesco = row["NombresParentesco"].ToString();
                    oAntecedenteTrabajadorContratistaBE.DescripcioEvento = row["DescripcionEventoCritico"].ToString();
                    oAntecedenteTrabajadorContratistaBE.IdPersonalInterviene = row["IdPersonaQueInterviene"].ToString();
                    oAntecedenteTrabajadorContratistaBE.NombrePersonalInterviene = row["NombrePersonalInterviene"].ToString();
                    oAntecedenteTrabajadorContratistaBE.IngresoPermitido = Convert.ToInt32(row["IngresoPermitido"].ToString());
                    oAntecedenteTrabajadorContratistaBE.Extension = row["Extension"].ToString();
                }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                        , oInfoMetodoBE.FullName
                                                                                        , NombreMetodo
                                                                                        , PackagName
                                                                                        , oInfoMetodoBE.VoidParams
                                                                                        , ""
                                                                                        , Helper.MensajesSalirMetodo()
                                                                                        , Convert.ToString(Enumerados.NivelesErrorLog.C)));

                return oAntecedenteTrabajadorContratistaBE;
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
