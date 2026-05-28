using EntidadNegocio;
using Google.Protobuf.WellKnownTypes;
using Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.NoTransaccional.GestionSeguridadPlanta
{
    public class VisitasNTAD : BaseAD, IMantenimientoNTAD
    {
        #region Metodos_Por_Defecto
            DataTable IMantenimientoNTAD.Buscar(string TextFind, string UserName)
            {
                throw new NotImplementedException();
            }

            BaseBE IMantenimientoNTAD.Detalle(string Id1)
            {
                throw new NotImplementedException();
            }

            BaseBE IMantenimientoNTAD.Detalle(string Id1, string UserName)
            {
                throw new NotImplementedException();
            }

            BaseBE IMantenimientoNTAD.Detalle(string Id1, string Id2, string UserName)
            {
                throw new NotImplementedException();
            }

            BaseBE IMantenimientoNTAD.Detalle(string Id1, string Id2, string Id3, string UserName)
            {
                throw new NotImplementedException();
            }

            DataTable IMantenimientoNTAD.ListarTodos()
            {
                throw new NotImplementedException();
            }

            public DataTable ListarTodos(string Id1, string UserName)
            {
                throw new NotImplementedException();
            }

            public DataTable ListarTodos(string Id1, string Id2, string UserName)
            {
                throw new NotImplementedException();
            }

            public DataTable ListarTodos(string Id1, string Id2, string Id3, string idUser)
            {
            // en id1 puedes pasar: -- num/fecha/texto
            // id2 : @Periodo
            // id3: @TipoProgramacion
            try
            {
                DataTable dtempty = new DataTable();
                StackTrace stack = new StackTrace();
                    string NombreMetodo = stack.GetFrame(0).GetMethod().Name;
                
                
                    InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, Id1.ToString(), Id2.ToString(), Id2.ToString(), idUser);
                    string PackagName = "seg_planta.uspNTADConsultarProgramacionVisita_CVST2";

                    LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(idUser
                                                                                         , oInfoMetodoBE.FullName
                                                                                         , NombreMetodo
                                                                                         , PackagName
                                                                                         , oInfoMetodoBE.VoidParams
                                                                                         , ""
                                                                                         , Helper.MensajesIngresarMetodo()
                                                                                         , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                     );
                // PARAMETROS: @NroProgramacion=0,@Periodo=2026,@idUsuario=86,@TipoProgramacion=1


                //int iParam1 = int.TryParse(Id1, NumberStyles.Integer, CultureInfo.InvariantCulture, out var _id1) ? _id1 : 0;
                string iParam1 = string.IsNullOrWhiteSpace(Id1) ? "" : Id1.Trim();
                int iParam2 = int.TryParse(Id2, NumberStyles.Integer, CultureInfo.InvariantCulture, out var _id2) ? _id2 : 0;
                int iParam3 = int.TryParse(Id3, NumberStyles.Integer, CultureInfo.InvariantCulture, out var _id3) ? _id3 : 2; // default = 2
                int iusuario = int.TryParse(idUser, NumberStyles.Integer, CultureInfo.InvariantCulture, out var _usr) ? _usr : 0;


                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, iParam1, iParam2, iusuario, iParam3);
                int irows = ds?.Tables?.Count > 0 ? ds.Tables[0].Rows.Count : 0;
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(idUser
                                                                                         , oInfoMetodoBE.FullName
                                                                                         , NombreMetodo
                                                                                         , PackagName
                                                                                         , ""
                                                                                         , "rstCount:" + irows.ToString()
                                                                                         , Helper.MensajesSalirMetodo()
                                                                                         , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                if (ds == null || ds.Tables.Count == 0)
                    return dtempty; // o return null; si tu contrato lo permite

                return ds.Tables[0];
                }
            catch (SqlException  oracleException)
                {
                    LogTransaccional.LanzarSIMAExcepcionDominio(idUser, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                    return null;
                }
                catch (Exception exception)
                {
                    LogTransaccional.LanzarSIMAExcepcionDominio(idUser, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                    return null;
                }

            }
        // para objetos JSON
        public List<Dictionary<string, object>> ListarTodos_JSON(string Id1, string Id2, string Id3, string idUser)
        {
            try
            {
                var empty = new List<Dictionary<string, object>>();
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, Id1.ToString(), Id2.ToString(), Id2.ToString(), idUser);
                string PackagName = "seg_planta.uspNTADConsultarProgramacionVisita_CVST";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(idUser
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );

                string iParam1 = string.IsNullOrWhiteSpace(Id1) ? "" : Id1.Trim();
                int iParam2 = int.TryParse(Id2, NumberStyles.Integer, CultureInfo.InvariantCulture, out var _id2) ? _id2 : 0;
                int iParam3 = int.TryParse(Id3, NumberStyles.Integer, CultureInfo.InvariantCulture, out var _id3) ? _id3 : 2;
                int iusuario = int.TryParse(idUser, NumberStyles.Integer, CultureInfo.InvariantCulture, out var _usr) ? _usr : 0;

                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, iParam1, iParam2, iusuario, iParam3);
                int irows = ds?.Tables?.Count > 0 ? ds.Tables[0].Rows.Count : 0;

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(idUser
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "rstCount:" + irows.ToString()
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                if (ds == null || ds.Tables.Count == 0)
                    return empty;

                var dt = ds.Tables[0];
                var list = new List<Dictionary<string, object>>(dt.Rows.Count);

                foreach (DataRow row in dt.Rows)
                {
                    var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                    foreach (DataColumn c in dt.Columns)
                    {
                        object val = row[c] == DBNull.Value ? null : row[c];

                        // Normaliza fechas a ISO 8601 si vienen como DateTime
                        if (val is DateTime dtVal)
                            val = dtVal.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);

                       
                        dict[c.ColumnName] = val;
                    }
                    list.Add(dict);
                }

                return list;
            }
            catch (SqlException oracleException) 
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(idUser, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception) 
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(idUser, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        #endregion


        // Helper opcional
        private static int TryParseInt(string s, int defaultValue = 0)
        {
            if (int.TryParse(s, out var v)) return v;
            return defaultValue; // o lanza excepción si debe ser obligatorio
        }

        public DataTable ListarVisitantes(string Periodo, string NroProgramacion, string idUser)
        {
            try
            {
                // =========================
                // INFO MÉTODO
                // =========================
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(
                    NombreMetodo,
                    Periodo,
                    NroProgramacion,
                    idUser
                );

                string PackagName = "seg_planta.CCTTuspNTADListarVisitantesInProg2";

                // =========================
                // LOG INGRESO
                // =========================
                LogTransaccional.GrabarLogTransaccionalArchivo(
                    new LogTransaccional(idUser,
                        oInfoMetodoBE.FullName,
                        NombreMetodo,
                        PackagName,
                        oInfoMetodoBE.VoidParams,
                        "",
                        Helper.MensajesIngresarMetodo(),
                        Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                // =========================
                // PARSEO SEGURO
                // =========================
                int iPeriodo = int.TryParse(Periodo, out var _per) ? _per : 0;
                int iNroProgramacion = int.TryParse(NroProgramacion, out var _prog) ? _prog : 0;

                // =========================
                // EJECUCIÓN SP  (FORMA CORRECTA)
                // =========================
                DataSet ds = Sql(SQLVersion.sqlSIMANET)
                                .ExecuteDataSet(PackagName, iPeriodo, iNroProgramacion);

                DataTable dt = null;

                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }

                int irows = dt?.Rows?.Count ?? 0;

                // =========================
                // LOG SALIDA
                // =========================
                LogTransaccional.GrabarLogTransaccionalArchivo(
                    new LogTransaccional(idUser,
                        oInfoMetodoBE.FullName,
                        NombreMetodo,
                        PackagName,
                        "",
                        "rstCount:" + irows.ToString(),
                        Helper.MensajesSalirMetodo(),
                        Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                return dt;
            }
            catch (SqlException sqlException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(
                    idUser,
                    this.GetType().Name,
                    Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD +
                    Helper.Cadena.CortarTextoDerecha(5, Constante.LogCtrl.CEROS + sqlException.Number.ToString()),
                    "Código de Error:" + sqlException.Number +
                    Constante.Caracteres.SeperadorSimple +
                    sqlException.Message
                );
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(
                    idUser,
                    this.GetType().Name,
                    Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(),
                    Constante.LogCtrl.CODIGOERRORGENERICONTAD,
                    exception.Message
                );
                return null;
            }
        }

        public DataTable BuscarTrabajadorExterno(string sValor, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;
                DataSet ds = new DataSet();  

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, sValor, UserName);

                string PackagName = "CCTTuspNTADLocalizarTrabajadoresContratista";


                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                    , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );


                int resultado;

                if (int.TryParse(sValor, out resultado))
                {
                    // ES NUMÉRICO
                     ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, "NRODNI", resultado);
                }
                else
                {
                    // NO ES NUMÉRICO
                     ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, "", sValor);
                }





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
