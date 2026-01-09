using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Xml;



namespace Utilitario
{


    public class ResposeBE
    {
        public ResposeBE() { }

        // public string Status { get; set; }
        public HttpStatusCode Status { get; set; }
        public string ObjResult { get; set; }
        public Dictionary<string,string> Mensaje { get; set; }  
    }

    public class Helper
    {

        public struct Configuracion
        {
            public struct Autenticacion
            {
                public static string getLDAP
                {

                    get { return BaseConfig("Autenticacion", "CadenaLDAP"); }

                }

                /*public static string BaseConfig(string Seccion,string Key)
                {
                    return ((Hashtable)ConfigurationManager.GetSection(Seccion))[Key].ToString(); 
                }*/
            }
            public static string BaseConfig(string Seccion, string Key)
            {
                return ((Hashtable)ConfigurationManager.GetSection(Seccion))[Key].ToString();
            }
        }

        public struct Data
        {
            public static DataTable GroupBy(DataTable SourceTable, string[] FieldNamesGroup, string[] FieldsNamesFnAgregado)
            {
                return GroupBy(SourceTable, "", FieldNamesGroup, FieldsNamesFnAgregado);
            }
            public static DataTable GroupBy(DataTable SourceTable, string Where, string[] FieldNamesGroup, string[] FieldsNamesFnAgregado)
            {
                object[] lastValues;
                DataTable newTable;
                DataRow[] orderedRows;

                if (FieldNamesGroup == null || FieldNamesGroup.Length == 0)
                    throw new ArgumentNullException("FieldNames");

                lastValues = new object[FieldNamesGroup.Length];
                newTable = new DataTable();

                foreach (string fieldName in FieldNamesGroup)
                {
                    newTable.Columns.Add(fieldName, SourceTable.Columns[fieldName].DataType);
                }

                if (FieldsNamesFnAgregado != null)
                {
                    foreach (string fieldName in FieldsNamesFnAgregado)
                    {
                        newTable.Columns.Add(fieldName, SourceTable.Columns[fieldName].DataType);
                    }
                }

                orderedRows = SourceTable.Select(Where, string.Join(", ", FieldNamesGroup));

                //SourceTable.Compute(


                foreach (DataRow row in orderedRows)
                {
                    //HttpContext.Current.Response.Write(row["RazonSocial"].ToString()+"<br>");

                    if (!fieldValuesAreEqual(lastValues, row, FieldNamesGroup))
                    {
                        DataRow fila = createRowClone(row, newTable.NewRow(), FieldNamesGroup);
                        newTable.Rows.Add(fila);

                        string Criterio = "";
                        for (int idx = 0; idx <= FieldNamesGroup.Length - 1; idx++)
                        {
                            string op = ((FieldNamesGroup.Length - 1 == idx) ? " " : " and");
                            if (SourceTable.Columns[FieldNamesGroup[idx].ToString()].DataType.ToString().Equals("System.String"))
                            {
                                Criterio = Criterio + " " + FieldNamesGroup[idx].ToString() + "='" + fila[FieldNamesGroup[idx].ToString()].ToString() + "'" + op;
                            }
                            else
                            {
                                Criterio = Criterio + " " + FieldNamesGroup[idx].ToString() + "=" + fila[FieldNamesGroup[idx].ToString()].ToString() + op;
                            }
                        }
                        if (FieldsNamesFnAgregado != null)
                        {
                            for (int idx = 0; idx <= FieldsNamesFnAgregado.Length - 1; idx++)
                            {
                                object drtotal = SourceTable.Compute("sum(" + FieldsNamesFnAgregado[idx].ToString() + ")", Criterio);
                                newTable.Rows[newTable.Rows.Count - 1][FieldsNamesFnAgregado[idx].ToString()] = drtotal;
                            }
                        }
                        newTable.AcceptChanges();
                        setLastValues(lastValues, row, FieldNamesGroup);
                    }
                }
                return newTable;
            }


            public static DataTable SelectDistinct(DataTable SourceTable, params string[] FieldNames)
            {
                object[] lastValues;
                DataTable newTable;
                DataRow[] orderedRows;

                if (FieldNames == null || FieldNames.Length == 0)
                    throw new ArgumentNullException("FieldNames");

                lastValues = new object[FieldNames.Length];
                newTable = new DataTable();

                foreach (string fieldName in FieldNames)
                    newTable.Columns.Add(fieldName, SourceTable.Columns[fieldName].DataType);

                orderedRows = SourceTable.Select("", string.Join(", ", FieldNames));

                foreach (DataRow row in orderedRows)
                {
                    if (!fieldValuesAreEqual(lastValues, row, FieldNames))
                    {
                        newTable.Rows.Add(createRowClone(row, newTable.NewRow(), FieldNames));

                        setLastValues(lastValues, row, FieldNames);
                    }
                }

                return newTable;
            }

            private static bool fieldValuesAreEqual(object[] lastValues, DataRow currentRow, string[] fieldNames)
            {
                bool areEqual = true;

                for (int i = 0; i < fieldNames.Length; i++)
                {
                    if (lastValues[i] == null || !lastValues[i].Equals(currentRow[fieldNames[i]]))
                    {
                        areEqual = false;
                        break;
                    }
                }

                return areEqual;
            }

            public static DataTable DataViewTODataTable(DataView dvDataOrigen)
            {
                if (dvDataOrigen == null) return null;
                DataTable obNewDt = dvDataOrigen.Table.Clone();
                int idx = 0;
                string[] strColNames = new string[obNewDt.Columns.Count];
                foreach (DataColumn col in obNewDt.Columns)
                {
                    strColNames[idx++] = col.ColumnName;
                }

                IEnumerator viewEnumerator = dvDataOrigen.GetEnumerator();
                while (viewEnumerator.MoveNext())
                {
                    DataRowView drv = (DataRowView)viewEnumerator.Current;
                    DataRow dr = obNewDt.NewRow();
                    try
                    {
                        foreach (string strName in strColNames)
                        {
                            dr[strName] = drv[strName];
                        }
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                    }
                    obNewDt.Rows.Add(dr);
                }
                return obNewDt;
            }



        }




        private static DataRow createRowClone(DataRow sourceRow, DataRow newRow, string[] fieldNames)
        {
            foreach (string field in fieldNames)
                newRow[field] = sourceRow[field];

            return newRow;
        }

        private static void setLastValues(object[] lastValues, DataRow sourceRow, string[] fieldNames)
        {
            for (int i = 0; i < fieldNames.Length; i++)
                lastValues[i] = sourceRow[fieldNames[i]];
        }

        public struct Archivo
        {
            public struct Configuracion
            {
                public struct All_Section
                {
                    public static string ArchivoLog
                    {
                        get { return "LogFile"; }
                    }
                }


                public struct All_Keys
                {
                    public static string PATH_ARCHIVO_LOG
                    {
                        get { return "RutaFileLog"; }
                    }
                    public static string NOMBRE_ARCHIVO_LOG
                    {
                        get { return "LogFileName"; }
                    }

                }


                public static string getKey(string Seccion, string key)
                {

                    return ((System.Collections.Hashtable)ConfigurationManager.GetSection(Seccion))[key].ToString();
                }

            }
            public struct Log
            {

                public static void Write(string message)
                {
                    string path = Helper.Archivo.Configuracion.getKey(Helper.Archivo.Configuracion.All_Section.ArchivoLog, Helper.Archivo.Configuracion.All_Keys.PATH_ARCHIVO_LOG) + Helper.Archivo.Configuracion.getKey(Helper.Archivo.Configuracion.All_Section.ArchivoLog, Helper.Archivo.Configuracion.All_Keys.NOMBRE_ARCHIVO_LOG);
                    string ArchivoLog = path + DateTime.Today.AddMonths(-1).ToString(Constante.Formato.Fecha.YYYYMM) + Constante.Archivo.Extension.TXT;
                    CultureInfo ci = CultureInfo.InvariantCulture;
                    try
                    {
                        FileStream fs = new FileStream(ArchivoLog, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter m_streamWriter = new StreamWriter(fs);
                        m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                        //Quitar posibles saltos de línea del mensaje
                        message = message.Replace(Environment.NewLine, Constante.Caracteres.Espacio + Constante.Caracteres.SeperadorSimple + Constante.Caracteres.Espacio);
                        message = message.Replace("\r\n", " | ").Replace("\n", Constante.Caracteres.Espacio + Constante.Caracteres.SeperadorSimple + Constante.Caracteres.Espacio).Replace("\r", Constante.Caracteres.Espacio + Constante.Caracteres.SeperadorSimple + Constante.Caracteres.Espacio);
                        m_streamWriter.WriteLine(DateTime.Now.ToString(Constante.Formato.Hora.HHmmssFFF, ci) + " " + message);
                        m_streamWriter.Flush();
                        m_streamWriter.Close();
                    }
                    catch
                    {
                        //Silenciosa
                    }
                }
            }

            public struct XMLinURL
            {

                public static void TransaccionalAccesoDatos(string Resultado)
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = "text/xml";
                    string output = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
                    output += "<DATASET>\n";
                    output += "  <DataTable>\n";
                    output += "    <Resultado>" + Resultado.ToString() + "</Resultado>\n";
                    output += "  </DataTable>\n";
                    output += "</DATASET>";
                    HttpContext.Current.Response.Write(output);
                    //HttpContext.Current.Response.End();  
                }
            }

        }



        public struct Cadena
        {
            public static string CortarTextoDerecha(int tamaño, string texto)
            {
                return texto.Substring(texto.Length - tamaño, tamaño);

            }
        }


        /*--------------------------------------------------------------------------------------------*/
        /* COD OLD*/
        public static string MensajesIngresarMetodo()
        {
            return "Ingresó al Metodo.";
        }

        public static string MensajesSalirMetodo()
        {
            return "Salió del Metodo.";
        }


        /* LLAMADA AL SERVICIO */
        public static DataTable CallServiceRestOracle(string Metodo, string oParams)
        {
            string TagName = "//Table";
            string strData = LoadBackGroundWS(Metodo, oParams).Result;

            XmlDocument Mi_xml = new XmlDocument();
            Mi_xml.LoadXml(strData);

            XmlNodeList datos_XML = Mi_xml.SelectNodes(TagName); // se coloca el nombre de nodo que es la tabla/vista

            DataSet conjunto_dx = new DataSet();
            conjunto_dx.ReadXml(new XmlNodeReader(Mi_xml));

            DataTable dt = conjunto_dx.Tables[0];
            dt.TableName = "Table";
            return dt;
        }

        /* RESPONDE AL SERVICIO */
        public static DataTable ReplyServiceRestOracle(string Metodo, string oParams)
        {
            string TagName = "//Table";
            string strData = WriteBackGroundWS(Metodo, oParams).Result;

            XmlDocument Mi_xml = new XmlDocument();
            Mi_xml.LoadXml(strData);

            XmlNodeList datos_XML = Mi_xml.SelectNodes(TagName); // se coloca el nombre de nodo que es la tabla/vista

            DataSet conjunto_dx = new DataSet();
            conjunto_dx.ReadXml(new XmlNodeReader(Mi_xml));

            DataTable dt = conjunto_dx.Tables[0];
            dt.TableName = "Table";
            return dt;
        }
        // LEE EL SERVICIO
        static async Task<string> LoadBackGroundWS(string Metodo, string ListaParametrosValor)
        {
            //referencia : https://stackoverflow.com/questions/40291526/why-async-function-returning-system-threading-tasks-task1system-string
            string susername = Helper.Configuracion.BaseConfig("WebServiceSIMAOracle", "WSUser");
            string spassword = Helper.Configuracion.BaseConfig("WebServiceSIMAOracle", "WSPwd");
            string sParametros = ListaParametrosValor;


            string sServicio = Helper.Configuracion.BaseConfig("WebServiceSIMAOracle", "PathWSOracle"); //"http://10.10.90.168:7060/xml_oracle/xml_api";
                                                                                                        //string sMetodo = ".get_planilla?"; // En este metodo esta expuesta toda la información necesaria

            using (var httpWS = new HttpClient())
            {
                httpWS.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(susername + ":" + spassword)));
                var resultado = await httpWS.GetAsync(sServicio + Utilitario.Constante.Caracteres.Punto + Metodo + Utilitario.Constante.Caracteres.interrogacion + sParametros);

                string get_contenido = await resultado.Content.ReadAsStringAsync();

                get_contenido = get_contenido.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
                return get_contenido;
            }

        }

        // ESCRIBE EN EL SERVICIO
        static async Task<string> WriteBackGroundWS(string Metodo, string ListaParametrosValor)
        {
            //referencia : https://stackoverflow.com/questions/40291526/why-async-function-returning-system-threading-tasks-task1system-string
            string susername = Helper.Configuracion.BaseConfig("WebServiceSIMAOracle", "WSUser");
            string spassword = Helper.Configuracion.BaseConfig("WebServiceSIMAOracle", "WSPwd");
            string sParametros = ListaParametrosValor;


            string sServicio = Helper.Configuracion.BaseConfig("WebServiceSIMAOracle", "PathWSOracle"); //"http://10.10.90.168:7060/xml_oracle/xml_api";
                                                                                                        //string sMetodo = ".get_planilla?"; // En este metodo esta expuesta toda la información necesaria

            using (var httpWS = new HttpClient())
            {
                httpWS.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(susername + ":" + spassword)));
                HttpContent contenido = new StringContent(sParametros, Encoding.UTF8, "text/plain");
                var resultado = await httpWS.PostAsync(sServicio + Utilitario.Constante.Caracteres.Punto + Metodo + Utilitario.Constante.Caracteres.interrogacion,
                                                       contenido);
                string get_contenido = await resultado.Content.ReadAsStringAsync();
                get_contenido = get_contenido.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
                return get_contenido;
            }

        }


        public struct WebAppi{

            public struct Rest {
                    public static ResposeBE Send(ApiInfoBE _ApiInfoBE) {
                        ResposeBE oResposeBE = new ResposeBE();
                        try
                            {
                            oResposeBE = (ResposeBE)BackGroudRest(_ApiInfoBE).Result;
                        }
                        catch (Exception ex)
                        {
                            int i = 0;

                        }
                        return oResposeBE;
                    }

            }
            public static async Task<ResposeBE> BackGroudRest( ApiInfoBE oApiInfoBE)
            {
                var baseAddress = oApiInfoBE.Url; 
                var endpoint = oApiInfoBE.Metodo; 

                var client = new HttpClient
                {
                    BaseAddress = new Uri(baseAddress)
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(oApiInfoBE.MediaType));// "application/json"
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "a28ASXzbGF0YDF256Dds41iYWxmYSI6ImE4OTM0Y2as51");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(oApiInfoBE.Tipo.ToString(), oApiInfoBE.TokenValue);

                /*var body = new
                {
                    nroDOI = "45105752"
                };*/
                var body = oApiInfoBE.BodyParam;

                var content = new StringContent(
                    JsonSerializer.Serialize(body),
                    Encoding.UTF8,
                    oApiInfoBE.MediaType
                );

                var response = client.PostAsync(endpoint, content).Result;

                ResposeBE oResposeBE = new ResposeBE();

                if (!response.IsSuccessStatusCode)
                {
                     //return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                   // oResposeBE.Mensaje = response.Content.ReadAsStringAsync().Result.ToString();
                    oResposeBE.Status = response.StatusCode;
                    return oResposeBE;
                }

                var strrptBE = await response.Content.ReadAsStringAsync();

                string strResult = response.RequestMessage.ToString();
                oResposeBE.Mensaje = Utilitario.Helper.WebAppi.SeriaizedDiccionario(strResult);
                oResposeBE.Mensaje.Add("StatusOperacion", strrptBE);
                oResposeBE.Status = response.StatusCode;
                oResposeBE.ObjResult = strrptBE;

                return oResposeBE;
            }


            public static ResposeBE Post(string _Url, object EntityBE)
            {
                return result(_Url, EntityBE);
            }
            public static ResposeBE Get(string _Url, object EntityBE)
            {
                return result(_Url, EntityBE);
            }
            static ResposeBE result(string _Url, object EntityBE)
            {
                ResposeBE oResposeBE = new ResposeBE();
                oResposeBE = Utilitario.Helper.WebAppi._PostGet(_Url, EntityBE).Result;
                return oResposeBE;
            }

      
            static async Task<ResposeBE> _PostGet(string _Url, object EntityBE)
            {
                /*rEFERENCIA PARA OBVIAR EL BLOQUEO: https://stackoverflow.com/questions/30653770/httpclient-postasjsonasync-never-sees-when-the-post-is-succeeding-and-responding
                 */
                ResposeBE oResposeBE = new ResposeBE();
                var strResult= "";

                HttpClientHandler clientHandler = new HttpClientHandler();//para evitar la certificacion
                    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


                    using (var httpClient = new HttpClient(clientHandler))
                    {
                        var respuesta = await httpClient.PostAsJsonAsync(_Url, EntityBE).ConfigureAwait(false);
                        var strrptBE = await respuesta.Content.ReadAsStringAsync();

                        strResult = respuesta.RequestMessage.ToString();
                        oResposeBE.Mensaje = Utilitario.Helper.WebAppi.SeriaizedDiccionario(strResult);
                        oResposeBE.Mensaje.Add("StatusOperacion", strrptBE);
                        oResposeBE.Status = respuesta.StatusCode;
                        oResposeBE.ObjResult = strrptBE;

                        return oResposeBE; ;
                    }
            }

            static async Task<string> _PostGete(string _Url, object EntityBE)
            {
                /*rEFERENCIA PARA OBVIAR EL BLOQUEO: https://stackoverflow.com/questions/30653770/httpclient-postasjsonasync-never-sees-when-the-post-is-succeeding-and-responding
                 */

                HttpClientHandler clientHandler = new HttpClientHandler();//para evitar la certificacion
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (var httpClient = new HttpClient(clientHandler))
                {
                    var respuesta = await httpClient.PostAsJsonAsync(_Url, EntityBE).ConfigureAwait(false);
                    var strrptBE = await respuesta.Content.ReadAsStringAsync();

                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            var cuerpo = await respuesta.Content.ReadAsStringAsync();

                            return cuerpo.ToString();
                            break;
                        case HttpStatusCode.BadRequest:
                            var cuerpo1 = await respuesta.Content.ReadAsStringAsync();
                            var erroresDelAPI1 = ExtraerErroresDelWebAPI(cuerpo1);
                            return strrptBE;
                            break;
                        case HttpStatusCode.NotFound:
                            string errDes = respuesta.RequestMessage.ToString();
                            return "{status:NotFound," + errDes + "}";
                            break;
                    }
                    return "";
                    /* if (respuesta.StatusCode == HttpStatusCode.BadRequest)
                     {
                         var cuerpo = await respuesta.Content.ReadAsStringAsync();
                         var erroresDelAPI = ExtraerErroresDelWebAPI(cuerpo);

                          //foreach (var campoErrores in erroresDelAPI)
                          //{
                          //    Console.WriteLine($"-{campoErrores.Key}");
                          //    foreach (var error in campoErrores.Value)
                          //    {
                          //        Console.WriteLine($"  {error}");
                          //    }
                          //}
                     }
                     return strrptBE;*/
                }


            }



            public static Dictionary<string, List<string>> ExtraerErroresDelWebAPI(string json)
            {
                var respuesta = new Dictionary<string, List<string>>();

                var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
                var errorsJsonElement = jsonElement.GetProperty("errors");

                foreach (var campoConErrores in errorsJsonElement.EnumerateObject())
                {
                    var campo = campoConErrores.Name;
                    var errores = new List<string>();
                    foreach (var errorKind in campoConErrores.Value.EnumerateArray())
                    {
                        var error = errorKind.GetString();
                        errores.Add(error);
                    }
                    respuesta.Add(campo, errores);
                }

                return respuesta;
            }

            public static Dictionary<string, string> SeriaizedDiccionario(string oStringEntity)
            {
                Dictionary<string, string> DataDiconario = new Dictionary<string, string>();
                oStringEntity = oStringEntity.Replace("{", "").Replace("}", "");
                string[] Items = oStringEntity.Split(',');
                foreach (string FV in Items)
                {
                    string[] Fiel_Value = FV.Split(Utilitario.Constante.Caracteres.DosPunto.ToCharArray());
                    string value = "";
                    if (Fiel_Value.Length > 2)
                    {
                        int LongIni = Fiel_Value[0].Length + 1;
                        value = FV.Substring(LongIni, (FV.Length - LongIni));
                    }
                    else
                    {
                        value = Fiel_Value[1];
                    }
                    DataDiconario[Fiel_Value[0].Replace(Utilitario.Constante.Caracteres.ComillasDobles.ToString(),"")] = value.Replace(Utilitario.Constante.Caracteres.ComillasDobles.ToString(), "").Replace("'", "");
                }
                return DataDiconario;
            }




        }





    }
}
