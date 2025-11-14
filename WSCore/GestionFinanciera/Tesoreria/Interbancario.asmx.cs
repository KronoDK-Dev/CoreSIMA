using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Web;
using System.Web.Services;
using Utilitario;
using Controladora.GestionFinanciera.Tesoreria;
using EntidadNegocio.GestionFinanciera.Tesoreria.Pagos;
using WSCore.General;

namespace WSCore.GestionFinanciera.Tesoreria
{
    /// <summary>
    /// Descripción breve de Interbancario
    /// </summary>
    [WebService(Namespace = "http://sima.com.pe/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Interbancario : WebService
    {
        private string cmll = Constante.Caracteres.ComillasDobles;

        [WebMethod]
        public void IniciarTransferencia(string NroLote, string UserName)
        {
            try
            {
                string Resultado = "";
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                DataTable dataTable1 = new CInterbancario().CabeceraLotePago(NroLote, "0", UserName);
                if (dataTable1 != null)
                {
                    DataRow row1 = dataTable1.Rows[0];
                    PlanCabProv planCabProv = new PlanCabProv().SetAttrValue(row1);
                    List<PlanDetProv> planDetProvList = new List<PlanDetProv>();
                    DataTable dataTable2 = new CInterbancario().DetalleLotePago(NroLote, UserName);
                    if (dataTable2.Rows.Count > 0)
                    {
                        foreach (DataRow row2 in (InternalDataCollectionBase)dataTable2.Rows)
                        {
                            PlanDetProv planDetProv = new PlanDetProv().SetAttrValue(row2);
                            planDetProv.detDocBenef = new DetDocBenef();
                            planDetProvList.Add(planDetProv);
                        }
                        planCabProv.listPlanDetProv = (IList<PlanDetProv>)planDetProvList;
                        EntidadNegocio.GestionFinanciera.Tesoreria.Pagos.Archivo archivo = new EntidadNegocio.GestionFinanciera.Tesoreria.Pagos.Archivo("C", row1["nombrePlanilla"].ToString(), ".txt");
                        object EntityBE = (object)new PlanillaPagos()
                        {
                            datos = planCabProv,
                            archivo = archivo
                        };
                        ResposeBE resposeBe = Helper.WebAppi.Post(Helper.Archivo.Configuracion.getKey("Tesoreria", "WSServerH2H") + Helper.Archivo.Configuracion.getKey("Tesoreria", "EnviaPago"), EntityBE);
                        if (resposeBe.Status == HttpStatusCode.OK)
                        {
                            StringOperationResult stringOperationResult = JsonSerializer.Deserialize<StringOperationResult>(resposeBe.ObjResult, options);
                            if (stringOperationResult.messageTech.ToString().ToUpper().Equals("OK"))
                                Resultado = $"{{Id:1,Mensaje:{this.cmll}{stringOperationResult.message}{this.cmll}}}";
                            else
                                Resultado = $"{{Id:-11,Mensaje:{this.cmll}{stringOperationResult.message}{this.cmll}}}";
                        }
                        else
                        {
                            string objResult = resposeBe.ObjResult;
                            string[] _Cc = Helper.Archivo.Configuracion.getKey("H2H", "LstSoporte").Split(',');
                            new Mail(Helper.Archivo.Configuracion.getKey("H2H", "UserSend"), Helper.Archivo.Configuracion.getKey("H2H", "AdmServer"), _Cc, "Servidor H2H dormido", "Levantar el srv").enviaMail();
                            Resultado = $"{{Id:1,Mensaje:{this.cmll}{objResult}{this.cmll}}}";
                        }
                    }
                    else
                        Resultado = $"{{Id:3,Mensaje:{this.cmll}No existe datos de proveedores a procesar..{this.cmll}}}";
                }
                Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(Resultado);
            }
            catch (Exception ex)
            {
                Helper.Archivo.XMLinURL.TransaccionalAccesoDatos($"{{Id:-98,Mensaje:{this.cmll}{ex.Message.Replace(",", " ")}{this.cmll}}}");
            }
        }

        [WebMethod]
        public void LeerTransferencia(string LotePago, string Estado = "1", string UserName = "Banco")
        {
            try
            {
                string Resultado = $"{{Id:2,Mensaje:{this.cmll}No existe envios que procesar..{this.cmll}}}";
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                DataTable dataTable1 = new CInterbancario().CabeceraLotePago(LotePago, Estado, UserName);
                if (dataTable1 != null)
                {
                    foreach (DataRow row in (InternalDataCollectionBase)dataTable1.Rows)
                    {
                        PlanCabProv planCabProv = new PlanCabProv().SetAttrValue(row);
                        object EntityBE = (object)new EntidadNegocio.GestionFinanciera.Tesoreria.Pagos.Archivo("C", planCabProv.cCodPlanilla, ".txt");
                        ResposeBE resposeBe = Helper.WebAppi.Get(Helper.Archivo.Configuracion.getKey("Tesoreria", "WSServerH2H") + Helper.Archivo.Configuracion.getKey("Tesoreria", "LeerPago"), EntityBE);
                        switch (resposeBe.Status)
                        {
                            case HttpStatusCode.OK:
                                StringOperationResult stringOperationResult = JsonSerializer.Deserialize<StringOperationResult>(resposeBe.ObjResult, options);
                                string[] strArray = new string[5]
                                {
                                    "{Id:'",
                                    null,
                                    null,
                                    null,
                                    null
                                };
                                int resultType = stringOperationResult.resultType;
                                strArray[1] = resultType.ToString();
                                strArray[2] = "',Mensaje:'";
                                strArray[3] = stringOperationResult.message;
                                strArray[4] = "'}";
                                Resultado = string.Concat(strArray);
                                //string str1 = planCabProv.cNroPlanilla.ToString().Replace(" ", "");
                                string str1 = LotePago;

                                resultType = stringOperationResult.resultType;
                                if (resultType.Equals(-7))
                                {
                                    PlanillaPagos planillaPagos = JsonSerializer.Deserialize<PlanillaPagos>(stringOperationResult.result.ToString(), options);
                                    DataTable dataTable2 = new CInterbancario().DetalleLotePago(str1, UserName);
                                    foreach (LecturaError lecturaError in planillaPagos.error)
                                    {
                                        DataRow[] dataRowArray = dataTable2.Select("NroLinea=" + lecturaError.linea.ToString());
                                        if (dataRowArray.Length != 0)
                                        {
                                            DataRow dataRow = dataRowArray[0];
                                        }
                                    }
                                    Resultado = $"{{Id:90,Mensaje:{this.cmll}Proceso exitoso{this.cmll}}}";
                                    continue;
                                }
                                resultType = stringOperationResult.resultType;
                                if (resultType.Equals(0))
                                {
                                    PlanillaPagos planillaPagos = JsonSerializer.Deserialize<PlanillaPagos>(stringOperationResult.result.ToString(), options);
                                    new CInterbancario().CabActulizaEstado(str1, 3, planillaPagos.datos.cEstado, UserName);
                                    foreach (PlanDetProv planDetProv in (IEnumerable<PlanDetProv>)planillaPagos.datos.listPlanDetProv)
                                    {
                                        string str2 = $"{planDetProv.cEstado}-{planDetProv.cObserva.Replace("Ninguna", "")}";
                                        string str3 = str2.Length <= 80 ? str2 : str2.Substring(0, 79);

                                        (new CInterbancario()).DetActulizaEstado(str1, planDetProv.cNroDocProv, str3,
                                            UserName);
                                    }
                                    Resultado = $"{{Id:90,Mensaje:{this.cmll}Proceso exitoso{this.cmll}}}";
                                    continue;
                                }
                                string str4 = stringOperationResult.message.Length <= 80 ? stringOperationResult.message : stringOperationResult.message.Substring(1, 79);
                                Resultado = $"{{Id:91,Mensaje:{this.cmll}Espera para volver a leer{this.cmll}}}";
                                continue;
                            case HttpStatusCode.NotFound:
                                Resultado = $"{{Id:92,Mensaje:{this.cmll}{resposeBe.ObjResult.ToString().Replace(",", " ")}{this.cmll}}}";
                                continue;
                            default:
                                Resultado = $"{{Id:93,Mensaje:{this.cmll}{resposeBe.ObjResult.ToString().Replace(",", " ")}{this.cmll}}}";
                                continue;
                        }
                    }
                }
                Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(Resultado);
            }
            catch (Exception ex)
            {
                Helper.Archivo.XMLinURL.TransaccionalAccesoDatos($"{{Id:92,Mensaje:{this.cmll}{ex.Message.Replace(",", " ")}{this.cmll}}}");
            }
        }

        [WebMethod]
        public void Test(string Valor)
        {
            Helper.Archivo.XMLinURL.TransaccionalAccesoDatos($"{{Id:1,Mensaje: {this.cmll}{Valor}{this.cmll}}}");
        }
    }
}
