using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using Controladora.HelpDesk.ChatBot;
using EntidadNegocio.HelpDesk.ChatBot;

namespace WSCore.HelpDesk.ChatBot
{
    /// <summary>
    /// Descripción breve de IchatBotManager
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class IChatBotManager : System.Web.Services.WebService
    {
        [WebMethod(Description = "Detalle de Contancto")]
        public DataTable DetalleContacto(string CodPersonal, string UserName)
        {
            return (new CCBContactoGrupo()).DetalleContacto(CodPersonal, UserName);
        }

        [WebMethod(Description = "Detalle de Contancto x ID")]
        public CBContactoGrupoBE DetalleContactoXID(int Id, string UserName)
        {
            return (CBContactoGrupoBE)(new CCBContactoGrupo()).DetalleContactoxID(Id, UserName);
        }

        [WebMethod(Description = "Busca y Lista los Contactos según criterio o Lista Contactos por grupo")]
        public DataTable ListarContatos(string NOMBRECONTACTO, string UserName)
        {
            return (new CCBContactoGrupo()).ListarTodos(NOMBRECONTACTO, UserName);
        }

        [WebMethod(Description = "Busca y Lista Miembro de  Contactos id Contacto")]
        public DataTable ListarMiembros(int IdContacto, string UserName)
        {
            return (new CCBContactoGrupo()).ListarTodos(IdContacto, UserName);
        }

        [WebMethod(Description = "Listado de Historial de Dialogo entre contactos")]
        public DataTable LstHistorialDialogo(string IdContactoOrg, int IdContactoDes, string UserName)
        {
            return (new CCBHistorialMsg()).ListarTodos(IdContactoOrg.ToString(), IdContactoDes.ToString(), UserName);
        }

        [WebMethod(Description = "Listado de Historial de Dialogo entre contactos COntenido de mensajes")]
        public DataTable LstHistorialDialogoContenido(string Idmsg, string UserName)
        {
            return (new CCBHistorialMsg()).ListarChatContenido(Idmsg, UserName);
        }

        [WebMethod(Description = "Listado de Likes ")]
        public DataTable LstHistorialDialogoContenidoLikes(string IdContents, string UserName)
        {
            return (new CCBHistorialMsg()).LstHistorialDialogoContenidoLikes(IdContents, UserName);
        }

        [WebMethod(Description = "Verifica si es Miembro del undeterminado grupo y devuelve el nro  o Id de Miembro grupo")]
        public DataTable IsMiembrodeGrupo(int IdContactGrupo, string CodPersonal, string UserName)
        {
            return (new CCBContactoGrupo()).IsMiembrodeGrupo(IdContactGrupo, CodPersonal, UserName);
        }

        [WebMethod(Description = "Lista contactos que enviaron mensajes a un determinado grupo grupo")]
        public DataTable LstContactSendtoGrupo(int IdContactGrupo, string UserName)
        {
            return (new CCBContactoGrupo()).LstContactSendtoGrupo(IdContactGrupo, UserName);
        }

        [WebMethod(Description = "Insertar Mensaje uy contenido, disponible del lado del servido", MessageName = "RegistrarMensajeyContenidoServer")]
        public string RegistrarMensajeyContenidoServer(MensajeContenidoBE oMensajeContenidoBE)
        {
            return (new CCBMensajeContendido()).Inserta(oMensajeContenidoBE);
        }

        [WebMethod(Description = "Insertar Mensaje uy contenido, DIsponible del lado del CLiente", MessageName = "RegistrarMensajeyContenidoCliente")]
        public string RegistrarMensajeyContenidoClient(int IdMiembro, string Texto, int IdContactOrg, int IdContactDes, int IdTablaInfo, string IdInfo)
        {
            MensajeContenidoBE oMensajeContenidoBE = new MensajeContenidoBE();
            oMensajeContenidoBE.IdMiembro = IdMiembro;
            oMensajeContenidoBE.Texto = Texto;
            oMensajeContenidoBE.IdContactoOrigen = IdContactOrg;
            oMensajeContenidoBE.IdContactoDestino = IdContactDes;
            oMensajeContenidoBE.IdUsuario = 86;
            oMensajeContenidoBE.IdTablaInfo = IdTablaInfo;
            oMensajeContenidoBE.IdInfo = IdInfo;
            //oMensajeContenidoBE.JSonBE 
            return (new CCBMensajeContendido()).Inserta(oMensajeContenidoBE);
        }

        [WebMethod(Description = "Insertar Modficar Contact y grupo")]
        public string IRegistrarContactoyGrupo(int IdContacto, int IsGrupo, string NombreGrupo, string FotoGrupo, string LIB_JS_SRVBROKER, string Descripcion, string CodPersonal, int IdUsuario)
        {
            CBContactoGrupoBE oCBContactoGrupoBE = new CBContactoGrupoBE();
            oCBContactoGrupoBE.IdContacto = IdContacto;
            oCBContactoGrupoBE.IsGrupo = IsGrupo;
            oCBContactoGrupoBE.NombreGrupo = NombreGrupo;
            oCBContactoGrupoBE.FotoGrupo = FotoGrupo;
            oCBContactoGrupoBE.LIB_JS_SRVBROKER = LIB_JS_SRVBROKER;
            oCBContactoGrupoBE.Descripcion = Descripcion;
            oCBContactoGrupoBE.CodPersonal = CodPersonal;
            oCBContactoGrupoBE.IdUsuario = IdUsuario;

            return (new CCBContactoGrupo()).Insertar(oCBContactoGrupoBE);
        }

        [WebMethod(Description = "Insertar Modficar COntact y grupo")]
        public string RegistrarContactoyGrupo(CBContactoGrupoBE oCBContactoGrupoBE)
        {
            return (new CCBContactoGrupo()).Insertar(oCBContactoGrupoBE);
        }

        [WebMethod(Description = "Cambia el estado del  Contact o grupo")]
        public string ActualizaEstadoContacto(string CodPersonal, int IdEstado, string UserName)
        {
            return (new CCBContactoGrupo()).ActualizaEstado(CodPersonal, IdEstado, UserName);
        }

        [WebMethod(Description = "Respuestas ChatBots")]
        public DataTable Response_Listar(string IdResponse, int IdTipo, string UserName)
        {
            return (new CCBResponse()).ListarTodos(IdResponse, IdTipo.ToString(), UserName);
        }

        [WebMethod(Description = "Buscar Respuestas ChatBots")]
        public DataTable Response_Buscar(string Criterio, string UserName)
        {
            return (new CCBResponse()).Buscar(Criterio, UserName);
        }

        [WebMethod(Description = "Listar Sub Respuestas ChatBots")]
        public DataTable Response_ListarSubRespuestas(string IdPadre, string UserName)
        {
            return (new CCBResponse()).ListarTodos(IdPadre, UserName);
        }

        [WebMethod(Description = "Listar de aplcaciones ChatBots")]
        public DataTable AplicacionesdeServicios_lst(int IdTipo, string UserName)
        {
            return (new CCBResponse()).ListarAplicaciones(IdTipo, UserName);
        }
    }
}
