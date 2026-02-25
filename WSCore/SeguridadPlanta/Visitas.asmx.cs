using Controladora.SeguridadPlanta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;

namespace WSCore.SeguridadPlanta
{
    /// <summary>
    /// Modulo de visitas para control de acceso de personas a la planta
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    [WebService(Namespace = "https://api-netsuite.sima.com.pe/seguridadplanta")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Visitas : System.Web.Services.WebService
    {
      
        [WebMethod(Description = "Lista la Programacion de visitas")]
        public string ListarTodos( string S_PROGRAMACION, string S_PERIODO, string S_TIPOPROGRA, string UserName)
        {
            try
            {
                DataTable dt = (new CVisitas()).ListarTodos(S_PROGRAMACION, S_PERIODO, S_TIPOPROGRA,  UserName);
                // PARAMETROS: @NroProgramacion=0,@Periodo=2026,@idUsuario=86,@TipoProgramacion=1
                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "uspNTADConsultarProgramacionVisita_CVST";

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
                throw new HttpException(500, "Error interno del servidor", ex);
            }
        }


        [WebMethod(Description = "Programación de visitas (JSON) ")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public string ListarProgramacionVisita_JSON(string Id1, string Id2, string Id3, string UserName)
        {
            try
            {
                Context.Response.ContentType = "application/json; charset=utf-8";
                var data = new CVisitas().ListarTodos_JSON(Id1, Id2, Id3, UserName);

                return (data == null)
                    ? JsonConvert.SerializeObject(new { success = false, error = new { code = "SERVER_ERROR", message = "Ocurrió un error al consultar los datos." } })
                    : JsonConvert.SerializeObject(new { success = true, data });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false, error = new { code = "SERVER_ERROR", message = ex.Message } });
            }
        }

    }
}
