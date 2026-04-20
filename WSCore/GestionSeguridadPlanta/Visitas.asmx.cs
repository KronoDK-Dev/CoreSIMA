using Controladora.SeguridadPlanta;
using Controladora.SIMANET.SeguridadPlanta;
using EntidadNegocio.SIMANET.SeguridadPlanta;
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
                DataTable dt = (new CVisita()).ListarTodos(S_PROGRAMACION, S_PERIODO, S_TIPOPROGRA,  UserName);
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
                var data = new CVisita().ListarTodos_JSON(Id1, Id2, Id3, UserName);

                return (data == null)
                    ? JsonConvert.SerializeObject(new { success = false, error = new { code = "SERVER_ERROR", message = "Ocurrió un error al consultar los datos." } })
                    : JsonConvert.SerializeObject(new { success = true, data });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false, error = new { code = "SERVER_ERROR", message = ex.Message } });
            }
        }


        [WebMethod(Description = "Insertar Programación de Visita (cabecera)")]
        public string ProgramacionVisita_Ins(
       string IdTipoVisita
     , string IdEntidad
     , string IdArea
     , string FechaInicio
     , string FechaTermino
     , string HoraInicio
     , string HoraTermino
     , string IdCIASeguros
     , string NroPoliza
     , string Observaciones
     , string IdUsuarioRegistro
     , string TipoProgramacion
     , string IdUsuarioAprobacion
     , string IdEstado
     , string UserName
 )
        {
            // =========================
            // VALIDACIONES Y PARSEO
            // =========================

            // NUMERICAS
            if (!int.TryParse(IdTipoVisita, out int idTipoVisita))
                throw new Exception($"\"{nameof(IdTipoVisita)}\" es obligatorio.");

            if (!int.TryParse(IdEntidad, out int idEntidad))
                throw new Exception($"\"{nameof(IdEntidad)}\" es obligatorio.");

            if (!int.TryParse(IdArea, out int idArea))
                throw new Exception($"\"{nameof(IdArea)}\" es obligatorio.");


            int idCia = 99; // valor por defecto

            if (int.TryParse(IdCIASeguros, out int tmpIdCia) && tmpIdCia > 0)
            {
                idCia = tmpIdCia;
            }

            if (!int.TryParse(IdUsuarioRegistro, out int idUsuarioRegistro))
                throw new Exception($"\"{nameof(IdUsuarioRegistro)}\" es obligatorio.");

            if (!int.TryParse(TipoProgramacion, out int tipoProgramacion))
                throw new Exception($"\"{nameof(TipoProgramacion)}\" es obligatorio.");

            if (!int.TryParse(IdUsuarioAprobacion, out int idUsuarioAprobacion))
                throw new Exception($"\"{nameof(IdUsuarioAprobacion)}\" es obligatorio.");

            if (!int.TryParse(IdEstado, out int idEstado))
                throw new Exception($"\"{nameof(IdEstado)}\" es obligatorio.");
            // FECHAS
            if (!DateTime.TryParse(FechaInicio, out DateTime dtInicio))
                throw new Exception($"\"{nameof(FechaInicio)}\" tiene formato inválido.");

            if (!DateTime.TryParse(FechaTermino, out DateTime dtTermino))
                throw new Exception($"\"{nameof(FechaTermino)}\" tiene formato inválido.");

            if (dtTermino < dtInicio)
                throw new Exception("La FechaTermino no puede ser menor que la FechaInicio.");

            // TEXTOS
            if (string.IsNullOrWhiteSpace(HoraInicio))
                throw new Exception($"\"{nameof(HoraInicio)}\" es obligatorio.");

            // 6 PM por defecto → "1800"
            string horaTerminoFinal = "1800";

            if (!string.IsNullOrWhiteSpace(HoraTermino) && HoraTermino != "0")
            {
                horaTerminoFinal = HoraTermino;
            }


            if (string.IsNullOrWhiteSpace(Observaciones))
                throw new Exception($"\"{nameof(Observaciones)}\" es obligatorio.");

            if (string.IsNullOrWhiteSpace(UserName))
                throw new Exception($"\"{nameof(UserName)}\" es obligatorio.");



            // =========================
            // MAPEO CORRECTO AL BE
            // =========================

            CCTT_ProgramacionBE oBE = new CCTT_ProgramacionBE
            {
                IdTipoEntidad = idTipoVisita,
                IdEntidad = idEntidad,
                IdArea = idArea,
                FechaInicio = dtInicio,
                FechaTermino = dtTermino,
                HoraInicio = HoraInicio,
                HoraTermino = horaTerminoFinal,
                IdCIASeguros = idCia,
                NroPoliza = string.IsNullOrWhiteSpace(NroPoliza) ? "S/N" : NroPoliza,
                Observaciones = Observaciones,
                IdUsuario = idUsuarioRegistro,
                TipoProgramacion = tipoProgramacion,
                IdUsuarioAprobacion = idUsuarioAprobacion,
                IdEstado = idEstado,
                UserName = UserName
            };

            // =========================
            // PERSISTENCIA
            // =========================
            return new CVisita().Insertar(oBE);
        }



    }
}
