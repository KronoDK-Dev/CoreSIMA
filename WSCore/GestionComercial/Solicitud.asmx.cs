using AccesoDatos.NoTransaccional.General;
using Controladora.General;
using Controladora.GestionComercial;
using EntidadNegocio.GestionComercial;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace WSCore.GestionComercial
{
    /// <summary>
    /// Descripción breve de Solicitud
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Solicitud : System.Web.Services.WebService
    {
        readonly string sAmbiente = ConfigurationManager.AppSettings["Ambiente"];

        [WebMethod(Description = "Detalle de la Solicitud")]
        public DataTable DetalleSolicitud(string V_CEO, string V_ID_SOLICITUD, string V_COD_DIV, string UserName)
        {
            return (new cSolicitud()).DetalleSolicitud(sAmbiente, V_CEO, V_ID_SOLICITUD, V_COD_DIV, UserName);
        }

        [WebMethod(Description = "Detalle de la Solicitud 2")]
        public DataTable DetalleSolicitud2(string V_CEO, string V_ID_SOLICITUD, string V_COD_DIV, string UserName)
        {
            return (new cSolicitud()).DetalleSolicitud2(sAmbiente, V_CEO, V_ID_SOLICITUD, V_COD_DIV, UserName);
        }

        [WebMethod(Description = "Lista de Solicitudes de Trabajo por CEO")]
        public DataTable ListarSolicitudTrabajo(string V_AMBIENTE, string V_FILTRO, string V_CEO, string V_UND_OPER, string V_FEC_STR_INI,  string V_FEC_STR_FIN, string UserName)
        {
          try 
          { 
              return (new cSolicitud()).ListarSolicitudTrabajo(sAmbiente, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);
          }
          catch (Exception ex)
          {
                // Decidimos aquí (sin filtro 'when') si procede failover
                if (EsErrorDeConectividad(ex))
                {
                    LogWarn($"Failover: ListarSolicitudTrabajo() en base primaria falló. " +
                            $"V_CODIGO={V_FILTRO}, user={UserName}, amb={sAmbiente}. Causa: {ex.Message}", ex);

                    try
                    {
                        // Contingencia: usa tu método alterno (otra fuente/base)
                        return (new cSolicitud()).ListarSolicitudTrabajo_SQL(sAmbiente, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);
                    }
                    catch (Exception exAlt)
                    {
                        // Si la contingencia también cae, registramos y re-lanzamos una excepción clara
                        LogWarn("Contingencia ListarTablaGeneral(205, …) también falló.", exAlt);
                        throw; // o: throw new ApplicationException("Primario y contingencia fallaron", exAlt);
                    }
                }

                // Si NO es un error de conectividad/proveedor, re-lanzar (es de negocio/validación)
                throw;
            }
        }

        [WebMethod(Description = "Lista de Solicitudes de Trabajo , por Metodo xml string")]
        public string ListarSolicitudTrabajo2(string V_AMBIENTE, string V_FILTRO, string V_CEO, string V_UND_OPER, string V_FEC_STR_INI, string V_FEC_STR_FIN, string UserName)
        {
            try
            {
                DataTable dt = (new cSolicitud()).ListarSolicitudTrabajo(sAmbiente, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "PR_GET_SOLICITUD";

                DataSet dset = new DataSet();
                dset.Tables.Add(dtCopy);

                using (StringWriter sw = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sw))
                    {
                        dset.WriteXml(writer, XmlWriteMode.IgnoreSchema);
                        return sw.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                // Decidimos aquí (sin filtro 'when') si procede failover
                if (EsErrorDeConectividad(ex))
                {
                    LogWarn($"Failover: ListarSolicitudTrabajo2() en base primaria falló. " +
                            $"V_CODIGO={V_FILTRO}, user={UserName}, amb={sAmbiente}. Causa: {ex.Message}", ex);

                    try
                    {
                        // Contingencia: usa tu método alterno (otra fuente/base)



                        List<Dictionary<string, object>> lista =
                            (new cSolicitud()).ListarSolicitudTrabajo_JSON(sAmbiente, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);

                        // 2) Convertimos esa lista a DataTable
                        DataTable dtFailover = ListDictToDataTable(lista);
                        dtFailover.TableName = "PR_GET_SOLICITUD";

                        // 3) Escribimos el MISMO XML que en el camino primario
                        var ds = new DataSet();
                        ds.Tables.Add(dtFailover);

                        using (var sw = new StringWriter())
                        using (var xw = XmlWriter.Create(sw))
                        {
                            ds.WriteXml(xw, XmlWriteMode.IgnoreSchema);
                            return sw.ToString();
                        }


                       

                    }
                    catch (Exception exAlt)
                    {
                        // Si la contingencia también cae, registramos y re-lanzamos una excepción clara
                        LogWarn("Contingencia ListarSolicitudTrabajo2(…) también falló.", exAlt);
                        throw; // o: throw new ApplicationException("Primario y contingencia fallaron", exAlt);
                    }
                }

                // Si NO es un error de conectividad/proveedor, re-lanzar (es de negocio/validación)
                throw;
            }

        }

        [WebMethod(Description = "Lista de Solicitudes de Trabajo , por Metodo  (JSON) ")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public string ListarSolicitudTrabajo_JSON(string V_AMBIENTE, string V_FILTRO, string V_CEO, string V_UND_OPER, string V_FEC_STR_INI, string V_FEC_STR_FIN, string UserName)
        {
            try
            {
                Context.Response.ContentType = "application/json; charset=utf-8";
                var data = new cSolicitud().ListarSolicitudTrabajo_JSON(sAmbiente, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);

                return (data == null)
                    ? JsonConvert.SerializeObject(new { success = false, error = new { code = "SERVER_ERROR", message = "Ocurrió un error al consultar los datos." } })
                    : JsonConvert.SerializeObject(new { success = true, data });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false, error = new { code = "SERVER_ERROR", message = ex.Message } });
            }
        }

        [WebMethod(Description = "Inserción de Solicitudes de Trabajo")]
        public string InsertarSolicitud(
            string v_ambiente, string v_cod_ceo, string v_cod_div, string v_nro_str, string v_cod_aus, string v_tip_str,
            string v_cod_cli, string v_cod_und, string v_cod_sis, string v_cod_sub, string v_cod_eqp, string v_fec_str,
            string v_nro_val, string v_tip_tbj, string v_cod_pro, string v_est_atl, string v_des_abr, string v_des_det,
            string v_nro_pro, string v_ref_str, string v_ubc_eqp, string v_tip_tar, string v_cls_tbj, string v_cod_nav,
            string v_fec_ref, string v_fec_acc, string v_alias_str, string v_ind_cnv, string v_fec_cnv, string v_ibp,
            string v_tip_ots, string v_usr_reg, string v_fec_reg, string v_ots_tar, string v_fec_rcp_str, string v_hra_rcp_str,
            string v_fec_ent_val, string v_hra_ent_val, string v_dique, string v_cod_sec, string v_tipo_val, string v_nro_ctto,
            string v_nro_sol_jde, string v_est_prc, string v_ref_str_mgp, string v_fec_ref_mgp, string v_cod_cliente, string v_proyecto,
            string v_sublinea, string v_otgenerica, string v_numacti, string v_actividad, string v_estructura, string v_estacionregistro,
            string v_v_solicitud_id, string v_v_embarcacion_id, string v_v_cliente_id, string v_und_ope, string v_nro_revision,
            string v_cod_presupuesto, string v_remitido)
        {
            SolicitudBE solicitud = new SolicitudBE
            {
                X_COD_CEO = v_cod_ceo,
                X_COD_DIV = v_cod_div,
                X_NRO_STR = string.IsNullOrEmpty(v_nro_str) ? 0 : Convert.ToInt32(v_nro_str),
                X_COD_AUS = v_cod_aus,
                X_TIP_STR = v_tip_str,
                X_COD_CLI = string.IsNullOrEmpty(v_cod_cli) ? 0 : Convert.ToInt32(v_cod_cli),
                X_COD_UND = string.IsNullOrEmpty(v_cod_und) ? 0 : Convert.ToInt32(v_cod_und),
                X_COD_SIS = string.IsNullOrEmpty(v_cod_sis) ? 0 : Convert.ToInt32(v_cod_sis),
                X_COD_SUB = string.IsNullOrEmpty(v_cod_sub) ? 0 : Convert.ToInt32(v_cod_sub),
                X_COD_EQP = string.IsNullOrEmpty(v_cod_eqp) ? 0 : Convert.ToInt32(v_cod_eqp),
                X_FEC_STR = v_fec_str,
                X_NRO_VAL = string.IsNullOrEmpty(v_nro_val) ? 0 : Convert.ToInt32(v_nro_val),
                X_TIP_TBJ = v_tip_tbj,
                X_COD_PRO = string.IsNullOrEmpty(v_cod_pro) ? 0 : Convert.ToInt32(v_cod_pro),
                X_EST_ATL = v_est_atl,
                X_DES_ABR = v_des_abr,
                X_DES_DET = v_des_det,
                X_NRO_PRO = string.IsNullOrEmpty(v_nro_pro) ? 0 : Convert.ToInt32(v_nro_pro),
                X_REF_STR = v_ref_str,
                X_UBC_EQP = v_ubc_eqp,
                X_TIP_TAR = v_tip_tar,
                X_CLS_TBJ = v_cls_tbj,
                X_COD_NAV = string.IsNullOrEmpty(v_cod_nav) ? 0 : Convert.ToInt32(v_cod_nav),
                X_FEC_REF = v_fec_ref,
                X_FEC_ACC = v_fec_acc,
                X_ALIAS_STR = v_alias_str,
                X_IND_CNV = v_ind_cnv,
                X_FEC_CNV = v_fec_cnv,
                X_IBP = v_ibp,
                X_TIP_OTS = v_tip_ots,
                X_USR_REG = v_usr_reg,
                X_FEC_REG = v_fec_reg,
                X_OTS_TAR = v_ots_tar,
                X_FEC_RCP_STR = v_fec_rcp_str,
                X_HRA_RCP_STR = v_hra_rcp_str,
                X_FEC_ENT_VAL = v_fec_ent_val,
                X_HRA_ENT_VAL = v_hra_ent_val,
                X_DIQUE = v_dique,
                X_COD_SEC = v_cod_sec,
                X_TIPO_VAL = v_tipo_val,
                X_NRO_CTTO = v_nro_ctto,
                X_NRO_SOL_JDE = string.IsNullOrEmpty(v_nro_sol_jde) ? 0 : Convert.ToInt32(v_nro_sol_jde),
                X_EST_PRC = string.IsNullOrEmpty(v_est_prc) ? 0 : Convert.ToInt32(v_est_prc),
                X_REF_STR_MGP = v_ref_str_mgp,
                X_FEC_REF_MGP = v_fec_ref_mgp,
                X_COD_CLIENTE = v_cod_cliente,
                X_PROYECTO = v_proyecto,
                X_SUBLINEA = v_sublinea,
                X_OTGENERICA = v_otgenerica,
                X_NUMACTI = v_numacti,
                X_ACTIVIDAD = v_actividad,
                X_ESTRUCTURA = v_estructura,
                X_ESTACIONREGISTRO = v_estacionregistro,
                X_V_SOLICITUD_ID = v_v_solicitud_id,
                X_V_EMBARCACION_ID = v_v_embarcacion_id,
                X_V_CLIENTE_ID = v_v_cliente_id,
                X_UND_OPE = v_und_ope,
                X_NRO_REVISION = v_nro_revision,
                X_COD_PRESUPUESTO = v_cod_presupuesto,
                X_REMITIDO = v_remitido
            };

            try
            {
                string result = (new cSolicitud()).InsertarSolicitud(solicitud, sAmbiente);

                if (result.Contains('-') && result.Length > 4)
                    result = (new cGeneral()).LISTA_DESCRIP_ERRORES(result, v_usr_reg);

                result = result.Replace("S0", "\n S0");

                return result;
            }
            catch (Exception ex)
            {
                return "InsertarSolicitud | FALLO EN PROCESAMIENTO...\r\n" + ex.Message;
            }
        }

        [WebMethod(Description = "Inserción de Solicitudes de Trabajo")]
        public string InsertarSolicitud2(SolicitudBE oSolicitudBE, string UserName)
        {
            try
            {
                string result = (new cSolicitud()).InsertarSolicitud(oSolicitudBE);

                if (result.Contains('-') && result.Length > 4)
                    result = (new cGeneral()).LISTA_DESCRIP_ERRORES(result, UserName);
                result = result.Replace("S0", "\n S0");

                return result;
            }
            catch (Exception ex)
            {
                return "InsertarSolicitud | FALLO EN PROCESAMIENTO...\r\n" + ex.Message;
            }
        }

        [WebMethod(Description = "Lista Lineas de Negocio de Usuarios")]
        public DataTable Lista_lineas_Usuario(string sUsuario, string UserName)
        {
            return (new cSolicitud()).Lista_Lineas_Usuario(sUsuario, UserName);
        }


        #region VERIFICA_ERROR

        private static bool EsErrorDeConectividad(Exception ex)
        {
            // 1) Root e inspección completa
            Exception root = ex;
            while (root.InnerException != null) root = root.InnerException;

            // Decodifica HTML (p.ej., &#39;) y unifica a minúsculas
            string msgRoot = HttpUtility.HtmlDecode(root.Message ?? string.Empty).ToLowerInvariant();
            string allText = HttpUtility.HtmlDecode(ex.ToString() ?? string.Empty).ToLowerInvariant();

            // 2) Heurística: tu excepción de dominio
            bool esSimaExcep = ex.GetType().Name.IndexOf("simaexcepciondominio", StringComparison.OrdinalIgnoreCase) >= 0
                               || allText.Contains("simaexcepciondominio");

            // 3) SQL Server: conectividad típica
            if (root is SqlException sqlEx)
            {
                if (sqlEx.Number == 53   // host/instancia no accesible
                 || sqlEx.Number == -2   // timeout
                 || sqlEx.Number == 18456// login failed
                 || sqlEx.Number == 4060)// cannot open database
                    return true;
            }

            // 4) Oracle vía OLE DB/ODBC o wrapper
            if (root is OleDbException || root is OdbcException || esSimaExcep)
            {
                if (msgRoot.Contains("ora-") || msgRoot.Contains("tns") || msgRoot.Contains("listener"))
                    return true;

                if (msgRoot.Contains("timeout") || msgRoot.Contains("time-out")
                 || msgRoot.Contains("no se pudo") || msgRoot.Contains("no se puede")
                 || msgRoot.Contains("could not") || msgRoot.Contains("unable to")
                 || msgRoot.Contains("network") || msgRoot.Contains("transport"))
                    return true;
            }

            // 5) PROVEEDOR/ENSAMBLADO: Oracle.DataAccess, PublicKeyToken, 0x80131040
            //    **NO** lo limites a tipos FileLoad/FileNotFound/BadImageFormat,
            //    porque la excepción puede venir envuelta en SIMAExcepcionDominio.
            if (msgRoot.Contains("oracle.dataaccess")
             || msgRoot.Contains("publickeytoken=89b483f429c47342")
             || msgRoot.Contains("0x80131040")
             || msgRoot.Contains("la definición del manifiesto del ensamblado no coincide")
             || msgRoot.Contains("the located assembly's manifest definition does not match"))
                return true;

            // 6) Heurísticas genéricas de red (CORREGIDO: '&&' en C#)
            if (msgRoot.Contains("timeout") || msgRoot.Contains("time-out")
             || msgRoot.Contains("no such host") || msgRoot.Contains("host not found")
             || msgRoot.Contains("unable to connect") || msgRoot.Contains("could not connect")
             || (msgRoot.Contains("connection") && (msgRoot.Contains("fail") || msgRoot.Contains("closed"))))
                return true;

            // 7) Backup: busca en todo el ToString por si el dato no está en root.Message
            if (allText.Contains("oracle.dataaccess") || allText.Contains("publickeytoken=89b483f429c47342")
             || allText.Contains("0x80131040") || allText.Contains("ora-") || allText.Contains("tns")
             || allText.Contains("listener"))
                return true;

            return false;
        }
        private static void LogWarn(string message, Exception ex = null)
        {
            try
            {
                System.Diagnostics.Trace.TraceWarning(message);
                if (ex != null) System.Diagnostics.Trace.TraceWarning(ex.ToString());
            }
            catch
            {
                // Evitar que logging falle la operación
            }
        }
        private string JsonListToXmlString(string json, string tableName)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                // XML vacío consistente (sin filas)
                DataSet dsEmpty = new DataSet();
                DataTable dtEmpty = new DataTable(tableName);
                dsEmpty.Tables.Add(dtEmpty);

                using (var sw = new StringWriter())
                using (var xw = XmlWriter.Create(sw))
                {
                    dsEmpty.WriteXml(xw, XmlWriteMode.IgnoreSchema);
                    return sw.ToString();
                }
            }

            // Intentamos deserializar la forma más común: arreglo de objetos
            DataTable dt = TryDeserializeArrayToDataTable(json);

            if (dt == null)
            {
                // Si no es arreglo directo, buscamos el primer array de objetos dentro de un objeto
                var token = JToken.Parse(json);

                if (token.Type == JTokenType.Object)
                {
                    var obj = (JObject)token;

                    // 1) Intentar con propiedad "data" si existe
                    if (obj.TryGetValue("data", StringComparison.OrdinalIgnoreCase, out var dataToken) &&
                        dataToken is JArray dataArr && dataArr.Count > 0 && dataArr[0].Type == JTokenType.Object)
                    {
                        dt = dataArr.ToObject<DataTable>();
                    }
                    else
                    {
                        // 2) Buscar el primer array de objetos en cualquier propiedad
                        foreach (var prop in obj.Properties())
                        {
                            if (prop.Value is JArray arr && arr.Count > 0 && arr[0].Type == JTokenType.Object)
                            {
                                dt = arr.ToObject<DataTable>();
                                break;
                            }
                        }

                        // 3) Si aún no hay tabla y el objeto podría ser una sola fila, convertirlo
                        if (dt == null)
                        {
                            var singleRow = new DataTable();
                            // crear columnas a partir de las propiedades
                            foreach (var p in obj.Properties())
                            {
                                // Definir tipo como string para evitar conflictos (fechas, numéricos)
                                if (!singleRow.Columns.Contains(p.Name))
                                    singleRow.Columns.Add(p.Name, typeof(string));
                            }
                            var row = singleRow.NewRow();
                            foreach (var p in obj.Properties())
                            {
                                row[p.Name] = TokenToScalarString(p.Value);
                            }
                            singleRow.Rows.Add(row);
                            dt = singleRow;
                        }
                    }
                }
                else if (token is JArray jarr && jarr.Count > 0 && jarr[0].Type == JTokenType.Object)
                {
                    dt = jarr.ToObject<DataTable>();
                }
                else
                {
                    // Array de escalares → 1 columna
                    if (token is JArray scalarsArr)
                    {
                        var t = new DataTable();
                        t.Columns.Add("Value", typeof(string));
                        foreach (var v in scalarsArr)
                        {
                            var r = t.NewRow();
                            r["Value"] = TokenToScalarString(v);
                            t.Rows.Add(r);
                        }
                        dt = t;
                    }
                }
            }

            if (dt == null)
            {
                // Como último recurso, devolver XML vacío coherente
                DataSet dsEmpty = new DataSet();
                DataTable dtEmpty = new DataTable(tableName);
                dsEmpty.Tables.Add(dtEmpty);

                using (var sw = new StringWriter())
                using (var xw = XmlWriter.Create(sw))
                {
                    dsEmpty.WriteXml(xw, XmlWriteMode.IgnoreSchema);
                    return sw.ToString();
                }
            }

            dt.TableName = tableName;

            var ds = new DataSet();
            ds.Tables.Add(dt);

            using (var sw = new StringWriter())
            using (var xw = XmlWriter.Create(sw))
            {
                ds.WriteXml(xw, XmlWriteMode.IgnoreSchema);
                return sw.ToString();
            }
        }
        private DataTable TryDeserializeArrayToDataTable(string json)
        {
            try
            {
                var token = JToken.Parse(json);
                if (token is JArray arr && arr.Count > 0 && arr[0].Type == JTokenType.Object)
                {
                    return arr.ToObject<DataTable>();
                }
            }
            catch
            {
                // ignorar y seguir con otros enfoques
            }
            return null;
        }

        /// <summary>
        /// Convierte un JToken escalar a string (para poner en celda).
        /// </summary>
        private static string TokenToScalarString(JToken token)
        {
            if (token == null || token.Type == JTokenType.Null)
                return string.Empty;

            if (token.Type == JTokenType.Boolean)
                return token.Value<bool>() ? "true" : "false";

            if (token.Type == JTokenType.Date)
                return token.Value<DateTime>().ToString("yyyy-MM-ddTHH:mm:ss");

            if (token.Type == JTokenType.Integer || token.Type == JTokenType.Float || token.Type == JTokenType.String)
                return token.ToString();

            // Para objetos/arrays anidados, serializamos compactos para no perder información
            return token.ToString(Formatting.None);
        }

        private static DataTable ListDictToDataTable(IEnumerable<Dictionary<string, object>> rows)
        {
            var dt = new DataTable();
            if (rows == null)
                return dt;

            // 1) Unir todas las llaves para definir el esquema
            var allCols = new LinkedHashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var r in rows)
            {
                if (r == null) continue;
                foreach (var k in r.Keys)
                    allCols.Add(k);
            }

            // 2) Crear columnas como string (robusto frente a tipos mixtos)
            foreach (var col in allCols)
                dt.Columns.Add(col, typeof(string));

            // 3) Poblar filas
            foreach (var r in rows)
            {
                var dr = dt.NewRow();
                if (r != null)
                {
                    foreach (var kv in r)
                    {
                        if (!dt.Columns.Contains(kv.Key)) continue;
                        dr[kv.Key] = ObjToCellString(kv.Value);
                    }
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }

    
        /// Conversión segura a string para celdas XML (compatible con C# 7.3).
        /// - Null → ""
        /// - bool → "true"/"false"
        /// - DateTime/DateTimeOffset → ISO
        /// - Números → InvariantCulture
        /// - string → tal cual
        /// - Objetos/colecciones → JSON compacto
        /// </summary>
        private static string ObjToCellString(object value)
        {
            if (value == null || value == DBNull.Value)
                return string.Empty;

            // bool
            if (value is bool b)
                return b ? "true" : "false";

            // DateTime
            if (value is DateTime dt)
                return dt.ToString("yyyy-MM-ddTHH:mm:ss");

            // DateTimeOffset
            if (value is DateTimeOffset dto)
                return dto.ToString("yyyy-MM-ddTHH:mm:sszzz");

            // string
            if (value is string s)
                return s;

            // Números: usar TypeCode para cubrir todos los tipos primitivos
            var tc = Type.GetTypeCode(value.GetType());
            switch (tc)
            {
                case TypeCode.SByte:
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    return Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture);

                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    // IFormattable para asegurar InvariantCulture
                    var f = value as IFormattable;
                    return (f != null)
                        ? f.ToString(null, System.Globalization.CultureInfo.InvariantCulture)
                        : Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture);
            }

            // Objetos complejos / colecciones → JSON compacto para no perder información
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(value,
                    new Newtonsoft.Json.JsonSerializerSettings { Formatting = Newtonsoft.Json.Formatting.None });
            }
            catch
            {
                // Fallback final
                return value.ToString();
            }
        }

        /// <summary>
        /// Conjunto que preserva orden de inserción.
        /// </summary>
        private sealed class LinkedHashSet<T> : ICollection<T>
        {
            private readonly Dictionary<T, object> _map;
            private static readonly object _dummy = new object();

            public LinkedHashSet() : this(null) { }
            public LinkedHashSet(IEqualityComparer<T> comparer)
            {
                _map = new Dictionary<T, object>(comparer);
                Order = new List<T>();
            }

            private List<T> Order { get; }

            public int Count => _map.Count;
            public bool IsReadOnly => false;

            public bool Add(T item)
            {
                if (_map.ContainsKey(item)) return false;
                _map[item] = _dummy;
                Order.Add(item);
                return true;
            }

            void ICollection<T>.Add(T item) => Add(item);

            public bool Contains(T item) => _map.ContainsKey(item);
            public void Clear() { _map.Clear(); Order.Clear(); }
            public void CopyTo(T[] array, int arrayIndex) => Order.CopyTo(array, arrayIndex);
            public bool Remove(T item)
            {
                if (!_map.Remove(item)) return false;
                Order.Remove(item);
                return true;
            }

            public IEnumerator<T> GetEnumerator() => Order.GetEnumerator();
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion 

    }
}
