using Controladora.GestionFinanciera.Tesoreria;
using EntidadNegocio.GestionFinanciera.Tesoreria.Pagos;
using EntidadNegocio.GestionReportes;
using SIMANET_W22R.Controles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text.Json;
using System.Web.Services;
using Utilitario;
using WSCore.General;
using static Utilitario.Helper;
using static WSCore.Test.CnsumirApiRest;


namespace WSCore.GestionFinanciera.Tesoreria
{
    /// <summary>
    /// Descripción breve de Interbancario
    /// </summary>
    [WebService(Namespace = "http://sima.com.pe/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    //Convertir json a entity  https://www.site24x7.com/tools/json-to-csharp.html
    public class Interbancario : System.Web.Services.WebService
    {
        string cmll = Utilitario.Constante.Caracteres.ComillasDobles;

        [WebMethod]
        public void IniciarTransferencia(string CodigoBanco, string NroLote,string UserName)
        {
            try
            {
                string strOperacionBE = "";
                ResposeBE oresposeBE = null;
                var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                DataTable dt = (new CInterbancario()).CabeceraLotePago(CodigoBanco, NroLote, "0", UserName);
                if (dt != null)
                {
                    DataRow dr = dt.Rows[0];
                    PlanCabProv oPlanCabProv = (new PlanCabProv()).SetAttrValue(dr);
                    //Cargar Detella 
                    List<PlanDetProv> oLstPlanDetProv = new List<PlanDetProv>();
                    DataTable dtdet = (new CInterbancario()).DetalleLotePago(CodigoBanco, NroLote, UserName);
                    if (dtdet.Rows.Count > 0)
                    {
                        foreach (DataRow drd in dtdet.Rows)
                        {
                            PlanDetProv oPlanDetProv = (new PlanDetProv()).SetAttrValue(drd);
                            //Aqui INstanciar la clase DetDocBenef
                            oPlanDetProv.detDocBenef = (new DetDocBenef());
                            oLstPlanDetProv.Add(oPlanDetProv);
                        }
                        oPlanCabProv.listPlanDetProv = oLstPlanDetProv;
                        //Setear el Arvhivo
                        EntidadNegocio.GestionFinanciera.Tesoreria.Pagos.Archivo oArchivo = new EntidadNegocio.GestionFinanciera.Tesoreria.Pagos.Archivo("C", dr["nombrePlanilla"].ToString(), ".txt");

                        PlanillaPagos oPlanillaPagos = new PlanillaPagos();
                        oPlanillaPagos.BANCO = CodigoBanco;
                        oPlanillaPagos.datos = oPlanCabProv;
                        oPlanillaPagos.archivo = oArchivo;

                        
                        //Llamar al servicio
                        object objBE = oPlanillaPagos;

                        var HttpServer = Utilitario.Helper.Archivo.Configuracion.getKey("Tesoreria", "WSServerH2H");
                        var Metodo = Utilitario.Helper.Archivo.Configuracion.getKey("Tesoreria", "EnviaPago");
                        var url = HttpServer + Metodo;

                        var rpt = Utilitario.Helper.WebAppi.Post(url, objBE);
                        oresposeBE = (ResposeBE)rpt;

                        switch (oresposeBE.Status)
                        {
                            case HttpStatusCode.OK:
                                var oStringOperationResult = JsonSerializer.Deserialize<StringOperationResult>(oresposeBE.ObjResult, jsonSerializerOptions);
                                if (oStringOperationResult.messageTech.ToString().ToUpper().Equals("OK"))
                                {
                                    strOperacionBE = "{Id:1,Mensaje:" + cmll + oStringOperationResult.message + cmll + "}";
                                }
                                else
                                {
                                    strOperacionBE = "{Id:-11,Mensaje:" + cmll + oStringOperationResult.message + cmll + "}";
                                }

                                break;

                            default:
                                string des = oresposeBE.ObjResult;
                                //Guardar el Error en la Bse de datos para ser mosrada en el FrontEnd de UNISYS
                                string[] cc = Utilitario.Helper.Archivo.Configuracion.getKey("H2H", "LstSoporte").Split(',');
                                Mail oMail = new Mail(Utilitario.Helper.Archivo.Configuracion.getKey("H2H", "UserSend"), Utilitario.Helper.Archivo.Configuracion.getKey("H2H", "AdmServer"), cc, "Servidor H2H dormido", "Levantar el srv", null);
                                MailResult oMailResult = oMail.enviaMail();

                                strOperacionBE = "{Id:1,Mensaje:" + cmll + des + cmll + "}";
                                break;
                        }
                    }
                    else {
                        
                        strOperacionBE = "{Id:3,Mensaje:" + cmll + "No existe datos de proveedores a procesar.." + cmll + "}";
                    }
                }
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(strOperacionBE);
            }
            catch (Exception e) {
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos("{Id:-98,Mensaje:" + cmll + e.Message.Replace(",", " ") + cmll + "}");
            }
        }


      

        [WebMethod]
        public void LeerTransferencia(string CodigoBanco,string LotePago,string Estado="1", string UserName="Banco")
        {
            try
            {
                string strOperacionBE = "{Id:2,Mensaje:"+ cmll + "No existe envios que procesar.." + cmll+"}";
                ResposeBE oresposeBE = null;
                var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                DataTable dt = (new CInterbancario()).CabeceraLotePago(CodigoBanco,LotePago, Estado, UserName);
                if (dt != null)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        PlanCabProv oPlanCabProv = (new PlanCabProv()).SetAttrValue(dr);
                        EntidadNegocio.GestionFinanciera.Tesoreria.Pagos.Archivo oArchivo = new EntidadNegocio.GestionFinanciera.Tesoreria.Pagos.Archivo("C", oPlanCabProv.cCodPlanilla, ".txt");
                        //Llamar al servicio
                        oArchivo.BANCO = CodigoBanco;
                        object objBE = oArchivo;

                        var HttpServer = Utilitario.Helper.Archivo.Configuracion.getKey("Tesoreria", "WSServerH2H");
                        var Metodo = Utilitario.Helper.Archivo.Configuracion.getKey("Tesoreria", "LeerPago");
                        var url = HttpServer + Metodo;

                        var rpt = Utilitario.Helper.WebAppi.Get(url, objBE);
                        oresposeBE = (ResposeBE)rpt;

                        switch (oresposeBE.Status)//comunicación con el servicios
                        {
                            case HttpStatusCode.OK:
                                var oStringOperationResult = JsonSerializer.Deserialize<StringOperationResult>(oresposeBE.ObjResult, jsonSerializerOptions);
                                strOperacionBE = "{Id:'" + oStringOperationResult.resultType.ToString() + "',Mensaje:'" + oStringOperationResult.message + "'}";

                                string NroLote = LotePago.ToString().Replace(" ", "");

                                if (oStringOperationResult.resultType.Equals(-7))//val
                                {
                                    var cab = JsonSerializer.Deserialize<PlanillaPagos>(oStringOperationResult.result.ToString(), jsonSerializerOptions);
                                    DataTable dtRegPrv = (new CInterbancario()).DetalleLotePago(CodigoBanco,NroLote, UserName);
                                    foreach (LecturaError err in cab.error)
                                    {
                                        DataRow[] drs = dtRegPrv.Select("NroLinea=" + err.linea.ToString());
                                        if (drs.Length > 0)
                                        {
                                            DataRow drErr = drs[0];
                                          // * (new CInterbancario()).DetActulizaEstado(NroLote, drErr["cNroDocProv"].ToString(), err.mensaje.ToString(), UserName);
                                        }
                                    }
                                    strOperacionBE = "{Id:90,Mensaje:" + cmll + "Proceso exitoso" + cmll + "}";
                                }
                                else if (oStringOperationResult.resultType.Equals(0))//res
                                {
                                    var cab = JsonSerializer.Deserialize<PlanillaPagos>(oStringOperationResult.result.ToString(), jsonSerializerOptions);
                                   //* (new CInterbancario()).CabActulizaEstado(NroLote, 3, cab.datos.cEstado, UserName);
                                    foreach (PlanDetProv opdp in cab.datos.listPlanDetProv) {
                                        string Obs = opdp.cEstado + '-' + opdp.cObserva.Replace("Ninguna","");
                                        Obs = ((Obs.Length <= 80) ? Obs : Obs.Substring(0, 79));

                                       //* (new CInterbancario()).DetActulizaEstado(NroLote, opdp.cNroDocProv, Obs, UserName);
                                    }
                                    strOperacionBE = "{Id:90,Mensaje:" + cmll + "Proceso exitoso" + cmll + "}";
                                }
                                else
                                {//-1 

                                    string msgReturn = ((oStringOperationResult.message.Length <= 80) ? oStringOperationResult.message : oStringOperationResult.message.Substring(1, 79));

                                 //   (new CInterbancario()).CabActulizaEstado(NroLote, 1, oStringOperationResult.message, UserName);
                                    strOperacionBE = "{Id:91,Mensaje:" + cmll + "Espera para volver a leer" + cmll + "}";
                                }
                                //Crea Una Tarea en el paquete rigth
                                break;
                            case HttpStatusCode.NotFound:
                                strOperacionBE = "{Id:92,Mensaje:" + cmll + oresposeBE.ObjResult.ToString().Replace(",", " ")+ cmll + "}";
                                break;
                            default:
                                strOperacionBE = "{Id:93,Mensaje:" + cmll + oresposeBE.ObjResult.ToString().Replace(",", " ") + cmll + "}";
                                break;
                        }
                    }
                }
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(strOperacionBE);
            }
            catch(Exception e){
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos("{Id:92,Mensaje:"+ cmll + e.Message.Replace(","," ") + cmll+ "}");
            }
            
        }


        [WebMethod]
        public void Test(string Valor) {

            Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos("{Id:1,Mensaje: " + cmll + Valor + cmll +"}");
        }


    }
}
 