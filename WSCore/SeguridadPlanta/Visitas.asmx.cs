
using EntidadNegocio.SIMANET.SeguridadPlanta;
using Controladora.GestionSeguridadPlanta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using static Utilitario.Constante.Formato;


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
        public string ListarTodos(string S_PROGRAMACION, string S_PERIODO, string S_TIPOPROGRA, string UserName)
        {
            try
            {
                DataTable dt = (new CVisita()).ListarTodos(S_PROGRAMACION, S_PERIODO, S_TIPOPROGRA, UserName);
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
                /*
                @NroProgramacion varchar(100), -- campo busca multiple: num / fecha / texto
                @Periodo           int,
                @idUsuario         int,
                @TipoProgramacion  int = 0
                */

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


        [WebMethod(Description = "Insertar Programación de Visita (cabecera) ")]
        public string ProgramacionVisita_Ins(int sPeriodo,
           string IdTipoVisita, string IdEntidad, string IdArea, string FechaInicio, string FechaTermino, string HoraInicio, string HoraTermino
         , string IdCIASeguros, string NroPoliza, string Observaciones, string IdUsuarioRegistro, string TipoProgramacion, string IdUsuarioAprobacion
         , string IdEstado, string UserName
         , string LstCorreos = "", string LstAnexos = "")

        {
            // =========================
            // VALIDACIONES Y PARSEO
            // =========================

            #region "Validaciones"
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

            #endregion

            // =========================
            // MAPEO CORRECTO AL BE
            // =========================

            ProgramacionBE oBE = new ProgramacionBE
            {
                PERIODO = sPeriodo,
                ID_TIPO_VISITA = idTipoVisita,          // antes: IdTipoEntidad
                ID_ENTIDAD = idEntidad,              // OK
                ID_LUGAR_TRABAJO = idArea,                 // antes: IdArea
                FECHA_INICIO = dtInicio,               // antes: FechaInicio
                FECHA_TERMINO = dtTermino,              // antes: FechaTermino
                HORA_INICIO = HoraInicio,             // OK (string)
                HORA_TERMINO = horaTerminoFinal,       // antes: HoraTermino
                ID_CIA_SEGUROS = idCia,                  // antes: IdCIASeguros
                NRO_POLIZA = string.IsNullOrWhiteSpace(NroPoliza) ? "S/N" : NroPoliza,
                OBSERVACIONES = Observaciones,
                ID_USUARIO_REGISTRO = idUsuarioRegistro,      // antes: IdUsuario
                TIPO_PROGRAMACION = tipoProgramacion,
                ID_USUARIO_APROBACION = idUsuarioAprobacion,
                ID_ESTADO = idEstado,
                UserName = UserName                // viene de BaseBE ✅
            };

            // =========================
            // PERSISTENCIA
            // =========================
            return new CVisita().Insertar(oBE, LstCorreos, LstAnexos);
        }


        [WebMethod(Description = "Insertar Programación de Visitas (cabecera) - Parámetros: pase de clases Entidad ")]
        public string ProgramacionVisitas_Ins(ProgramacionBE oProgramacionBE, string LstCorreos = "", string LstAnexos = "")


        {
            // =========================
            // VALIDACIONES Y PARSEO
            // =========================
            #region Validaciones
            // NUMERICAS

            if (oProgramacionBE.ID_TIPO_VISITA <= 0)
                throw new Exception("\"ID_TIPO_VISITA\" es obligatorio.");


            if (oProgramacionBE.ID_ENTIDAD < 0)
                throw new Exception("\"ID_ENTIDAD\" es obligatorio.");


            if (!oProgramacionBE.ID_LUGAR_TRABAJO.HasValue || oProgramacionBE.ID_LUGAR_TRABAJO <= 0)
                throw new Exception("\"ID_LUGAR_TRABAJO\" es obligatorio.");


            int idCia = 99; // valor por defecto


            if (oProgramacionBE.ID_CIA_SEGUROS > 0)
            {
                idCia = oProgramacionBE.ID_CIA_SEGUROS;
            }


            if (oProgramacionBE.ID_USUARIO_REGISTRO <= 0)
                throw new Exception("\"ID_USUARIO_REGISTRO\" es obligatorio.");


            if (oProgramacionBE.TIPO_PROGRAMACION <= 0)
                throw new Exception("\"TIPO_PROGRAMACION\" es obligatorio.");


            if (!oProgramacionBE.ID_USUARIO_APROBACION.HasValue || oProgramacionBE.ID_USUARIO_APROBACION < 0)
                throw new Exception("\"ID_USUARIO_APROBACION\" es obligatorio.");


            if (oProgramacionBE.ID_ESTADO < 0)
                throw new Exception("\"ID_ESTADO\" es obligatorio.");


            if (oProgramacionBE.PERIODO <= 0)
                throw new Exception("\"PERIODO\" es obligatorio.");

            // FECHAS

            DateTime dtInicio = oProgramacionBE.FECHA_INICIO;
            DateTime dtTermino = oProgramacionBE.FECHA_TERMINO;

            // Validación de rango
            if (dtTermino < dtInicio)
                throw new Exception("La FECHA_TERMINO no puede ser menor que la FECHA_INICIO.");

            // TEXTOS

            if (string.IsNullOrWhiteSpace(oProgramacionBE.HORA_INICIO))
                throw new Exception("\"HORA_INICIO\" es obligatorio.");

            // 6 PM por defecto → "1800"
            string horaTerminoFinal = "18:00:00";


            if (!string.IsNullOrWhiteSpace(oProgramacionBE.HORA_TERMINO) &&
                oProgramacionBE.HORA_TERMINO != "0")
            {
                oProgramacionBE.HORA_TERMINO = horaTerminoFinal;
            }


            if (string.IsNullOrWhiteSpace(oProgramacionBE.OBSERVACIONES))
                throw new Exception("\"OBSERVACIONES\" es obligatorio.");


            if (string.IsNullOrWhiteSpace(oProgramacionBE.UserName))
                throw new Exception("\"UserName\" es obligatorio.");
            #endregion

            // =========================
            // PERSISTENCIA
            // =========================
            return new CVisita().Insertar(oProgramacionBE, LstCorreos, LstAnexos);
        }
    }
}
