using Controladora.SeguridadPlanta;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace WSCore.SeguridadPlanta
{
    /// <summary>
    /// Descripción breve de Visitas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
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

    }
}
