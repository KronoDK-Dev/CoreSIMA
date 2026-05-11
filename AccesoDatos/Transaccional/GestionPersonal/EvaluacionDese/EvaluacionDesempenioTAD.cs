using Log;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;
using EntidadNegocio;


namespace AccesoDatos.Transaccional.GestionPersonal.EvaluacionDese
{
    public class EvaluacionDesempenioTAD:BaseAD
    {
        public string ActualizarAccesoEvaluacion(string V_TIPO_EVAL, int V_VALOR, string V_OPCION, string V_DNI_JEFE, string UserName)
        {
            string sResultado = "";

            Database db = Sql(SQLVersion.sqlSIMANET);

            using (DbConnection cn = db.CreateConnection())
            {
                cn.Open();

                using (DbTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        string NombreMetodo = nameof(ActualizarAccesoEvaluacion);

                        InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(
                            NombreMetodo,
                            V_TIPO_EVAL, V_VALOR.ToString(), V_OPCION, V_DNI_JEFE, UserName
                        );

                        string PackageName = "[RRHHevaluacion].[sp_Actualizar_AccesoEvaluacion]";

                        // LOG INICIO
                        LogTransaccional.GrabarLogTransaccionalArchivo(
                            new LogTransaccional(
                                UserName,
                                oInfoMetodoBE.FullName,
                                NombreMetodo,
                                PackageName,
                                oInfoMetodoBE.VoidParams,
                                "",
                                Helper.MensajesIngresarMetodo(),
                                Convert.ToString(Enumerados.NivelesErrorLog.I)
                            )
                        );

                        DbCommand cmd = db.GetStoredProcCommand(PackageName);

                        // INPUTS
                        db.AddInParameter(cmd, "@V_CAMPO", DbType.String, V_TIPO_EVAL);
                        db.AddInParameter(cmd, "@V_VALOR", DbType.Int32, V_VALOR);
                        db.AddInParameter(cmd, "@V_OPCION", DbType.String, V_OPCION);
                        db.AddInParameter(cmd, "@V_DNI_JEFE", DbType.String, V_DNI_JEFE);

                        // OUTPUT
                        db.AddOutParameter(cmd, "@V_RESULTADO", DbType.String, 500);

                        // EXEC
                        db.ExecuteNonQuery(cmd, tran);

                        // OBTENER RESULTADO
                        sResultado = Convert.ToString(db.GetParameterValue(cmd, "@V_RESULTADO"));

                        // LOG SALIDA
                        LogTransaccional.GrabarLogTransaccionalArchivo(
                            new LogTransaccional(
                                UserName,
                                oInfoMetodoBE.FullName,
                                NombreMetodo,
                                PackageName,
                                oInfoMetodoBE.VoidParams,
                                sResultado,
                                Helper.MensajesSalirMetodo(),
                                Convert.ToString(Enumerados.NivelesErrorLog.I)
                            )
                        );

                        tran.Commit();

                        return sResultado;
                    }
                    catch (SqlException sqlException)
                    {
                        tran.Rollback();

                        LogTransaccional.LanzarSIMAExcepcionDominio(
                            UserName,
                            this.GetType().Name,
                            Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                            Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString()
                            + Helper.Cadena.CortarTextoDerecha(5,
                                Utilitario.Constante.LogCtrl.CEROS + sqlException.Number.ToString()),
                            "Código de Error:" + sqlException.Number.ToString()
                            + Utilitario.Constante.Caracteres.SeperadorSimple
                            + sqlException.Message
                        );

                        return "-1";
                    }
                    catch (Exception exception)
                    {
                        tran.Rollback();

                        LogTransaccional.LanzarSIMAExcepcionDominio(
                            UserName,
                            this.GetType().Name,
                            Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                            Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(),
                            exception.Message
                        );

                        return "-1";
                    }
                }
            }
        }




    }
}
