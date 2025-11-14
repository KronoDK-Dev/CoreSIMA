using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Web;

namespace Utilitario
{
    public class Helper
    {
        private static DataRow createRowClone(DataRow sourceRow, DataRow newRow, string[] fieldNames)
        {
            foreach (string fieldName in fieldNames)
                newRow[fieldName] = sourceRow[fieldName];
            return newRow;
        }

        private static void setLastValues(object[] lastValues, DataRow sourceRow, string[] fieldNames)
        {
            for (int index = 0; index < fieldNames.Length; ++index)
                lastValues[index] = sourceRow[fieldNames[index]];
        }

        public static string MensajesIngresarMetodo() => "Ingresó al Metodo.";

        public static string MensajesSalirMetodo() => "Salió del Metodo.";

        public static DataTable CallServiceRestOracle(string Metodo, string oParams)
        {
            string xpath = "//Table";
            string result = Helper.LoadBackGroundWS(Metodo, oParams).Result;
            XmlDocument node = new XmlDocument();
            node.LoadXml(result);
            node.SelectNodes(xpath);
            DataSet dataSet = new DataSet();
            int num = (int)dataSet.ReadXml((XmlReader)new XmlNodeReader((XmlNode)node));
            DataTable table = dataSet.Tables[0];
            table.TableName = "Table";
            return table;
        }

        public static DataTable ReplyServiceRestOracle(string Metodo, string oParams)
        {
            string xpath = "//Table";
            string result = Helper.WriteBackGroundWS(Metodo, oParams).Result;
            XmlDocument node = new XmlDocument();
            node.LoadXml(result);
            node.SelectNodes(xpath);
            DataSet dataSet = new DataSet();
            int num = (int)dataSet.ReadXml((XmlReader)new XmlNodeReader((XmlNode)node));
            DataTable table = dataSet.Tables[0];
            table.TableName = "Table";
            return table;
        }

        private static async Task<string> LoadBackGroundWS(string Metodo, string ListaParametrosValor)
        {
            string str1 = Helper.Configuracion.BaseConfig("WebServiceSIMAOracle", "WSUser");
            string str2 = Helper.Configuracion.BaseConfig("WebServiceSIMAOracle", "WSPwd");
            string str3 = ListaParametrosValor;
            string str4 = Helper.Configuracion.BaseConfig("WebServiceSIMAOracle", "PathWSOracle");
            string str5;
            using (HttpClient httpWS = new HttpClient())
            {
                httpWS.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{str1}:{str2}")));
                str5 = (await (await httpWS.GetAsync(str4 + Constante.Caracteres.Punto + Metodo + Constante.Caracteres.interrogacion + str3)).Content.ReadAsStringAsync()).Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            }
            return str5;
        }

        private static async Task<string> WriteBackGroundWS(string Metodo, string ListaParametrosValor)
        {
            string str1 = Helper.Configuracion.BaseConfig("WebServiceSIMAOracle", "WSUser");
            string str2 = Helper.Configuracion.BaseConfig("WebServiceSIMAOracle", "WSPwd");
            string content1 = ListaParametrosValor;
            string str3 = Helper.Configuracion.BaseConfig("WebServiceSIMAOracle", "PathWSOracle");
            string str4;
            using (HttpClient httpWS = new HttpClient())
            {
                httpWS.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{str1}:{str2}")));
                HttpContent content2 = (HttpContent)new StringContent(content1, Encoding.UTF8, "text/plain");
                str4 = (await (await httpWS.PostAsync(str3 + Constante.Caracteres.Punto + Metodo + Constante.Caracteres.interrogacion, content2)).Content.ReadAsStringAsync()).Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            }
            return str4;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct Configuracion
        {
            public static string BaseConfig(string Seccion, string Key)
            {
                return ((Hashtable)ConfigurationManager.GetSection(Seccion))[(object)Key].ToString();
            }

            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct Autenticacion
            {
                public static string getLDAP
                {
                    get => Helper.Configuracion.BaseConfig(nameof(Autenticacion), "CadenaLDAP");
                }
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct Data
        {
            public static DataTable GroupBy(
              DataTable SourceTable,
              string[] FieldNamesGroup,
              string[] FieldsNamesFnAgregado)
            {
                return Helper.Data.GroupBy(SourceTable, "", FieldNamesGroup, FieldsNamesFnAgregado);
            }

            public static DataTable GroupBy(
              DataTable SourceTable,
              string Where,
              string[] FieldNamesGroup,
              string[] FieldsNamesFnAgregado)
            {
                object[] lastValues = FieldNamesGroup != null && FieldNamesGroup.Length != 0 ? new object[FieldNamesGroup.Length] : throw new ArgumentNullException("FieldNames");
                DataTable dataTable = new DataTable();
                foreach (string str in FieldNamesGroup)
                    dataTable.Columns.Add(str, SourceTable.Columns[str].DataType);
                if (FieldsNamesFnAgregado != null)
                {
                    foreach (string str in FieldsNamesFnAgregado)
                        dataTable.Columns.Add(str, SourceTable.Columns[str].DataType);
                }
                foreach (DataRow dataRow in SourceTable.Select(Where, string.Join(", ", FieldNamesGroup)))
                {
                    if (!Helper.Data.fieldValuesAreEqual(lastValues, dataRow, FieldNamesGroup))
                    {
                        DataRow rowClone = Helper.createRowClone(dataRow, dataTable.NewRow(), FieldNamesGroup);
                        dataTable.Rows.Add(rowClone);
                        string filter = "";
                        for (int index = 0; index <= FieldNamesGroup.Length - 1; ++index)
                        {
                            string str = FieldNamesGroup.Length - 1 == index ? " " : " and";
                            if (SourceTable.Columns[FieldNamesGroup[index].ToString()].DataType.ToString().Equals("System.String"))
                                filter = $"{filter} {FieldNamesGroup[index].ToString()}='{rowClone[FieldNamesGroup[index].ToString()].ToString()}'{str}";
                            else
                                filter = $"{filter} {FieldNamesGroup[index].ToString()}={rowClone[FieldNamesGroup[index].ToString()].ToString()}{str}";
                        }
                        if (FieldsNamesFnAgregado != null)
                        {
                            for (int index = 0; index <= FieldsNamesFnAgregado.Length - 1; ++index)
                            {
                                object obj = SourceTable.Compute($"sum({FieldsNamesFnAgregado[index].ToString()})", filter);
                                dataTable.Rows[dataTable.Rows.Count - 1][FieldsNamesFnAgregado[index].ToString()] = obj;
                            }
                        }
                        dataTable.AcceptChanges();
                        Helper.setLastValues(lastValues, dataRow, FieldNamesGroup);
                    }
                }
                return dataTable;
            }

            public static DataTable SelectDistinct(DataTable SourceTable, params string[] FieldNames)
            {
                object[] lastValues = FieldNames != null && FieldNames.Length != 0 ? new object[FieldNames.Length] : throw new ArgumentNullException(nameof(FieldNames));
                DataTable dataTable = new DataTable();
                foreach (string fieldName in FieldNames)
                    dataTable.Columns.Add(fieldName, SourceTable.Columns[fieldName].DataType);
                foreach (DataRow dataRow in SourceTable.Select("", string.Join(", ", FieldNames)))
                {
                    if (!Helper.Data.fieldValuesAreEqual(lastValues, dataRow, FieldNames))
                    {
                        dataTable.Rows.Add(Helper.createRowClone(dataRow, dataTable.NewRow(), FieldNames));
                        Helper.setLastValues(lastValues, dataRow, FieldNames);
                    }
                }
                return dataTable;
            }

            private static bool fieldValuesAreEqual(
              object[] lastValues,
              DataRow currentRow,
              string[] fieldNames)
            {
                bool flag = true;
                for (int index = 0; index < fieldNames.Length; ++index)
                {
                    if (lastValues[index] == null || !lastValues[index].Equals(currentRow[fieldNames[index]]))
                    {
                        flag = false;
                        break;
                    }
                }
                return flag;
            }

            public static DataTable DataViewTODataTable(DataView dvDataOrigen)
            {
                if (dvDataOrigen == null)
                    return (DataTable)null;
                DataTable dataTable = dvDataOrigen.Table.Clone();
                int num = 0;
                string[] strArray = new string[dataTable.Columns.Count];
                foreach (DataColumn column in (InternalDataCollectionBase)dataTable.Columns)
                    strArray[num++] = column.ColumnName;
                foreach (DataRowView dataRowView in dvDataOrigen)
                {
                    DataRow row = dataTable.NewRow();
                    try
                    {
                        foreach (string str in strArray)
                            row[str] = dataRowView[str];
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                    }
                    dataTable.Rows.Add(row);
                }
                return dataTable;
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct Archivo
        {
            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct Configuracion
            {
                public static string getKey(string Seccion, string key)
                {
                    return ((Hashtable)ConfigurationManager.GetSection(Seccion))[(object)key].ToString();
                }

                [StructLayout(LayoutKind.Sequential, Size = 1)]
                public struct All_Section
                {
                    public static string ArchivoLog => "LogFile";
                }

                [StructLayout(LayoutKind.Sequential, Size = 1)]
                public struct All_Keys
                {
                    public static string PATH_ARCHIVO_LOG => "RutaFileLog";

                    public static string NOMBRE_ARCHIVO_LOG => "LogFileName";
                }
            }

            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct Log
            {
                public static void Write(string message)
                {
                    string str1 = Helper.Archivo.Configuracion.getKey(Helper.Archivo.Configuracion.All_Section.ArchivoLog, Helper.Archivo.Configuracion.All_Keys.PATH_ARCHIVO_LOG) + Helper.Archivo.Configuracion.getKey(Helper.Archivo.Configuracion.All_Section.ArchivoLog, Helper.Archivo.Configuracion.All_Keys.NOMBRE_ARCHIVO_LOG);
                    DateTime dateTime = DateTime.Today;
                    dateTime = dateTime.AddMonths(-1);
                    string str2 = dateTime.ToString(Constante.Formato.Fecha.YYYYMM);
                    string txt = Constante.Archivo.Extension.TXT;
                    string path = str1 + str2 + txt;
                    CultureInfo invariantCulture = CultureInfo.InvariantCulture;
                    try
                    {
                        StreamWriter streamWriter = new StreamWriter((Stream)new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write));
                        streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
                        message = message.Replace(Environment.NewLine, Constante.Caracteres.Espacio + Constante.Caracteres.SeperadorSimple + Constante.Caracteres.Espacio);
                        message = message.Replace("\r\n", " | ").Replace("\n", Constante.Caracteres.Espacio + Constante.Caracteres.SeperadorSimple + Constante.Caracteres.Espacio).Replace("\r", Constante.Caracteres.Espacio + Constante.Caracteres.SeperadorSimple + Constante.Caracteres.Espacio);
                        streamWriter.WriteLine($"{DateTime.Now.ToString(Constante.Formato.Hora.HHmmssFFF, (IFormatProvider)invariantCulture)} {message}");
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                    catch
                    {
                    }
                }
            }

            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct XMLinURL
            {
                public static void TransaccionalAccesoDatos(string Resultado)
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = "text/xml";
                    HttpContext.Current.Response.Write($"{"<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n" + "<DATASET>\n" + "  <DataTable>\n"}    <Resultado>{Resultado.ToString()}</Resultado>\n" + "  </DataTable>\n" + "</DATASET>");
                }
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct Cadena
        {
            public static string CortarTextoDerecha(int tamaño, string texto)
            {
                return texto.Substring(texto.Length - tamaño, tamaño);
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct WebAppi
        {
            public static ResposeBE Post(string _Url, object EntityBE)
            {
                return Helper.WebAppi.result(_Url, EntityBE);
            }

            public static ResposeBE Get(string _Url, object EntityBE)
            {
                return Helper.WebAppi.result(_Url, EntityBE);
            }

            private static ResposeBE result(string _Url, object EntityBE)
            {
                ResposeBE resposeBe = new ResposeBE();
                return Helper.WebAppi._PostGet(_Url, EntityBE).Result;
            }

            private static readonly HttpClient httpClient = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true // Solo si es necesario
            });

            private static async Task<ResposeBE> _PostGet(string _Url, object EntityBE)
            {
                ResposeBE oResposeBE = new ResposeBE();
                ResposeBE resposeBe;
                using (HttpClient httpClient = new HttpClient((HttpMessageHandler)new HttpClientHandler()
                       {
                           ServerCertificateCustomValidationCallback = (Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool>)((sender, cert, chain, sslPolicyErrors) => true)
                       }))
                {
                    HttpResponseMessage respuesta = await httpClient.PostAsJsonAsync<object>(_Url, EntityBE).ConfigureAwait(false);
                    string str = await respuesta.Content.ReadAsStringAsync();
                    oResposeBE.Mensaje = Helper.WebAppi.SeriaizedDiccionario(respuesta.RequestMessage.ToString());
                    oResposeBE.Mensaje.Add("StatusOperacion", str);
                    oResposeBE.Status = respuesta.StatusCode;
                    oResposeBE.ObjResult = str;
                    resposeBe = oResposeBE;
                }
                oResposeBE = (ResposeBE)null;
                return resposeBe;
            }


            /*
            private static async Task<ResposeBE> PostAsync<T>(string url, T entity)
            {
                var responseBe = new ResposeBE();

                try
                {
                    using var response = await httpClient.PostAsJsonAsync(url, entity).ConfigureAwait(false);
                    string content = await response.Content.ReadAsStringAsync();

                    responseBe.Status = response.StatusCode;
                    responseBe.ObjResult = content;

                    if (response.IsSuccessStatusCode)
                    {
                        responseBe.Mensaje = new Dictionary<string, string>
                        {
                            { "StatusOperacion", "OK" }
                        };
                    }
                    else
                    {
                        responseBe.Mensaje = new Dictionary<string, string>
                        {
                            { "Error", $"Código HTTP {(int)response.StatusCode}: {response.ReasonPhrase}" }
                        };
                    }
                }
                catch (Exception ex)
                {
                    responseBe.Mensaje = new Dictionary<string, string>
                    {
                        { "Exception", ex.Message }
                    };
                    responseBe.Status = System.Net.HttpStatusCode.InternalServerError;
                }

                return responseBe;
            }
            */

            private static async Task<string> _PostGete(string _Url, object EntityBE)
            {
                using (HttpClient httpClient = new HttpClient((HttpMessageHandler)new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool>)((sender, cert, chain, sslPolicyErrors) => true)
                }))
                {
                    HttpResponseMessage respuesta = await httpClient.PostAsJsonAsync<object>(_Url, EntityBE).ConfigureAwait(false);
                    string strrptBE = await respuesta.Content.ReadAsStringAsync();
                    switch (respuesta.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            return (await respuesta.Content.ReadAsStringAsync()).ToString();
                        case HttpStatusCode.BadRequest:
                            Helper.WebAppi.ExtraerErroresDelWebAPI(await respuesta.Content.ReadAsStringAsync());
                            return strrptBE;
                        case HttpStatusCode.NotFound:
                            return $"{{status:NotFound,{respuesta.RequestMessage.ToString()}}}";
                        default:
                            return "";
                    }
                }
            }

            public static Dictionary<string, List<string>> ExtraerErroresDelWebAPI(string json)
            {
                Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
                foreach (JsonProperty jsonProperty in JsonSerializer.Deserialize<JsonElement>(json).GetProperty("errors").EnumerateObject())
                {
                    string name = jsonProperty.Name;
                    List<string> stringList = new List<string>();
                    foreach (JsonElement enumerate in jsonProperty.Value.EnumerateArray())
                    {
                        string str = enumerate.GetString();
                        stringList.Add(str);
                    }
                    dictionary.Add(name, stringList);
                }
                return dictionary;
            }

            public static Dictionary<string, string> SeriaizedDiccionario(string oStringEntity)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                oStringEntity = oStringEntity.Replace("{", "").Replace("}", "");
                string str1 = oStringEntity;
                char[] chArray = new char[1] { ',' };
                foreach (string str2 in str1.Split(chArray))
                {
                    string[] strArray = str2.Split(Constante.Caracteres.DosPunto.ToCharArray());
                    string str3;
                    if (strArray.Length > 2)
                    {
                        int startIndex = strArray[0].Length + 1;
                        str3 = str2.Substring(startIndex, str2.Length - startIndex);
                    }
                    else
                        str3 = strArray[1];
                    dictionary[strArray[0].Replace(Constante.Caracteres.ComillasDobles.ToString(), "")] = str3.Replace(Constante.Caracteres.ComillasDobles.ToString(), "").Replace("'", "");
                }
                return dictionary;
            }
        }
    }
}
