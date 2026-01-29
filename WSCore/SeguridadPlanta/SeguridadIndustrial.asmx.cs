using Controladora.General;
using Controladora.SeguridadPlanta;
using EntidadNegocio.GestionFinanciera.Tesoreria.Pagos;
using EntidadNegocio.SeguridadPlanta;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using Utilitario;



namespace WSCore.SeguridadPlanta
{
    /// <summary>
    /// Descripción breve de SeguridadIndustrial
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class SeguridadIndustrial : System.Web.Services.WebService
    {
        [WebMethod]
        public string ActualizarPeronslInduccion_up(string Centro,string UserName)
        {
            string Retorna = "OK";
            try
            {
                DataTable odtInfo = (new CInformacionGeneral()).ListarInterfaceWService(1, UserName);
                DataRow drLst = odtInfo.Rows[0];
                ApiInfoBE apiInfo = new ApiInfoBE();
                apiInfo.Url = drLst["UrlService"].ToString();  //"https://gruposolmar.pe/api/smart/sima/v1/";
                apiInfo.Metodo = drLst["Metodo"].ToString(); //"estadoPersonaNotaIcma/";
                apiInfo.MediaType = "application/json";
                apiInfo.Tipo = TipoAPI.Bearer;
                apiInfo.TokenValue = drLst["Token"].ToString(); //"a28ASXzbGF0YDF256Dds41iYWxmYSI6ImE4OTM0Y2as51";

                apiInfo.BodyParam = new
                {
                    nroDOI = "TODO",
                    sucursal = Centro
                };
                //Api info actualiza
                DataTable dtIUp = (new CInformacionGeneral()).ListarInterfaceWService(2, UserName);
                DataRow drIUp = dtIUp.Rows[0];

                ApiInfoBE apiInfoUp = new ApiInfoBE();
                apiInfoUp.Url = drIUp["UrlService"].ToString(); ;
                apiInfoUp.Metodo = drIUp["Metodo"].ToString();
                apiInfoUp.MediaType = "application/json";
                apiInfoUp.Tipo = TipoAPI.Bearer;
                apiInfoUp.TokenValue = drIUp["Token"].ToString(); ;

                var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                ResposeBE oResposeBE = Helper.WebAppi.Rest.Send(apiInfo);
                MensajeResultBE oMensajeResultBE = System.Text.Json.JsonSerializer.Deserialize<MensajeResultBE>(oResposeBE.ObjResult, jsonSerializerOptions);

                foreach (personal oPersonal in oMensajeResultBE.data.personal)
                {
                    if (oPersonal.aprobado == 1)
                    {
                        //verificar su existencia en la bd de trabajador
                        string id = (new CInduccion()).ModificaInsertar(oPersonal);
                        if (id.Length > 0)
                        {
                            ActualizarEstado(apiInfoUp, Centro, oPersonal.nroDoc.Replace("\"", ""));
                        }
                      //  break;
                    }
                }
            }
            catch (Exception ex) {
                Retorna = "Error";
            }
            return Retorna;
        }

        public void ActualizarEstado(ApiInfoBE _apiIUp,string _Centro, string NroDNI) {
            _apiIUp.BodyParam = new
            {
                nroDOI = NroDNI,
                sucursal = _Centro
            };

            var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            ResposeBE oResposeBE = Helper.WebAppi.Rest.Send(_apiIUp);
            MensajeResultBE oMensajeResultBE = System.Text.Json.JsonSerializer.Deserialize<MensajeResultBE>(oResposeBE.ObjResult, jsonSerializerOptions);
        }
    }






    public class ParametroBE {
        public ParametroBE() { }

        public string nroDOI { get; set; }
        public ParametroBE(string _NroDOI)
        {
            this.nroDOI = _NroDOI;
        }
    }



}
